import { Component, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";

import { Dialog } from "../../../interfaces/dialog";

@Component({
  selector: 'app-confirmation-dialog',
  templateUrl: './confirmation-dialog.component.html'
})
export class ConfirmationDialogComponent {

  cancelText!: string;
  confirmText!: string;
  content!: string;
  title!: string;

  constructor(
    public dialogRef: MatDialogRef<ConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Dialog
  ) {
    this.cancelText = data.cancelText ? data.cancelText : 'Cancelar';
    this.confirmText = data.confirmText ? data.confirmText : 'Confirmar';
    this.content = data.content;
    this.title = data.title;
  }

  onConfirm(result: boolean): void {
    this.dialogRef.close(result);
  }
}
