import { Component, OnInit } from '@angular/core';
import { ShoppingListsService, ListShoppingListItemsRequest, DeleteShoppingListItemRequest, CompleteShoppingListItemRequest } from '../shopping-lists.service';
import { ActivatedRoute } from '@angular/router';
import { ShoppingListItem } from '../entities/shopping-list-item';
import { first } from 'rxjs/operators';
import { ShoppingList } from '../entities/shopping-list';

@Component({
  selector: 'app-edit-shopping-list',
  templateUrl: './edit-shopping-list.component.html',
  styleUrls: ['./edit-shopping-list.component.css']
})
export class EditShoppingListComponent implements OnInit {

  records: ShoppingListItem[];
  total: number;
  shoppingListId: string;

  constructor(
    private route: ActivatedRoute,
    private shoppingListsService: ShoppingListsService
  ) { }

  ngOnInit() {
    this.getShoppingListItems();
    this.total = 0;
  }

  calculateTotal(){
    let i = 0;
    this.total = 0;

    for(i=0; i<this.records.length; i++) {
      this.total += this.records[i].price;
    }
  }

  handleDelete(record: ShoppingListItem){
    let request = new DeleteShoppingListItemRequest();
    request.id = record.id;
    
    this.shoppingListsService.deleteShoppingListItem(request)
    .pipe(first())
    .subscribe(response => 
    { 
        console.log(response);
        this.getShoppingListItems();
    });
  } 

  getShoppingListItems(): void {
    let id = this.route.snapshot.paramMap.get('id');
    this.shoppingListId = id;
    let request = new ListShoppingListItemsRequest();
    request.shoppingListId = id;

    this.shoppingListsService.getShoppingListItems(request)
    .pipe(first())
    .subscribe(response => 
    { 
        this.records = response.records;
        this.calculateTotal();
    });
  }  

  onItemCompleted(record: ShoppingListItem): void {
    let request = new CompleteShoppingListItemRequest();
    request.shoppingListItemId = record.id;

    this.shoppingListsService.completeShoppingListItem(request)
    .pipe(first())
    .subscribe(response => 
    { 
        
    });
  }
}
