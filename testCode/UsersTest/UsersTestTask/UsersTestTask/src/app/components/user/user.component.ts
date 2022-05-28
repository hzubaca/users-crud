import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { UsersService } from '../../services/users.service';
import { User } from '../../models/user.model';
import { UserPermissionsService } from '../../services/permissions.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  isAdd: boolean = true;
  id!: number;
  formGroup!: FormGroup;

  constructor(private usersService: UsersService, private userPermissions: UserPermissionsService, private route: ActivatedRoute, private formBuilder: FormBuilder, private location: Location, private router: Router) { }

  ngOnInit(): void {
    this.isAdd = this.route.snapshot.paramMap.get('id') ? false : true;

    if (!this.isAdd) {
      this.id = Number(this.route.snapshot.paramMap.get('id'));
    }

    this.formGroup = this.formBuilder.group({
      firstName: [this.isAdd ? null : this.usersService.selectedUser.firstName, [Validators.required]],
      lastName: [this.isAdd ? null : this.usersService.selectedUser.lastName, [Validators.required]],
      username: [this.isAdd ? null : this.usersService.selectedUser.username, [Validators.required]],
      password: [this.isAdd ? null : this.usersService.selectedUser.password, [Validators.required]],
      email: [this.isAdd ? null : this.usersService.selectedUser.email, [Validators.required]],
      status: [this.isAdd ? null : this.usersService.selectedUser.statusId, Validators.required]
    });
  }

  cancel(): void {
    this.location.back();
    this.formGroup.reset();
  }

  assignPermissions(): void {
    this.router.navigateByUrl(`user-permissions/${this.id}`);
  }

  saveUser(): void {
    if (this.isAdd) {
      const newUser = this.formGroup.getRawValue();
      this.usersService.addUser(newUser).subscribe(() => {
        this.usersService.selectedUser = {} as User;
        this.router.navigateByUrl('');
      });
    }
    else {
      let newUser = this.formGroup.getRawValue();
      newUser.Id = this.usersService.selectedUser.id;
      this.usersService.updateUser(newUser).subscribe(() => {
        this.usersService.selectedUser = {} as User;
        this.router.navigateByUrl('');
      });
    }
  }

}
