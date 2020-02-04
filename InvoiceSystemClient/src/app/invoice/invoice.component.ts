import { InvoiceLine, Invoice } from './../models/invoice';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InvoiceService } from '../services/invoice.service';

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
    private invoiceService: InvoiceService
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

  view(id: number) {

  }
}
