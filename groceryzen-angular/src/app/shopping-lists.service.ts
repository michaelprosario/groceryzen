import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap, first } from 'rxjs/operators';
import { ShoppingList } from './entities/shopping-list';
import { ShoppingListItem } from './entities/shopping-list-item';
import { WalmartProductSearchItem } from './entities/walmart-product-search-item';
import { environment } from '../environments/environment'
import { User } from './entities/user';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class BaseResponse {
  code: number;
  message:string;
  validationErrors:string[];
}

export class BasicRequest {
  userId: string;
}

export class ListShoppingListsResponse extends BaseResponse {
  records: ShoppingList[];
}

export class ListShoppingListItemsRequest extends BasicRequest {
  userId: string;
  shoppingListId: string;
}

export class ListShoppingListItemsResponse extends BaseResponse {
  records: ShoppingListItem[];
}

export class WalmartProductSearchRequest extends BasicRequest {
  query: string;
}

export class WalmartProductSearchResponse extends BaseResponse {
  records: WalmartProductSearchItem[];
}

export class DeleteShoppingListItemRequest extends BasicRequest {
    id: string;
}

export class CreateShoppingListItemRequest extends BasicRequest
{
    ShoppingListId : string;
    ProductName: string;
    ProductCategory: string;
    UnitPrice: number;
    Qty: number;
    Price: number;
    Completed: boolean;
}

export class CreateShoppingListItemResponse extends Response
{ 
  Id: string;
}


export class CreateShoppingListRequest extends BasicRequest
{
  Name: string;
  UserId: string;
}

export class CreateShoppingListResponse extends Response
{
  Id: string;
}

export class ArchiveShoppingListRequest extends BasicRequest
{
    Id: string;
}

@Injectable({
  providedIn: 'root'
})
export class ShoppingListsService {

  constructor( private http: HttpClient ) {}

  ShoppingListsUrl(): string {
    return environment.apiUrl + '/GroceryZen/ListShoppingLists';
  }

  deleteShoppingListItemUrl(): string {
    return environment.apiUrl + '/GroceryZen/DeleteShoppingListItem';
  }  

  ShoppingListsItemsUrl(): string {
    return environment.apiUrl + '/GroceryZen/ListShoppingListItems';
  }

  WalmartProductSearchUrl(): string {
    return environment.apiUrl + '/GroceryZen/ListProductsForSearch';
  } 
  
  CreateShoppingListItemUrl(): string {
    return environment.apiUrl + '/GroceryZen/CreateShoppingListItem';
  }    

  CreateShoppingListUrl(): string {
    return environment.apiUrl + '/GroceryZen/CreateShoppingList';
  }    

  ArchiveShoppingListUrl(): string {
    return environment.apiUrl + '/GroceryZen/ArchiveShoppingList';
  }    

  GetShoppingLists (request: BasicRequest): Observable<ListShoppingListsResponse> {
    return this.http.post<ListShoppingListsResponse>(this.ShoppingListsUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('fetched shopping lists')),
        catchError(this.handleError('getShoppingLists', null))
      );
  }

  getShoppingListItems (request: ListShoppingListItemsRequest): Observable<ListShoppingListItemsResponse> {
    return this.http.post<ListShoppingListItemsResponse>(this.ShoppingListsItemsUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('fetched shopping list items')),
        catchError(this.handleError('getShoppingListItems', null))
      );
  }  

  deleteShoppingListItem (request: DeleteShoppingListItemRequest): Observable<BaseResponse> {
    return this.http.post<BaseResponse>(this.deleteShoppingListItemUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('deleted shopping list item')),
        catchError(this.handleError('deleteShoppingListItem', null))
      );
  }  

  archiveShoppingList (request: ArchiveShoppingListRequest): Observable<BaseResponse> {
    return this.http.post<BaseResponse>(this.ArchiveShoppingListUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('archive shopping list')),
        catchError(this.handleError('archiveShoppingListItem', null))
      );
  }  

  walmartProductSearch (request: WalmartProductSearchRequest): Observable<WalmartProductSearchResponse> {
    return this.http.post<WalmartProductSearchResponse>(this.WalmartProductSearchUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('fetched shopping list items')),
        catchError(this.handleError('walmartProductSearch', null))
      );
  }  

  createShoppingListItem (request: CreateShoppingListItemRequest): Observable<CreateShoppingListItemResponse> {
    return this.http.post<CreateShoppingListItemResponse>(this.CreateShoppingListItemUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('createShoppingListItem done')),
        catchError(this.handleError('createShoppingListItem', null))
      );
  }  

  createShoppingList (request: CreateShoppingListRequest): Observable<CreateShoppingListResponse> {
    return this.http.post<CreateShoppingListResponse>(this.CreateShoppingListUrl(), request, httpOptions)
      .pipe(
        tap(_ => this.log('createShoppingList done')),
        catchError(this.handleError('createShoppingList', null))
      );
  }  

  login(username: string, password: string) {
    return this.http.post<any>(`${environment.apiUrl}/users/authenticate`, { username: username, password: password })
        .pipe(map(user => {
            // login successful if there's a jwt token in the response
            if (user && user.token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
            }

            return user;
        }));
  }

  logout() {
      localStorage.removeItem('currentUser');
  }

  getAll() {
    return this.http.get<User[]>(`${environment.apiUrl}/users`);
  }

  getById(id: number) {
      return this.http.get(`${environment.apiUrl}/users/` + id);
  }

  register(user: User) {
      return this.http.post(`${environment.apiUrl}/users/register`, user);
  }

  update(user: User) {
      return this.http.put(`${environment.apiUrl}/users/` + user.id, user);
  }

  delete(id: number) {
      return this.http.delete(`${environment.apiUrl}/users/` + id);
  }  
  
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  private log(message: string) {
    console.log(message);
  }  

}
