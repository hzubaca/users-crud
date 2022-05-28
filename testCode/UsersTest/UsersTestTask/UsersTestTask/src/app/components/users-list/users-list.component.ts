import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { User } from '../../models/user.model';
import { UsersService } from '../../services/users.service';
import { Router } from '@angular/router';
import { Paging } from '../../models/paging.model';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'username', 'email', 'status', 'edit', 'delete'];
  searchType!: number;
  searchValue!: string;
  users: User[] = [];
  paging: Paging = {
    currentPage: 1,
    pageSize: 1
  };

  dataSource = new MatTableDataSource<User>([]);

  paginator!: MatPaginator;
  sort!: MatSort;

  @ViewChild(MatSort) set matSort(ms: MatSort) {
    this.sort = ms;
    this.setDataSourceAttributes();
  }

  @ViewChild(MatPaginator) set matPaginator(mp: MatPaginator) {
    this.paginator = mp;
    this.setDataSourceAttributes();
  }

  constructor(private usersService: UsersService, public dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    this.getTableData();
  }

  setDataSourceAttributes() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  public handlePaginatorEvent(event?: PageEvent) {
    this.paging = new Paging({ currentPage: event?.pageIndex, pageSize: event?.pageSize });
    this.getTableData();
  }

  addUser(): void {
    this.router.navigateByUrl('/user-page');
  }

  editUser(user: User) {
    this.usersService.selectedUser = user;
    this.router.navigateByUrl(`user-page/${user.id}`);
  }

  deleteUser(user: User) {
    this.usersService.deleteUser(user.id).subscribe(() => {
      this.getTableData();
    });
  }

  private getTableData() {
    this.usersService.getAll(this.searchType, this.searchValue, this.paging).subscribe(response => {
      this.users = response.users;
      this.paging = response.paging;
    });
  }
}
