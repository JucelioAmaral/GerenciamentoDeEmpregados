import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Empregado } from '../utils/empregado';

@Injectable({
  providedIn: 'root'
})
export class EmpregadoService {

  baseUrl = environment.apiURL + 'Empregado/ListaEmpregados'

  constructor(
    private httpClient : HttpClient
  ) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  getEmpregados(): Observable<Empregado[]> {
    return this.httpClient.get<Empregado[]>(this.baseUrl)
      .pipe(
        retry(2),
        catchError(throwError))
  }

}
