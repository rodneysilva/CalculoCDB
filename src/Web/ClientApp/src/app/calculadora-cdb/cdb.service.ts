import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CalculoCdbClient, RequisicaoInvestimentoDto, ResultadoInvestimentoDto } from './cdb.api';

@Injectable({
  providedIn: 'root'
})
export class CdbService {

  constructor(private api: CalculoCdbClient) { }

  calculate(initialValue: number, termInMonths: number): Observable<ResultadoInvestimentoDto> {
    const request = new RequisicaoInvestimentoDto({
      valorInicial: initialValue,
      duracaoEmMeses: termInMonths
    });

    return this.api.calculoCdb_CalcularCdb(request);
  }
}