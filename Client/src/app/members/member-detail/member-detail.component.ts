import { Component, Input, input } from '@angular/core';
import type { Member } from '../../Models/Member';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-member-detail',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css'
})
export class MemberDetailComponent {
}
