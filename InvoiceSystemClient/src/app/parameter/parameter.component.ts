import { ParameterService } from './../services/parameter.service';
import { Component, OnInit } from '@angular/core';
import { ClrLoadingState } from '@clr/angular';
import { HttpClient } from '@angular/common/http';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-parameter',
  templateUrl: './parameter.component.html',
  styleUrls: ['./parameter.component.scss']
})
export class ParameterComponent implements OnInit {

  submitBtnState: ClrLoadingState = ClrLoadingState.DEFAULT;

  form: FormGroup;

  constructor(
    private http: HttpClient,
    private formBuilder: FormBuilder,
    private parameterService: ParameterService
  ) { }

  ngOnInit() {
    this.form = this.formBuilder.group({
      companyName: ['', Validators.required],
      address: ['', Validators.required],
      postalCode: ['', Validators.required],
      postalPlace: ['', Validators.required],
      telephone: ['', Validators.required],
      email: ['', Validators.required],
      rib: ['', Validators.required],
      parameterId:['', Validators.required]
    });

    this.parameterService.getParameter().subscribe(param => {
      this.form.patchValue({
        companyName: param.companyName,
        address: param.address,
        postalCode: param.postalCode,
        postalPlace: param.postalPlace,
        telephone: param.telephone,
        email: param.email,
        rib: param.rib,
        parameterId: param.parameterId
      });
    });
  }

  save() {
    this.submitBtnState = ClrLoadingState.LOADING;

    this.parameterService.saveParameter(this.form.value)
      .subscribe(data => {
        console.log(data);
      });

    //Submit Logic
    this.submitBtnState = ClrLoadingState.DEFAULT;
  }

}
;