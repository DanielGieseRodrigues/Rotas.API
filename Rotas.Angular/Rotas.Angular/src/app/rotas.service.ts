import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Rota } from './rota.model';

@Injectable({
  providedIn: 'root'
})
export class RotasService {
  private apiUrl = 'https://localhost:7028/api/Rotas';

  constructor(private http: HttpClient) { }

  getRotas(): Observable<Rota[]> {
    return this.http.get<Rota[]>(`${this.apiUrl}`);
  }

  addRota(rota: Rota): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}`, rota);
  }

  excluirRota(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  editarRota(id: number, rota: Rota): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, rota);
  }

  calcularMelhorRota(origem: string, destino: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/calcular-melhor-rota/${origem}/${destino}`);
  }
}
