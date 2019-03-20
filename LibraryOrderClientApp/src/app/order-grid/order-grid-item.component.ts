import { Component, Input } from "@angular/core";
import { IOrder } from '../shared/order.model';

@Component({
    selector: 'order-grid-item',
    templateUrl: './order-grid-item.component.html',
    styleUrls: ['./order-grid-item.component.css']
})
export class OrderGridItemComponent {
    @Input() order: IOrder
}