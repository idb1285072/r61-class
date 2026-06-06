import { Component, inject } from '@angular/core';
import {
  MatDialog,
  
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
@Component({
  selector: 'app-entry',
  imports: [MatDialogActions,MatDialogContent,MatButtonModule,  MatDialogClose, MatDialogTitle],
  templateUrl: './entry.component.html',
  styleUrl: './entry.component.css'
})
export class EntryComponent {
  readonly dialogRef = inject(MatDialogRef<EntryComponent>);
}
