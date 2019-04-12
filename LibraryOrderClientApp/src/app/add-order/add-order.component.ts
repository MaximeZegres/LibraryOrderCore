import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';

@Component({
  selector: 'add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  orderForm: FormGroup

  constructor(private router: Router, private fb: FormBuilder) {   
  }

  get orderItems(): FormArray {
    return this.orderForm.get('orderItems') as FormArray;
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
      orderItems: this.fb.array([ this.buildBooks() ])
    });
  }

    addBooks() : void {
        this.orderItems.push(this.buildBooks());
    }


    buildBooks() {
      return this.fb.group({
        quantity: ['', [Validators.required]],
        isOrdered: [false, [Validators.required]],
        book: this.fb.group({
          title: ['', [Validators.required]],
          author: ['', [Validators.required]],
          editor: ['', [Validators.required]],
          isbn: ['', [Validators.required]]
        })
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
