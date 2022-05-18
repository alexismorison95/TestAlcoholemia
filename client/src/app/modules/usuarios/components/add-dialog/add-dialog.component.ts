import { Component, Inject,OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { GetUsuarioDTO } from '../../interfaces/Usuarios';

@Component({
  selector: 'app-add-dialog',
  templateUrl: './add-dialog.component.html',
  styleUrls: ['./add-dialog.component.css']
})
export class AddDialogComponent implements OnInit {

  constructor(
    public _dialogRef: MatDialogRef<AddDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public _data: GetUsuarioDTO
  ) { 

  }

  ngOnInit(): void {
  }

  cancel() {
    this._dialogRef.close();
  }
}
