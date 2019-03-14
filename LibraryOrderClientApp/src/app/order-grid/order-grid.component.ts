import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-order-grid',
  templateUrl: './order-grid.component.html',
  styleUrls: ['./order-grid.component.css']
})
export class OrderGridComponent implements OnInit {
  
  order = {
    "id": 1,
    "orderNumber": "125125",
    "orderDate": "2019-01-21T22:11:36",
    "isContacted": false,
    "items": [
        {
            "id": 6,
            "book": {
                "id": 4,
                "title": "Demain",
                "author": "Guillaume Musso",
                "editor": "Pocket",
                "isbn": "9782266246880"
            },
            "quantity": 1,
            "isOrdered": false
        }
    ],
    "customer": {
        "id": 1,
        "firstName": "Maxime",
        "lastName": "Zeg",
        "email": "maxime@test.be",
        "phoneNumber": "020130506"
    }
  }

  private loadComponent: boolean = false;
  loadOrderGridItemComponent() {
    this.loadComponent = true;
  }


  ngOnInit() {
  }

}
