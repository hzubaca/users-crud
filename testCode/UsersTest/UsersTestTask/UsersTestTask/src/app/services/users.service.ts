import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { UsersResponse } from '../models/response/users-response.model';
import { Paging } from '../models/paging.model';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  selectedUser!: User;

  constructor(private http: HttpClient) { }

  getAll(searchType: number, searchValue: string, paging: Paging): Observable<UsersResponse> {
    const params = new HttpParams({ fromObject: { searchType: searchType, searchValue: searchValue, currentPage: paging.currentPage, pageSize: paging.pageSize } });
    return this.http.get<any>('User', { params });
  }

  addUser(user: User): Observable<User> {
    return this.http.post<Observable<User>>('User', user, { observe: 'response' })
      .pipe(map((response: HttpResponse<any>) => {
        return response.body;
      }));
  }

  updateUser(user: User): Observable<User> {
    return this.http.put<Observable<User>>('User', user, { observe: 'response' })
      .pipe(map((response: HttpResponse<any>) => {
        return response.body;
      }));
  }

  deleteUser(id: number): Observable<any> {
    return this.http.delete<Observable<any>>(`User/delete/${id}`)
      .pipe(map(() => {
        return true;
      }));
  }
}
