import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: './add-order.component.html',
  styleUrls: ['./add-order.component.css']
})
export class AddOrderComponent implements OnInit {
  constructor(private router: Router) { }

  cancel() {
    this.router.navigate(['/orders'])
  }


  ngOnInit() {
  }

}
