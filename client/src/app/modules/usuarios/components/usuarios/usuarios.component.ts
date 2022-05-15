import { Component, OnInit } from '@angular/core';

import { UsuariosService } from '../../services/usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor(
    private _usuariosService: UsuariosService
  ) { }

  ngOnInit(): void {

    this.getUsuarios();
  }

  getUsuarios(): void {

    this._usuariosService.getUsuarios().subscribe(pResponse => {

      console.log(pResponse);
    });
  }

}
