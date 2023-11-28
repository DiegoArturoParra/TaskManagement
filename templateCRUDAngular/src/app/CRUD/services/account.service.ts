import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { appSettings } from 'src/utils/constants';
import { LoginDto } from '../models/LoginDto';
import { Observable } from 'rxjs';
import { ResponseDto, Unit } from 'src/utils/Response';
import { UserRegisterDto } from '../models/UserDto';
import { TokenDto } from '../models/TokenDto';

@Injectable({
  providedIn: 'root'
})
export class AccountService {


  private url = `${appSettings.url_api_app}/account`;

  constructor(private http: HttpClient) { }

  login(data: LoginDto): Observable<ResponseDto<TokenDto>> {
    return this.http.post<ResponseDto<TokenDto>>(`${this.url}/login`, data);
  }

  register(data: UserRegisterDto): Observable<ResponseDto<Unit>> {
    return this.http.post<ResponseDto<Unit>>(`${this.url}/register`, data);
  }

  getDataUser(): Observable<ResponseDto<UserRegisterDto>> {
    return this.http.get<ResponseDto<UserRegisterDto>>(`${this.url}/info-person`);
  }
}
