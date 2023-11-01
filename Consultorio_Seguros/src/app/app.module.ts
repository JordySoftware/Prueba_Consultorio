import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AseguradoComponent } from './asegurado/pages/asegurado/asegurado.component';
import { AgregarAseguradoComponent } from './asegurado/pages/agregar-asegurado/agregar-asegurado.component';
import { MainComponent } from './seguro/pages/main/main.component';
import { SeguroComponent } from './seguro/pages/seguro/seguro.component';
import { AgregarSeguroComponent } from './seguro/pages/agregar-seguro/agregar-seguro.component';

@NgModule({
  declarations: [
    AppComponent,
    AseguradoComponent,
    AgregarAseguradoComponent,
    MainComponent,
    SeguroComponent,
    AgregarSeguroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
