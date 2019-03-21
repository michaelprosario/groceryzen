import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShoppingListsComponent } from './shopping-lists/shopping-lists.component';
import { HttpClientModule, HTTP_INTERCEPTORS }    from '@angular/common/http';
import { EditShoppingListComponent } from './edit-shopping-list/edit-shopping-list.component';
import { FormsModule } from '@angular/forms';
import { ItemSearchComponent } from './item-search/item-search.component';
import { AuthGuard } from './guards/auth.guard';
import { ShoppingListsService } from './shopping-lists.service';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { ErrorInterceptor } from './helpers/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    ShoppingListsComponent,
    EditShoppingListComponent,
    ItemSearchComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthGuard,
    ShoppingListsService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
