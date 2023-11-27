import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../services/crud.service';
import { Router } from '@angular/router';
import { BranchDetailOfficeDto, BranchOfficeDto } from '../../models/BranchOfficeDto';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-ListarData',
  templateUrl: './ListarData.component.html',
  styleUrls: ['./ListarData.component.css']
})
export class ListarDataComponent implements OnInit {
  Data?: BranchOfficeDto[];
  currentData?: BranchDetailOfficeDto;
  currentIndex = -1;
  constructor(private _crudService: CrudService,
    private router: Router) { }

  ngOnInit() {
    this.LoadData();
  }
  LoadData() {
    this._crudService.getData().subscribe(
      {
        next: response => {
          this.Data = response.Data;
        },
        error: err => {
          console.log(err);
        }
      }
    );
  }

  deleteCurrent(BranchOfficeId?: string) {
    this._crudService.softDelete(BranchOfficeId).subscribe(
      {
        next: response => {
          alert(response.Message);
          this.currentIndex = -1;
          this.LoadData();
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
  editCurrent(BranchOfficeId?: string) {
    this.router.navigate(['/sucursales/actualizar/', BranchOfficeId]);
  }

  setActiveData(current: BranchOfficeDto, index: number): void {
    this._crudService.getDetailData(current.BranchOfficeId).subscribe(
      {
        next: response => {
          this.currentData = response.Data;
          this.currentIndex = index;
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
