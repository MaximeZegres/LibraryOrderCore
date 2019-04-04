import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'add-order',
  templateUrl: './add-order-customer.component.html',
  styleUrls: ['./add-order-customer.component.css']
})
export class AddOrderCustomerComponent implements OnInit {
  orderForm: FormGroup
  constructor(private router: Router, private fb: FormBuilder) {   
  }

  ngOnInit() {
    this.orderForm = this.fb.group({
      orderNumber: ['', [Validators.required]],
      orderDate: ['', [Validators.required]],
      isContacted: [false, [Validators.required]],
      customerFirstName: ['', [Validators.required]],
      customerLastName : ['', [Validators.required]],
      customerEmail: ['', [Validators.required]],
      customerPhoneNumber: ['', [Validators.required]],
      orderItems: []
    });




  }
  

  saveCustomer() {
    console.log(this.orderForm);
    console.log('Saved: ' + JSON.stringify(this.orderForm.value));
  }

  cancel() {
    this.router.navigate(['/orders'])
  }


}
