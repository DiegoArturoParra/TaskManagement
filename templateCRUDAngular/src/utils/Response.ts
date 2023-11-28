export interface ErrorDto {
  Message: string;
}

export interface ResponseDto<T> {
  Message: string;
  Data: T;
  Errors: ErrorDto[];
  StatusCode: number;
}

export interface Unit {

}
