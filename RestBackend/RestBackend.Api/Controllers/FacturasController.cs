using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestBackend.Api.Resources;
using RestBackend.Api.Validators;
using RestBackend.Core.Models;
using RestBackend.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        readonly IFacturaService _dataService;
        private readonly IMapper _mapper;

        public FacturasController(
            IMapper mapper,
            IFacturaService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<FacturaResource>>> GetAll()
        {
            var models = await _dataService.GetAll();
            var modelsResources = _mapper.Map<IEnumerable<Factura>, IEnumerable<FacturaResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaResource>> GetById(int id)
        {
            var model = await _dataService.GetById(id);
            var modelResource = _mapper.Map<Factura, FacturaResource>(model);

            return Ok(modelResource);
        }

        [HttpPost()]
        public async Task<ActionResult<FacturaResource>> Create([FromBody] NuevoFacturaResource saveResource)
        {
            #region [ Model Validations ]

            var validator = new FacturaResourceValidator();
            var validationResult = await validator.ValidateAsync(saveResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            #endregion

            var modelToCreate = _mapper.Map<NuevoFacturaResource, Factura>(saveResource);
            var newModel = await _dataService.Create(modelToCreate);

            var model = await _dataService
                .GetById(newModel.Id);

            return Created(nameof(GetById), _mapper.Map<Factura, FacturaResource>(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FacturaResource>> Update(int id, [FromBody] NuevoFacturaResource saveResource)
        {
            #region [ Model Validations ]

            var validator = new FacturaResourceValidator();
            var validationResult = await validator.ValidateAsync(saveResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            #endregion

            var source = await _dataService.GetById(id);
            if (source == default)
                return BadRequest($"El producto {id} no existe.");

            var modelToUpdate = _mapper.Map<NuevoFacturaResource, Factura>(saveResource);
            await _dataService.Update(modelToUpdate, source);

            var model = await _dataService.GetById(id);
            return Created(nameof(GetById), _mapper.Map<Factura, FacturaResource>(model));
        }
    }
}
