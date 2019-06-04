import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { FormlyFormOptions, FormlyFieldConfig } from '@ngx-formly/core';

@Component({
  selector: 'add-order-customer',
  templateUrl: './add-order-customer.component.html',
  styleUrls: ['./add-order-customer.component.css']
})
export class AddOrderCustomerComponent {
  form = new FormGroup({});
  model = { 
    orderNumber: '',
    orderDate: '',
    isContacted: false,
    customerFirstName: '',
    customerLastName: '',
    customerEmail: '',
    customerPhoneNumber: ''
  };

  fields: FormlyFieldConfig[] = [
  {
    key: 'orderNumber',
    type: 'input',
    templateOptions: {
      label: 'Numéro de commande',
      required: true,
    }
  },
  {
    key: 'orderDate',
    type: 'datepicker',
    templateOptions: {
      required: true,
      type: 'text',
      label: 'Date de commande'
    }
  },
  {
    key: 'customerFirstName',
    type: 'input',
    templateOptions: {
      label: 'Prénom',
      required: true,
    }
  }
];

  submit(model) {
    console.log(model);
  }


}
