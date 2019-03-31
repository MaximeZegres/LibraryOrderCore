import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { IOrder, IOrderItems, IBook } from '../shared/order.model';

@Component({
  selector: 'add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  

  orderForm: FormGroup;
  bookForm: FormGroup;
  order: IOrder = {
    orderNumber: '',
    orderDate: '',
    isContacted: false,
    customerFirstName: '',
    customerLastName: '',
    customerEmail: '',
    customerPhoneNumber: ''
  };
  orderItems: IOrderItems[];
  book: IBook = {
    title: '',
    author: '',
    editor: '',
    isbn: ''
  }

  
  constructor(private router: Router, private formBuilder: FormBuilder) {   
  }

  
  

  buildForm() {
    this.orderForm = this.formBuilder.group({
      orderNumber: [this.order.customerFirstName, Validators.required],
      orderDate: [this.order.orderDate, Validators.required],
      customerFirstName: [this.order.customerFirstName, Validators.required],
      customerLastName: [this.order.customerLastName, Validators.required],
      customerEmail: [this.order.customerEmail, Validators.required],
      customerPhoneNumber: [this.order.customerPhoneNumber, Validators.required],
    });
    this.bookForm = this.formBuilder.group({
      title: [this.book.title, Validators.required],
      author: [this.book.author, Validators.required],
      editor: [this.book.editor, Validators.required],
      isbn: [this.book.isbn, Validators.required],
    });
  }

  saveOrder() {

  }

  cancel() {
    this.router.navigate(['/orders'])
  }

  ngOnInit() {
    this.buildForm();
  }




}
