import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'Client';

  http = inject(HttpClient)
  ngOnInit(): void {
    this.http.get<any>('https://localhost:7198/api/Users/GetAllUsers').subscribe(
      (Respounse)=>{
        console.log("this is the respounse" , Respounse)
      }
    )
  }
 

  
}
