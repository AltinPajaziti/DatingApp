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


  account = inject(AccountService)



  public model : any = {}



  login(){
    this.account.login(this.model).subscribe(
    {
      next : Response =>{
        console.log(Response)
      }
    }
    

    )
    console.log("this is the model" , this.model)
  }

  logout(){
    this.account.logout()
  }
}
