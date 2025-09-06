'use client'

import { useParams } from "next/navigation"
import { AddWageForm } from "./components/form"
import { WageSummaryCard } from "./components/card"
import { WageTable } from "./components/table"
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactNode } from 'react';

export default function AddWage() {
    // Get userid from dynamic route
    const params = useParams()
    const userid = Number(params.userid)
    const queryClient = new QueryClient();

    return (
        <QueryClientProvider client={queryClient}>
            <div className="flex flex-row gap-8">
                {/* Left side: summary card and form */}
                <div className="flex flex-col gap-8 w-1/2">
                    <div>
                        <WageSummaryCard userid={userid} />
                    </div>
                    <div>
                        <AddWageForm userid={userid} />
                    </div>
                </div>
                {/* Right side: wage table */}
                <div className="w-1/2">
                    <WageTable userid={userid} />
                </div>
            </div>
        </QueryClientProvider>
    )
}

