import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams, HttpClient } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  userId: number;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
    ) {
      this.userId = this.authenticationService.currentUserValue.id;
    }

    getCustomers(): Observable<any> {
      const params = new HttpParams().set('userId', this.userId.toString());
      return this.http.get(`${environment.apiUrl}/api/customers`, {params});
    }

    getCustomer(id: number): Observable<any> {
      return this.http.get(`${environment.apiUrl}/api/customers/` + id);
    }

    postCustomer(value: Customer): Observable<any> {
      value.userId = this.userId;
      return this.http.post(`${environment.apiUrl}/api/customers`, value);
    }

    putCustomer(value: Customer): Observable<any> {
      return this.http.put(`${environment.apiUrl}/api/customers/` + value.id, value);
    }
}
