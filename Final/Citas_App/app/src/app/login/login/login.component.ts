import { Component, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApoloService, Perfil } from 'src/app/apolo/ApoloService';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
 
  confirmacion:string;
  a:boolean;
  password:string;
  correo:string;
  constructor(private Apolo:ApoloService,
    private router:Router) {
  
   }

  ngOnInit(): void {
    this.confirmacion="No se pudo iniciar sesion";
    this.a=false;
  }

  Inicio(){
    this.Apolo.Validar(1,this.correo,this.password).subscribe(
      data => 
      {
        console.log(data);
      if(data=='Ok')
      {
       this.router.navigate(['perfil',this.correo,this.password]);
       this.correo='';
       this.password='';
      }
      else
      {
        this.a=true;
        this.correo='';
        this.password='';
      } 
    }
    )
  }
  Reset(){
    this.a=false;
  }
  
  }


