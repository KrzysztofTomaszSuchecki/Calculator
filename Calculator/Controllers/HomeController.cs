using Calculator.Models;
using CalculatorDataLayer.Interface;
using CalculatorDataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly OperationService _operationService;

        private readonly IRepositoryOperation<Operation> _repositoryOperation;
        private readonly IRepositoryOperaionsTypes<OperaionsTypes> _repositoryOperaionsTypes;

        public HomeController(IRepositoryOperation<Operation> operation, IRepositoryOperaionsTypes<OperaionsTypes> operaionsTypes, OperationService operationService)
        {
            _operationService = operationService;
            _repositoryOperation = operation;
            _repositoryOperaionsTypes = operaionsTypes;
        }

        //GET All operations
        [HttpGet("/all")]
        public async Task<IActionResult> Getall()
        {
            return View(_repositoryOperation.GetAll());
        }

        [HttpGet("/calc")]
        public async Task<IActionResult> Calc(int id, float no1, float no2)
        {
            if (ModelState.IsValid)
            {
                switch (id)
                {
                    case 1:
                        Add(id, no1, no2);
                        break;
                    case 2:
                        Sub(id, no1, no2);
                        break;
                    case 3:
                        Mul(id, no1, no2);
                        break;                        
                    case 4:
                        Div(id, no1, no2);
                        break;
                    default: break;
                }
                return RedirectToAction(nameof(Getall));
            }
            else
            {
                return View();
            }
        }

        [HttpGet("/calculator")]
        public async Task<IActionResult> Calculator()
        {
            List<OperaionsTypes> operationsTypes = (List<OperaionsTypes>)_repositoryOperaionsTypes.GetAllOperaionsTypes();
            ViewData["OperaionsTypes"] = operationsTypes;

            return View();
        }

        // GET: /OperationsTypes
        [HttpGet("/ot")]
        public Object GetAllOperationsTypes()
        {
            var data = _repositoryOperaionsTypes.GetAllOperaionsTypes();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        // GET: /Add 
        [HttpGet("/add/{id}/{no1}/{no2}")]
        public Object Add(int id, float No1, float No2)
        {
            _ = AddOperation(new Operation()
            {
                No1 = No1,
                No2 = No2,
                OperaionTypeId = id,
                OperationDateTime = DateTime.Now,
                Result = _repositoryOperation.Addition(No1, No2)
            }); ;

            return RedirectToAction(nameof(Getall));
        }

        [HttpGet("/sub/{id}/{no1}/{no2}")]
        public Object Sub(int id, float No1, float No2)
        {
            _ = AddOperation(new Operation()
            {
                No1 = No1,
                No2 = No2,
                OperaionTypeId = id,
                OperationDateTime = DateTime.Now,
                Result = _repositoryOperation.Subtraction(No1, No2)
            }); ;

            return RedirectToAction(nameof(Getall));
        }

        [HttpGet("/mul/{id}/{no1}/{no2}")]
        public Object Mul(int id, float No1, float No2)
        {
            _ = AddOperation(new Operation()
            {
                No1 = No1,
                No2 = No2,
                OperaionTypeId = id,
                OperationDateTime = DateTime.Now,
                Result = _repositoryOperation.Multiplication(No1, No2)
            }); ;

            return RedirectToAction(nameof(Getall));
        }

        [HttpGet("/div/{id}/{no1}/{no2}")]
        public Object Div(int id, float No1, float No2)
        {
            _ = AddOperation(new Operation()
            {
                No1 = No1,
                No2 = No2,
                OperaionTypeId = id,
                OperationDateTime = DateTime.Now,
                Result = _repositoryOperation.Division(No1, No2)
            }); ;

            return RedirectToAction(nameof(Getall));
        }

        //Add operation
        [HttpPost("/ao")]
        public async Task<Object> AddOperation(Operation operation)
        {
            try
            {
                await _repositoryOperation.Create(operation);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        // DELETE: api/del/5
        //[HttpGet("/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _operationService.DeleteOperation(id);
                return RedirectToAction(nameof(Getall));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
