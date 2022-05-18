import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { GetUsuarioDTO } from '../interfaces/Usuarios';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  private readonly cGET_USUARIOS_URL = `${environment.apiUrl}/Usuario/GetUsuarios`;

  constructor(private _http: HttpClient) { }

  getUsuarios(): Observable<GetUsuarioDTO[]> {

    return this._http.get<GetUsuarioDTO[]>(this.cGET_USUARIOS_URL);
  }
}
