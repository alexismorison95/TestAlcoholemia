import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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
  iTipousuarioList: Tipousuario[] = [];


  constructor(
    private _usuariosService: UsuariosService,
    public _dialog: MatDialog
  ) { }

  ngOnInit(): void {

    this.getTipoUsuarios();

    this.getUsuarios();
  }

  getTipoUsuarios(): void {

    this._usuariosService.getTipoUsuario().subscribe(pResponse => {

      this.iTipousuarioList = pResponse;
    })
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

    const mAddDialog = this._dialog.open(
      AddDialogComponent,
      { width: '400px', data: this.iTipousuarioList }
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

    const mEditDialog = this._dialog.open(
      EditDialogComponent,
      { width: '400px', data: { usuario: pUsuario, tipousuario: this.iTipousuarioList } }
    );

    //despues de cerrar el dialogo
    mEditDialog.afterClosed().subscribe(pUsuario => {

      //si cargo correctamente el form
      if (pUsuario !== undefined) {

        this._usuariosService.editUsuario(pUsuario as UsuarioDTO).subscribe(() => {

          this.getUsuarios();
        });
      }
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

          this.getUsuarios();
        });
      }
    });
  }

}
