import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ErrorSnackBarComponent } from 'src/app/components/error-snack-bar/error-snack-bar.component';
import { OkSnackBarComponent } from 'src/app/components/ok-snack-bar/ok-snack-bar.component';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(private snackBar: MatSnackBar) { }

  showOkMessage(message: string) {

    this.snackBar.openFromComponent(OkSnackBarComponent, {
      data: message,
      duration: 5 * 1000,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: ['ok-snack-bar']
    });
  }

  showErrorMessage(message: string) {

    this.snackBar.openFromComponent(ErrorSnackBarComponent, {
      data: message,
      duration: 5 * 1000,
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      panelClass: ['error-snack-bar']
    });
  }
}
