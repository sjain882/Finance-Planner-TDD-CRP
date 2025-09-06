'use server'

import { cidrv4 } from "zod";
import { ErrorResult, Result, SuccessResult } from "@/types/result";

import { DayWageResponse } from "@/interface/wage";
import { WageCalculationResponse } from "@/interface/wage";
import { WageCalculationRequest } from "@/interface/wage";

export async function addWage(userid: number,
                                value: number, 
                                datepaid: Date) : Promise<Result<string>> {

    const response = await fetch(process.env.COMMAND_SERVER_URL + `/Wage`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            userid: userid,
            value: value,
            datepaid: datepaid
        }),
    });

    if (response.ok) {
        var addWageResponse = await response.text()
        console.log(addWageResponse)
        return JSON.parse(JSON.stringify(new SuccessResult(addWageResponse)));
    }

    console.log("Error!");
    var errorResponse = await response.text()
    console.log(errorResponse)

    return JSON.parse(JSON.stringify(new ErrorResult(errorResponse, false)));
}


export async function getAllWages(userid: number,
                                        personalAllowance: number,
                                        taxFreeAmount: number
                                        ): Promise<Result<WageCalculationResponse>> {

    const url = `${process.env.QUERY_SERVER_URL}/Wage/all/raw/${userid}`

    const response = await fetch(url, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    });

    if (response.ok) {
        var getAllWagesResponse = await response.json()
        console.log(getAllWagesResponse)
        return JSON.parse(JSON.stringify(new SuccessResult(getAllWagesResponse)));
    }

    console.log("Error!");
    var errorResponse = await response.json()
    console.log(errorResponse)

    return JSON.parse(JSON.stringify(new ErrorResult(errorResponse, false)));
}



export async function getEmployeeWage(userid: number,
                                        personalAllowance: number,
                                        taxFreeAmount: number
                                        ): Promise<Result<WageCalculationResponse>> {

        const url = `${process.env.QUERY_SERVER_URL}/Wage/all/${userid}?personalAllowance=${personalAllowance}&taxFreeAmount=${taxFreeAmount}`


    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            userid: userid,
            personalAllowance: personalAllowance,
            taxFreeAmount: taxFreeAmount
        }),
    });

    if (response.ok) {
        var getEmployeeWageResponse = await response.json()
        console.log(getEmployeeWageResponse)
        return JSON.parse(JSON.stringify(new SuccessResult(getEmployeeWageResponse)));
    }

    console.log("Error!");
    var errorResponse = await response.json()
    console.log(errorResponse)

    return JSON.parse(JSON.stringify(new ErrorResult(errorResponse, false)));
}