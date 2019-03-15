import { OrderGridComponent } from './order-grid/order-grid.component';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { Routes } from '@angular/router';
import { AddOrderComponent } from './add-order/add-order.component';

export const appRoutes:Routes = [
    {path: 'orders/new', component: AddOrderComponent},
    {path: 'orders', component: OrderGridComponent},
    {path: 'orders/:id', component: OrderDetailsComponent},
    {path: '', redirectTo: '/orders', pathMatch: 'full'}
]