import { Component } from "@angular/core";
import { OrderService } from '../shared/order.service';
import { ActivatedRoute } from '@angular/router';

@Component({
    templateUrl: './order-details.component.html',
    styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent{
    order: any

    constructor(private orderService: OrderService, private route:ActivatedRoute){

    }

    ngOnInit(){
        this.order = this.orderService.getOrder(+this.route.snapshot.params['id'])
    }
}
