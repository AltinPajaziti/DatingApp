import { Component, inject, Input, input, type OnInit } from '@angular/core';
import type { Member } from '../../Models/Member';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MembersService } from '../../services/members.service';

@Component({
  selector: 'app-member-detail',
  standalone: true,
  imports: [],
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css'
})
export class MemberDetailComponent implements OnInit{


  private memberservice = inject(MembersService)
  private route = inject(ActivatedRoute)

  member! : Member



  ngOnInit(): void {
    this.loadmember()
  }


  loadmember(){
    const username = this.route.snapshot.paramMap.get('username')
    if(!username) return

    this.memberservice.getMember(username).subscribe({
      next : member =>{
        this.member = member
      }
    })
       

  }


}
