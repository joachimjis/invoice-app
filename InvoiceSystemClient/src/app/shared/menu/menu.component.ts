import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  isLoggedIn$: Observable<boolean>;

  constructor(
    private authService: AuthenticationService,
    private router: Router,
    ) { }

  ngOnInit() { 
    this.isLoggedIn$ = this.authService.isLoggedIn;
  }

  logOut() {
    this.authService.logout();
    this.router.navigate(['login']);
  }
}
