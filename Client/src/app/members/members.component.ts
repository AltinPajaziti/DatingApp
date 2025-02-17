import { Component, inject, type OnInit } from '@angular/core';
import { MembersService } from '../services/members.service';
import type { Member } from '../Models/Member';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberCardComponent } from './member-card/member-card.component';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [MemberCardComponent],
  templateUrl: './members.component.html',
  styleUrl: './members.component.css'
})
export class MembersComponent implements OnInit{

  MemberService = inject(MembersService)
  

  ngOnInit(): void {
    if(this.MemberService.members().length === 0) this.LoadMembers()
  }

  LoadMembers() {
    this.MemberService.getMembers()
     
  }
  

  

}
