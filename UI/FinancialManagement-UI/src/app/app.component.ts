import { Component } from '@angular/core';
import { Users } from './models/Users';
import { UsersService } from './services/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FinancialManagement-UI';
  users: Users[] = [];

  constructor(private usersService: UsersService){

  }

  ngOnInit(): void {
    this.users = this.usersService.getUsers();
    console.log(this.users);
  }
}
