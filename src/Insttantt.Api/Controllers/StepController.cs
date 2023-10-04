using AutoMapper;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/steps")]
    [ApiController]
    public class StepController : ControllerBase
    {
        private readonly IStepRepository _stepRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<StepController> _logger;

        public StepController(IStepRepository stepRepository, IMapper mapper, ILogger<StepController> logger)
        {
            _stepRepository = stepRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetSteps()
        {
            try
            {
                var steps = _stepRepository.GetAllAsync().Result;

                if (!steps.Any())
                {
                    return NoContent();
                }

                var stepModels = _mapper.Map<List<StepModel>>(steps);
                _logger.LogInformation("Envio de datos exitoso", new { message = "success", passed = true });
                return Ok(stepModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer los datos");
                throw ex;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetStep(int id)
        {
            try
            {
                var step = _stepRepository.GetByIdAsync(id).Result;

                if (step == null)
                {
                    return NotFound();
                }

                var stepModel = _mapper.Map<StepModel>(step);
                _logger.LogInformation("Envio de datos exitoso", new { message = "success", passed = true });
                return Ok(stepModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer los datos");
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult CreateStep([FromBody] StepModel stepModel)
        {
            try
            {
                if (stepModel == null)
                {
                    return BadRequest();
                }

                var step = _mapper.Map<Step>(stepModel);

                _stepRepository.AddAsync(step).Wait();
                _logger.LogInformation("Creacion de datos exitosa", new { message = "success", passed = true });
                return CreatedAtAction("GetStep", new { id = step.StepID }, step.StepID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear los datos");
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateStep(int id, [FromBody] StepModel stepModel)
        {
            try
            {
                if (stepModel == null || id != stepModel.StepID)
                {
                    return BadRequest();
                }

                var existingStep = _stepRepository.GetByIdAsync(id).Result;

                if (existingStep == null)
                {
                    return NotFound();
                }

                _mapper.Map(stepModel, existingStep);

                _stepRepository.UpdateAsync(existingStep).Wait();
                _logger.LogInformation("Actualizacion de datos exitosa", new { message = "success", passed = true });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar los datos");
                throw ex;
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStep(int id)
        {
            try
            {
                var step = _stepRepository.GetByIdAsync(id).Result;

                if (step == null)
                {
                    return NotFound();
                }

                _stepRepository.DeleteAsync(id).Wait();
                _logger.LogInformation("Eliminacion de datos exitosa", new { message = "success", passed = true });
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar los datos");
                throw ex;
            }
        }
    }
}
