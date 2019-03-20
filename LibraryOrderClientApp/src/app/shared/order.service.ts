import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IOrder } from './order.model';
import { catchError } from 'rxjs/operators';

@Injectable()
export class OrderService {
    constructor(private http: HttpClient){

    }

  getOrders():Observable<IOrder[]> {
    return this.http.get<IOrder[]>('http://localhost:59654/api/orders?includeitems=true');    
  }

  private handleError<T>(operation = 'operation', result?: T){
    return (error:any): Observable<T> => {
        console.error(error);
        return of(result as T);
    }
  }

  getOrder(orderNumber: number):Observable<IOrder> {
    return this.http.get<IOrder>('http://localhost:59654/api/orders/' + orderNumber + '?includeitems=true')
        .pipe(catchError(this.handleError<IOrder>('getOrder')));
  }
}