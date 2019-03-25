(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["main"],{

/***/ "./src/$$_lazy_route_resource lazy recursive":
/*!**********************************************************!*\
  !*** ./src/$$_lazy_route_resource lazy namespace object ***!
  \**********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

function webpackEmptyAsyncContext(req) {
	// Here Promise.resolve().then() is used instead of new Promise() to prevent
	// uncaught exception popping up in devtools
	return Promise.resolve().then(function() {
		var e = new Error("Cannot find module '" + req + "'");
		e.code = 'MODULE_NOT_FOUND';
		throw e;
	});
}
webpackEmptyAsyncContext.keys = function() { return []; };
webpackEmptyAsyncContext.resolve = webpackEmptyAsyncContext;
module.exports = webpackEmptyAsyncContext;
webpackEmptyAsyncContext.id = "./src/$$_lazy_route_resource lazy recursive";

/***/ }),

/***/ "./src/app/app-routing.module.ts":
/*!***************************************!*\
  !*** ./src/app/app-routing.module.ts ***!
  \***************************************/
/*! exports provided: AppRoutingModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppRoutingModule", function() { return AppRoutingModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _app_edit_shopping_list_edit_shopping_list_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../app/edit-shopping-list/edit-shopping-list.component */ "./src/app/edit-shopping-list/edit-shopping-list.component.ts");
/* harmony import */ var _shopping_lists_shopping_lists_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./shopping-lists/shopping-lists.component */ "./src/app/shopping-lists/shopping-lists.component.ts");
/* harmony import */ var _item_search_item_search_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./item-search/item-search.component */ "./src/app/item-search/item-search.component.ts");
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! ./login/login.component */ "./src/app/login/login.component.ts");
/* harmony import */ var _register_register_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./register/register.component */ "./src/app/register/register.component.ts");








var routes = [
    { path: 'edit-shopping-list/:id', component: _app_edit_shopping_list_edit_shopping_list_component__WEBPACK_IMPORTED_MODULE_3__["EditShoppingListComponent"] },
    { path: 'add-shopping-list-item/:id', component: _item_search_item_search_component__WEBPACK_IMPORTED_MODULE_5__["ItemSearchComponent"] },
    { path: '', component: _login_login_component__WEBPACK_IMPORTED_MODULE_6__["LoginComponent"] },
    { path: 'register', component: _register_register_component__WEBPACK_IMPORTED_MODULE_7__["RegisterComponent"] },
    { path: 'shopping-list', component: _shopping_lists_shopping_lists_component__WEBPACK_IMPORTED_MODULE_4__["ShoppingListsComponent"] },
];
var AppRoutingModule = /** @class */ (function () {
    function AppRoutingModule() {
    }
    AppRoutingModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["NgModule"])({
            imports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forRoot(routes)],
            exports: [_angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"]]
        })
    ], AppRoutingModule);
    return AppRoutingModule;
}());



/***/ }),

/***/ "./src/app/app.component.css":
/*!***********************************!*\
  !*** ./src/app/app.component.css ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FwcC5jb21wb25lbnQuY3NzIn0= */"

/***/ }),

/***/ "./src/app/app.component.html":
/*!************************************!*\
  !*** ./src/app/app.component.html ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n\r\n<router-outlet></router-outlet>\r\n"

/***/ }),

/***/ "./src/app/app.component.ts":
/*!**********************************!*\
  !*** ./src/app/app.component.ts ***!
  \**********************************/
/*! exports provided: AppComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppComponent", function() { return AppComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");


var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.title = 'groceryzen-angular';
    }
    AppComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-root',
            template: __webpack_require__(/*! ./app.component.html */ "./src/app/app.component.html"),
            styles: [__webpack_require__(/*! ./app.component.css */ "./src/app/app.component.css")]
        })
    ], AppComponent);
    return AppComponent;
}());



/***/ }),

/***/ "./src/app/app.module.ts":
/*!*******************************!*\
  !*** ./src/app/app.module.ts ***!
  \*******************************/
