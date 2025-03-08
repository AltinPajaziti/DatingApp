import { Component, inject, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../services/account.service';
import { CommonModule, NgIf } from '@angular/common';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { HasRolesDirective } from '../_directives/has-roles.directive';
export interface model {
  username :string,
  password : string
}
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule , RouterLink ,RouterLinkActive , HasRolesDirective],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {


  account = inject(AccountService)
  private router = inject(Router)



  public model : any = {}



  login(){
    this.account.login(this.model).subscribe(
    {
      next : _ =>{
        this.router.navigateByUrl('/members')
      }
    }
    

    )
    console.log("this is the model" , this.model)
  }

  logout(){
    this.account.logout()
    this.router.navigateByUrl('')
  }
}
