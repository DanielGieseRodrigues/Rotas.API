import { Component } from '@angular/core';
import { RotasService } from '../rotas.service';

@Component({
  selector: 'app-melhor-rota',
  templateUrl: './melhor-rota.component.html',
  styleUrls: ['./melhor-rota.component.css']
})
export class MelhorRotaComponent {
  origem: string = '';
  destino: string = '';
  melhorRota: string = '';

  constructor(private rotasService: RotasService) { }

  calcularMelhorRota(): void {
    this.rotasService.calcularMelhorRota(this.origem, this.destino).subscribe((response) => {
      this.melhorRota = response.melhorRota;
    });
  }
}
