import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { DeleteDialogComponent } from "../delete-dialog/delete-dialog.component";
import { AddDialogComponent } from "../add-dialog/add-dialog.component";

import { UsuariosService } from '../../services/usuarios.service';

import { GetUsuarioDTO, UsuarioDTO } from '../../interfaces/Usuarios';
import { Tipousuario } from '../../interfaces/Tipousuario';


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

  /**
   * Lista de tipos de usuarios
   * TODO: agregar interface y traer desde API
   */
  mTipousuarioList: Tipousuario[] = [
    { id: 1, tipo: 'administrador' },
    { id: 2, tipo: 'administrativo' },
    { id: 3, tipo: 'base' }
  ];


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

    const mAddDialog = this._dialog.open(
      AddDialogComponent, 
      { width: '400px', data: this.mTipousuarioList }
    );

    //despues de cerrar el dialogo
    mAddDialog.afterClosed().subscribe(pUsuario => {

      //si cargo correctamente el form
      if (pUsuario !== undefined) {
        
        this._usuariosService.addUsuario(pUsuario as UsuarioDTO).subscribe(() => {
          
          this.getUsuarios();
        });
      }
    });
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

    //despues de cerrar el dialogo
    mDeleteDialog.afterClosed().subscribe(pDelete => {

      //si la opción fue eliminar
      if (pDelete !== undefined) {
        
        this._usuariosService.deleteUsuario(pNombreusuario).subscribe(() => {
          
          this.getUsuarios();
        });
      }
    });
  }
}
