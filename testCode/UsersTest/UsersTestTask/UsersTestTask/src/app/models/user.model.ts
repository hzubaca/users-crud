export class User {

  id: number;
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password: string;
  status: string;
  statusId: string;

  constructor(data: any) {
    this.id = data.id;
    this.firstName = data.firstName;
    this.lastName = data.firstName;
    this.username = data.username;
    this.email = data.email;
    this.password = data.password;
    this.status = data.status;
    this.statusId = data.statusId;
  }
}
