import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventosComponent } from './componente/eventos/eventos.component';
import { DashboardComponent } from './componente/dashboard/dashboard.component';
import { ContatoComponent } from './componente/contato/contato.component';
import { PerfilComponent } from './componente/perfil/perfil.component';
import { PalestranteComponent } from './componente/palestrante/palestrante.component';

const routes: Routes = [
  {path:'eventos',component:EventosComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:'contato',component:ContatoComponent},
  {path:'perfil',component:PerfilComponent},
  {path:'palestrante',component:PalestranteComponent},
  {path:'',redirectTo:'dashboard',pathMatch:'full'},
  {path:'**',redirectTo:'dashboard',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
