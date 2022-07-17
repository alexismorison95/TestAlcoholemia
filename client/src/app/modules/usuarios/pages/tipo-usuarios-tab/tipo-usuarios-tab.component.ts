import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SnackBarService } from 'src/app/shared/messages/snack-bar.service';
import { AddDialogComponent } from '../../components/tipo-usuarios/add-dialog/add-dialog.component';
import { DeleteDialogComponent } from '../../components/tipo-usuarios/delete-dialog/delete-dialog.component';
import { Tipousuario } from '../../interfaces/Tipousuario';
import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-tipo-usuarios-tab',
  templateUrl: './tipo-usuarios-tab.component.html',
  styleUrls: ['./tipo-usuarios-tab.component.css']
})
export class TipoUsuariosTabComponent implements OnInit {

  /**
   * Lista de tipos de usuarios
   */
  iTipoUsuariosList: Tipousuario[] = [];

  constructor(
    private _usuariosService: UsuariosService,
    public _dialog: MatDialog,
    private snackBar: SnackBarService
  ) { }

  ngOnInit(): void {

    this.getTipoUsuarios();
  }

  getTipoUsuarios(): void {

    this._usuariosService.getTipoUsuario().subscribe(pResponse => {

      this.iTipoUsuariosList = pResponse;
    })
  }

  /**
   * Abre un dialogo para agregar un tipo de usuario
   */
  addTipoUsuario(): void {

    const mAddDialog = this._dialog.open(
      AddDialogComponent,
      { width: '400px' }
    );

    //despues de cerrar el dialogo
    mAddDialog.afterClosed().subscribe(pDescription => {

      //si cargo correctamente el form
      if (pDescription !== undefined) {

        const mTipoDeUsuario: Tipousuario = {
          id: 0,
          tipo: pDescription.descripcion
        };

        this._usuariosService.addTipoUsuario(mTipoDeUsuario).subscribe(() => {

          this.snackBar.showOkMessage("Tipo de usuario agregado con éxito");

          this.getTipoUsuarios();
        });
      }
    });
  }

  /**
   * Abre un dialogo para eliminar un tipo de usuario
   * @param pNombreusuario clave unica del tipo de usuario a liminar
   */
  deleteTipoUsuario(pTipoUsuario: Tipousuario): void {

    const mDeleteDialog = this._dialog.open(
      DeleteDialogComponent,
      { data: pTipoUsuario.tipo }
    );

    //despues de cerrar el dialogo
    mDeleteDialog.afterClosed().subscribe(pDelete => {

      //si la opción fue eliminar
      if (pDelete !== undefined) {

        this._usuariosService.deleteTipoUsuario(pTipoUsuario.id).subscribe(() => {

          this.snackBar.showOkMessage("Tipo de usuario eliminado con éxito");

          this.getTipoUsuarios();
        });
      }
    });
  }
}
