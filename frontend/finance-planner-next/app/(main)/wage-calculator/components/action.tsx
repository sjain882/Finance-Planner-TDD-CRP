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
        return JSON.parse(JSON.stringify(await response.text()));
    }

    console.log("error returned add new account");

    var x = response.text

    console.log(x)

    return JSON.parse(JSON.stringify(await response.text()));
}
