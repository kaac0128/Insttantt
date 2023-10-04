
using AutoMapper;
using Insttantt.Api.Controllers;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;
using Insttantt.Data.Repositories.ProjectName.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Insttantt.Tests
{
    public class FlowTest
    {

        [Fact]
        public void test_get_flow_valid_input()
        {
            var flowRepositoryMock = new Mock<IFlowRepository>();
            var mapperMock = new Mock<IMapper>();
            var flowController = new FlowController(flowRepositoryMock.Object, mapperMock.Object);
            var flow = new Flow();
            flowRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(flow);
            mapperMock.Setup(mapper => mapper.Map<FlowModel>(flow)).Returns(new FlowModel());

            var result = flowController.GetFlow(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void test_get_flows_empty_input()
        {
            var flowRepositoryMock = new Mock<IFlowRepository>();
            var mapperMock = new Mock<IMapper>();
            var flowController = new FlowController(flowRepositoryMock.Object, mapperMock.Object);
            var flows = new List<Flow>();
            flowRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(flows);

            var result = flowController.GetFlows();

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void test_get_flow_invalid_input()
        {
            var flowRepositoryMock = new Mock<IFlowRepository>();
            var mapperMock = new Mock<IMapper>();
            var flowController = new FlowController(flowRepositoryMock.Object, mapperMock.Object);
            flowRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Flow)null);

            var result = flowController.GetFlow(1);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void test_create_flow_null_input()
        {
            var flowRepositoryMock = new Mock<IFlowRepository>();
            var mapperMock = new Mock<IMapper>();
            var flowController = new FlowController(flowRepositoryMock.Object, mapperMock.Object);

            var result = flowController.CreateFlow(null);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
