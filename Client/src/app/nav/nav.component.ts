import { Component, inject, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { CommonModule, NgIf } from '@angular/common';
export interface model {
  username :string,
  password : string
}
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  loggedIn !: boolean;

  private account = inject(AccountService)



  public model : any = {}



  login(){
    this.account.login(this.model).subscribe(
    {
      next : Response =>{
        this.loggedIn = true
        console.log(Response)
      }
    }
    

    )
    this.loggedIn = false;
    console.log("this is the model" , this.model)
  }

  logout(){
    this.loggedIn =false
  }
}
