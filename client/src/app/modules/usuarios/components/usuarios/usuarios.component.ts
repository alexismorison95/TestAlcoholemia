import { Component, OnInit } from '@angular/core';
import { GetUsuarioDTO } from '../../interfaces/Usuarios';

import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  mUsuariosList: GetUsuarioDTO[] = [];

  constructor(
    private _usuariosService: UsuariosService
  ) { }

  ngOnInit(): void {

    this.getUsuarios();
  }

  getUsuarios(): void {

    this._usuariosService.getUsuarios().subscribe(pResponse => {

      this.mUsuariosList = pResponse;
    });
  }

  addUsuario(): void {

    console.log("add");
  }

  editUsuario(pUsuario: GetUsuarioDTO): void {
    
    console.log("edit " + pUsuario.nombreusuario);
  }

  deleteUsuario(pNombreusuario: string): void {
    
    console.log("delete " + pNombreusuario);
  }
}
