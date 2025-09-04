import { RepeatedPaymentResponse } from "./RepeatedPaymentResponse"

export interface WageCalculationResponse {
    GrossYearlyIncome: number
    Wage: RepeatedPaymentResponse[]
}