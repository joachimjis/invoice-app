import { AuthenticationService } from './../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {



  constructor(
    private authService: AuthenticationService,
    private router: Router,
    ) { }

  ngOnInit() {
  }

  logOut() {
    this.authService.logout();
    this.router.navigate(['login']);
  }

}
