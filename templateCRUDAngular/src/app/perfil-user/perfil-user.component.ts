import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { AccountService } from '../CRUD/services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-perfil-user',
  templateUrl: './perfil-user.component.html',
  styleUrls: ['./perfil-user.component.css']
})
export class PerfilUserComponent implements OnInit {
  public valForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private _accountService: AccountService,
    private router: Router, private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.valForm = this.fb.group({
      Email: this.fb.control(null),
      Name: this.fb.control(null),
    });
    this.getDataUser();
  }
  getDataUser() {
    this._accountService.getDataUser().subscribe(
      {
        next: response => {
          this.valForm.patchValue(response.Data);
        },
        error: err => {
          const errors = err.error.Errors;
          if (errors && errors.length > 0) {
            const errorMessages = errors.map((x: ErrorDto) => x.Message).join("\n");
            alert("Errores:\n" + errorMessages);
          }
        }
      }
    );
  }

  navigateListTasks() {
    this.router.navigate(['/gestion-tareas']);
  }

}
