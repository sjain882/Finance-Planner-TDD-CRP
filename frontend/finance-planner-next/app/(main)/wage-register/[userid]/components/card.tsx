"use client"

import { WageCalculationResponse } from "@/interface/wage"
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"

interface WageSummaryCardProps {
  userid: number
}

export function WageSummaryCard({ userid }: WageSummaryCardProps) {
  // Get WageCalculationResponse
  const wageSummary: WageCalculationResponse | null = null

  return (
    <div className="border rounded-lg p-6 shadow bg-white">
      <h2 className="text-lg font-bold mb-2">Wage Summary</h2>
      {/* Replace with actual data */}
      <div>
        <div className="mb-4">
          <span className="font-semibold">Gross Yearly Income: </span>
          {wageSummary ? wageSummary.GrossYearlyIncome : "No data"}
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
              {wageSummary
                ? wageSummary.Wage.map((w, i) => (
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
      </div>
    </div>
  )
}