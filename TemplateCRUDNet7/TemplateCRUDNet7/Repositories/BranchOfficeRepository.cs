using Microsoft.EntityFrameworkCore;
using TemplateCRUDNet7.Context;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Entities;
using TemplateCRUDNet7.Helpers;

namespace TemplateCRUDNet7.Repositories
{
    public class BranchOfficeRepository : IBranchOfficeRepository
    {
        private readonly TemplateContext _context;

        public BranchOfficeRepository(TemplateContext templateContext)
        {
            _context = templateContext;
        }
        public async Task<ResponseDto<BranchDetailOfficeDto>> GetBranchOffice(Guid id)
        {
            var entity = await _context.TableBranchOffices.AnyAsync(x => x.Id == id);
            if (!entity)
                return Responses.ResponseNotFound<BranchDetailOfficeDto>("No se encontro la sucursal.");

            var data = await _context.TableBranchOffices.Include(x => x.TypeCurrency).Where(y => y.Id == id)
                .Select(y => new BranchDetailOfficeDto
                {
                    Address = y.Address,
                    BranchOfficeId = y.Id,
                    CurrencyDescription = y.TypeCurrency.Description,
                    Description = y.Description,
                    Code = y.Code,
                    Identification = y.Identification,
                    CurrencyId = y.TypeCurrency.Id,
                    DateCreated = y.DateCreated,
                    DateUpdated = y.DateUpdated
                }).FirstOrDefaultAsync();
            return Responses.ResponseSuccess(data);
        }

        public async Task<ResponseDto<IEnumerable<BranchOfficeDto>>> GetBranchOffices()
        {
            var data = await _context.TableBranchOffices.Where(y => y.IsDeleted == false)
                .Select(y => new BranchOfficeDto
                {
                    BranchOfficeId = y.Id,
                    Code = y.Code,
                    Description = y.Description,
                }).ToListAsync();
            return Responses.ResponseSuccess<IEnumerable<BranchOfficeDto>>(data);
        }

        public async Task<ResponseDto<Unit>> CreateBranchOffice(BranchOfficeCreateDto dto)
        {
            try
            {
                var entity = new BranchOffice
                {
                    Address = dto.Address.Trim(),
                    Description = dto.Description.Trim(),
                    CurrencyId = dto.CurrencyId,
                    DateCreated = DateTime.Now,
                    Code = dto.Code,
                    Identification = dto.Identification.Trim()
                };
                var validate = ValidateDataToCreated(entity);
                if (validate != null)
                    return validate;

                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Responses.ResponseCreated();
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al crear la sucursal.", ex);
            }
        }



        public async Task<ResponseDto<Unit>> UpdateBranchOffice(Guid id, BranchOfficeUpdateDto dto)
        {
            try
            {
                var entity = _context.TableBranchOffices.Find(id);
                if (entity is null)
                    return Responses.ResponseNotFound<Unit>("No se encontro la sucursal");

                var validate = ValidateDataToUpdate(dto, id);
                if (validate != null)
                    return validate;

                entity.Identification = dto.Identification.Trim();
                entity.Address = dto.Address.Trim();
                entity.Description = dto.Description.Trim();
                entity.CurrencyId = dto.CurrencyId;
                entity.DateUpdated = DateTime.Now;
                entity.Code = dto.Code;
                _context.TableBranchOffices.Update(entity);
                await _context.SaveChangesAsync();
                return Responses.ResponseUpdated();
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al actualizar la sucursal.", ex);
            }
        }

        public async Task<ResponseDto<Unit>> SoftDeleteBranchOffice(Guid id)
        {
            try
            {
                var entity = _context.TableBranchOffices.Find(id);
                if (entity is null)
                    return Responses.ResponseNotFound<Unit>("No se encontro la sucursal");

                entity.IsDeleted = true;
                _context.TableBranchOffices.Update(entity);
                await _context.SaveChangesAsync();
                return Responses.ResponseUpdated("Se ha eliminado satisfactoriamente.");
            }
            catch (Exception ex)
            {
                return Responses.ResponseInternalErrorServer("Error al eliminar la sucursal", ex);
            }
        }
        public async Task<ResponseDto<IEnumerable<CurrencyDto>>> GetCurrencies()
        {
            var data = await _context.TableCurrency.Select(y => new CurrencyDto
            {
                CurrencyId = y.Id,
                CurrencyDescription = y.Description + " - " + y.Acronym
            }).ToListAsync();
            return Responses.ResponseSuccess<IEnumerable<CurrencyDto>>(data);
        }

        private ResponseDto<Unit> ValidateDataToCreated(BranchOffice entity)
        {
            List<ErrorDto> errores = new();

            var existCurrency = _context.TableCurrency.Any(x => x.Id == entity.CurrencyId);
            if (!existCurrency)
                Responses.ResponseNotFound<Unit>("No existe la moneda.");

            var existIdentification = _context.TableBranchOffices.Any(x => x.Identification.ToUpper() == entity.Identification.ToUpper());

            if (existIdentification)
                errores.Add(new ErrorDto("Ya existe una sucursal con la misma identificación."));

            var existDescription = _context.TableBranchOffices.Any(x => x.Description.ToUpper() == entity.Description.ToUpper());

            if (existDescription)
                errores.Add(new ErrorDto("Ya existe una sucursal con la misma descripción."));

            var existCode = _context.TableBranchOffices.Any(x => x.Code == entity.Code);

            if (existCode)
                errores.Add(new ErrorDto("Ya existe una sucursal con el mismo código."));

            return errores.Any() ? Responses.ResponseConflict(errores) : null;
        }

        private ResponseDto<Unit> ValidateDataToUpdate(BranchOfficeUpdateDto entity, Guid Id)
        {
            List<ErrorDto> errores = new();

            var existCurrency = _context.TableCurrency.Any(x => x.Id == entity.CurrencyId);
            if (!existCurrency)
                Responses.ResponseNotFound<Unit>("No existe la moneda.");

            var existIdentification = _context.TableBranchOffices.Any(x => x.Identification.ToUpper() == entity.Identification.ToUpper()
             && x.Id != Id);

            if (existIdentification)
                errores.Add(new ErrorDto("Ya existe una sucursal con la misma identificación."));

            var existDescription = _context.TableBranchOffices.Any(x => x.Description.ToUpper() == entity.Description.ToUpper()
            && x.Id != Id);

            if (existDescription)
                errores.Add(new ErrorDto("Ya existe una sucursal con la misma descripción."));

            var existCode = _context.TableBranchOffices.Any(x => x.Code == entity.Code && x.Id != Id);

            if (existCode)
                errores.Add(new ErrorDto("Ya existe una sucursal con el mismo código."));

            return errores.Any() ? Responses.ResponseConflict(errores) : null;
        }


    }
}
