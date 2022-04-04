import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './layout/layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule} from '@angular/material/toolbar';
import { EmpregadoComponent } from './components/empregados/empregados.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent,
    EmpregadoComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatToolbarModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
