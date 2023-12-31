import { NgModule } from "@angular/core";
import { MaterialModule } from "./material.module";
import { ConfirmationDialogComponent } from "./components/dialog/confirmation-dialog/confirmation-dialog.component";
import { SuccessSnackBarComponent } from "./components/snackbar/success-snackbar/success-snackbar.component";
import { ErrorSnackBarComponent } from "./components/snackbar/error-snackbar/error-snackbar.component";

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    SuccessSnackBarComponent,
    ErrorSnackBarComponent
  ],
  imports: [
    MaterialModule
  ]
})
export class SharedModule {}
