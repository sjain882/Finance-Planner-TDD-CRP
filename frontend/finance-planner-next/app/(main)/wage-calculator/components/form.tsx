"use client"

import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { toast } from "sonner"
import { z } from "zod"

import { Button } from "@/components/ui/button"
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form"
import { Input } from "@/components/ui/input"

const FormSchema = z.object({
  salary: z.coerce.number(),
  salaryFrequency: z.string(),
  taxFreeAmount: z.coerce.number(),
  personalAllowance: z.coerce.number()
})

export function WageCalculatorForm() {
  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      salary: 30000,
      salaryFrequency: "yearly",
      taxFreeAmount: 3000,
      personalAllowance: 12000,
    },
  })

  function onSubmit(data: z.infer<typeof FormSchema>) {
    toast("You submitted the following values", {
      description: (
        <pre className="mt-2 w-[320px] rounded-md bg-neutral-950 p-4">
          <code className="text-white">{JSON.stringify(data, null, 2)}</code>
        </pre>
      ),
    })
  }

  return (
    <Form {...form}>

      <form onSubmit={form.handleSubmit(onSubmit)} className="w-2/3 space-y-6">

        <FormField
          control={form.control}
          name="salary"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Salary</FormLabel>
              <FormControl>
                <Input placeholder="30000" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="salaryFrequency"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Salary Frequency</FormLabel>
              <FormControl>
                <Input placeholder="Yearly" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="taxFreeAmount"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Tax Free Amount</FormLabel>
              <FormControl>
                <Input placeholder="3000" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="personalAllowance"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Personal Allowance</FormLabel>
              <FormControl>
                <Input placeholder="12000" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <Button type="submit">Submit</Button>
      </form>
    </Form>
  )
}
