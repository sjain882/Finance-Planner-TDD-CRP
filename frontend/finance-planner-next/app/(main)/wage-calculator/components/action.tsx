'use server'

import { WageCalculationRequest } from "@/interface/WageCalculationRequest";
import { WageCalculationResponse } from "@/interface/WageCalculationResponse";
import WageCalculator from "../page";
import { cidrv4 } from "zod";


export async function calculateWage(salary: number, salaryFrequency: string, taxfreeAmount: number, personalAllowance: number): Promise<WageCalculationResponse> {
    const response = await fetch(process.env.QUERY_SERVER_URL + `/Wage/calculate`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            salary: salary,
            salaryFrequency: salaryFrequency,
            taxfreeAmount: taxfreeAmount,
            personalAllowance: personalAllowance,
        }),
    });

    if (response.ok) {
        var calculateWageResponse = await response.json()
        console.log(calculateWageResponse)
        return JSON.parse(JSON.stringify(calculateWageResponse));
    }

    console.log("Error!");
    var errorResponse = response.text
    console.log(errorResponse)

    return JSON.parse(JSON.stringify(await response.text()));
}
