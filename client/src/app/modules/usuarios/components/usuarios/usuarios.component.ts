import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { DeleteDialogComponent } from "../delete-dialog/delete-dialog.component";

import { UsuariosService } from '../../services/usuarios.service';

import { GetUsuarioDTO } from '../../interfaces/Usuarios';


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
    private _usuariosService: UsuariosService,
    public _dialog: MatDialog
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
    
    const mDeleteDialog = this._dialog.open(
      DeleteDialogComponent, 
      { data: pNombreusuario }
    );

    mDeleteDialog.afterClosed().subscribe(pUsuario => {

      if (pUsuario !== undefined) {
        
        //TODO: eliminar llamando al servicio
        console.log(pUsuario);
      }
    });
  }
}
