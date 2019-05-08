import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IOrder } from './order.model';
import { catchError } from 'rxjs/operators';

@Injectable()
export class OrderService {
  baseUrl = "https://libraryordercore20190507051056.azurewebsites.net/api/";
  baseOrdersUrl = this.baseUrl + 'orders?includeitems=true';


    constructor(private http: HttpClient){
    }

  getOrders():Observable<IOrder[]> {
    return this.http.get<IOrder[]>(this.baseOrdersUrl)
    .pipe(catchError(this.handleError<IOrder[]>('getOrders')));  
  }

  getOrder(orderNumber: string):Observable<IOrder> {
    return this.http.get<IOrder>(this.baseOrdersUrl + orderNumber + '?includeitems=true')
        .pipe(catchError(this.handleError<IOrder>('getOrder')));
  }

  saveOrder(order: IOrder) : Observable<IOrder> {
    return this.http.post<IOrder>(this.baseOrdersUrl, order.orderId)
      .pipe(catchError(this.handleError<IOrder>('saveOrder')));
  }

  private handleError<T>(operation = 'operation', result?: T){
    return (error:any): Observable<T> => {
        console.error(error);
        return of(result as T);
    }
  }
}