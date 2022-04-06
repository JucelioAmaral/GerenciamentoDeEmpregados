import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule} from '@angular/material/toolbar';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatCardModule} from '@angular/material/card';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { NgxSpinnerModule } from 'ngx-spinner';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { EmpregadosComponent } from './components/empregados/empregados.component';
import { EmpregadoListaComponent } from './components/empregados/empregado-lista/empregado-lista.component';
import { EmpregadoDetalheComponent } from './components/empregados/empregado-detalhe/empregado-detalhe.component';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    EmpregadosComponent,
    EmpregadoListaComponent,
    EmpregadoDetalheComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
    NgxSpinnerModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDatepickerModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
