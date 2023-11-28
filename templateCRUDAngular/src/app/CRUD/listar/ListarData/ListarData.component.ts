import { Component, OnInit } from '@angular/core';
import { CrudService } from '../../services/crud.service';
import { Router } from '@angular/router';
import { TaskDetailDto, TaskDto } from '../../models/TaskDto';
import { ErrorDto } from 'src/utils/Response';

@Component({
  selector: 'app-ListarData',
  templateUrl: './ListarData.component.html',
  styleUrls: ['./ListarData.component.css']
})
export class ListarDataComponent implements OnInit {

  Data?: TaskDto[];
  currentData?: TaskDetailDto;
  currentIndex?= -1;
  constructor(private _crudService: CrudService,
    private router: Router) { }

  ngOnInit() {
    this.LoadData();
  }
  LoadData() {
    this._crudService.getListTasksOfUser().subscribe(
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
  completedTaskCurrent(taskId?: string) {
    this._crudService.completedTask(taskId).subscribe(
      {
        next: response => {
          alert(response.Message);
          this.currentIndex = -1;
          this.LoadData();
          let current = this.Data?.find(x => x.TaskId == taskId);
          this.setActiveData(current, this.currentIndex);
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

  deleteCurrent(TaskId?: string) {
    this._crudService.softDelete(TaskId).subscribe(
      {
        next: response => {
          alert(response.Message);
          this.currentIndex = -1;
          this.LoadData();
          let current = this.Data?.find(x => x.TaskId == TaskId);
          this.setActiveData(current, this.currentIndex);
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

  setActiveData(current?: TaskDto, index?: number): void {
    this._crudService.getDetailTaskIdOfUser(current?.TaskId).subscribe(
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
