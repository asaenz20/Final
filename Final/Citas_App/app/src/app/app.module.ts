import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import {ApoloService } from './apolo/ApoloService';
import { LoginComponent } from './login/login/login.component';
import { PerfilComponent } from './perfil/perfil/perfil.component';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PerfilComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule
  ],
  providers: [ApoloService],
  bootstrap: [AppComponent]
})
export class AppModule { }
