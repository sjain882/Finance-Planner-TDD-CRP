"use client"

import { WageCalculationResponse } from "@/interface/wage"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { useEffect, useState } from "react"
import { getEmployeeWage } from "./action"
import { queryKeyWageCalculation } from "@/app/data/queryKeys"
import { useQuery } from "@tanstack/react-query"
import { Result } from "@/types/result"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

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
        <div className="flex gap-4 mb-4">
          <div>
            <Label htmlFor="personalAllowance" className="mb-1 block">
              Personal Allowance
            </Label>
            <Input
              id="personalAllowance"
              type="number"
              value={personalAllowance}
              onChange={e => setPersonalAllowance(Number(e.target.value) || 0)}
              min={0}
              step={1}
              className="w-32"
            />
          </div>
          <div>
            <Label htmlFor="taxFreeAmount" className="mb-1 block">
              Tax Free Amount
            </Label>
            <Input
              id="taxFreeAmount"
              type="number"
              value={taxFreeAmount}
              onChange={e => setTaxFreeAmount(Number(e.target.value) || 0)}
              min={0}
              step={1}
              className="w-32"
            />
          </div>
        </div>
        <div className="mb-4">
          <span className="font-semibold">Gross Yearly Income: </span>
          {wageCalc ? wageCalc.GrossYearlyIncome : "No data"}
        </div>
        <div>
          <span className="font-semibold">Payments:</span>
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>Value</TableHead>
                <TableHead>Number Of Payments</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {wageCalc && wageCalc.Wage.length > 0
                ? wageCalc.Wage.map((w, i) => (
                    <TableRow key={i}>
                      <TableCell>{w.Value}</TableCell>
                      <TableCell>{w.NumberOfPayments}</TableCell>
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
      </CardContent>
    </Card>
  )
}