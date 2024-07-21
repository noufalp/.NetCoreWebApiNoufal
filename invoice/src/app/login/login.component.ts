import { Component } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})


export class LoginComponent {
  user: any = {};
  errorMessage: string ="";

  constructor(private authService: AuthService, private router: Router) { }

  login() {
    this.authService.login(this.user).subscribe({
      next: (res) => {
        this.authService.setToken(res.token);
        this.router.navigate(['/product']);
      },
      error: (err) => {
        this.errorMessage = 'Invalid username or password';
      }
    });
  }
}