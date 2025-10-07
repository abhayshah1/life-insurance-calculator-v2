import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { InsuranceService } from '../../services/insurance.service';
import { InsuranceCalculationRequest, InsuranceCalculationResponse } from '../../models/insurance-calculation.model';

@Component({
  selector: 'app-insurance-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './insurance-form.component.html',
  styleUrl: './insurance-form.component.css'
})
export class InsuranceFormComponent {
  request: InsuranceCalculationRequest = {
    age: 35,
    annualIncome: 75000,
    currentDebts: 10000,
    mortgageBalance: 250000,
    numberOfDependents: 2,
    yearsOfIncomeReplacement: 10,
    existingLifeInsurance: 100000,
    funeralExpenses: 15000,
    educationFundNeeded: 100000
  };

  response: InsuranceCalculationResponse | null = null;
  loading = false;
  error: string | null = null;

  constructor(private insuranceService: InsuranceService) {}

  onSubmit(): void {
    this.loading = true;
    this.error = null;
    this.response = null;

    this.insuranceService.calculateInsurance(this.request).subscribe({
      next: (result) => {
        this.response = result;
        this.loading = false;
      },
      error: (err) => {
        this.error = err.error?.message || err.message || 'An error occurred while calculating insurance needs.';
        this.loading = false;
      }
    });
  }

  resetForm(): void {
    this.request = {
      age: 35,
      annualIncome: 75000,
      currentDebts: 10000,
      mortgageBalance: 250000,
      numberOfDependents: 2,
      yearsOfIncomeReplacement: 10,
      existingLifeInsurance: 100000,
      funeralExpenses: 15000,
      educationFundNeeded: 100000
    };
    this.response = null;
    this.error = null;
  }
}
