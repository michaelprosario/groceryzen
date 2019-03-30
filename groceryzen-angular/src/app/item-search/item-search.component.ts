import { Component, OnInit, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShoppingListsService, WalmartProductSearchRequest, CreateShoppingListItemRequest } from '../shopping-lists.service';
import { WalmartProductSearchItem } from '../entities/walmart-product-search-item';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-item-search',
  templateUrl: './item-search.component.html',
  styleUrls: ['./item-search.component.css']
})
export class ItemSearchComponent implements OnInit {
  productItems: WalmartProductSearchItem[];
  productSearchTerm: string;
  showProductItems: boolean;
  shoppingListId: string;

  constructor(
    private route: ActivatedRoute,
    private shoppingListsService: ShoppingListsService,
    private router: Router
  ) { 
    this.shoppingListId = this.route.snapshot.paramMap.get('id');    
  }

  ngOnInit() {
    this.productItems = [];
    this.showProductItems = false;
  }

  handleProductSearch(){
    let request = new WalmartProductSearchRequest();
    request.query = this.productSearchTerm;
    this.shoppingListsService.walmartProductSearch(request)
    .pipe(first())
    .subscribe(response => 
    { 
        this.showProductItems = true;
        this.productItems = response.records;
    });
  }  

  handleProductItemSelected(record: WalmartProductSearchItem){

    let request = new CreateShoppingListItemRequest();
    request.Completed = false;
    request.Price = record.salePrice;
    request.ProductCategory = record.categoryPath;
    request.ProductName = record.name;
    request.Qty = 1;
    request.ShoppingListId = this.shoppingListId;
    request.UnitPrice = record.salePrice;
    
    this.shoppingListsService.createShoppingListItem(request)
    .pipe(first())
    .subscribe(response => 
    { 
        console.log(response);
        this.productSearchTerm = '';
        this.router.navigateByUrl('/edit-shopping-list/' +  this.shoppingListId);
    });
  }  

  @ViewChild('txtProductSearchTerm') txtProductSearchTerm:ElementRef;

  ngAfterViewInit() {
        setTimeout(() => this.txtProductSearchTerm.nativeElement.focus());
  }

}
