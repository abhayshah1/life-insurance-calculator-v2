import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InsuranceCalculationRequest, InsuranceCalculationResponse } from '../models/insurance-calculation.model';

@Injectable({
  providedIn: 'root'
})
export class InsuranceService {
  private apiUrl = 'https://localhost:58390/api/insurance';

  constructor(private http: HttpClient) { }

  calculateInsurance(request: InsuranceCalculationRequest): Observable<InsuranceCalculationResponse> {
    return this.http.post<InsuranceCalculationResponse>(`${this.apiUrl}/calculate`, request);
  }

  checkHealth(): Observable<any> {
    return this.http.get(`${this.apiUrl}/health`);
  }
}
