using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Entities;
using TemplateCRUDNet7.Helpers;

namespace TemplateCRUDNet7.Repositories
{
    public interface IBranchOfficeRepository
    {
        Task<ResponseDto<BranchDetailOfficeDto>> GetBranchOffice(Guid id);
        Task<ResponseDto<IEnumerable<BranchOfficeDto>>> GetBranchOffices();
        Task<ResponseDto<Unit>> CreateBranchOffice(BranchOfficeCreateDto entity);
        Task<ResponseDto<Unit>> SoftDeleteBranchOffice(Guid id);
        Task<ResponseDto<Unit>> UpdateBranchOffice(Guid id, BranchOfficeUpdateDto entity);
        Task<ResponseDto<IEnumerable<CurrencyDto>>> GetCurrencies();
    }
}