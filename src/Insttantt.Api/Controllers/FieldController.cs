using AutoMapper;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/fields")]
    [ApiController]
    public class FieldController : ControllerBase
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FieldController> _logger;

        public FieldController(IFieldRepository fieldRepository, IMapper mapper, ILogger<FieldController> logger)
        {
            _fieldRepository = fieldRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetField(int id)
        {
            try
            {
                var Field = _fieldRepository.GetByIdAsync(id).Result;

                if (Field == null)
                {
                    return NotFound();
                }

                var FieldModel = _mapper.Map<FieldModel>(Field);
                _logger.LogInformation("Envio de datos exitoso", new { message = "success", passed = true });
                return Ok(FieldModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer los datos");
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult CreateField([FromBody] FieldModel fieldModel)
        {
            try
            {
                if (fieldModel == null)
                {
                    return BadRequest();
                }
                var Field = _mapper.Map<Field>(fieldModel);

                _fieldRepository.AddAsync(Field).Wait();
                _logger.LogInformation("Creacion de datos exitosa", new { message = "success", passed = true });
                return CreatedAtAction("GetField", new { id = Field.FieldID }, Field.FieldID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateField(int id, [FromBody] FieldModel fieldModel)
        {
            try
            {
                if (fieldModel == null || id != fieldModel.FieldID)
                {
                    return BadRequest();
                }

                var existingField = _fieldRepository.GetByIdAsync(id).Result;

                if (existingField == null)
                {
                    return NotFound();
                }

                _mapper.Map(fieldModel, existingField);

                _fieldRepository.UpdateAsync(existingField).Wait();
                _logger.LogInformation("Actualizacion de datos exitosa", new { message = "success", passed = true });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteField(int id)
        {
            try
            {
                var Field = _fieldRepository.GetByIdAsync(id).Result;

                if (Field == null)
                {
                    return NotFound();
                }

                _fieldRepository.DeleteAsync(id).Wait();
                _logger.LogInformation("Eliminacion de datos exitosa", new { message = "success", passed = true });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");
                throw ex;
            }

        }
    }
}