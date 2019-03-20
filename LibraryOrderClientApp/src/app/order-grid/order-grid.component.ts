import { Component, OnInit } from '@angular/core';
import { OrderService } from '../shared/order.service';
import { IOrder } from '../shared/order.model';

@Component({
  templateUrl: './order-grid.component.html',
  styleUrls: ['./order-grid.component.css']
})
export class OrderGridComponent implements OnInit {
    orders:IOrder[]
    order: IOrder

    constructor(private orderService: OrderService) {
    }


  ngOnInit() {
    this.orderService.getOrders()
      .subscribe((orders: IOrder[]) => this.orders = orders);
  }

}
