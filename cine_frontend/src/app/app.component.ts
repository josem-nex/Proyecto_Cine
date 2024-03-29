import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from "./login/login.component";
import { HomeComponent } from "./home/home.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, LoginComponent, HomeComponent]
})
export class AppComponent {
  title = 'CINE+';
  logo = 'pendiente';
  footer = 'Proyecto Final de Ingeniería de Software'
}
