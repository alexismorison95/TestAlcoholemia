import { Component, Inject,OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { GetUsuarioDTO } from '../../interfaces/Usuarios';

@Component({
  selector: 'app-add-dialog',
  templateUrl: './add-dialog.component.html',
  styleUrls: ['./add-dialog.component.css']
})
export class AddDialogComponent implements OnInit {

  //formulario
  form!: FormGroup;

  constructor(
    public _dialogRef: MatDialogRef<AddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: GetUsuarioDTO,
    private _formBuilder: FormBuilder
  ) { 

  }

  ngOnInit(): void {

    this.form = this._formBuilder.group({
      nombreusuario: ['', [Validators.required, Validators.minLength(4)]],
      nombrereal: ['', [Validators.required, Validators.minLength(4)]],
      contrasenia: ['', [Validators.required, Validators.minLength(4)]],
      tipousuario: ['', [Validators.required, Validators.minLength(4)]]
    });
  }

  cancel() {
    this._dialogRef.close();
  }
}
