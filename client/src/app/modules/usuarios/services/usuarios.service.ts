import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetUsuarioDTO, UsuarioDTO } from '../interfaces/Usuarios';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private readonly cGET_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetUsuarios`;
  private readonly cADD_USUARIO_URL = `${environment.apiUrl}/Usuario/InsertUsuario`;
  private readonly cDELETE_USUARIO_URL = `${environment.apiUrl}/Usuario/DeleteUsuario/`;

  
  constructor(private _http: HttpClient) { }

  /**
   * Obtiene la lista de usuarios desde la API
   * @returns GetUsuarioDTO[]
   */
  getUsuarios(): Observable<GetUsuarioDTO[]> {

    return this._http.get<GetUsuarioDTO[]>(this.cGET_USUARIOS_URL);
  }

  /**
   * Agrega un nuevo usuario desde la API
   * @param pUsuario usuario a agregar
   * @returns UsuarioDTO
   */
  addUsuario(pUsuario: UsuarioDTO): Observable<UsuarioDTO> {

    return this._http.post<UsuarioDTO>(this.cADD_USUARIO_URL, pUsuario);
  }

  editUsuario() {

  }

  /**
   * Elimina un usuario desde la API
   * @param pNombreusuario clave unica del usuario a eliminar
   * @returns UsuarioDTO
   */
  deleteUsuario(pNombreusuario: string): Observable<UsuarioDTO> {

    return this._http.delete<UsuarioDTO>(this.cDELETE_USUARIO_URL + pNombreusuario);
  }
}