/*! exports provided: AppModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AppModule", function() { return AppModule; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser */ "./node_modules/@angular/platform-browser/fesm5/platform-browser.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _app_routing_module__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./app-routing.module */ "./src/app/app-routing.module.ts");
/* harmony import */ var _app_component__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./app.component */ "./src/app/app.component.ts");
/* harmony import */ var _shopping_lists_shopping_lists_component__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./shopping-lists/shopping-lists.component */ "./src/app/shopping-lists/shopping-lists.component.ts");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_6__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var _edit_shopping_list_edit_shopping_list_component__WEBPACK_IMPORTED_MODULE_7__ = __webpack_require__(/*! ./edit-shopping-list/edit-shopping-list.component */ "./src/app/edit-shopping-list/edit-shopping-list.component.ts");
/* harmony import */ var _angular_forms__WEBPACK_IMPORTED_MODULE_8__ = __webpack_require__(/*! @angular/forms */ "./node_modules/@angular/forms/fesm5/forms.js");
/* harmony import */ var _item_search_item_search_component__WEBPACK_IMPORTED_MODULE_9__ = __webpack_require__(/*! ./item-search/item-search.component */ "./src/app/item-search/item-search.component.ts");
/* harmony import */ var _guards_auth_guard__WEBPACK_IMPORTED_MODULE_10__ = __webpack_require__(/*! ./guards/auth.guard */ "./src/app/guards/auth.guard.ts");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_11__ = __webpack_require__(/*! ./shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var _helpers_jwt_interceptor__WEBPACK_IMPORTED_MODULE_12__ = __webpack_require__(/*! ./helpers/jwt.interceptor */ "./src/app/helpers/jwt.interceptor.ts");
/* harmony import */ var _helpers_error_interceptor__WEBPACK_IMPORTED_MODULE_13__ = __webpack_require__(/*! ./helpers/error.interceptor */ "./src/app/helpers/error.interceptor.ts");
/* harmony import */ var _login_login_component__WEBPACK_IMPORTED_MODULE_14__ = __webpack_require__(/*! ./login/login.component */ "./src/app/login/login.component.ts");
/* harmony import */ var _register_register_component__WEBPACK_IMPORTED_MODULE_15__ = __webpack_require__(/*! ./register/register.component */ "./src/app/register/register.component.ts");
/* harmony import */ var _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_16__ = __webpack_require__(/*! @angular/platform-browser/animations */ "./node_modules/@angular/platform-browser/fesm5/animations.js");
/* harmony import */ var _angular_material_form_field__WEBPACK_IMPORTED_MODULE_17__ = __webpack_require__(/*! @angular/material/form-field */ "./node_modules/@angular/material/esm5/form-field.es5.js");
/* harmony import */ var _angular_material_input__WEBPACK_IMPORTED_MODULE_18__ = __webpack_require__(/*! @angular/material/input */ "./node_modules/@angular/material/esm5/input.es5.js");
/* harmony import */ var _angular_material_button__WEBPACK_IMPORTED_MODULE_19__ = __webpack_require__(/*! @angular/material/button */ "./node_modules/@angular/material/esm5/button.es5.js");
/* harmony import */ var _angular_material_card__WEBPACK_IMPORTED_MODULE_20__ = __webpack_require__(/*! @angular/material/card */ "./node_modules/@angular/material/esm5/card.es5.js");
/* harmony import */ var _angular_material_list__WEBPACK_IMPORTED_MODULE_21__ = __webpack_require__(/*! @angular/material/list */ "./node_modules/@angular/material/esm5/list.es5.js");
/* harmony import */ var _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_22__ = __webpack_require__(/*! @angular/material/toolbar */ "./node_modules/@angular/material/esm5/toolbar.es5.js");
/* harmony import */ var _angular_material_sidenav__WEBPACK_IMPORTED_MODULE_23__ = __webpack_require__(/*! @angular/material/sidenav */ "./node_modules/@angular/material/esm5/sidenav.es5.js");
























var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_2__["NgModule"])({
            declarations: [
                _app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"],
                _shopping_lists_shopping_lists_component__WEBPACK_IMPORTED_MODULE_5__["ShoppingListsComponent"],
                _edit_shopping_list_edit_shopping_list_component__WEBPACK_IMPORTED_MODULE_7__["EditShoppingListComponent"],
                _item_search_item_search_component__WEBPACK_IMPORTED_MODULE_9__["ItemSearchComponent"],
                _login_login_component__WEBPACK_IMPORTED_MODULE_14__["LoginComponent"],
                _register_register_component__WEBPACK_IMPORTED_MODULE_15__["RegisterComponent"]
            ],
            imports: [
                _angular_material_sidenav__WEBPACK_IMPORTED_MODULE_23__["MatSidenavModule"],
                _angular_material_toolbar__WEBPACK_IMPORTED_MODULE_22__["MatToolbarModule"],
                _angular_material_list__WEBPACK_IMPORTED_MODULE_21__["MatListModule"],
                _angular_material_card__WEBPACK_IMPORTED_MODULE_20__["MatCardModule"],
                _angular_material_button__WEBPACK_IMPORTED_MODULE_19__["MatButtonModule"],
                _angular_material_form_field__WEBPACK_IMPORTED_MODULE_17__["MatFormFieldModule"],
                _angular_material_input__WEBPACK_IMPORTED_MODULE_18__["MatInputModule"],
                _angular_platform_browser__WEBPACK_IMPORTED_MODULE_1__["BrowserModule"],
                _app_routing_module__WEBPACK_IMPORTED_MODULE_3__["AppRoutingModule"],
                _angular_common_http__WEBPACK_IMPORTED_MODULE_6__["HttpClientModule"],
                _angular_forms__WEBPACK_IMPORTED_MODULE_8__["FormsModule"],
                _angular_platform_browser_animations__WEBPACK_IMPORTED_MODULE_16__["BrowserAnimationsModule"]
            ],
            providers: [
                _guards_auth_guard__WEBPACK_IMPORTED_MODULE_10__["AuthGuard"],
                _shopping_lists_service__WEBPACK_IMPORTED_MODULE_11__["ShoppingListsService"],
                { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_6__["HTTP_INTERCEPTORS"], useClass: _helpers_jwt_interceptor__WEBPACK_IMPORTED_MODULE_12__["JwtInterceptor"], multi: true },
                { provide: _angular_common_http__WEBPACK_IMPORTED_MODULE_6__["HTTP_INTERCEPTORS"], useClass: _helpers_error_interceptor__WEBPACK_IMPORTED_MODULE_13__["ErrorInterceptor"], multi: true },
            ],
            bootstrap: [_app_component__WEBPACK_IMPORTED_MODULE_4__["AppComponent"]]
        })
    ], AppModule);
    return AppModule;
}());



/***/ }),

