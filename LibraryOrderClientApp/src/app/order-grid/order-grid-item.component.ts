import { Component, Input } from "@angular/core";

@Component({
    selector: 'order-grid-item',
    templateUrl: './order-grid-item.component.html',
    styleUrls: ['./order-grid-item.component.css']
})
export class OrderGridItemComponent {
    @Input() order:any
}