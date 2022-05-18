import { Component, OnInit } from '@angular/core';
import { GetUsuarioDTO } from '../../interfaces/Usuarios';

import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  /**
   * Lista de usuarios a mostrar en la tabla
   */
  mUsuariosList: GetUsuarioDTO[] = [];


  constructor(
    private _usuariosService: UsuariosService
  ) { }

  ngOnInit(): void {

    this.getUsuarios();
  }

  /**
   * Obtiene los usuarios a mostrar
   */
  getUsuarios(): void {

    this._usuariosService.getUsuarios().subscribe(pResponse => {

      this.mUsuariosList = pResponse;
    });
  }

  /**
   * Abre un dialogo para agregar un usuario
   */
  addUsuario(): void {

    console.log("add");
  }

  /**
   * Abre un dialogo para editar un usuario
   * @param pUsuario usuario a editar
   */
  editUsuario(pUsuario: GetUsuarioDTO): void {
    
    console.log("edit " + pUsuario.nombreusuario);
  }

  /**
   * Abre un dialogo para eliminar un usuario
   * @param pNombreusuario clave unica del usuario a liminar
   */
  deleteUsuario(pNombreusuario: string): void {
    
    console.log("delete " + pNombreusuario);
  }
}
