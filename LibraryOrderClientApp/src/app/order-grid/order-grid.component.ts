import { Component, OnInit } from '@angular/core';
import { OrderService } from '../shared/order.service';

@Component({
  templateUrl: './order-grid.component.html',
  styleUrls: ['./order-grid.component.css']
})
export class OrderGridComponent implements OnInit {
    orders:any[]

    constructor(private orderService: OrderService) {
    }


  ngOnInit() {
    this.orders = this.orderService.getOrders()
  }

}
