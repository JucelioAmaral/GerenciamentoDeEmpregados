import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmpregadoDetalheComponent } from './components/empregados/empregado-detalhe/empregado-detalhe.component';
import { EmpregadoListaComponent } from './components/empregados/empregado-lista/empregado-lista.component';
import { EmpregadosComponent } from './components/empregados/empregados.component';

const routes: Routes = [
  {path: 'empregados', redirectTo: 'empregados/lista'},
  {
    path: 'empregados', component: EmpregadosComponent,
    children:[
      {path: 'detalhe', component: EmpregadoDetalheComponent},
      {path: 'lista', component: EmpregadoListaComponent},
    ]
  },
  {path: '', redirectTo:'empregados/lista', pathMatch: 'full'},
  {path: '**', redirectTo:'empregados/lista', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
