import { AuthenticationService } from './authentication.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {

  userId: string;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
    ) {
      this.userId = this.authenticationService.currentUserValue.id.toString();
    }

    getParameter(): Observable<any> {
      const params = new HttpParams().set('userId', this.userId);
      return this.http.get(`${environment.apiUrl}/api/parameters`, {params});
    }
}
