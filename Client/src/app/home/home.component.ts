import { Component, inject, type OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // Import CommonModule
import { HttpClient } from '@angular/common/http';
import { RegisterComponent } from "../register/register.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RegisterComponent],  // Import CommonModule to enable common Angular directives
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
 
  

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  cancelRegisterMode(event:boolean){
  this.registerMode=event;
  }

}
