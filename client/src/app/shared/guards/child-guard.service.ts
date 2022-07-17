import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateChild, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class ChildGuardService implements CanActivateChild {

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

    const token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){

      return true;
    }

    this.router.navigate(['/login']);

    return false;
  }
}
