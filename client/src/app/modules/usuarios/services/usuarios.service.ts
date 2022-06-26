import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetUsuarioDTO, UsuarioDTO } from '../interfaces/Usuarios';
import { Tipousuario } from '../interfaces/Tipousuario';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private readonly cGET_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetUsuarios`;
  private readonly cADD_USUARIO_URL = `${environment.apiUrl}/Usuario/InsertUsuario`;
  private readonly cUPDATE_USUARIO_URL = `${environment.apiUrl}/Usuario/UpdateUsuario`;
  private readonly cDELETE_USUARIO_URL = `${environment.apiUrl}/Usuario/DeleteUsuario/`;

  private readonly cGET_TIPO_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetTipoUsuarios`;

  
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

  /**
   * Edita un usario desde la API
   * @param pUsuario usuario a editar
   * @returns UsuarioDTO
   */
  editUsuario(pUsuario: UsuarioDTO): Observable<UsuarioDTO> {
    
    return this._http.put<UsuarioDTO>(this.cUPDATE_USUARIO_URL, pUsuario);
  }

  /**
   * Elimina un usuario desde la API
   * @param pNombreusuario clave unica del usuario a eliminar
   * @returns UsuarioDTO
   */
  deleteUsuario(pNombreusuario: string): Observable<UsuarioDTO> {

    return this._http.delete<UsuarioDTO>(this.cDELETE_USUARIO_URL + pNombreusuario);
  }


  /**
   * Obtiene la lista de tipos de usuarios desde la API
   * @returns Tipousuario[]
   */
  getTipoUsuario(): Observable<Tipousuario[]> {

    return this._http.get<Tipousuario[]>(this.cGET_TIPO_USUARIOS_URL);
  }
}
