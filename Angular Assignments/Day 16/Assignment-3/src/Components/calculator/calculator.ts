import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CalculatorService } from '../../Services/calculator/calculator';

@Component({
  selector: 'app-calculator',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './calculator.html',
  styleUrl: './calculator.css',
})
export class Calculator {

  private calcService = inject(CalculatorService);

  num1 = 0;
  num2 = 0;
  operation = '+';
  result = 0;

  calculate() {
    switch (this.operation) {
      case '+':
        this.result = this.calcService.add(this.num1, this.num2);
        break;
      case '-':
        this.result = this.calcService.sub(this.num1, this.num2);
        break;
      case '*':
        this.result = this.calcService.mul(this.num1, this.num2);
        break;
      case '/':
        this.result = this.calcService.div(this.num1, this.num2);
        break;
    }
  }
}
