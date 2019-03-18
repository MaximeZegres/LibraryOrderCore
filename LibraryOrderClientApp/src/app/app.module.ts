import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { OrderGridComponent } from './order-grid/order-grid.component';
import { AddOrderComponent } from './add-order/add-order.component';
import { HttpClientModule } from '@angular/common/http';
import { OrderGridItemComponent } from './order-grid/order-grid-item.component';
import { OrderService } from './shared/order.service';
import { OrderDetailsComponent } from './order-details/order-details.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { NavBarComponent } from './nav/nav-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    OrderGridComponent,
    AddOrderComponent,
    OrderGridItemComponent,
    OrderDetailsComponent,
    NavBarComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