/***/ "./src/app/edit-shopping-list/edit-shopping-list.component.css":
/*!*********************************************************************!*\
  !*** ./src/app/edit-shopping-list/edit-shopping-list.component.css ***!
  \*********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2VkaXQtc2hvcHBpbmctbGlzdC9lZGl0LXNob3BwaW5nLWxpc3QuY29tcG9uZW50LmNzcyJ9 */"

/***/ }),

/***/ "./src/app/edit-shopping-list/edit-shopping-list.component.html":
/*!**********************************************************************!*\
  !*** ./src/app/edit-shopping-list/edit-shopping-list.component.html ***!
  \**********************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-heading\">Edit Shopping List</div>\r\n    <div class=\"panel-body\">\r\n\r\n        <button \r\n              className=\"btn btn-primary\"\r\n              routerLink=\"/add-shopping-list-item/{{shoppingListId}}\"\r\n              class=\"btn btn-primary\"> Add </button>\r\n\r\n        <br>\r\n        <table class=\"table table-striped\">\r\n        <tr>\r\n          <td>Name</td>\r\n          <td style=\"text-align:right;\">Qty</td>\r\n          <td style=\"text-align:right;\">Unit Price</td>\r\n          <td style=\"text-align:right;\">Price</td>\r\n          <td>&nbsp;</td>\r\n        </tr>\r\n        <tr *ngFor=\"let record of records\">\r\n          <td>\r\n            <a routerLink=\"/edit-shopping-list-item/{{record.id}}\">\r\n            {{ record.productName }}\r\n            </a><br>\r\n            {{ record.productCategory }}\r\n          </td>\r\n          <td style=\"text-align:right;\">{{ record.qty }}</td>\r\n          <td style=\"text-align:right;\">${{ record.unitPrice }}</td>\r\n          <td style=\"text-align:right;\">${{ record.price }}</td>\r\n          <td>\r\n              <button \r\n              className=\"btn btn-primary\"\r\n              (click)=\"handleDelete(record)\"\r\n              class=\"btn btn-danger\"              \r\n              > Delete </button>\r\n          </td>\r\n        </tr>\r\n        <br>\r\n        Grand Total: ${{ total | number:'1.2-2' }}\r\n        </table>\r\n        \r\n    </div>\r\n  </div>\r\n\r\n\r\n\r\n"

/***/ }),

/***/ "./src/app/edit-shopping-list/edit-shopping-list.component.ts":
/*!********************************************************************!*\
  !*** ./src/app/edit-shopping-list/edit-shopping-list.component.ts ***!
  \********************************************************************/
/*! exports provided: EditShoppingListComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "EditShoppingListComponent", function() { return EditShoppingListComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");





var EditShoppingListComponent = /** @class */ (function () {
    function EditShoppingListComponent(route, shoppingListsService) {
        this.route = route;
        this.shoppingListsService = shoppingListsService;
    }
    EditShoppingListComponent.prototype.ngOnInit = function () {
        this.getShoppingListItems();
        this.total = 0;
    };
    EditShoppingListComponent.prototype.calculateTotal = function () {
        var i = 0;
        this.total = 0;
        for (i = 0; i < this.records.length; i++) {
            this.total += this.records[i].price;
        }
    };
    EditShoppingListComponent.prototype.handleDelete = function (record) {
        var _this = this;
        var request = new _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["DeleteShoppingListItemRequest"]();
        request.id = record.id;
        this.shoppingListsService.deleteShoppingListItem(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["first"])())
            .subscribe(function (response) {
            console.log(response);
            _this.getShoppingListItems();
        });
    };
    EditShoppingListComponent.prototype.getShoppingListItems = function () {
        var _this = this;
        var id = this.route.snapshot.paramMap.get('id');
        this.shoppingListId = id;
        var request = new _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["ListShoppingListItemsRequest"]();
        request.shoppingListId = id;
        this.shoppingListsService.getShoppingListItems(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["first"])())
            .subscribe(function (response) {
            _this.records = response.records;
            _this.calculateTotal();
        });
    };
    EditShoppingListComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-edit-shopping-list',
            template: __webpack_require__(/*! ./edit-shopping-list.component.html */ "./src/app/edit-shopping-list/edit-shopping-list.component.html"),
            styles: [__webpack_require__(/*! ./edit-shopping-list.component.css */ "./src/app/edit-shopping-list/edit-shopping-list.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_3__["ActivatedRoute"],
            _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["ShoppingListsService"]])
    ], EditShoppingListComponent);
    return EditShoppingListComponent;
}());



/***/ }),

/***/ "./src/app/entities/user.ts":
/*!**********************************!*\
  !*** ./src/app/entities/user.ts ***!
  \**********************************/
/*! exports provided: User */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "User", function() { return User; });
// https://github.com/cornflourblue/angular-6-registration-login-example-cli
var User = /** @class */ (function () {
    function User() {
    }
    return User;
}());



/***/ }),

/***/ "./src/app/guards/auth.guard.ts":
/*!**************************************!*\
  !*** ./src/app/guards/auth.guard.ts ***!
  \**************************************/
/*! exports provided: AuthGuard */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "AuthGuard", function() { return AuthGuard; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");



// https://github.com/cornflourblue/angular-6-registration-login-example-cli
var AuthGuard = /** @class */ (function () {
    function AuthGuard(router) {
        this.router = router;
    }
    AuthGuard.prototype.canActivate = function (route, state) {
        if (localStorage.getItem('currentUser')) {
            // logged in so return true
            return true;
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    };
    AuthGuard = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], AuthGuard);
    return AuthGuard;
}());



