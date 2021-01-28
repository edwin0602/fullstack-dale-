using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestBackend.Api.Resources;
using RestBackend.Api.Validators;
using RestBackend.Core.Models;
using RestBackend.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        readonly IClienteService _dataService;
        private readonly IMapper _mapper;

        public ClientesController(
            IMapper mapper,
            IClienteService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ClienteResource>>> GetAll()
        {
            var models = await _dataService.GetAll();
            var modelsResources = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResource>> GetById(int id)
        {
            var model = await _dataService.GetById(id);
            var modelResource = _mapper.Map<Cliente, ClienteResource>(model);

            return Ok(modelResource);
        }

        [HttpPost()]
        public async Task<ActionResult<ClienteResource>> Create([FromBody] NuevoClienteResource saveResource)
        {
            #region [ Model Validations ]

            var validator = new ClienteResourceValidator();
            var validationResult = await validator.ValidateAsync(saveResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            #endregion

            var modelToCreate = _mapper.Map<NuevoClienteResource, Cliente>(saveResource);
            var newModel = await _dataService.Create(modelToCreate);

            var model = await _dataService
                .GetById(newModel.Id);

            return Created(nameof(GetById), _mapper.Map<Cliente, ClienteResource>(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteResource>> Update(int id, [FromBody] ClienteResource saveResource)
        {
            var source = await _dataService.GetById(id);
            if (source == default)
                return BadRequest($"El cliente {id} no existe.");

            var modelToUpdate = _mapper.Map<ClienteResource, Cliente>(saveResource);
            await _dataService.Update(modelToUpdate, source);

            var model = await _dataService.GetById(id);
            return Created(nameof(GetById), _mapper.Map<Cliente, ClienteResource>(model));
        }
    }
}
