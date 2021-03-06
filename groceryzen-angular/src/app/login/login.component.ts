import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ShoppingListsService } from '../shopping-lists.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  userName: string = "";
  password: string = "";
  returnUrl: string = "";
  message: string = "";

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private shoppingListsService: ShoppingListsService
  ) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    this.shoppingListsService.logout();
  }

  handleLogin(){
    this.shoppingListsService.login(this.userName, this.password)
    .pipe(first())
    .subscribe(response => 
    { 
      this.message = "";
      this.router.navigate(["/shopping-list"]);
    }, 
    error => {
      this.message = "Enter valid user name and password";
    });
  }

}
