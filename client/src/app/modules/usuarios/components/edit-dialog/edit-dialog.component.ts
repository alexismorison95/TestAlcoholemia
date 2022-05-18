import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-edit-dialog',
  templateUrl: './edit-dialog.component.html',
  styleUrls: ['./edit-dialog.component.css']
})
export class EditDialogComponent implements OnInit {

  //formulario
  form!: FormGroup;

  constructor(
    public _dialogRef: MatDialogRef<EditDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {

    this.form = this._formBuilder.group({
      nombreusuario: [this.data.usuario.nombreusuario, [Validators.required, Validators.minLength(4)]],
      activo: [this.data.usuario.activo, [Validators.required]],
      nombrereal: [this.data.usuario.nombrereal, [Validators.required, Validators.minLength(4)]],
      contrasenia: [this.data.usuario.contrasenia, [Validators.required, Validators.minLength(4)]],
      tipousuarioid: [this.data.usuario.tipousuarioid, [Validators.required]]
    });
  }

  cancel(): void {
    this._dialogRef.close();
  }
}