/***/ }),

/***/ "./src/app/helpers/error.interceptor.ts":
/*!**********************************************!*\
  !*** ./src/app/helpers/error.interceptor.ts ***!
  \**********************************************/
/*! exports provided: ErrorInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ErrorInterceptor", function() { return ErrorInterceptor; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");





// https://github.com/cornflourblue/angular-6-registration-login-example-cli
var ErrorInterceptor = /** @class */ (function () {
    function ErrorInterceptor(service) {
        this.service = service;
    }
    ErrorInterceptor.prototype.intercept = function (request, next) {
        var _this = this;
        return next.handle(request).pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["catchError"])(function (err) {
            if (err.status === 401) {
                // auto logout if 401 response returned from api
                _this.service.logout();
                location.reload(true);
            }
            var error = err.error.message || err.statusText;
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_2__["throwError"])(error);
        }));
    };
    ErrorInterceptor = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])(),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shopping_lists_service__WEBPACK_IMPORTED_MODULE_4__["ShoppingListsService"]])
    ], ErrorInterceptor);
    return ErrorInterceptor;
}());



/***/ }),

/***/ "./src/app/helpers/jwt.interceptor.ts":
/*!********************************************!*\
  !*** ./src/app/helpers/jwt.interceptor.ts ***!
  \********************************************/
/*! exports provided: JwtInterceptor */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "JwtInterceptor", function() { return JwtInterceptor; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
// https://github.com/cornflourblue/angular-6-registration-login-example-cli/blob/master/src/app/_helpers/jwt.interceptor.ts


var JwtInterceptor = /** @class */ (function () {
    function JwtInterceptor() {
    }
    JwtInterceptor.prototype.intercept = function (request, next) {
        // add authorization header with jwt token if available
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if (currentUser && currentUser.token) {
            request = request.clone({
                setHeaders: {
                    Authorization: "Bearer " + currentUser.token
                }
            });
        }
        return next.handle(request);
    };
    JwtInterceptor = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])()
    ], JwtInterceptor);
    return JwtInterceptor;
}());



/***/ }),

/***/ "./src/app/item-search/item-search.component.css":
/*!*******************************************************!*\
  !*** ./src/app/item-search/item-search.component.css ***!
  \*******************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2l0ZW0tc2VhcmNoL2l0ZW0tc2VhcmNoLmNvbXBvbmVudC5jc3MifQ== */"

/***/ }),

/***/ "./src/app/item-search/item-search.component.html":
/*!********************************************************!*\
  !*** ./src/app/item-search/item-search.component.html ***!
  \********************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<div class=\"panel panel-default\">\r\n  <div class=\"panel-heading\">Item search</div>\r\n  <div class=\"panel-body\">\r\n    <div>\r\n      Search for product:<br>\r\n      <input [(ngModel)]=\"productSearchTerm\" \r\n             name=\"txtProductSearchTerm\" \r\n             id=\"txtProductSearchTerm\" \r\n             #txtProductSearchTerm\r\n             (keyup.enter)=\"handleProductSearch($event)\" \r\n             />\r\n      <input type=\"button\" value=\"Search\" (click)=\"handleProductSearch()\" class=\"btn btn-primary\" />\r\n    </div>\r\n    <div>\r\n      <table class=\"table table-striped table-hover\" *ngIf=\"showProductItems\">\r\n        <thead>\r\n          <tr>\r\n            <th scope=\"col\">Product</th>\r\n            <th scope=\"col\">Unit Price</th>\r\n            <th>&nbsp;</th>\r\n          </tr>\r\n        </thead>\r\n        <tbody>\r\n          <tr *ngFor=\"let record of productItems\">\r\n            <td>\r\n              {{record.name}}<br>\r\n              {{record.categoryPath}}\r\n            </td>\r\n            <td style=\"text-align:right;\">${{record.salePrice}}</td>\r\n            <td>\r\n              <button  (click)=\"handleProductItemSelected(record)\" class=\"btn btn-primary\"> Select </button>\r\n            </td>\r\n          </tr>\r\n        </tbody>\r\n      </table>\r\n    </div>\r\n\r\n  </div>\r\n</div>"

/***/ }),

/***/ "./src/app/item-search/item-search.component.ts":
/*!******************************************************!*\
  !*** ./src/app/item-search/item-search.component.ts ***!
  \******************************************************/
