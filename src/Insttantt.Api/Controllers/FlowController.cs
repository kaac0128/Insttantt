using AutoMapper;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories.ProjectName.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Api.Controllers
{
    [Route("api/flows")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FlowController> _logger;

        public FlowController(IFlowRepository flowRepository, IMapper mapper, ILogger<FlowController> logger)
        {
            _flowRepository = flowRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetFlows()
        {
            try
            {
                var flows = _flowRepository.GetAllAsync().Result;

                if (!flows.Any())
                {
                    return NoContent();
                }

                var flowModels = _mapper.Map<List<FlowModel>>(flows);
                _logger.LogInformation("Envio de datos exitoso", new { message = "success", passed = true });
                return Ok(flowModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer los datos");
                throw ex;
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetFlow(int id)
        {
            try
            {
                var flow = _flowRepository.GetByIdAsync(id).Result;

                if (flow == null)
                {
                    return NotFound();
                }

                var flowModel = _mapper.Map<FlowModel>(flow);
                _logger.LogInformation("Envio de datos exitoso", new { message = "success", passed = true });
                return Ok(flowModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al traer los datos");
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult CreateFlow([FromBody] FlowModel flowModel)
        {
            try
            {
                if (flowModel == null)
                {
                    return BadRequest();
                }

                var flow = _mapper.Map<Flow>(flowModel);

                _flowRepository.AddAsync(flow).Wait();
                _logger.LogInformation("Creacion de datos exitosa", new { message = "success", passed = true });
                return CreatedAtAction("GetFlow", new { id = flow.FlowID }, flow.FlowID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear los datos");
                throw ex;
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateFlow(int id, [FromBody] FlowModel flowModel)
        {
            try
            {
                if (flowModel == null || id != flowModel.FlowID)
                {
                    return BadRequest();
                }

                var existingFlow = _flowRepository.GetByIdAsync(id).Result;

                if (existingFlow == null)
                {
                    return NotFound();
                }

                _mapper.Map(flowModel, existingFlow);

                _flowRepository.UpdateAsync(existingFlow).Wait();
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
        public IActionResult DeleteFlow(int id)
        {
            try
            {
                var flow = _flowRepository.GetByIdAsync(id).Result;

                if (flow == null)
                {
                    return NotFound();
                }

                _flowRepository.DeleteAsync(id).Wait();
                _logger.LogInformation("Eliminacion de datos exitosa", new {message = "success", passed= true});

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
