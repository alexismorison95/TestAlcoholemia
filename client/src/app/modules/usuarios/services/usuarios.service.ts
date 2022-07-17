import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetUsuarioDTO, UsuarioDTO } from '../interfaces/Usuarios';
import { Tipousuario } from '../interfaces/Tipousuario';

const httpOptions = { 
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private readonly cGET_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetUsuarios`;
  private readonly cADD_USUARIO_URL = `${environment.apiUrl}/Usuario/InsertUsuario`;
  private readonly cUPDATE_USUARIO_URL = `${environment.apiUrl}/Usuario/UpdateUsuario`;
  private readonly cDELETE_USUARIO_URL = `${environment.apiUrl}/Usuario/DeleteUsuario/`;

  private readonly cGET_TIPO_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetTipoUsuarios`;
  private readonly cADD_TIPO_USUARIOS_URL = `${environment.apiUrl}/Usuario/InsertTipoUsuario`;
  private readonly cDELETE_TIPO_USUARIOS_URL = `${environment.apiUrl}/Usuario/DeleteTipoUsuario/`;

  
  constructor(private _http: HttpClient) { }

  /**
   * Obtiene la lista de usuarios desde la API
   * @returns GetUsuarioDTO[]
   */
  getUsuarios(): Observable<GetUsuarioDTO[]> {

    return this._http.get<GetUsuarioDTO[]>(this.cGET_USUARIOS_URL, httpOptions);
  }

  /**
   * Agrega un nuevo usuario desde la API
   * @param pUsuario usuario a agregar
   * @returns UsuarioDTO
   */
  addUsuario(pUsuario: UsuarioDTO): Observable<UsuarioDTO> {

    return this._http.post<UsuarioDTO>(this.cADD_USUARIO_URL, pUsuario, httpOptions);
  }

  /**
   * Edita un usario desde la API
   * @param pUsuario usuario a editar
   * @returns UsuarioDTO
   */
  editUsuario(pUsuario: UsuarioDTO): Observable<UsuarioDTO> {
    
    return this._http.put<UsuarioDTO>(this.cUPDATE_USUARIO_URL, pUsuario, httpOptions);
  }

  /**
   * Elimina un usuario desde la API
   * @param pNombreusuario clave unica del usuario a eliminar
   * @returns UsuarioDTO
   */
  deleteUsuario(pNombreusuario: string): Observable<UsuarioDTO> {

    return this._http.delete<UsuarioDTO>(this.cDELETE_USUARIO_URL + pNombreusuario, httpOptions);
  }


  /**
   * Obtiene la lista de tipos de usuarios desde la API
   * @returns Tipousuario[]
   */
  getTipoUsuario(): Observable<Tipousuario[]> {

    return this._http.get<Tipousuario[]>(this.cGET_TIPO_USUARIOS_URL, httpOptions);
  }

  /**
   * Agrega un nuevo tipo usuario desde la API
   * @param pUsuario tipo de usuario a agregar
   * @returns Tipousuario
   */
  addTipoUsuario(pTipoUsuario: Tipousuario): Observable<Tipousuario> {

    return this._http.post<Tipousuario>(this.cADD_TIPO_USUARIOS_URL, pTipoUsuario, httpOptions);
  }

  /**
   * Elimina un tipo de usuario desde la API
   * @param pId clave unica del tipo usuario a eliminar
   * @returns Tipousuario
   */
  deleteTipoUsuario(pId: number): Observable<Tipousuario> {

    return this._http.delete<Tipousuario>(this.cDELETE_TIPO_USUARIOS_URL + pId, httpOptions);
  }
}