/*! exports provided: ItemSearchComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ItemSearchComponent", function() { return ItemSearchComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");





var ItemSearchComponent = /** @class */ (function () {
    function ItemSearchComponent(route, shoppingListsService, router) {
        this.route = route;
        this.shoppingListsService = shoppingListsService;
        this.router = router;
    }
    ItemSearchComponent.prototype.ngOnInit = function () {
        this.productItems = [];
        this.showProductItems = false;
    };
    ItemSearchComponent.prototype.handleProductSearch = function () {
        var _this = this;
        var request = new _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__["WalmartProductSearchRequest"]();
        request.query = this.productSearchTerm;
        this.shoppingListsService.walmartProductSearch(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["first"])())
            .subscribe(function (response) {
            _this.showProductItems = true;
            _this.productItems = response.records;
        });
    };
    ItemSearchComponent.prototype.handleProductItemSelected = function (record) {
        var _this = this;
        this.shoppingListId = this.route.snapshot.paramMap.get('id');
        var request = new _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__["CreateShoppingListItemRequest"]();
        request.Completed = false;
        request.Price = record.salePrice;
        request.ProductCategory = record.categoryPath;
        request.ProductName = record.name;
        request.Qty = 1;
        request.ShoppingListId = this.shoppingListId;
        request.UnitPrice = record.salePrice;
        this.shoppingListsService.createShoppingListItem(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["first"])())
            .subscribe(function (response) {
            console.log(response);
            _this.productSearchTerm = '';
            _this.router.navigateByUrl('/edit-shopping-list/' + _this.shoppingListId);
        });
    };
    ItemSearchComponent.prototype.ngAfterViewInit = function () {
        var _this = this;
        setTimeout(function () { return _this.txtProductSearchTerm.nativeElement.focus(); });
    };
    tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["ViewChild"])('txtProductSearchTerm'),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:type", _angular_core__WEBPACK_IMPORTED_MODULE_1__["ElementRef"])
    ], ItemSearchComponent.prototype, "txtProductSearchTerm", void 0);
    ItemSearchComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-item-search',
            template: __webpack_require__(/*! ./item-search.component.html */ "./src/app/item-search/item-search.component.html"),
            styles: [__webpack_require__(/*! ./item-search.component.css */ "./src/app/item-search/item-search.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__["ShoppingListsService"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"]])
    ], ItemSearchComponent);
    return ItemSearchComponent;
}());



/***/ }),

/***/ "./src/app/login/login.component.css":
/*!*******************************************!*\
  !*** ./src/app/login/login.component.css ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "div\r\n{\r\n    text-align: center;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbG9naW4vbG9naW4uY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7SUFFSSxrQkFBa0I7QUFDdEIiLCJmaWxlIjoic3JjL2FwcC9sb2dpbi9sb2dpbi5jb21wb25lbnQuY3NzIiwic291cmNlc0NvbnRlbnQiOlsiZGl2XHJcbntcclxuICAgIHRleHQtYWxpZ246IGNlbnRlcjtcclxufSJdfQ== */"

/***/ }),

/***/ "./src/app/login/login.component.html":
/*!********************************************!*\
  !*** ./src/app/login/login.component.html ***!
  \********************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-card>\r\n  <mat-card-title>\r\n    Welcome To GroceryZen\r\n  </mat-card-title>\r\n\r\n  <div>\r\n    <mat-form-field>\r\n      <input matInput placeholder=\"Enter user name\" type=\"text\" name=\"txtUserName\" id=\"txtUserName\"\r\n        [(ngModel)]=\"userName\" />\r\n    </mat-form-field>\r\n  </div>\r\n  <div>\r\n    <mat-form-field>\r\n      <input matInput placeholder=\"Enter Password\" type=\"password\" name=\"txtPassword\" id=\"txtPassword\"\r\n        [(ngModel)]=\"password\" />\r\n    </mat-form-field>\r\n  </div>\r\n  <div>\r\n    <button mat-raised-button color=\"primary\" (click)=\"handleLogin()\">Login</button>\r\n  </div>\r\n  <div id=\"divMessage\" class=\"divErrorMessage\">{{message}}</div>\r\n\r\n</mat-card>"

/***/ }),

/***/ "./src/app/login/login.component.ts":
/*!******************************************!*\
  !*** ./src/app/login/login.component.ts ***!
  \******************************************/
/*! exports provided: LoginComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "LoginComponent", function() { return LoginComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");





var LoginComponent = /** @class */ (function () {
    function LoginComponent(router, route, shoppingListsService) {
        this.router = router;
        this.route = route;
        this.shoppingListsService = shoppingListsService;
        this.userName = "";
        this.password = "";
        this.returnUrl = "";
        this.message = "";
    }
    LoginComponent.prototype.ngOnInit = function () {
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.shoppingListsService.logout();
    };
    LoginComponent.prototype.handleLogin = function () {
        var _this = this;
        this.shoppingListsService.login(this.userName, this.password)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["first"])())
            .subscribe(function (response) {
            _this.message = "";
            _this.router.navigate(["/shopping-list"]);
        }, function (error) {
            _this.message = "Enter valid user name and password";
        });
    };
    LoginComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-login',
            template: __webpack_require__(/*! ./login.component.html */ "./src/app/login/login.component.html"),
            styles: [__webpack_require__(/*! ./login.component.css */ "./src/app/login/login.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_router__WEBPACK_IMPORTED_MODULE_2__["Router"],
            _angular_router__WEBPACK_IMPORTED_MODULE_2__["ActivatedRoute"],
            _shopping_lists_service__WEBPACK_IMPORTED_MODULE_3__["ShoppingListsService"]])
    ], LoginComponent);
    return LoginComponent;
}());



/***/ }),

/***/ "./src/app/register/register.component.css":
/*!*************************************************!*\
  !*** ./src/app/register/register.component.css ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL3JlZ2lzdGVyL3JlZ2lzdGVyLmNvbXBvbmVudC5jc3MifQ== */"

/***/ }),

