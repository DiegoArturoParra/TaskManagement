import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CrudService } from '../../services/crud.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CurrencyDto } from '../../models/CurrencyDto';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-CreateUpdate',
  templateUrl: './CreateUpdate.component.html',
  styleUrls: ['./CreateUpdate.component.css']
})
export class CreateUpdateComponent implements OnInit {

  listaCurrencies!: CurrencyDto[];
  public valForm!: FormGroup;
  branchOfficeId?: string;
  fechaActual?: Date;
  licencia?: any;
  isEdit: boolean = false;
  constructor(
    private fb: FormBuilder,
    private _crudService: CrudService,
    private router: Router, private route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
    this.valForm = this.fb.group({
      Description: this.fb.control(null, [Validators.required]),
      Code: this.fb.control(null, [Validators.required]),
      Identification: this.fb.control(null, [Validators.required]),
      Address: this.fb.control(null, [Validators.required]),
      CurrencyId: this.fb.control(null, [Validators.required]),
    });
    if (this.router.url.includes('actualizar')) {
      this.isEdit = true;
    }
    this.getBranchOffice();
    this.LoadCurrencies();
  }
  getBranchOffice() {
    if (this.isEdit) {
      this.branchOfficeId = this.route.snapshot.params['BranchOfficeId'];
      this._crudService.getDetailData(this.branchOfficeId).subscribe(
        {
          next: response => {
            this.valForm.patchValue(response.Data);
          },
          error: err => {
            console.log(err);
          }
        }
      );
    }
  }
  LoadCurrencies() {
    this._crudService.getDataCurrencies().subscribe(
      {
        next: response => {
          console.log(response);
          this.listaCurrencies = response.Data;
          if (!this.isEdit) {
            this.TypeCurrencyId?.setValue(this.listaCurrencies[0].CurrencyId);
          }
        },
        error: err => {
          console.log(err);
        }
      }
    );
  }
  get TypeCurrencyId() {
    return this.valForm.get('CurrencyId');
  }
  get Code() {
    return this.valForm.get('Code');
  }
  get Address() {
    return this.valForm.get('Address');
  }
  get Identification() {
    return this.valForm.get('Identification');
  }

  get Description() {
    return this.valForm.get('Description');
  }

  devolver() {
    this.router.navigate(['/sucursales']);
  }
  addBranchOffice() {
    if (!this.isEdit) {
      this._crudService.create(this.valForm?.value).subscribe(
        {
          next: response => {
            this.router.navigate(['/', 'sucursales']).then(
              (nav) => {
                alert(response.Message);
              },
            );
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
    else {
      this._crudService.update(this.valForm?.value, this.branchOfficeId).subscribe(
        {
          next: response => {
            this.router.navigate(['/', 'sucursales']).then(
              (nav) => {
                alert(response.Message);
              },
            );
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
  }
}
