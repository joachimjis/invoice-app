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
  canDelete: boolean;

  constructor(
    private customerService: CustomerService,
    private router: Router,
  ) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.customerService.getCustomers().subscribe(data => this.customers = data);
  }

  create() {
    this.isEditing = true;
    this.router.navigate(['customer/detail/' + 'new']);
  }

  edit(id: number) {
    this.isEditing = true;
    this.router.navigate(['customer/detail/' + id]);
  }

  delete(id: number) {
    this.customerService.deleteCustomer(id).subscribe(data => {
      this.load();
    },
    error => {
      alert('An error has occured with the following message : ' + error.error);
    });
  }
}