/***/ "./src/app/register/register.component.html":
/*!**************************************************!*\
  !*** ./src/app/register/register.component.html ***!
  \**************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<h1>Register User</h1>\r\n<div id=\"divMessage\"></div>\r\n<div>\r\n  First name:\r\n</div>\r\n<div>\r\n  <input type=\"text\" id=\"txtFirstName\" id=\"txtFirstName\" [(ngModel)]=\"firstName\" >\r\n</div>\r\n<div>\r\n  Last name:\r\n</div>\r\n<div>\r\n  <input type=\"text\" id=\"txtLastName\" id=\"txtLastName\" [(ngModel)]=\"lastName\" >\r\n</div>\r\n<div>\r\n  User name:\r\n</div>\r\n<div>\r\n  <input type=\"text\" id=\"txtUserName\" id=\"txtUserName\" [(ngModel)]=\"userName\" >\r\n</div>\r\n<div>\r\n  Password:\r\n</div>\r\n<div>\r\n  <input type=\"password\" id=\"txtPassword\" id=\"txtPassword\" [(ngModel)]=\"password\" >\r\n</div>\r\n<div>\r\n  Confirm Password:\r\n</div>\r\n<div>\r\n  <input type=\"password\" id=\"txtConfirmPassword\" id=\"txtConfirmPassword\" [(ngModel)]=\"confirmPassword\" >\r\n</div>\r\n<div>\r\n  <input type=\"button\" value=\"Register\" (click)=\"handleSubmit()\" >\r\n</div>\r\n\r\n"

/***/ }),

/***/ "./src/app/register/register.component.ts":
/*!************************************************!*\
  !*** ./src/app/register/register.component.ts ***!
  \************************************************/
/*! exports provided: RegisterComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "RegisterComponent", function() { return RegisterComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var _entities_user__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ../entities/user */ "./src/app/entities/user.ts");




var RegisterComponent = /** @class */ (function () {
    function RegisterComponent(shoppingListsService) {
        this.shoppingListsService = shoppingListsService;
        this.firstName = "";
        this.lastName = "";
        this.userName = "";
        this.password = "";
    }
    RegisterComponent.prototype.ngOnInit = function () {
    };
    RegisterComponent.prototype.getFormErrors = function () {
        var errors = [];
        if (this.firstName === "") {
            errors.push("First name is required");
        }
        if (this.lastName === "") {
            errors.push("Last name is required");
        }
        if (this.userName === "") {
            errors.push("User name is required");
        }
        if (this.password === "") {
            errors.push("Password is required");
        }
        if (this.password !== this.confirmPassword) {
            errors.push("Make sure the password and confirmed password match");
        }
        return errors;
    };
    RegisterComponent.prototype.handleSubmit = function () {
        var errors = this.getFormErrors();
        if (errors.length == 0) {
            var user = new _entities_user__WEBPACK_IMPORTED_MODULE_3__["User"]();
            user.firstName = this.firstName;
            user.lastName = this.lastName;
            user.username = this.userName;
            user.password = this.password;
            this.shoppingListsService.register(user);
        }
        else {
            errors.forEach(function (x) {
                alert(x);
            });
        }
    };
    RegisterComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-register',
            template: __webpack_require__(/*! ./register.component.html */ "./src/app/register/register.component.html"),
            styles: [__webpack_require__(/*! ./register.component.css */ "./src/app/register/register.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["ShoppingListsService"]])
    ], RegisterComponent);
    return RegisterComponent;
}());



/***/ }),

/***/ "./src/app/shopping-lists.service.ts":
/*!*******************************************!*\
  !*** ./src/app/shopping-lists.service.ts ***!
  \*******************************************/
/*! exports provided: BaseResponse, BasicRequest, ListShoppingListsResponse, ListShoppingListItemsRequest, ListShoppingListItemsResponse, WalmartProductSearchRequest, WalmartProductSearchResponse, DeleteShoppingListItemRequest, CreateShoppingListItemRequest, CreateShoppingListItemResponse, ShoppingListsService */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BaseResponse", function() { return BaseResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "BasicRequest", function() { return BasicRequest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ListShoppingListsResponse", function() { return ListShoppingListsResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ListShoppingListItemsRequest", function() { return ListShoppingListItemsRequest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ListShoppingListItemsResponse", function() { return ListShoppingListItemsResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WalmartProductSearchRequest", function() { return WalmartProductSearchRequest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "WalmartProductSearchResponse", function() { return WalmartProductSearchResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "DeleteShoppingListItemRequest", function() { return DeleteShoppingListItemRequest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateShoppingListItemRequest", function() { return CreateShoppingListItemRequest; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "CreateShoppingListItemResponse", function() { return CreateShoppingListItemResponse; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ShoppingListsService", function() { return ShoppingListsService; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common_http__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/common/http */ "./node_modules/@angular/common/fesm5/http.js");
/* harmony import */ var rxjs__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs */ "./node_modules/rxjs/_esm5/index.js");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ../environments/environment */ "./src/environments/environment.ts");






var httpOptions = {
    headers: new _angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpHeaders"]({ 'Content-Type': 'application/json' })
};
var BaseResponse = /** @class */ (function () {
    function BaseResponse() {
    }
    return BaseResponse;
}());

var BasicRequest = /** @class */ (function () {
    function BasicRequest() {
    }
    return BasicRequest;
}());

var ListShoppingListsResponse = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](ListShoppingListsResponse, _super);
    function ListShoppingListsResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return ListShoppingListsResponse;
}(BaseResponse));

var ListShoppingListItemsRequest = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](ListShoppingListItemsRequest, _super);
    function ListShoppingListItemsRequest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return ListShoppingListItemsRequest;
}(BasicRequest));

