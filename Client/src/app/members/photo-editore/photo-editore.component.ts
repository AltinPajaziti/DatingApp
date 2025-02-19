import { Component, inject, input, Input, output } from '@angular/core';
import { Member } from '../../Models/Member';
import { environment } from '../../../environments/environment.development';
import { Photo } from '../../Models/Photo';
import { AccountService } from '../../services/account.service';
import { MembersService } from '../../services/members.service';
import { NgIf, NgFor, NgStyle, NgClass, DecimalPipe } from '@angular/common';
import { FileUploader, FileUploadModule } from 'ng2-file-upload';

@Component({
  selector: 'app-photo-editore',
  standalone: true,
  imports: [NgIf, NgFor, NgStyle, NgClass, FileUploadModule, DecimalPipe],
  templateUrl: './photo-editore.component.html',
  styleUrl: './photo-editore.component.css'
})
export class PhotoEditoreComponent {

  member = input.required<Member>();
  private accountService = inject(AccountService);
  private memberService = inject(MembersService);
  uploader?: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  memberChange = output<Member>();

  ngOnInit(): void {
    this.initializeUploader();
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  deletePhoto(photo: Photo) {
    this.memberService.deletePhoto(photo).subscribe({
      next: _ => {
        const updatedMember = {...this.member()};
        updatedMember.photos = updatedMember.photos.filter(x => x.id !== photo.id);
        this.memberChange.emit(updatedMember);
      }
    })
  }

  setMainPhoto(photo: Photo) {
    this.memberService.setMainPhoto(photo).subscribe({
      next: _ => {
        const user = this.accountService.currentuser();
        if (user) {
          user.photoUrl = photo.url;
          this.accountService.setCurrentUser(user)
        }
        const updatedMember = {...this.member()}
        updatedMember.photoUrl = photo.url;
        updatedMember.photos.forEach(p => {
          if (p.isMain) p.isMain = false;
          if (p.id === photo.id) p.isMain = true;
        });
        this.memberChange.emit(updatedMember)
      }
    })
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'users/add-photo',
      authToken: 'Bearer ' + this.accountService.currentuser()?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false
    }

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      const photo = JSON.parse(response);
      const updatedMember = {...this.member()}
      updatedMember.photos.push(photo);
      this.memberChange.emit(updatedMember);
    }
  }

}
