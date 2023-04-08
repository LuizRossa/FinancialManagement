import { Injectable } from '@angular/core';
import { Users } from '../models/Users';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor() { }

  public getUsers() : Users[] {
    let user = new Users();
    user.id = 1;
    user.name = "Luiz";
    user.cpf = "0001";
    user.rg = "0002";
    user.email = "teste@outlook.com";

    return [user];
  }
}
