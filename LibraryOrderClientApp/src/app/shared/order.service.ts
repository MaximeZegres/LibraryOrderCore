import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IOrder } from './order.model';
import { catchError } from 'rxjs/operators';

@Injectable()
export class OrderService {
    constructor(private http: HttpClient){

    }

  getOrders():Observable<IOrder[]> {
    return this.http.get<IOrder[]>('http://localhost:59654/api/orders?includeitems=true')
    .pipe(catchError(this.handleError<IOrder[]>('getOrders')));  
  }

  getOrder(orderNumber: string):Observable<IOrder> {
    return this.http.get<IOrder>('http://localhost:59654/api/orders/' + orderNumber + '?includeitems=true')
        .pipe(catchError(this.handleError<IOrder>('getOrder')));
  }

  saveOrder(order){
    let options = {headers: new HttpHeaders({'Content-Type': 'application/json'})}
    this.http.post<IOrder>('http://localhost:59654/api/orders', order, options)
    .pipe(catchError(this.handleError<IOrder>('saveOrder')));
  }

  private handleError<T>(operation = 'operation', result?: T){
    return (error:any): Observable<T> => {
        console.error(error);
        return of(result as T);
    }
  }
}