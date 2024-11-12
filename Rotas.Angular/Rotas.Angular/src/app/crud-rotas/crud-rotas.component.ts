import { Component, OnInit } from '@angular/core';
import { RotasService, Rota } from '../rotas.service';

@Component({
  selector: 'app-crud-rotas',
  templateUrl: './crud-rotas.component.html',
  styleUrls: ['./crud-rotas.component.css']
})
export class CrudRotasComponent implements OnInit {
  rotas: Rota[] = [];
  novaRota: Rota = { origem: '', destino: '', valor: 0 };

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
    this.rotasService.addRota(this.novaRota).subscribe(() => {
      this.getRotas();
      this.novaRota = { origem: '', destino: '', valor: 0 };
    });
  }

  excluirRota(id: number): void {
    this.rotasService.excluirRota(id).subscribe(() => {
      this.getRotas();
    });
  }
}
