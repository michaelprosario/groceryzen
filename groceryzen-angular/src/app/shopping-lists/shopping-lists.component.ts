import { Component, OnInit } from '@angular/core';
import { ShoppingList } from '../entities/shopping-list';
import { ShoppingListsService } from '../shopping-lists.service';
import { ListShoppingListsResponse, BasicRequest } from '../shopping-lists.service';
import { first } from 'rxjs/operators';

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

  ngOnInit() {
    this.getList();
    
  }

}
