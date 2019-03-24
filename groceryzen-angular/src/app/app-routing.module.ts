import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EditShoppingListComponent } from '../app/edit-shopping-list/edit-shopping-list.component'
import { ShoppingListsComponent } from './shopping-lists/shopping-lists.component';
import { ItemSearchComponent } from './item-search/item-search.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'edit-shopping-list/:id', component: EditShoppingListComponent },
  { path: 'add-shopping-list-item/:id', component: ItemSearchComponent },
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },  
  { path: 'shopping-list', component: ShoppingListsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
