import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatIconModule} from '@angular/material/icon';
import { MatDialog,MatDialogRef } from '@angular/material/dialog'; 
import { EntryComponent } from '../entry/entry.component';
@Component({
  selector: 'app-matex',
  imports: [MatSlideToggleModule,MatIconModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './matex.component.html',
  styleUrl: './matex.component.css'
})
export class MatexComponent {
 constructor(public dialog:MatDialog){}
 openDialog(enterAnimationDuration: string, exitAnimationDuration: string): void {
  this.dialog.open(EntryComponent, {
    width: '250px',
    enterAnimationDuration,
    exitAnimationDuration,
  });
}
}
