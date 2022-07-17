import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorSnackBarComponent } from 'src/app/components/error-snack-bar/error-snack-bar.component';
import { OkSnackBarComponent } from 'src/app/components/ok-snack-bar/ok-snack-bar.component';
import { SnackBarService } from 'src/app/shared/messages/snack-bar.service';
import { AddDialogComponent } from '../../components/usuarios/add-dialog/add-dialog.component';
import { DeleteDialogComponent } from '../../components/usuarios/delete-dialog/delete-dialog.component';
import { EditDialogComponent } from '../../components/usuarios/edit-dialog/edit-dialog.component';
import { Tipousuario } from '../../interfaces/Tipousuario';
import { GetUsuarioDTO, UsuarioDTO } from '../../interfaces/Usuarios';
import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-usuarios-tab',
  templateUrl: './usuarios-tab.component.html',
  styleUrls: ['./usuarios-tab.component.css']
})
export class UsuariosTabComponent implements OnInit {

  /**
   * Lista de usuarios a mostrar en la tabla
   */
  iUsuariosList: GetUsuarioDTO[] = [];

  /**
   * Lista de tipos de usuarios
   */
  //iTipousuarioList: Tipousuario[] = [];


  constructor(
    private _usuariosService: UsuariosService,
    public _dialog: MatDialog,
    private snackBar: SnackBarService
  ) { }

  ngOnInit(): void {

    this.getUsuarios();
  }

  /**
   * Obtiene los usuarios a mostrar
   */
  getUsuarios(): void {

    this._usuariosService.getUsuarios().subscribe(pResponse => {

      this.iUsuariosList = pResponse;
    });
  }

  /**
   * Abre un dialogo para agregar un usuario
   */
  addUsuario(): void {

    this._usuariosService.getTipoUsuario().subscribe(pResponse => {

      const mAddDialog = this._dialog.open(
        AddDialogComponent,
        { width: '400px', data: pResponse}
      );
  
      //despues de cerrar el dialogo
      mAddDialog.afterClosed().subscribe(pUsuario => {
  
        //si cargo correctamente el form
        if (pUsuario !== undefined) {
  
          this._usuariosService.addUsuario(pUsuario as UsuarioDTO).subscribe(() => {

            this.snackBar.showOkMessage("Usuario agregado con éxito");
  
            this.getUsuarios();
          },
          (error: HttpErrorResponse) => {

            console.log(error);
            
            if (error.status == 500) { this.snackBar.showErrorMessage("Error al insertar usuario"); } 
            else { this.snackBar.showErrorMessage("Error inesperado"); }
          });
        }
      });

    });
  }

  /**
   * Abre un dialogo para editar un usuario
   * @param pUsuario usuario a editar
   */
  editUsuario(pUsuario: GetUsuarioDTO): void {

    this._usuariosService.getTipoUsuario().subscribe(pResponse => {

      const mEditDialog = this._dialog.open(
        EditDialogComponent,
        { width: '400px', data: { usuario: pUsuario, tipousuario: pResponse } }
      );

      //despues de cerrar el dialogo
      mEditDialog.afterClosed().subscribe(pUsuario => {

        //si cargo correctamente el form
        if (pUsuario !== undefined) {

          this._usuariosService.editUsuario(pUsuario as UsuarioDTO).subscribe(() => {

            this.snackBar.showOkMessage("Usuario actualizado con éxito");

            this.getUsuarios();
          });
        }
      });
    });
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

          this.snackBar.showOkMessage("Usuario eliminado con éxito");

          this.getUsuarios();
        });
      }
    });
  }

}
