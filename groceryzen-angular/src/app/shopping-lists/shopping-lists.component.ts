import { Component, OnInit } from '@angular/core';
import { ShoppingList } from '../entities/shopping-list';
import { ShoppingListsService, CreateShoppingListItemRequest, CreateShoppingListRequest } from '../shopping-lists.service';
import { ListShoppingListsResponse, BasicRequest } from '../shopping-lists.service';
import { first } from 'rxjs/operators';
import { getListeners } from '@angular/core/src/render3/discovery_utils';

@Component({
  selector: 'app-shopping-lists',
  templateUrl: './shopping-lists.component.html',
  styleUrls: ['./shopping-lists.component.css']
})
export class ShoppingListsComponent implements OnInit {
  records: ShoppingList[];

  constructor(private shoppingListService: ShoppingListsService) { }

  getList(): void {
    let request = new BasicRequest();
    request.userId = "fixme";

    this.shoppingListService.getShoppingLists(request)
    .pipe(first())
    .subscribe(response => { 
      this.records = response.records; 
      console.log(this.records);
    });
  }

  handleCreateList(){
    var request = new CreateShoppingListRequest();
    request.Name = "List - " + new Date().toLocaleDateString();

    this.shoppingListService.createShoppingList(request)
    .pipe(first())
    .subscribe(response => { 
      this.getList();
    });    
  }

  ngOnInit() {
    this.getList(); 
  }

}
