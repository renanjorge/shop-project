import localePt from "@angular/common/locales/pt";
import { LOCALE_ID, NgModule } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { MatDialogModule } from '@angular/material/dialog';
import { MatOptionModule } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { MatRadioModule } from "@angular/material/radio";
import { MatSelectModule } from "@angular/material/select";
import { MatTableModule } from "@angular/material/table";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { registerLocaleData } from "@angular/common";

registerLocaleData(localePt);

@NgModule({
  exports: [
    BrowserAnimationsModule,
    MatCardModule,
    MatDialogModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatTooltipModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatRadioModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'pt-BR' }]
})
export class MaterialModule { }
