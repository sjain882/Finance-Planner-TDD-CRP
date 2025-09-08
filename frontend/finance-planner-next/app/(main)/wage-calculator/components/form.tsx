"use client"

import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import { toast } from "sonner"
import { z } from "zod"
import { WageCalculationRequest } from "@/interface/wage";

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
import { calculateWage } from "./action"
import { useState } from "react"
import { WageCalculationResponse } from "@/interface/wage"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

const FormSchema = z.object({
  salary: z.coerce.number(),
  salaryFrequency: z.string(),
  taxFreeAmount: z.coerce.number(),
  personalAllowance: z.coerce.number()
})

export function WageCalculatorForm() {

  const [addWageCalculationResponseMessage, setWageCalculationResponseMessage] = useState<WageCalculationResponse | null>(null);

  const form = useForm<z.infer<typeof FormSchema>>({
    resolver: zodResolver(FormSchema),
    defaultValues: {
      salary: 30000,
      salaryFrequency: "yearly",
      taxFreeAmount: 3000,
      personalAllowance: 12000,
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

    var calculateWageResponse = await calculateWage(data.salary, data.salaryFrequency, data.taxFreeAmount, data.personalAllowance)
    setWageCalculationResponseMessage(calculateWageResponse.item!);
  }

  const columnWidth = "max-w-[220px] w-[220px]"

  return (
    <div className="flex flex-row gap-8 w-full items-stretch h-full">
      <Card className="w-full max-w-xs h-full flex flex-col flex-1">
        <CardHeader>
          <CardTitle>Wage Calculator</CardTitle>
        </CardHeader>
        <CardContent className="flex-1 flex flex-col justify-between">
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-6 w-full flex flex-col flex-1 h-full">
              <FormField
                control={form.control}
                name="salary"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Salary</FormLabel>
                    <FormControl>
                      <Input
                        placeholder="30000"
                        {...field}
                        className="w-full"
                      />
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
                      <Input
                        placeholder="Yearly"
                        {...field}
                        className="w-full"
                      />
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
                      <Input
                        placeholder="3000"
                        {...field}
                        className="w-full"
                      />
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
                      <Input
                        placeholder="12000"
                        {...field}
                        className="w-full"
                      />
                    </FormControl>
                    <FormMessage />
                  </FormItem>
                )}
              />
              <div className="flex-1" />
              <Button type="submit">Submit</Button>
            </form>
          </Form>
        </CardContent>
      </Card>
      <Card className="flex-1 h-full flex flex-col min-h-[500px]">
        <CardHeader>
          <CardTitle>Wage Calculation Table</CardTitle>
        </CardHeader>
        <CardContent className="flex-1 flex flex-col p-0">
          <div className="overflow-auto h-full p-6 min-h-[350px] flex-1">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className={columnWidth}>Value</TableHead>
                  <TableHead className={columnWidth}>Number Of Payments</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {addWageCalculationResponseMessage &&
                  addWageCalculationResponseMessage.Wage.map(x => (
                    <TableRow key={x.Value}>
                      <TableCell className={columnWidth}>{x.Value}</TableCell>
                      <TableCell className={columnWidth}>{x.NumberOfPayments}</TableCell>
                    </TableRow>
                  ))}
              </TableBody>
            </Table>
          </div>
        </CardContent>
      </Card>
    </div>
  )
}
