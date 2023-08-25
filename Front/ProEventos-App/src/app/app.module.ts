import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PalestranteComponent } from './componente/palestrante/palestrante.component';
import { EventosComponent } from './componente/eventos/eventos.component';
import { PerfilComponent } from './componente/perfil/perfil.component';
import { ContatoComponent } from './componente/contato/contato.component';
import { DashboardComponent } from './componente/dashboard/dashboard.component';
import { TituloComponent } from './shared/titulo/titulo.component';
import { NavComponent } from './shared/Nav/Nav.component';

import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';


@NgModule({
  declarations: [
    AppComponent,
      PalestranteComponent,
      EventosComponent,
      ContatoComponent,
      PerfilComponent,
      DashboardComponent,
      NavComponent,
      TituloComponent,
      DateTimeFormatPipe,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar:true,

    }),
    NgxSpinnerModule.forRoot({ type: 'ball-scale-multiple' })

  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
