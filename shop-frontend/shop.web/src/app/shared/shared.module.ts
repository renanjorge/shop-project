import { NgModule } from "@angular/core";
import { MaterialModule } from "./material.module";
import { ConfirmationDialogComponent } from "./components/dialog/confirmation-dialog/confirmation-dialog.component";
import { SuccessSnackBarComponent } from "./components/snackbar/success-snackbar/success-snackbar.component";
import { MessageService } from "./services/message.service";

@NgModule({
  declarations: [
    ConfirmationDialogComponent,
    SuccessSnackBarComponent
  ],
  imports: [
    MaterialModule
  ]
})
export class SharedModule {}
