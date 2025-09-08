'use client'

import { useParams } from "next/navigation"
import { AddWageForm } from "./components/form"
import { WageSummaryCard } from "./components/card"
import { WageTable } from "./components/table"
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { useEffect, useRef } from 'react';
import { Dialog, DialogContent, DialogTitle } from "@/components/ui/dialog"

export default function AddWage() {
    const params = useParams()
    const userid = Number(params.userid)
    const queryClient = new QueryClient();

    const open = true

    const dialogRef = useRef<HTMLDivElement>(null)
    useEffect(() => {
        dialogRef.current?.focus()
    }, [])

    return (
        <QueryClientProvider client={queryClient}>
            <Dialog open={open}>
                <DialogContent
                    ref={dialogRef}
                    style={{ width: "85vw", maxWidth: "85vw", height: "auto", maxHeight: "95vh" }}
                    className="p-8 flex flex-col gap-8 outline-none"
                    tabIndex={-1}
                >
                    <DialogTitle>Wage Register</DialogTitle>
                    <div className="flex flex-row gap-8 h-full">
                        {/* Left side: summary card and form */}
                        <div className="flex flex-col gap-8 w-1/2">
                            <WageSummaryCard userid={userid} />
                            <AddWageForm userid={userid} />
                        </div>
                        {/* Right side: wage table */}
                        <div className="w-1/2">
                            <WageTable userid={userid} />
                        </div>
                    </div>
                </DialogContent>
            </Dialog>
        </QueryClientProvider>
    )
}

