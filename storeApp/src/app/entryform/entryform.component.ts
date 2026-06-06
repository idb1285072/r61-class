import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-entryform',
 
   imports: [CommonModule, FormsModule,ReactiveFormsModule],
  templateUrl: './entryform.component.html',
  styleUrl: './entryform.component.css'
})
export class EntryformComponent implements OnInit {

  employeeForm!: FormGroup
  countries = ['United States', 'India', 'United Kingdom', 'Australia'];
  ngOnInit(): void {
    this.employeeForm= new FormGroup({
      name: new FormControl('',[Validators.required,Validators.minLength(3)]),
      email:new FormControl('',[Validators.required]),
      age:new FormControl('',[Validators.min(18)]),
      phoneNumber:new FormControl(),
      address:new FormControl(),
      country:new FormControl(),
      dateOfBirth:new FormControl(),
      password:new FormControl('',[Validators.required]),
      confirmPassword:new FormControl('',[Validators.required]),
      
    })

     
  }

OnSubmit(){
  if (this.employeeForm.valid) {
    console.log('Form Submitted!', this.employeeForm.value);
} else {
    console.log('Form not valid');
}
}

}
