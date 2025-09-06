"use client"

import { addWage, getAllWages, getEmployeeWage } from "./action"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { toast } from "sonner"
import { z } from "zod"
import { Button } from "@/components/ui/button"
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form"
import { Input } from "@/components/ui/input"
import { Calendar } from "@/components/ui/calendar"
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover"
import { useState } from "react"
import { format } from "date-fns"
import { CalendarIcon } from "lucide-react"
import { cn } from "@/lib/utils"
import { useQueryClient } from "@tanstack/react-query"
import { queryKeyWageCalculation, queryKeyWages } from "@/app/data/queryKeys"

const FormSchema = z.object({
  value: z.coerce.number(),
  datePaid: z.date(),
})

interface AddWageFormProps {
  userid: number
}

export function AddWageForm({ userid }: AddWageFormProps) {

  const queryClient = useQueryClient();

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      value: 0,
      datePaid: undefined,
    },
  })

  async function onSubmit(data: z.infer<typeof FormSchema>) {
     toast("You submitted the following values", {
       description: (
         <pre className="mt-2 w-[320px] rounded-md bg-neutral-950 p-4">
           <code className="text-white">{JSON.stringify(data, null, 2)}</code>
         </pre>
       ),
     })
 
     var addWageResponse = await addWage(userid, data.value, data.datePaid);

     if (addWageResponse.hasError || addWageResponse.hasFailed) {
       toast.error("Error adding wage: " + addWageResponse.errorMessage);
       return;
     }

    toast.success("Wage added successfully");
    form.reset();

    // Update the wage table with the new entry
    queryClient.invalidateQueries({ queryKey: [queryKeyWages] })
    queryClient.invalidateQueries({ queryKey: [queryKeyWageCalculation] })

     // var formatted = `Gross yearly income: ${calculateWageResponse.GrossYearlyIncome}\nWage values: \n${calculateWageResponse.Wage}`
     console.log(addWageResponse)
     console.log(addWageResponse.item)
     console.log(addWageResponse.hasError)
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6">
        <FormField
          control={form.control}
          name="value"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Value</FormLabel>
              <FormControl>
                <Input placeholder="Amount" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="datePaid"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel>Date Paid</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-[240px] pl-3 text-left font-normal",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? format(field.value, "PPP") : <span>Pick a date</span>}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    disabled={(date) =>
                      date > new Date() || date < new Date("1900-01-01")
                    }
                    captionLayout="dropdown"
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  )
}
