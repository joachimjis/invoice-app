import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClrLoadingState } from '@clr/angular';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {

  id: number;
  title: string;

  submitBtnState: ClrLoadingState = ClrLoadingState.DEFAULT;

  form: FormGroup;

  errorMessage: string;
  isSuccess = false;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
    if(this.route.snapshot.params['id'] !== 'new') {
      this.id = this.route.snapshot.params['id'];
      this.title = 'Edit';
    } else {
      this.title = 'Create a customer';
    }

    this.form = this.formBuilder.group({
      id: 0,
      name: ['', Validators.required],
      telephone: [''],
      email: ['', Validators.required],
      address: ['', Validators.required],
      activitySector: ['', Validators.required],
      rcs: ['', Validators.required],
      suburb: ['', Validators.required],
      island: ['', Validators.required],
      comments: ['']
    });
  }

  get canSave() {
    return this.isSuccess === false && this.form.valid;
  }

  save() {
    if (this.canSave) {
      this.submitBtnState = ClrLoadingState.LOADING;
      this.customerService.postCustomer(this.form.value).subscribe(data => {
        this.submitBtnState = ClrLoadingState.DEFAULT;
        this.isSuccess = true;
      },
      error => {
        this.errorMessage = error.error;
        });
    }
  }

  cancel() {
    this.router.navigate(['/customers']);
  }

}
