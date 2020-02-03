import { CustomerService } from './../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { ClrDatagridComparatorInterface } from '@clr/angular';
import { Customer } from '../models/customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [];

  constructor(
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(data => this.customers = data);
  }

}
