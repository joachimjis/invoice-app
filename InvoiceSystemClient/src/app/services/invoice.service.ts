import { Invoice } from './../models/invoice';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  userId: number;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
    ) {
      this.userId = this.authenticationService.currentUserValue.id;
    }

    getInvoices(): Observable<any> {
      const params = new HttpParams().set('userId', this.userId.toString());
      return this.http.get(`${environment.apiUrl}/api/invoices`, {params});
    }

    getInvoice(id: number): Observable<Invoice> {
      return this.http.get<Invoice>(`${environment.apiUrl}/api/invoices/` + id);
    }

    postInvoice(value: Invoice): Observable<any> {
      value.userId = this.userId;
      value.dateCreation = new Date(value.dateCreation);
      value.dateEcheance = new Date(value.dateEcheance);
      value.customerId = Number(value.customerId);
      return this.http.post(`${environment.apiUrl}/api/invoices`, value);
    }
}
