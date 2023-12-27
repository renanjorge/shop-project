import { NgModule } from "@angular/core";
import { ConfirmationDialogComponent } from "./components/confirmation-dialog/confirmation-dialog.component";
import { MaterialModule } from "./material.module";
import { MatDialogModule } from "@angular/material/dialog";

@NgModule({
  declarations: [
    ConfirmationDialogComponent
  ],
  imports: [
    MatDialogModule,
    MaterialModule
  ]
})
export class SharedModule {}
