"use client"

import {
  Table,
  TableBody,
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
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

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
        setWages([]);
      } else {
        setWages(data?.item)
      }
    }, [data]);

    return (
      <Card className="flex flex-col h-full min-h-[500px]">
        <CardHeader>
          <CardTitle>All Wage Entries</CardTitle>
        </CardHeader>
        <CardContent className="flex-1 flex flex-col p-0">
          <div className="overflow-auto h-full p-6 min-h-[350px] flex-1">
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead className="w-[220px] max-w-[220px]">Value</TableHead>
                  <TableHead className="w-[220px] max-w-[220px]">Date Paid</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {wages.length > 0 ? wages.map((w, i) => (
                  <TableRow key={i}>
                    <TableCell className="w-[220px] max-w-[220px]">{w.Value}</TableCell>
                    <TableCell className="w-[220px] max-w-[220px]">{w.DatePaid.toString()}</TableCell>
                  </TableRow>
                )) : (
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