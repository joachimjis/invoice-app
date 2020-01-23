import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'InvoiceSystemClient';

  constructor(private httpClient: HttpClient) {

  }

  test() {
    alert('hey');
    this.httpClient.get('https://localhost:5001/weatherforecast').subscribe((res)=>{
      console.log(res);
      alert(res);
  });
  }
}
