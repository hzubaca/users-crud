import { HttpClientModule, HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UsersHttpInterceptor } from './http.interceptor';
import { UsersListComponent } from './components/users-list/users-list.component';
import { UserComponent } from './components/user/user.component';
import { MatSortModule } from '@angular/material/sort';
import { AssignPermissionsComponent } from './components/assign-permissions/assign-permissions.component';

@NgModule({
  declarations: [
    AppComponent,
    UsersListComponent,
    UserComponent,
    AssignPermissionsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatCardModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatSortModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: UsersHttpInterceptor,
      multi: true
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
