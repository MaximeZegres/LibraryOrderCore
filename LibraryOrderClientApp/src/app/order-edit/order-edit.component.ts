import { Component } from "@angular/core";
import { OrderService } from '../shared/order.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IOrder } from '../shared/order.model';

@Component({
    templateUrl: './order-edit.component.html',
    styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent{
    order: IOrder = {
        orderId: 0,
        orderNumber: '',
        orderDate: '',
        isContacted: false,
        customerFirstName: '',
        customerLastName: '',
        customerEmail: '',
        customerPhoneNumber: '',
        orderItems: []
    }



    constructor(private orderService: OrderService, private route:ActivatedRoute, private router: Router) { }

    ngOnInit(){
        let orderNumber = this.route.snapshot.params['orderNumber'];
        if (orderNumber !== 0) {
            this.getOrder(orderNumber);
        }
    }

    getOrder(orderNumber: string) {
        this.orderService.getOrder(orderNumber)
            .subscribe((order: IOrder) => {
                this.order = order;
            },
            (err: any) => console.log(err));
    }

    submit() {

    }

    cancel(event: Event) {
        event.preventDefault();
        this.router.navigate(['/']);
    }

    delete(event: Event) {

    }

}
