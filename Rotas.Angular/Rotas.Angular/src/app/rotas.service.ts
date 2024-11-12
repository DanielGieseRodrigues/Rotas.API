import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Rota {
  id?: number;  
  origem: string;
  destino: string;
  valor: number;
}

@Injectable({
  providedIn: 'root',
})
export class RotasService {
  private apiUrl = 'https://localhost:7028/api/Rotas';

  constructor(private http: HttpClient) { }

  getRotas(): Observable<Rota[]> {
    return this.http.get<Rota[]>(`${this.apiUrl}`);
  }

  addRota(rota: Rota): Observable<Rota> {
    return this.http.post<Rota>(`${this.apiUrl}`, rota);
  }

  excluirRota(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  calcularMelhorRota(origem: string, destino: string): Observable<{ melhorRota: string }> {
    return this.http.get<{ melhorRota: string }>(`${this.apiUrl}/calcular-melhor-rota/${origem}/${destino}`);
  }
}
