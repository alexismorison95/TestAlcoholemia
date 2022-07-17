import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    private loginService: LoginService
  ) { }

  ngOnInit(): void {

    this.form = this.formBuilder.group({
      UserName: ["", [Validators.required, Validators.minLength(4)]],
      Password: ["", [Validators.required, Validators.minLength(4)]]
    });
  }

  login() {

    this.loginService.login(this.form.value).subscribe(response => {

      console.log(response);
      
      this.router.navigate(["/inicio"]);
    },
      error => {

        console.log(error);
      });
  }
}
