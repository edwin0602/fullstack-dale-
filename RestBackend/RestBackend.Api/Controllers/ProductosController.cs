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
    public class ProductosController : ControllerBase
    {
        readonly IProductoService _dataService;
        private readonly IMapper _mapper;

        public ProductosController(
            IMapper mapper,
            IProductoService dataService)
        {
            _mapper = mapper;
            _dataService = dataService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProductoResource>>> GetAll()
        {
            var models = await _dataService.GetAll();
            var modelsResources = _mapper.Map<IEnumerable<Producto>, IEnumerable<ProductoResource>>(models);

            return Ok(modelsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoResource>> GetById(int id)
        {
            var model = await _dataService.GetById(id);
            var modelResource = _mapper.Map<Producto, ProductoResource>(model);

            return Ok(modelResource);
        }

        [HttpPost()]
        public async Task<ActionResult<ProductoResource>> Create([FromBody] NuevoProductoResource saveResource)
        {
            #region [ Model Validations ]

            var validator = new ProductoResourceValidator();
            var validationResult = await validator.ValidateAsync(saveResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            #endregion

            var modelToCreate = _mapper.Map<NuevoProductoResource, Producto>(saveResource);
            var newModel = await _dataService.Create(modelToCreate);

            var model = await _dataService
                .GetById(newModel.Id);

            return Created(nameof(GetById), _mapper.Map<Producto, ProductoResource>(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductoResource>> Update(int id, [FromBody] ProductoResource saveResource)
        {
            var source = await _dataService.GetById(id);
            if (source == default)
                return BadRequest($"El producto {id} no existe.");

            var modelToUpdate = _mapper.Map<ProductoResource, Producto>(saveResource);
            await _dataService.Update(modelToUpdate, source);

            var model = await _dataService.GetById(id);
            return Created(nameof(GetById), _mapper.Map<Producto, ProductoResource>(model));
        }
    }
}
