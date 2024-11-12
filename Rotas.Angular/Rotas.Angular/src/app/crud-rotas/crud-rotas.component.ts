import { Component, OnInit } from '@angular/core';
import { RotasService } from '../rotas.service';
import { Rota } from '../rota.model';

@Component({
  selector: 'app-crud-rotas',
  templateUrl: './crud-rotas.component.html',
  styleUrls: ['./crud-rotas.component.css']
})
export class CrudRotasComponent implements OnInit {
  rotas: Rota[] = [];
  novaRota: Rota = { origem: '', destino: '', valor: 0 };
  rotaEditando: Rota | null = null;

  constructor(private rotasService: RotasService) { }

  ngOnInit(): void {
    this.getRotas(); 
  }

  getRotas(): void {
    this.rotasService.getRotas().subscribe((data: Rota[]) => {
      this.rotas = data;
    });
  }

  addRota(): void {
    if (this.rotaEditando) {
      this.rotasService.editarRota(this.rotaEditando.id!, this.novaRota).subscribe(() => {
        this.getRotas();  
        this.rotaEditando = null;  
        this.novaRota = { origem: '', destino: '', valor: 0 };
      });
    } else {
      
      this.rotasService.addRota(this.novaRota).subscribe(() => {
        this.getRotas();  
        this.novaRota = { origem: '', destino: '', valor: 0 };  
      });
    }
  }

  excluirRota(id: number): void {
    if (id !== undefined && id !== null) {  
      this.rotasService.excluirRota(id).subscribe(() => {
        this.getRotas(); 
      });
    } else {
      console.error('ID da rota inválido');
    }
  }


  editarRota(rota: Rota): void {
    this.rotaEditando = { ...rota }; 
    this.novaRota = { ...rota }; 
  }
}
