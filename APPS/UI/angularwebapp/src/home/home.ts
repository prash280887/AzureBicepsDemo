import { Component, signal } from '@angular/core';
import { Header } from '../header/header';

@Component({
  selector: 'app-home',
  imports: [Header],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {

  username = signal<string | null>(localStorage.getItem('username')) ;
  

}
