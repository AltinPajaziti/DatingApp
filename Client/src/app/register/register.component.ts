import { Component, inject, Input, input, output } from '@angular/core';
import { AccountService } from '../services/account.service';
import { FormsModule } from '@angular/forms';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  cancelRegister = output<boolean>();
  @Input() usersfromComponent!: any[];
  private toastr  = inject(ToastrService);

  model: any = {}
  register() {
    this.accountService.register(this.model).subscribe({
      next: response =>{
        this.toastr.success('Success', 'Toastr fun!');  
              console.log(response);
        this.cancel();
      },
      error: error =>console.log(error)
    })
  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
