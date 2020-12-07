import { Component, OnInit} from '@angular/core';
import { ApoloService,Perfil,Lugar,Aficion } from 'src/app/apolo/ApoloService';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  p:Perfil=null;
  constructor(private Apolo:ApoloService,
    private route:ActivatedRoute) 
    {
      this.route.params.subscribe(params => {
        let correo=params.correo;
        let password=params.password;
        this.Apolo.Perfil(2,correo,password).subscribe( data => {
          this.p=data;
          console.log(this.p.contexInt)
          this.p.foto='data:image/jpg;base64,' + data.foto;
          for(let i=0;i<this.p.lugares.length;i++){
            this.p.lugares[i].foto='data:image/jpg;base64,' + data.lugares[i].Foto;
          }
          for(let i=0;i<this.p.Aficiones.length;i++){
            this.p.Aficiones[i].foto='data:image/jpg;base64,' + data.Aficiones[i].Foto;
          }
        })
      });
    } 
  ngOnInit(): void {   
  }
}
