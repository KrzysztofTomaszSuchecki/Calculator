using CalculatorDataLayer.Interface;
using CalculatorDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class OperationService
    {
        private readonly IRepositoryOperation<Operation> _repositoryOperation;
        private readonly IRepositoryOperaionsTypes<OperaionsTypes> _repositoryOperaionsTypes;
        public OperationService(IRepositoryOperation<Operation> operation, IRepositoryOperaionsTypes<OperaionsTypes> operation_type) 
        {
            _repositoryOperation = operation;
            _repositoryOperaionsTypes = operation_type;
        }
        //GET All operations
        public IEnumerable<Operation> GetAllOperations()
        {
            try
            {
                return _repositoryOperation.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Delete operation 
        public bool DeleteOperation(int Id)
        {
            try
            {
                foreach (var item in _repositoryOperation.GetAll().Where(x => x.Id == Id).ToList())
                {
                    _repositoryOperation.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        //GET All operations types
        public IEnumerable<OperaionsTypes> GetAllOperationsTypes()
        {
            try
            {
                return _repositoryOperaionsTypes.GetAllOperaionsTypes().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Add Operation
        public async Task<Operation> AddOperation(Operation operation)
        {
            return await _repositoryOperation.Create(operation);
        }
    }
}
