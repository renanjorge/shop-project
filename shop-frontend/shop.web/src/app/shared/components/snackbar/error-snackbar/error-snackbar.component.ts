import { Component, Inject } from "@angular/core";
import { MAT_SNACK_BAR_DATA, MatSnackBarHorizontalPosition, MatSnackBarRef } from "@angular/material/snack-bar";

@Component({
  selector: 'app-error-snackbar',
  templateUrl: './error-snackbar.component.html'
})
export class ErrorSnackBarComponent {

  message!: string;
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';

  constructor(
    public snackBarRef: MatSnackBarRef<ErrorSnackBarComponent>,
    @Inject(MAT_SNACK_BAR_DATA) public data: string
  ) {
    this.message = data;
  }
}
