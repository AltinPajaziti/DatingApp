import { Component, inject, input, output, ViewChild } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { TimeagoModule } from 'ngx-timeago';
import { Message } from '../../Models/Message';
import { MessageService } from '../../services/message.service';

@Component({
  selector: 'app-member-messages',
  standalone: true,
  imports: [TimeagoModule, FormsModule],
  templateUrl: './member-messages.component.html',
  styleUrl: './member-messages.component.css'
})
export class MemberMessagesComponent {
  @ViewChild('messageForm') messageForm?: NgForm;
  username = input.required<string>();
  messages = input.required<Message[]>();
  messageContent = '';
  updateMessages = output<Message>();


  messageService = inject(MessageService);
  
  
  sendMessage() {
    this.messageService.sendMessage(this.username(), this.messageContent).subscribe(() => {
      this.messageForm?.reset();
    })
  }
}