var ListShoppingListItemsResponse = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](ListShoppingListItemsResponse, _super);
    function ListShoppingListItemsResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return ListShoppingListItemsResponse;
}(BaseResponse));

var WalmartProductSearchRequest = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](WalmartProductSearchRequest, _super);
    function WalmartProductSearchRequest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return WalmartProductSearchRequest;
}(BasicRequest));

var WalmartProductSearchResponse = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](WalmartProductSearchResponse, _super);
    function WalmartProductSearchResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return WalmartProductSearchResponse;
}(BaseResponse));

var DeleteShoppingListItemRequest = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](DeleteShoppingListItemRequest, _super);
    function DeleteShoppingListItemRequest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return DeleteShoppingListItemRequest;
}(BasicRequest));

var CreateShoppingListItemRequest = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](CreateShoppingListItemRequest, _super);
    function CreateShoppingListItemRequest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return CreateShoppingListItemRequest;
}(BasicRequest));

var CreateShoppingListItemResponse = /** @class */ (function (_super) {
    tslib__WEBPACK_IMPORTED_MODULE_0__["__extends"](CreateShoppingListItemResponse, _super);
    function CreateShoppingListItemResponse() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return CreateShoppingListItemResponse;
}(Response));

var ShoppingListsService = /** @class */ (function () {
    function ShoppingListsService(http) {
        this.http = http;
    }
    ShoppingListsService.prototype.getShoppingListsUrl = function () {
        return _environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + '/GroceryZen/ListShoppingLists';
    };
    ShoppingListsService.prototype.deleteShoppingListItemUrl = function () {
        return _environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + '/GroceryZen/DeleteShoppingListItem';
    };
    ShoppingListsService.prototype.getShoppingListsItemsUrl = function () {
        return _environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + '/GroceryZen/ListShoppingListItems';
    };
    ShoppingListsService.prototype.getWalmartProductSearchUrl = function () {
        return _environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + '/GroceryZen/ListProductsForSearch';
    };
    ShoppingListsService.prototype.getCreateShoppingListItemUrl = function () {
        return _environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + '/GroceryZen/CreateShoppingListItem';
    };
    ShoppingListsService.prototype.getShoppingLists = function (request) {
        var _this = this;
        return this.http.post(this.getShoppingListsUrl(), request, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return _this.log('fetched shopping lists'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('getShoppingLists', null)));
    };
    ShoppingListsService.prototype.getShoppingListItems = function (request) {
        var _this = this;
        return this.http.post(this.getShoppingListsItemsUrl(), request, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return _this.log('fetched shopping list items'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('getShoppingListItems', null)));
    };
    ShoppingListsService.prototype.deleteShoppingListItem = function (request) {
        var _this = this;
        return this.http.post(this.deleteShoppingListItemUrl(), request, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return _this.log('deleted shopping list item'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('deleteShoppingListItem', null)));
    };
    ShoppingListsService.prototype.walmartProductSearch = function (request) {
        var _this = this;
        return this.http.post(this.getWalmartProductSearchUrl(), request, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return _this.log('fetched shopping list items'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('walmartProductSearch', null)));
    };
    ShoppingListsService.prototype.createShoppingListItem = function (request) {
        var _this = this;
        return this.http.post(this.getCreateShoppingListItemUrl(), request, httpOptions)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["tap"])(function (_) { return _this.log('createShoppingListItem done'); }), Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["catchError"])(this.handleError('createShoppingListItem', null)));
    };
    ShoppingListsService.prototype.login = function (username, password) {
        return this.http.post(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users/authenticate", { username: username, password: password })
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_4__["map"])(function (user) {
            // login successful if there's a jwt token in the response
            if (user && user.token) {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
            }
            return user;
        }));
    };
    ShoppingListsService.prototype.logout = function () {
        localStorage.removeItem('currentUser');
    };
    ShoppingListsService.prototype.getAll = function () {
        return this.http.get(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users");
    };
    ShoppingListsService.prototype.getById = function (id) {
        return this.http.get(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users/" + id);
    };
    ShoppingListsService.prototype.register = function (user) {
        return this.http.post(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users/register", user);
    };
    ShoppingListsService.prototype.update = function (user) {
        return this.http.put(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users/" + user.id, user);
    };
    ShoppingListsService.prototype.delete = function (id) {
        return this.http.delete(_environments_environment__WEBPACK_IMPORTED_MODULE_5__["environment"].apiUrl + "/users/" + id);
    };
    ShoppingListsService.prototype.handleError = function (operation, result) {
        var _this = this;
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            // TODO: send the error to remote logging infrastructure
            console.error(error); // log to console instead
            // TODO: better job of transforming error for user consumption
            _this.log(operation + " failed: " + error.message);
            // Let the app keep running by returning an empty result.
            return Object(rxjs__WEBPACK_IMPORTED_MODULE_3__["of"])(result);
        };
    };
    ShoppingListsService.prototype.log = function (message) {
        console.log(message);
    };
    ShoppingListsService = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Injectable"])({
            providedIn: 'root'
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_angular_common_http__WEBPACK_IMPORTED_MODULE_2__["HttpClient"]])
    ], ShoppingListsService);
    return ShoppingListsService;
}());



/***/ }),

