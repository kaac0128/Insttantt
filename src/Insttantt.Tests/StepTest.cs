
using AutoMapper;
using Insttantt.Api.Controllers;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Insttantt.Tests
{
    public class StepTest
    {
        [Fact]
        public void test_get_steps_with_valid_data()
        {
            var mockStepRepository = new Mock<IStepRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StepController(mockStepRepository.Object, mockMapper.Object);

            var steps = new List<Step>();
            var flow1 = new Flow { FlowName = "Flujo de ejemplo 99" };
            var inputField6 = new Field { FieldName = "prueba" };
            var outputField1 = new Field { FieldName = "Campo de salida 99" };
            var step1 = new Step { StepName = "Paso 1", Flow = flow1 };
            step1.InputField = inputField6;
            step1.OutputField = outputField1;
            steps.Add(step1);


            var stepModels = new List<StepModel>();
            var flowModel1 = new FlowModel { FlowName = "Flujo de ejemplo 99" };
            var inputFieldModel6 = new FieldModel { FieldName = "prueba" };
            var outputFieldModel1 = new FieldModel { FieldName = "Campo de salida 99" };
            var stepModel1 = new StepModel { StepName = "Paso 1", Flow = flowModel1 };
            stepModel1.InputField = inputFieldModel6;
            stepModel1.OutputField = outputFieldModel1;
            stepModels.Add(stepModel1);

            mockStepRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(steps);
            mockMapper.Setup(mapper => mapper.Map<List<StepModel>>(steps)).Returns(stepModels);

            var result = controller.GetSteps();

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(stepModels, okResult.Value);
        }

        [Fact]
        public void test_get_step_with_valid_id()
        {
            var mockStepRepository = new Mock<IStepRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StepController(mockStepRepository.Object, mockMapper.Object);

            var flow1 = new Flow { FlowName = "Flujo de ejemplo 99" };
            var inputField6 = new Field { FieldName = "prueba" };
            var outputField1 = new Field { FieldName = "Campo de salida 99" };
            var step = new Step { StepName = "Paso 1", Flow = flow1 };
            step.InputField = inputField6;
            step.OutputField = outputField1;

            var flowModel1 = new FlowModel { FlowName = "Flujo de ejemplo 99" };
            var inputFieldModel6 = new FieldModel { FieldName = "prueba" };
            var outputFieldModel1 = new FieldModel { FieldName = "Campo de salida 99" };
            var stepModel = new StepModel { StepName = "Paso 1", Flow = flowModel1 };
            stepModel.InputField = inputFieldModel6;
            stepModel.OutputField = outputFieldModel1;

            mockStepRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(step);
            mockMapper.Setup(mapper => mapper.Map<StepModel>(step)).Returns(stepModel);

            var result = controller.GetStep(1);

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(stepModel, okResult.Value);
        }

        [Fact]
        public void test_get_steps_with_empty_data()
        {
            var mockStepRepository = new Mock<IStepRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StepController(mockStepRepository.Object, mockMapper.Object);

            var steps = new List<Step>();

            mockStepRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(steps);

            var result = controller.GetSteps();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void test_get_step_with_invalid_id()
        {
            var mockStepRepository = new Mock<IStepRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StepController(mockStepRepository.Object, mockMapper.Object);

            var step = (Step)null;

            mockStepRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(step);

            var result = controller.GetStep(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void test_create_step_with_null_data()
        {
            var mockStepRepository = new Mock<IStepRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new StepController(mockStepRepository.Object, mockMapper.Object);

            StepModel stepModel = null;

            var result = controller.CreateStep(stepModel);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
