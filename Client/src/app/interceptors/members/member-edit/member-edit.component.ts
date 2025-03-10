import { Component, HostListener, inject, ViewChild, viewChild, type OnInit, type TemplateRef } from '@angular/core';
import type { Member } from '../../../Models/Member';
import { AccountService } from '../../../services/account.service';
import { MembersService } from '../../../services/members.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, type NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PhotoEditoreComponent } from "../../../members/photo-editore/photo-editore.component";
import { DatePipe } from '@angular/common';
import { TimeagoModule } from 'ngx-timeago';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule, FormsModule, PhotoEditoreComponent , DatePipe , TimeagoModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css'
})
export class MemberEditComponent implements OnInit{

member ?: Member;
private accountService = inject(AccountService) 
private memberservice = inject(MembersService)
private toastr = inject(ToastrService)
@ViewChild('editform') editform! : NgForm;
@HostListener('window:beforeunload', ['$event'])
notify($event: any): void {
  if (this.editform?.dirty) {
    $event.returnValue = true ;
  }
}

ngOnInit(): void {
  this.loadusers()
}


// updateMember(){
//   this.toastr.success('Profile updated successfully');
//   this.editform?.reset(this.member);



  
// }

updateMember() {
  this.memberservice.updateMember(this.editform?.value).subscribe({
    next: _ => {
      this.toastr.success('Profile updated successfully');
      this.editform?.reset(this.member);
    }
  })
}


loadusers(){
  const user = this.accountService.currentuser();
  if(!user){
    return
  }

  this.memberservice.getMember(user.username).subscribe({
    next : respounse =>{
      this.member = respounse
    }
  })
}


onMemberChange(event: Member) {
  this.member = event;
}

}
