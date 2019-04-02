import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { IOrder, IOrderItems, IBook } from '../shared/order.model';

@Component({
  selector: 'add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  

  orderForm: FormGroup;
  order: IOrder = {
    orderNumber: '',
    orderDate: '',
    isContacted: false,
    customerFirstName: '',
    customerLastName: '',
    customerEmail: '',
    customerPhoneNumber: ''
  };
  orderItems: IOrderItems = {
    quantity: 0,
    isOrdered: false
  };
  book: IBook = {
    title: '',
    author: '',
    editor: '',
    isbn: ''
  }

  get orderBooks(): FormArray {
    return <FormArray>this.orderForm.get('orderBooks');
  }

  
  constructor(private router: Router, private formBuilder: FormBuilder) {   
  }

  ngOnInit() {
    this.orderForm = this.formBuilder.group({
      orderNumber: [this.order.customerFirstName, Validators.required],
      orderDate: [this.order.orderDate, Validators.required],
      customerFirstName: [this.order.customerFirstName, Validators.required],
      customerLastName: [this.order.customerLastName, Validators.required],
      customerEmail: [this.order.customerEmail, Validators.required],
      customerPhoneNumber: [this.order.customerPhoneNumber, Validators.required],
      orderBooks: this.formBuilder.array([ this.buildBooks() ])
    });
  }

  buildBooks(): FormGroup {
    return this.formBuilder.group({
      title: '',
      author: '',
      editor: '',
      isbn: '',
      quantity: ''
    });
  }



  addBook(): void {
    this.orderBooks.push(this.buildBooks());
  }
  

    saveOrder() {
      console.log(this.orderForm);
      console.log('Saved: ' + JSON.stringify(this.orderForm.value));

  }

  cancel() {
    this.router.navigate(['/orders'])
  }







}
