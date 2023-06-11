using Microsoft.AspNetCore.Mvc;
using Test.DTOs;
using Test.Models;
using Test.Repositories;

namespace Test.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public TestController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public void CreateTestModel(TestModelCreateUpdateDTO input)
        {
            _unitOfWork.TestModelRepository.Add(input.ToTestModel());
            _unitOfWork.SaveChanges();
        }

        [HttpPut]
        public void UpdateTestModel(int id, TestModelCreateUpdateDTO input)
        {
            _unitOfWork.TestModelRepository.Update(input.ToTestModel(id));
            _unitOfWork.SaveChanges();
        }

        [HttpDelete]
        public void DeleteTestModel(int id)
        {
            _unitOfWork.TestModelRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        [HttpGet]
        public TestModel? GetTestModelById(int id)
        {
            return _unitOfWork.TestModelRepository.GetById(id);
        }

        [HttpGet]
        public List<TestModel> GetTestModelsList()
        {
            return _unitOfWork.TestModelRepository.GetAll();
        }

    }
}