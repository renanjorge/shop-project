import { Injectable } from "@angular/core";
import { MatSnackBar, MatSnackBarVerticalPosition } from "@angular/material/snack-bar";
import { SuccessSnackBarComponent } from "../components/snackbar/success-snackbar/success-snackbar.component";
import { ErrorSnackBarComponent } from "../components/snackbar/error-snackbar/error-snackbar.component";

@Injectable({ providedIn: 'root' })
export class MessageService {

  private DURATION: number = 2000;
  private VERTICAL_POSITION: MatSnackBarVerticalPosition = 'top';

  constructor(private snackBar: MatSnackBar) { }

  openDeleteSuccess(): void {
    this.openSuccess("Excluído com sucesso!");
  }

  openAddSuccess(): void {
    this.openSuccess("Cadastrado com sucesso!");
  }

  openEditSuccess(): void {
    this.openSuccess("Atualizado com sucesso!");
  }

  openSuccess(data: string): void {
    this.snackBar.openFromComponent(SuccessSnackBarComponent, {
      verticalPosition: this.VERTICAL_POSITION,
      duration: this.DURATION,
      panelClass: ['success-snackbar'],
      data
    });
  }

  openError(data: string): void {
    this.snackBar.openFromComponent(ErrorSnackBarComponent, {
      verticalPosition: this.VERTICAL_POSITION,
      panelClass: ['error-snackbar'],
      data
    });
  }
}
