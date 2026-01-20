
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  private data: string[] = [];

  getData(): string[] {
    return this.data;
  }

  addData(msg: string) {
    this.data.push(msg);
  }
}
