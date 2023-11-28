import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ResponseDto, Unit } from 'src/utils/Response';
import { appSettings } from 'src/utils/constants';
import { TaskDetailDto, TaskDto } from '../models/TaskDto';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  private url = `${appSettings.url_api_app}/task-user`;

  constructor(private http: HttpClient) { }

  getListTasksOfUser(): Observable<ResponseDto<TaskDto[]>> {
    return this.http.get<ResponseDto<TaskDto[]>>(`${this.url}/list`);
  }

  create(data: TaskDto): Observable<ResponseDto<Unit>> {
    return this.http.post<ResponseDto<Unit>>(`${this.url}/create`, data);
  }

  completedTask(taskId?: string): Observable<ResponseDto<Unit>> {
    return this.http.put<ResponseDto<Unit>>(`${this.url}/completed/${taskId}`, null);
  }

  softDelete(taskId?: string): Observable<ResponseDto<Unit>> {
    return this.http.put<ResponseDto<Unit>>(`${this.url}/soft-delete/${taskId}`, null);
  }

  getDetailTaskIdOfUser(id?: string): Observable<ResponseDto<TaskDetailDto>> {
    return this.http.get<ResponseDto<TaskDetailDto>>(`${this.url}/detail/${id}`);
  }
}
