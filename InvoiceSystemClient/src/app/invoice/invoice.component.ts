import { InvoiceLine, Invoice } from './../models/invoice';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InvoiceService } from '../services/invoice.service';
import { Router } from '@angular/router';

enum InvoiceStatus {
  NonPaye,
  Paye,
  RetardPaiement,
  Impaye
}

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.scss']
})
export class InvoiceComponent implements OnInit {

  invoices: Invoice[];

  enumInvoiceStatus = {
    NonPaye: {id: InvoiceStatus.NonPaye, label: 'Non payé' },
    Paye: {id: InvoiceStatus.Paye, label: 'Payé' },
    RetardPaiement: {id: InvoiceStatus.RetardPaiement, label: 'Retard de paiement' },
    Impaye: { id: InvoiceStatus.Impaye, label: 'Impayé'}
  };

  constructor(
    private http: HttpClient,
    private invoiceService: InvoiceService,
    private router: Router,
    ) { }

  ngOnInit() {
    this.load();
  }

  load() {
    this.invoiceService.getInvoices().subscribe(data => this.invoices = data);
  }

  getInvoiceStatus(invoiceStatus: number) {
    switch(invoiceStatus) {
      case InvoiceStatus.NonPaye:
        return this.enumInvoiceStatus.NonPaye.label;
      case InvoiceStatus.Paye:
        return this.enumInvoiceStatus.Paye.label;
      case InvoiceStatus.RetardPaiement:
        return this.enumInvoiceStatus.RetardPaiement.label;
      case InvoiceStatus.Impaye:
        return this.enumInvoiceStatus.Impaye.label;
      default:
        return '';
    }
  }

  create() {
    this.router.navigate(['invoice/create/']);
  }

  view(id: number) {
    this.router.navigate(['invoice/detail/' + id]);
  }
}
