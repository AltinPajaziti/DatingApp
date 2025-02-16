import { Component, inject, Input, input, type OnInit } from '@angular/core';
import type { Member } from '../../Models/Member';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MembersService } from '../../services/members.service';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { GalleryItem, GalleryModule, ImageItem } from 'ng-gallery';


@Component({
  selector: 'app-member-detail',
  standalone: true,
  imports: [TabsModule , GalleryModule],
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css'
})
export class MemberDetailComponent implements OnInit{

  images: GalleryItem[] = [];

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
        member.photos.map(p => {
          this.images.push(new ImageItem({src: p.url, thumb: p.url}))
        })
      }
    })
       

  }


}
