import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { OrderGridComponent } from './order-grid/order-grid.component';
import { AddOrUpdateOrderComponent } from './add-or-update-order/add-or-update-order.component';
import { HttpClientModule } from '@angular/common/http';
import { OrderGridItemComponent } from './order-grid/order-grid-item.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderGridComponent,
    AddOrUpdateOrderComponent,
    OrderGridItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
