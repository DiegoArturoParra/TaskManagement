import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { appSettings } from 'src/utils/constants';
import { ResponseDto } from 'src/utils/Response';
import { BranchDetailOfficeDto, BranchOfficeDto } from '../models/BranchOfficeDto';
import { CurrencyDto } from '../models/CurrencyDto';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  private url = `${appSettings.url_api_app}`;

  constructor(private http: HttpClient) { }

  getData(): Observable<ResponseDto<BranchOfficeDto[]>> {
    return this.http.get<ResponseDto<BranchOfficeDto[]>>(`${this.url}/list`);
  }

  create(data: any): Observable<any> {
    return this.http.post(`${this.url}/create`, data);
  }

  update(data: any, branchOfficeId?: string): Observable<any> {
    return this.http.put(`${this.url}/update/${branchOfficeId}`, data);
  }

  softDelete(branchOfficeId?: string): Observable<any> {
    return this.http.put(`${this.url}/soft-delete/${branchOfficeId}`, null);
  }

  getDataCurrencies(): Observable<ResponseDto<CurrencyDto[]>> {
    return this.http.get<ResponseDto<CurrencyDto[]>>(`${this.url}/list-currencies`);
  }

  getDetailData(id?: string): Observable<ResponseDto<BranchDetailOfficeDto>> {
    return this.http.get<ResponseDto<BranchDetailOfficeDto>>(`${this.url}/${id}`);
  }
}
