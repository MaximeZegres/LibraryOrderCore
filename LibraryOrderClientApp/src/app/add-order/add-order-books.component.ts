import { OnInit, Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, Validators, FormControl } from '@angular/forms';

@Component({
    selector: 'add-order-books',
    templateUrl: './add-order-books.component.html',
    styleUrls: ['./add-order-books.component.css']
  })
  export class AddOrderBooksComponent implements OnInit {
    orderItems: FormArray;
    booksForm: FormGroup;

    constructor(private fb: FormBuilder){
    }


    ngOnInit() { 
      this.booksForm = this.fb.group({
        quantity: ['', [Validators.required]],
        isOrdered: [false, [Validators.required]],
        book: this.fb.array([
          this.buildBooks()
        ])
      });
    }

    buildBooks(): FormGroup {
        return this.fb.group({
          title: '',
          author: '',
          editor: '',
          isbn: ''
        });
      }

      addBook() : void {
        this.book.push(this.buildBooks());
      }


      saveBooks() {
        console.log(this.booksForm);
        console.log('Saved: ' + JSON.stringify(this.booksForm.value));
      }

  }