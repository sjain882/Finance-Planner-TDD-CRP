'use server'

import { WageCalculationRequest } from "@/interface/wage";
import { WageCalculationResponse } from "@/interface/wage";
import WageCalculator from "../page";
import { cidrv4 } from "zod";
import { ErrorResult, Result, SuccessResult } from "@/types/result";


export async function calculateWage(salary: number, 
                                    salaryFrequency: string, 
                                    taxfreeAmount: number, 
                                    personalAllowance: number) : Promise<Result<WageCalculationResponse>> {
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
        console.log(calculateWageResponse.item)
        console.log(calculateWageResponse.hasError)
        return JSON.parse(JSON.stringify(new SuccessResult(calculateWageResponse)));
    }

    console.log("Error!");
    var errorResponse = await response.text()
    console.log(errorResponse)

    return JSON.parse(JSON.stringify(new ErrorResult(errorResponse, false)));
}
