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
import { queryKeyWages } from "@/app/data/queryKeys";
import { DayWageResponse } from "@/interface/wage"
import { useQuery } from "@tanstack/react-query";
import { getAllWages } from "./action";
import { Result } from "@/types/result";
import { useEffect, useState } from "react";

interface WageTableProps {
  userid: number
}

export function WageTable({ userid }: WageTableProps) {
  
    const [wages, setWages] = useState<DayWageResponse[]>([]);

    const { data } = useQuery<Result<DayWageResponse[]>>({
        queryKey: [queryKeyWages],
        queryFn: () => {
            return getAllWages(userid);
        },
    });

    useEffect(() => {
      if (data == null || data.hasError || data.item == undefined) {

      } else {
          setWages(data?.item)
      }
    }, [data]);

    
    return (
      <div className="border rounded-lg p-6 shadow bg-white">
        <h2 className="text-lg font-bold mb-2">All Wage Entries</h2>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Value</TableHead>
              <TableHead>Date Paid</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {wages.length > 0 ? wages.map((w, i) => (
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