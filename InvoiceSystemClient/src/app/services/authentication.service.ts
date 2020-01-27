import { HelperService } from './helper.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { BehaviorSubject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    public getToken(): string {
        return localStorage.getItem('token');
      }

    private loggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    get isLoggedIn() {
        return this.loggedIn.asObservable();
    }

    baseUrl: string;

    constructor(
        private http: HttpClient,
        private helper: HelperService
        ) {
            this.baseUrl = helper.getBaseUrl();
        }

    login(username: string, password: string) {
        return this.http.post<any>(this.baseUrl + `/api/Auth/login`, { username, password })
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    this.loggedIn.next(true);
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('token', JSON.stringify(user));
                }

                return user;
            }));
    }

    logout() {
        this.loggedIn.next(false);

        // remove user from local storage to log user out
        localStorage.removeItem('token');
    }
}
