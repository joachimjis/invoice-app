import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ParameterService {

  baseUrl: string;

  constructor(
    private http: HttpClient
    ) {
        // this.baseUrl = helper.getBaseUrl();
    }

    getParameter(): Observable<any> {
      return this.http.get(`${environment.apiUrl}/api/parameters`);
    }
}
