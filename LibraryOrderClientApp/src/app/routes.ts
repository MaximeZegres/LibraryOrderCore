import { OrderGridComponent } from './order-grid/order-grid.component';
import { Routes } from '@angular/router';
import { AddOrderCustomerComponent } from './add-order/add-order-customer.component';
import { OrderEditComponent } from './order-edit/order-edit.component';

export const appRoutes:Routes = [
    {path: 'orders/new', component: AddOrderCustomerComponent},
    {path: 'orders', component: OrderGridComponent},
    {path: 'orders/:id', component: OrderEditComponent},
    {path: '', redirectTo: '/orders', pathMatch: 'full'}
]