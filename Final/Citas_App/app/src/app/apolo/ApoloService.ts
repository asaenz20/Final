import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { Binary } from '@angular/compiler';


@Injectable({
  providedIn: 'root'
})
export class ApoloService {

  url:string;
  constructor(private http:HttpClient) { 
    this.url='https://localhost:44312/api/Citas';
  }

  Validar(tipo:number,correo:string,password:string):Observable<any>{
    let urlT=this.url+ "?tipo=" + tipo + "&correo="+ correo +
     "&password=" + password; 
     return this.http.get<string>(urlT);
  }
  Perfil(tipo:number,correo:string,password:string):Observable<any>{
    let urlT=this.url+ "?tipo=" + tipo + "&correo="+ correo +
     "&password=" + password;  
     return this.http.get<Perfil>(urlT);
   }
   
   
}
export class Perfil{
  id:number;
  nombre:string;
  Aficiones:Aficion[];
  nacimiento:string;
  correo:string;
  educacion:string;
  contextura:string;
  foto:string;
  sexo:string;
  pais:string;
  sexInt:string;
  contexInt:string;
  lugares:Lugar[];
  clave:string;
}
export class Lugar{
  id:number;
  nombre:string;
  foto:string;
}
export class Aficion{
  id:number;
  nombre:string;
  foto:string;
}
