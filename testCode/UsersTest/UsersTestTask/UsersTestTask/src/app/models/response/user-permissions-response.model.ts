export class UsersPermissionsResponse {

  userId: number
  permissionIds: number[];

  constructor(data: any) {
    this.userId = data.userId;
    this.permissionIds = data.permissionIds;
  }
}
