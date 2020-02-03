import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams, HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  userId: string;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
    ) {
      this.userId = this.authenticationService.currentUserValue.id.toString();
    }

    getCustomers(): Observable<any> {
      const params = new HttpParams().set('userId', this.userId);
      return this.http.get(`${environment.apiUrl}/api/customers`, {params});
    }
}
