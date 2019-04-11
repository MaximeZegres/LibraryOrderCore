import { OrderGridComponent } from './order-grid/order-grid.component';
import { Routes } from '@angular/router';
import { AddOrderComponent } from './add-order/add-order.component';
import { OrderEditComponent } from './order-edit/order-edit.component';

export const appRoutes:Routes = [
    {path: 'orders/new', component: AddOrderComponent},
    {path: 'orders', component: OrderGridComponent},
    {path: 'orders/:id', component: OrderEditComponent},
    {path: '', redirectTo: '/orders', pathMatch: 'full'}
]