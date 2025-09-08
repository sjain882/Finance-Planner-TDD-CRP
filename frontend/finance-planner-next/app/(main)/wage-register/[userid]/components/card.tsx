"use client"

import { useEffect, useState } from "react"
import { useQuery } from "@tanstack/react-query"
import { getEmployeeWage } from "./action"
import { queryKeyWageCalculation } from "@/app/data/queryKeys"
import { WageCalculationResponse } from "@/interface/wage"
import { Result } from "@/types/result"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"

interface WageSummaryCardProps {
  userid: number
}

export function WageSummaryCard({ userid }: WageSummaryCardProps) {
  const [personalAllowance, setPersonalAllowance] = useState<number>(12000)
  const [taxFreeAmount, setTaxFreeAmount] = useState<number>(3000)
  const [wageCalc, setWageCalc] = useState<WageCalculationResponse | null>(null)

  const { data } = useQuery<Result<WageCalculationResponse>>({
    queryKey: [queryKeyWageCalculation, personalAllowance, taxFreeAmount],
    queryFn: () => getEmployeeWage(userid, personalAllowance, taxFreeAmount),
  })

  useEffect(() => {
    if (data == null || data.hasError || data.item == undefined) {
      setWageCalc(null)
    } else {
      setWageCalc(data.item)
    }
  }, [data])

  return (
    <Card>
      <CardHeader>
        <CardTitle>Wage Summary</CardTitle>
      </CardHeader>
      <CardContent>
        <div className="mb-4">
          <span className="font-semibold">Gross Yearly Income: </span>
          {wageCalc ? wageCalc.GrossYearlyIncome : "No data"}
        </div>
        <div>
          <span className="font-semibold">Payments:</span>
          <div className="mt-2 max-h-64 overflow-x-auto overflow-y-auto rounded">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="w-[220px] max-w-[220px]">Value</TableHead>
                  <TableHead className="w-[220px] max-w-[220px]">Number Of Payments</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {wageCalc && wageCalc.Wage.length > 0
                  ? wageCalc.Wage.map((w, i) => (
                      <TableRow key={i}>
                        <TableCell className="w-[220px] max-w-[220px]">{w.Value}</TableCell>
                        <TableCell className="w-[220px] max-w-[220px]">{w.NumberOfPayments}</TableCell>
                      </TableRow>
                    ))
                  : (
                    <TableRow>
                      <TableCell colSpan={2}>No data</TableCell>
                    </TableRow>
                  )}
              </TableBody>
            </Table>
          </div>
        </div>
      </CardContent>
    </Card>
  )
}