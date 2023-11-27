using Microsoft.AspNetCore.Mvc;
using TemplateCRUDNet7.Dtos;
using TemplateCRUDNet7.Repositories;

namespace TemplateCRUDNet7.Controllers
{
    [Route("api/branch-offices")]
    [ApiController]
    public class BranchOfficeController : ControllerBase
    {
        private readonly ILogger<BranchOfficeController> _logger;
        private readonly IBranchOfficeRepository _repository;
        public BranchOfficeController(ILogger<BranchOfficeController> logger, IBranchOfficeRepository branchOfficeRepository)
        {
            _logger = logger;
            _repository = branchOfficeRepository;
        }

        [HttpGet]
        [Route("list-currencies")]
        public async Task<IActionResult> ListCurrencies()
        {
            var listado = await _repository.GetCurrencies();
            return Ok(listado);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListBranchOffices()
        {
            var listado = await _repository.GetBranchOffices();
            return Ok(listado);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBranchOffice(Guid id)
        {
            var response = await _repository.GetBranchOffice(id);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatebranchOffice([FromBody] BranchOfficeCreateDto createbranchOffice)
        {
            var response = await _repository.CreateBranchOffice(createbranchOffice);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdatebranchOffice([FromBody] BranchOfficeUpdateDto updateBranchOffice, Guid id)
        {
            var response = await _repository.UpdateBranchOffice(id, updateBranchOffice);
            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut]
        [Route("soft-delete/{id}")]
        public async Task<IActionResult> UpdatebranchOffice(Guid id)
        {
            var response = await _repository.SoftDeleteBranchOffice(id);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}