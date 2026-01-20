import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Calculator } from "../Components/calculator/calculator";
import { Messages } from "../Components/messages/messages";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Calculator, Messages],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-3');
}
