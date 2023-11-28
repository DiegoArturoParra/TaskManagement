import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../CRUD/services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public valForm!: FormGroup;
  IsRegister: boolean = false;
  constructor(
    private fb: FormBuilder,
    private _accountService: AccountService,
    private router: Router, private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.valForm = this.fb.group({
      Name: this.fb.control(null, [Validators.required]),
      Email: this.fb.control(null, [Validators.required, Validators.email]),
      Password: this.fb.control(null, [Validators.required]),
    });
  }

  navigateLogin() {
    this.router.navigate(['/']);
  }
  register() {
    this.IsRegister = true;
    this._accountService.register(this.valForm?.value).subscribe(
      {
        next: response => {
          this.router.navigate(['/']).then(
            (nav) => {
              this.IsRegister = false;
              alert(response.Message);
            },
          );
        },
        error: err => {
          this.IsRegister = false;
          const errors = err.error.Errors;
          if (errors && errors.length > 0) {
            const errorMessages = errors.map((x: ErrorDto) => x.Message).join("\n");
            alert("Errores:\n" + errorMessages);
          }
        }
      }
    );
  }

  get Email() {
    return this.valForm.get('Email');
  }
  get Password() {
    return this.valForm.get('Password');
  }
  get Name() {
    return this.valForm.get('Name');
  }
}
