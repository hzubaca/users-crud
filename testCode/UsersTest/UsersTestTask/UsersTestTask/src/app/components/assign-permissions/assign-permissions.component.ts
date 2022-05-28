import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { UserPermissionsService } from '../../services/permissions.service';

@Component({
  selector: 'app-assign-permissions',
  templateUrl: './assign-permissions.component.html',
  styleUrls: ['./assign-permissions.component.css']
})
export class AssignPermissionsComponent implements OnInit {

  id!: number;
  formGroup!: FormGroup;
  permissions = [
    {
      id: 1,
      code: "View"
    },
    {
      id: 2,
      code: "Add"
    },
    {
      id: 3,
      code: "Edit"
    },
    {
      id: 4,
      code: "Delete"
    },
  ];

  constructor(private userPermissions: UserPermissionsService, private route: ActivatedRoute, private formBuilder: FormBuilder, private location: Location, private router: Router) { }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    this.formGroup = this.formBuilder.group({
      userId: [null, [Validators.required]],
      permissionIds: [null]
    });

    this.userPermissions.getUserPermissions(this.id).subscribe(response => {
      this.formGroup.patchValue({
        userId: this.id,
        permissionIds: response.permissionIds
      });
    });
  }

  cancel(): void {
    this.location.back();
    this.formGroup.reset();
  }

  savePermissions(): void {
    this.userPermissions.assignPermissions(this.id, this.formGroup.get('permissionIds')?.value).subscribe(() => {
      this.router.navigateByUrl('');
    });
  }

}
