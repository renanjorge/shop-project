import { Component, Inject } from "@angular/core";
import { MAT_SNACK_BAR_DATA, MatSnackBarHorizontalPosition } from "@angular/material/snack-bar";

@Component({
  selector: 'app-success-snackbar',
  templateUrl: './success-snackbar.component.html'
})
export class SuccessSnackBarComponent {

  message!: string;
  horizontalPosition: MatSnackBarHorizontalPosition = 'start';

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: string) {
    this.message = data;
  }
}
