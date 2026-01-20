import { Component } from '@angular/core';

@Component({
  selector: 'app-insurance-profiles',
  imports: [],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
  profiles = [
    { name: 'Auto Insurance', img: 'car.jpg' },
    { name: 'Auto + Home Insurance', img: 'house.png' },
    { name: 'Home Insurance', img: 'home.png' },
    { name: 'Business Insurance', img: 'business.png' }
  ];

}
