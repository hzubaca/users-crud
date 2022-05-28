import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { UsersPermissionsResponse } from '../models/response/user-permissions-response.model';

@Injectable({
  providedIn: 'root'
})
export class UserPermissionsService {

  selectedUser!: User;

  constructor(private http: HttpClient) { }

  getUserPermissions(userId: number): Observable<UsersPermissionsResponse> {
    return this.http.get<any>(`Permission/${userId}`);
  }

  assignPermissions(userId: number, permissionIds: number[]): Observable<User> {
    return this.http.post<Observable<User>>('Permission', { userId, permissionIds }, { observe: 'response' })
      .pipe(map((response: HttpResponse<any>) => {
        return response.body;
      }));
  }
}
