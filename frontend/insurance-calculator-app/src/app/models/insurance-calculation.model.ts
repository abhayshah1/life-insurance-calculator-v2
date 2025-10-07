export interface InsuranceCalculationRequest {
  age: number;
  annualIncome: number;
  currentDebts: number;
  mortgageBalance: number;
  numberOfDependents: number;
  yearsOfIncomeReplacement: number;
  existingLifeInsurance: number;
  funeralExpenses: number;
  educationFundNeeded: number;
}

export interface InsuranceCalculationResponse {
  recommendedCoverage: number;
  incomeReplacement: number;
  debtCoverage: number;
  funeralExpenses: number;
  educationFund: number;
  existingCoverage: number;
  netInsuranceNeeded: number;
  calculationMethod: string;
  recommendations: string[];
}
