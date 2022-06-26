import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
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
    public _dialog: MatDialog
  ) { }

  ngOnInit(): void {

    this.getTipoUsuarios();
  }

  getTipoUsuarios(): void {

    this._usuariosService.getTipoUsuario().subscribe(pResponse => {

      this.iTipoUsuariosList = pResponse;
    })
  }

}
