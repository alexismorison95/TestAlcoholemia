import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GetUsuarioDTO } from '../../usuarios/interfaces/Usuarios';
import { AuthenticationDTO, LoginDTO } from '../interfaces/Login';

const httpOptions = { 
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private readonly cLOGIN_URL = `${environment.apiUrl}/Login/Login`;

  //datos de la sesión
  //private _isUserAuthenticated: boolean = false;
  private _authenticatedUser: GetUsuarioDTO | null = null;

  constructor(private _http: HttpClient, private jwtHelper: JwtHelperService) { }

  /**
   * Inicia sesion con los datos de usuario y contraseña
   * @param pLoginDTO 
   * @returns 
   */
  login(pLoginDTO: LoginDTO): Observable<AuthenticationDTO> {

    return this._http.post<AuthenticationDTO>(
      this.cLOGIN_URL, 
      pLoginDTO, 
      httpOptions)
    .pipe(
      map((response: AuthenticationDTO) => {

        //guardo el token en el local storage
        const mToken = response.token;
        localStorage.setItem('jwt', mToken);

        //this._isUserAuthenticated = true;

        return response;
      }));
  }

  /**
   * Cierra la sesión del usuario
   */
  logout() {
    
    //this._isUserAuthenticated = false;
    this._authenticatedUser = null;

    localStorage.removeItem('jwt');
  }

  /**
   * Devuelve true si el usuario está autenticado, false en caso contrario
   * @returns 
   */
  isUserAuthenticated(): boolean {

    const token = localStorage.getItem("jwt");
    
    if (token && !this.jwtHelper.isTokenExpired(token)){

      return true;
    }

    return false;
  }

  /**
   * Devuelve los datos del usuario autenticado
   * @returns 
   */
  authenticatedUser(): GetUsuarioDTO | null {
      
      return this._authenticatedUser;
  }
}
