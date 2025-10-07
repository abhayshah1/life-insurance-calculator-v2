import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { InsuranceFormComponent } from './components/insurance-form/insurance-form.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, InsuranceFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'insurance-calculator-app';
}
