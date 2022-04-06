import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, retry, take, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Empregado } from '../models/empregado';

@Injectable({
  providedIn: 'root'
})
export class EmpregadoService {

  baseUrl = environment.apiURL + 'Empregado'

  constructor(
    private httpClient : HttpClient
  ) { }
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  public getEmpregados(): Observable<Empregado[]> {
    return this.httpClient.get<Empregado[]>(`${this.baseUrl}/ListaEmpregados`).pipe(take(1));
  }

  public postEmpregado(empregado: Empregado): Observable<Empregado>{
    return this.httpClient.post<Empregado>(`${this.baseUrl}/CriaEmpregado`, empregado).pipe(take(1));
  }

  public putEmpregado(id: number, empregado: Empregado): Observable<Empregado>{
    return this.httpClient.put<Empregado>(`${this.baseUrl}/AtualizaEmpregado/${id}`, empregado).pipe(take(1));
  }
}
