export interface Invoice {
    invoiceId: number;
    userId: number;
    invoiceNumber: number;
    dateCreation: Date;
    dateEcheance: Date;
    invoiceStatus: number;
    object: string;
    customerId: number;
    invoiceLines: InvoiceLine[];
}

export interface InvoiceLine {
    invoiceLineId: number;
    invoiceId: number;
    label: string;
    quantity: number;
    montantHT: number;
    montantTVA: number;
    montantTTC: number;
}