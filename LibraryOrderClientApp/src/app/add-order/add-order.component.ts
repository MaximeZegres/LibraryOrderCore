import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'add-order',
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  constructor(private router: Router) { }

  orderForm: FormGroup




  
  cancel() {
    this.router.navigate(['/orders'])
  }


  ngOnInit() {
    let orderNumber = new FormControl()
    let datePicker = new FormControl()
    let customerFirstName = new FormControl()
    let customerLastName = new FormControl()
    let customerEmail = new FormControl()
    let customerPhoneNumber = new FormControl()
    let book = new FormControl()
    this.orderForm = new FormGroup({
      orderNumber: orderNumber,
      datePicker: datePicker,
      customerFirstName: customerFirstName,
      customerLastName: customerLastName,
      customerEmail: customerEmail,
      customerPhoneNumber: customerPhoneNumber,
      book: book
    })
  }

}
