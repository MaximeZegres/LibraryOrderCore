import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-grid',
  templateUrl: './order-grid.component.html',
  styleUrls: ['./order-grid.component.css']
})
export class OrderGridComponent implements OnInit {
  
  order = {
    "orderId": 3,
    "orderNumber": "125127",
    "orderDate": "2019-01-23T20:15:10",
    "isContacted": true,
    "customerFirstName": "Coralie",
    "customerLastName": "Prov",
    "customerEmail": "coralie@test.be",
    "customerPhoneNumber": "020103020",
    "orderItems": [
        {
            "orderItemId": 4,
            "book": {
                "bookId": 2,
                "title": "Learning JavaScript Design Patterns",
                "author": "Addy Osmani",
                "editor": "OReilly Media",
                "isbn": "9781449331818"
            },
            "quantity": 1,
            "isOrdered": true
        }
    ]
}

  private loadComponent: boolean = false;
  loadOrderGridItemComponent() {
    this.loadComponent = true;
  }


  ngOnInit() {
  }

}
