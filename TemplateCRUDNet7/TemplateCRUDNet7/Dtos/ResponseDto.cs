using System.Collections.Immutable;
using System.Net;
using TemplateCRUDNet7.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TemplateCRUDNet7.Dtos
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public ImmutableArray<ErrorDto> Errors { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
    public class Responses
    {
        public static ResponseDto<Unit> ResponseBadRequest(List<ErrorDto> errores)
        {
            return new ResponseDto<Unit>
            {
                Data = Unit.Value,
                Errors = errores.ToImmutableArray(),
                Message = "Bad Request",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
        public static ResponseDto<Unit> ResponseConflict(List<ErrorDto> errores)
        {
            return new ResponseDto<Unit>
            {
                Data = Unit.Value,
                Errors = errores.ToImmutableArray(),
                Message = "Conflict",
                StatusCode = HttpStatusCode.Conflict
            };
        }
        public static ResponseDto<T> ResponseSuccess<T>(T data)
        {
            return new ResponseDto<T>
            {
                Data = data,
                Message = "Success",
                Errors = ImmutableArray<ErrorDto>.Empty,
                StatusCode = HttpStatusCode.OK
            };
        }

        public static ResponseDto<Unit> ResponseUpdated(string message = "Actualizado satisfactoriamente.")
        {
            return new ResponseDto<Unit>
            {
                Data = Unit.Value,
                Errors = ImmutableArray<ErrorDto>.Empty,
                Message = message,
                StatusCode = HttpStatusCode.OK
            };
        }
        public static ResponseDto<Unit> ResponseCreated()
        {
            return new ResponseDto<Unit>
            {
                Data = Unit.Value,
                Errors = ImmutableArray<ErrorDto>.Empty,
                Message = "Creado satisfactoriamente.",
                StatusCode = HttpStatusCode.Created
            };
        }

        public static ResponseDto<Unit> ResponseInternalErrorServer(string Message, Exception ex)
        {
            return new ResponseDto<Unit>
            {
                Data = Unit.Value,
                Errors = new ImmutableArray<ErrorDto>()
                {
                    new ErrorDto(ex.Message)
                },
                Message = Message,
                StatusCode = HttpStatusCode.InternalServerError
            };
        }

        public static ResponseDto<T> ResponseNotFound<T>(string message)
        {
            return new ResponseDto<T>
            {
                Data = default,
                Errors = new ImmutableArray<ErrorDto>()
                {
                    new ErrorDto(message)
                },
                Message = string.Empty,
                StatusCode = HttpStatusCode.NotFound
            };
        }
    }
}
