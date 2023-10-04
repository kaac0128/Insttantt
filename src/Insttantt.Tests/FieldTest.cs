
using AutoMapper;
using Insttantt.Api.Controllers;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Insttantt.Tests
{
    public class FieldTest
    {
        [Fact]
        public void test_get_field_with_valid_id()
        {
            int id = 1;
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);
            var field = new Field { FieldID = id };
            var fieldModel = new FieldModel { FieldID = id };

            mockRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(field);
            mockMapper.Setup(mapper => mapper.Map<FieldModel>(field)).Returns(fieldModel);

            var result = controller.GetField(id);

            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(fieldModel, okResult.Value);
        }

        [Fact]
        public void test_create_field_with_valid_input()
        {
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);
            var fieldModel = new FieldModel { FieldID = 1 };
            var field = new Field { FieldID = 1 };

            mockMapper.Setup(mapper => mapper.Map<Field>(fieldModel)).Returns(field);

            var result = controller.CreateField(fieldModel);

            Assert.IsType<CreatedAtActionResult>(result);
            var createdAtActionResult = result as CreatedAtActionResult;
            Assert.Equal("GetField", createdAtActionResult.ActionName);
            Assert.Equal(field.FieldID, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(field.FieldID, createdAtActionResult.Value);
        }

        [Fact]
        public void test_update_field_with_valid_id_and_input()
        {
            int id = 1;
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);
            var fieldModel = new FieldModel { FieldID = id };
            var existingField = new Field { FieldID = id };

            mockRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync(existingField);

            var result = controller.UpdateField(id, fieldModel);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void test_get_field_with_invalid_id()
        {
            int id = 1;
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);

            mockRepository.Setup(repo => repo.GetByIdAsync(id)).ReturnsAsync((Field)null);

            var result = controller.GetField(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void test_create_field_with_null_input()
        {
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);

            var result = controller.CreateField(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void test_update_field_with_null_input_or_mismatched_id()
        {
            int id = 1;
            var mockRepository = new Mock<IFieldRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new FieldController(mockRepository.Object, mockMapper.Object);
            var fieldModel = new FieldModel { FieldID = id + 1 };

            var result1 =  controller.UpdateField(id, null);
            var result2 =  controller.UpdateField(id, fieldModel);

            Assert.IsType<BadRequestResult>(result1);
            Assert.IsType<BadRequestResult>(result2);
        }
    }
}
