import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AssignPermissionsComponent } from './components/assign-permissions/assign-permissions.component';
import { UserComponent } from './components/user/user.component';
import { UsersListComponent } from './components/users-list/users-list.component';
import { UserPermissionsService } from './services/permissions.service';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: UsersListComponent },
  { path: 'user-page', component: UserComponent },
  { path: 'user-page/:id', component: UserComponent },
  { path: 'user-permissions/:id', component: AssignPermissionsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
