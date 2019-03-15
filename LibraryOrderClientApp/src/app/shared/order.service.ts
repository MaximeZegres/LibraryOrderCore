import { Injectable } from '@angular/core';

@Injectable()
export class OrderService {
  getOrders() {
    return ORDERS
  }

  getOrder(id: number) {
    return ORDERS.find(order => order.id === id)
  }
}

const ORDERS = [
    {
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
    },
    {
        "id": 2,
        "orderNumber": "125126",
        "orderDate": "2019-01-22T22:13:05",
        "isContacted": false,
        "items": [
            {
                "id": 7,
                "book": {
                    "id": 10,
                    "title": "L'étranger",
                    "author": "Albert Camus",
                    "editor": "Gallimard",
                    "isbn": "9782070360024"
                },
                "quantity": 2,
                "isOrdered": false
            },
            {
              "id": 8,
              "book": {
                  "id": 2,
                  "title": "Learning JavaScript Design Patterns",
                  "author": "Addy Osmani",
                  "editor": "OReilly Media",
                  "isbn": "9781449331818"
              },
              "quantity": 1,
              "isOrdered": true
          }
        ],
        "customer": {
            "id": 2,
            "firstName": "Maxime",
            "lastName": "Zog",
            "email": "maxime1@test.be",
            "phoneNumber": "020150809"
        }
    },
    {
        "id": 3,
        "orderNumber": "125127",
        "orderDate": "2019-01-23T20:15:10",
        "isContacted": true,
        "items": [
            {
                "id": 8,
                "book": {
                    "id": 2,
                    "title": "Learning JavaScript Design Patterns",
                    "author": "Addy Osmani",
                    "editor": "OReilly Media",
                    "isbn": "9781449331818"
                },
                "quantity": 1,
                "isOrdered": true
            }
        ],
        "customer": {
            "id": 3,
            "firstName": "Coralie",
            "lastName": "Prov",
            "email": "coralie@test.be",
            "phoneNumber": "020103020"
        }
    }
]
