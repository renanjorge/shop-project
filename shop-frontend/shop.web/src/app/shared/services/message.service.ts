import { Injectable } from "@angular/core";
import { MatSnackBar, MatSnackBarVerticalPosition } from "@angular/material/snack-bar";
import { SuccessSnackBarComponent } from "../components/snackbar/success-snackbar/success-snackbar.component";

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
      data
    });
  }
}
