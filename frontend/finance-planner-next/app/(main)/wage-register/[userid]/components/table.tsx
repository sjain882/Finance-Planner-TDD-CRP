"use client"

import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { DayWageResponse } from "@/interface/wage"

interface WageTableProps {
  userid: number
}

export function WageTable({ userid }: WageTableProps) {
  
  const wageData: DayWageResponse[] = []

  return (
    <div className="border rounded-lg p-6 shadow bg-white">
      <h2 className="text-lg font-bold mb-2">All Wage Entries</h2>
      <Table>
        <TableCaption>All wage entries for current user</TableCaption>
        <TableHeader>
          <TableRow>
            <TableHead>Value</TableHead>
            <TableHead>Date Paid</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {wageData.length > 0 ? wageData.map((w, i) => (
            <TableRow key={i}>
              <TableCell>{w.Value}</TableCell>
              <TableCell>{w.DatePaid.toString()}</TableCell>
            </TableRow>
          )) : (
            <TableRow>
              <TableCell colSpan={2}>No data</TableCell>
            </TableRow>
          )}
        </TableBody>
      </Table>
    </div>
  )
}