import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from '../components/nav-bar/nav-bar';
import { Description } from '../components/description/description';
import { WelcomeBanner } from '../components/welcome-banner/welcome-banner';
import { InsuranceProfiles } from '../components/insurance-profiles/insurance-profiles';
import { Header } from "../components/header/header";
import { Footer } from "../components/footer/footer";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBar, Description, WelcomeBanner, InsuranceProfiles, Header, Footer],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('insurance');
}
