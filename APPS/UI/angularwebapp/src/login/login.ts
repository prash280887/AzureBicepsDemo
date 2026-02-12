import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.html',
  styleUrl: './login.scss',
})
export class Login {

  username: string = '';
  password: string = '';
  loginStatus: string = '';

  router = inject(Router);

  login() {
    if (this.username === 'admin' && this.password === 'admin') {
      
      let isloggedIn: boolean = true;
      localStorage.setItem('isLoggedIn', 'true');
      localStorage.setItem('username', this.username);
      this.router.navigate(['/home' ,{loggedIn : isloggedIn}]);

      this.loginStatus = 'Login Successful';
    } else {
      this.loginStatus = 'Login Failed';
    }
  }
}
