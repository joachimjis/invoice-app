import { CustomerService } from './../services/customer.service';
import { Component, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { ClrDatagridComparatorInterface } from '@clr/angular';
import { Customer } from '../models/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers: Customer[] = [];
  isEditing: boolean;

  constructor(
    private customerService: CustomerService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(data => this.customers = data);
  }

  create() {
    this.isEditing = true;
    this.router.navigate(['customer/detail/' + 'new']);
  }

}
