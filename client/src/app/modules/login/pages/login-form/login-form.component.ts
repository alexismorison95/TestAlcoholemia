import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ErrorSnackBarComponent } from 'src/app/components/error-snack-bar/error-snack-bar.component';
import { OkSnackBarComponent } from 'src/app/components/ok-snack-bar/ok-snack-bar.component';
import { SnackBarService } from 'src/app/shared/messages/snack-bar.service';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  //formulario
  form!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private loginService: LoginService,
    private snackBar: SnackBarService
  ) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      UserName: ["", [Validators.required, Validators.minLength(4)]],
      Password: ["", [Validators.required, Validators.minLength(4)]]
    });
  }

  login() {

    this.loginService.login(this.form.value).subscribe(response => {

      this.snackBar.showOkMessage("Inicio de sesión exitoso");
      
      this.router.navigate(["/inicio"]);
    },
      (error: HttpErrorResponse) => {

        console.log(error);

        if (error.status == 401) { this.snackBar.showErrorMessage("Usuario o contraseña incorrectos"); } 
        else { this.snackBar.showErrorMessage("Error inesperado"); }
      });
  }
}
