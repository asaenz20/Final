import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PerfilComponent } from './perfil/perfil/perfil.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login/login.component';


const routes: Routes = [
  {path:'perfil/:correo/:password',component:PerfilComponent},
  {path:'inicio', component:AppComponent},
  {path:'login',component:LoginComponent},
  {path:'**',pathMatch:'full',redirectTo:'inicio'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
