import { Component, inject, type OnInit } from '@angular/core';
import { MembersService } from '../services/members.service';
import type { Member } from '../Models/Member';
import { MemberDetailComponent } from './member-detail/member-detail.component';
import { MemberCardComponent } from './member-card/member-card.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgIf } from '@angular/common';
import { AccountService } from '../services/account.service';
import { UserParams } from '../Models/UserParams';
import { FormsModule } from '@angular/forms';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

@Component({
  selector: 'app-members',
  standalone: true,
  imports: [MemberCardComponent, PaginationModule , NgIf , FormsModule,ButtonsModule ],
  templateUrl: './members.component.html',
  styleUrl: './members.component.css'
})
export class MembersComponent implements OnInit{

  MemberService = inject(MembersService)
  private accouneservice = inject(AccountService)
  userParams = new UserParams(this.accouneservice.currentuser())
  genderList = [{value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}]

  pagenumber = 1
  pagesize = 5
  

  ngOnInit(): void {
    if(!this.MemberService.paginatedResult()) this.LoadMembers()
  }

  LoadMembers() {
    this.MemberService.getMembers()
     
  }


  resetFilters() {
    this.MemberService.resetUserParams();
    this.LoadMembers();
  }

  pageChanged(event: any) {
    if (this.MemberService.userParams().pageNumber != event.page) {
      this.MemberService.userParams().pageNumber = event.page;
      this.LoadMembers();
    }
  
  }
  

  

}
