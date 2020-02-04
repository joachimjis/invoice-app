import { CustomerDetailComponent } from './customer/customer-detail/customer-detail.component';
import { CustomerComponent } from './customer/customer.component';
import { ParameterComponent } from './parameter/parameter.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/authguard.service';


const routes: Routes = [
  { path: '', component: InvoiceComponent, canActivate: [AuthGuard] },
  { path: 'invoice', component: InvoiceComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'parameters', component: ParameterComponent, canActivate: [AuthGuard] },
  { path: 'customers', component: CustomerComponent, canActivate: [AuthGuard] },
  { path: 'customer/detail/:id', component: CustomerDetailComponent, canActivate: [AuthGuard] },

  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
