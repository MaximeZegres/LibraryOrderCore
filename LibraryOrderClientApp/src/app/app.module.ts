import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { OrderGridComponent } from './order-grid/order-grid.component';
import { HttpClientModule } from '@angular/common/http';
import { OrderGridItemComponent } from './order-grid/order-grid-item.component';
import { OrderService } from './shared/order.service';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { NavBarComponent } from './nav/nav-bar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderEditComponent } from './order-edit/order-edit.component';
import { AddOrderCustomerComponent } from './add-order/add-order-customer.component';
import { AddOrderItemsComponent } from './add-order/add-order-items.component';

import {FormlyModule} from '@ngx-formly/core';
import { FormlyMaterialModule } from '@ngx-formly/material';
import { DatepickerTypeComponent } from './datepicker-type.component';
import { MatDatepickerModule, MatInputModule, MatNativeDateModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    OrderGridComponent,
    AddOrderCustomerComponent,
    AddOrderItemsComponent,
    OrderGridItemComponent,
    OrderEditComponent,
    NavBarComponent,
    DatepickerTypeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    FormlyModule.forRoot({
      types: [{
        name: 'datepicker',
        component: DatepickerTypeComponent,
        wrappers: ['form-field'],
        defaultOptions: {
          defaultValue: new Date(),
          templateOptions: {
            datepickerOptions: {},
          },
        },
      }]
    }),
    FormlyMaterialModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [OrderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
