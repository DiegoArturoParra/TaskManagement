import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CrudService } from '../../services/crud.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserRegisterDto } from '../../models/UserDto';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-CreateUpdate',
  templateUrl: './CreateUpdate.component.html',
  styleUrls: ['./CreateUpdate.component.css']
})
export class CreateUpdateComponent implements OnInit {

  listaCurrencies!: UserRegisterDto[];
  public valForm!: FormGroup;
  IsCreating: boolean = false;
  constructor(
    private fb: FormBuilder,
    private _crudService: CrudService,
    private router: Router, private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.valForm = this.fb.group({
      Description: this.fb.control(null, [Validators.required]),
      TaskName: this.fb.control(null, [Validators.required]),
    });
  }

  get TaskName() {
    return this.valForm.get('TaskName');
  }

  get Description() {
    return this.valForm.get('Description');
  }

  devolver() {
    this.router.navigate(['/gestion-tareas']);
  }
  addTask() {
    this.IsCreating = true;
    this._crudService.create(this.valForm?.value).subscribe(
      {
        next: response => {
          this.IsCreating = false;
          this.router.navigate(['/', 'gestion-tareas']).then(
            (nav) => {
              alert(response.Message);
            },
          );
        },
        error: err => {
          this.IsCreating = false;
          const errors = err.error.Errors;
          if (errors && errors.length > 0) {
            const errorMessages = errors.map((x: ErrorDto) => x.Message).join("\n");
            alert("Errores:\n" + errorMessages);
          }
        }
      }
    );
  }
}
