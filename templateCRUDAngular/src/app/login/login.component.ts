import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../CRUD/services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorDto } from 'src/utils/Response';
import { TokenService } from '../CRUD/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public valForm!: FormGroup;
  IsLogin: boolean = false;
  constructor(
    private fb: FormBuilder,
    private _accountService: AccountService,
    private _tokenService: TokenService,
    private router: Router, private route: ActivatedRoute,
  ) { }

  ngOnInit() {
    this.valForm = this.fb.group({
      Email: this.fb.control(null, [Validators.required, Validators.email]),
      Password: this.fb.control(null, [Validators.required]),
    });
  }

  register() {
    this.router.navigate(['/registrarse']);
  }
  login() {
    this.IsLogin = true;
    this._accountService.login(this.valForm?.value).subscribe(
      {
        next: response => {
          this.router.navigate(['/', 'perfil']).then(
            (nav) => {
              this.IsLogin = false;
              this._tokenService.setToken(response.Data.Token);
            },
          );
        },
        error: err => {
          const errors = err.error.Errors;
          this.IsLogin = false;
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
}
