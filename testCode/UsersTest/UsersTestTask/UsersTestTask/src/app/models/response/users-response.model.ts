import { Paging } from "../paging.model";
import { User } from "../user.model";

export class UsersResponse {

  users: User[];
  paging: Paging;

  constructor(data: any) {
    this.users = data.users;
    this.paging = data.paging;
  }
}
