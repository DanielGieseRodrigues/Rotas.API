import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CrudRotasComponent } from './crud-rotas/crud-rotas.component';
import { MelhorRotaComponent } from './melhor-rota/melhor-rota.component';

const routes: Routes = [
  { path: '', redirectTo: '/crud-rotas', pathMatch: 'full' },
  { path: 'crud-rotas', component: CrudRotasComponent },
  { path: 'melhor-rota', component: MelhorRotaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
