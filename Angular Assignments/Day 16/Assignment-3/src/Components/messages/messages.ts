import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MessageService } from '../../Services/Message/messageservice';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [FormsModule, CommonModule],  
  templateUrl: './messages.html',
  styleUrl: './messages.css'
})
export class Messages {

  private msgService = inject(MessageService);

  message = '';
  messages = this.msgService.getData();

  addMessage() {
    if (this.message.trim() !== '') {
      this.msgService.addData(this.message);
      this.message = '';
    }
  }
}