/***/ "./src/app/shopping-lists/shopping-lists.component.css":
/*!*************************************************************!*\
  !*** ./src/app/shopping-lists/shopping-lists.component.css ***!
  \*************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ".align-right\r\n{\r\n    position: absolute;\r\n    right:0px;\r\n}\r\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvc2hvcHBpbmctbGlzdHMvc2hvcHBpbmctbGlzdHMuY29tcG9uZW50LmNzcyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQTs7SUFFSSxrQkFBa0I7SUFDbEIsU0FBUztBQUNiIiwiZmlsZSI6InNyYy9hcHAvc2hvcHBpbmctbGlzdHMvc2hvcHBpbmctbGlzdHMuY29tcG9uZW50LmNzcyIsInNvdXJjZXNDb250ZW50IjpbIi5hbGlnbi1yaWdodFxyXG57XHJcbiAgICBwb3NpdGlvbjogYWJzb2x1dGU7XHJcbiAgICByaWdodDowcHg7XHJcbn0iXX0= */"

/***/ }),

/***/ "./src/app/shopping-lists/shopping-lists.component.html":
/*!**************************************************************!*\
  !*** ./src/app/shopping-lists/shopping-lists.component.html ***!
  \**************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<mat-toolbar>\r\n    <span>Shopping Lists</span>\r\n</mat-toolbar>\r\n\r\n<mat-card>    \r\n    <mat-list>\r\n      <mat-list-item *ngFor=\"let record of records\">\r\n        <a routerLink=\"/edit-shopping-list/{{record.id}}\">\r\n          {{record.name}}\r\n        </a>\r\n        &nbsp;\r\n        <button \r\n          type=\"button\" \r\n          class=\"btn btn-danger align-right\" \r\n          mat-raised-button color=\"primary\" \r\n          >\r\n          Archive\r\n        </button>\r\n  \r\n      </mat-list-item>\r\n    </mat-list>\r\n</mat-card>      \r\n\r\n"

/***/ }),

/***/ "./src/app/shopping-lists/shopping-lists.component.ts":
/*!************************************************************!*\
  !*** ./src/app/shopping-lists/shopping-lists.component.ts ***!
  \************************************************************/
/*! exports provided: ShoppingListsComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "ShoppingListsComponent", function() { return ShoppingListsComponent; });
/* harmony import */ var tslib__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! tslib */ "./node_modules/tslib/tslib.es6.js");
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ../shopping-lists.service */ "./src/app/shopping-lists.service.ts");
/* harmony import */ var rxjs_operators__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! rxjs/operators */ "./node_modules/rxjs/_esm5/operators/index.js");





var ShoppingListsComponent = /** @class */ (function () {
    function ShoppingListsComponent(shoppingListService) {
        this.shoppingListService = shoppingListService;
    }
    ShoppingListsComponent.prototype.getList = function () {
        var _this = this;
        var request = new _shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["BasicRequest"]();
        request.userId = "fixme";
        this.shoppingListService.getShoppingLists(request)
            .pipe(Object(rxjs_operators__WEBPACK_IMPORTED_MODULE_3__["first"])())
            .subscribe(function (response) {
            _this.records = response.records;
            console.log(_this.records);
        });
    };
    ShoppingListsComponent.prototype.ngOnInit = function () {
        this.getList();
    };
    ShoppingListsComponent = tslib__WEBPACK_IMPORTED_MODULE_0__["__decorate"]([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_1__["Component"])({
            selector: 'app-shopping-lists',
            template: __webpack_require__(/*! ./shopping-lists.component.html */ "./src/app/shopping-lists/shopping-lists.component.html"),
            styles: [__webpack_require__(/*! ./shopping-lists.component.css */ "./src/app/shopping-lists/shopping-lists.component.css")]
        }),
        tslib__WEBPACK_IMPORTED_MODULE_0__["__metadata"]("design:paramtypes", [_shopping_lists_service__WEBPACK_IMPORTED_MODULE_2__["ShoppingListsService"]])
    ], ShoppingListsComponent);
    return ShoppingListsComponent;
}());



/***/ }),

/***/ "./src/environments/environment.ts":
/*!*****************************************!*\
  !*** ./src/environments/environment.ts ***!
  \*****************************************/
/*! exports provided: environment */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "environment", function() { return environment; });
// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.
var environment = {
    production: false,
    apiUrl: 'http://localhost:8080'
};
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.


/***/ }),

/***/ "./src/main.ts":
/*!*********************!*\
  !*** ./src/main.ts ***!
  \*********************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/platform-browser-dynamic */ "./node_modules/@angular/platform-browser-dynamic/fesm5/platform-browser-dynamic.js");
/* harmony import */ var _app_app_module__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./app/app.module */ "./src/app/app.module.ts");
/* harmony import */ var _environments_environment__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./environments/environment */ "./src/environments/environment.ts");




if (_environments_environment__WEBPACK_IMPORTED_MODULE_3__["environment"].production) {
    Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["enableProdMode"])();
}
Object(_angular_platform_browser_dynamic__WEBPACK_IMPORTED_MODULE_1__["platformBrowserDynamic"])().bootstrapModule(_app_app_module__WEBPACK_IMPORTED_MODULE_2__["AppModule"])
    .catch(function (err) { return console.error(err); });


/***/ }),

/***/ 0:
/*!***************************!*\
  !*** multi ./src/main.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__(/*! C:\dev\groceryzen\groceryzen-angular\src\main.ts */"./src/main.ts");


/***/ })

},[[0,"runtime","vendor"]]]);
//# sourceMappingURL=main.js.map