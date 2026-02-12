import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {

  username = signal<string | null>(localStorage.getItem('username')) ;

router = inject(Router);

signout()
{
  localStorage.removeItem('isLoggedIn');
  localStorage.removeItem('username');
  this.router.navigate(['/login']);
}

}
