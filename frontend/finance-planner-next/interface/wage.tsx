export interface WageCalculationRequest {
    salary: number
    salaryFrequency: string
    taxFreeAmount: number
    personalAllowance: number
}

export interface WageCalculationResponse {
    GrossYearlyIncome: number
    Wage: RepeatedPaymentResponse[]
}

export interface RepeatedPaymentResponse {
    Value: number
    NumberOfPayments: number
}