import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CdbService } from './cdb.service';
import { finalize } from 'rxjs/operators';

interface CdbResult {
  resultadoBruto: number;
  resultadoLiquido: number;
  rendimentoTotal: number;
  impostoRenda: number;
}

@Component({
  selector: 'app-calculadora-cdb',
  templateUrl: './calculadora-cdb.component.html',
  styleUrls: ['./calculadora-cdb.component.scss'],
  standalone: false
})
export class CalculadoraCdbComponent {
  calculatorForm: FormGroup;
  result: CdbResult | null = null;
  isLoading = false;
  errorMessage: string | null = null;

  constructor(private fb: FormBuilder, private cdbService: CdbService) {
    this.calculatorForm = this.fb.group({
      initialValue: ['', [Validators.required, Validators.min(0.01)]],
      termInMonths: ['', [Validators.required, Validators.min(2), Validators.pattern('^[0-9]*$')]]
    });
  }

  calculateCdb(): void {
    this.errorMessage = null;
    this.result = null;

    if (this.calculatorForm.invalid) {
      this.calculatorForm.markAllAsTouched();
      this.errorMessage = 'Por favor, preencha os campos corretamente.';
      return;
    }

    this.isLoading = true;

    const { initialValue, termInMonths } = this.calculatorForm.value;

    this.cdbService.calculate(initialValue, termInMonths)
      .pipe(finalize(() => this.isLoading = false))
      .subscribe({
        next: (response) => { this.result = response; },
        error: (err) => { this.errorMessage = 'Não foi possível realizar o cálculo. Tente novamente mais tarde.'; console.error(err); }
      });
  }
}