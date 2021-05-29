using CalculatorDataLayer.Interface;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using CalculatorDataLayer.Model;
using CalculatorDataLayer.Data;

namespace CalculatorDataLayer.Repository
{
    public class RepositoryOperation : IRepositoryOperation<Operation>, IRepositoryOperaionsTypes<OperaionsTypes>
    {
        CalculatorDbContext _dbContext;
        public RepositoryOperation(CalculatorDbContext calculatorDbContext)
        {
            _dbContext = calculatorDbContext;
        }
        public async Task<Operation> Create(Operation _object)
        {
            var obj = await _dbContext.Operations.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public void Delete(Operation _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }
        public IEnumerable<Operation> GetAll()
        {
            try
            {
                var op = new Operation();

                return _dbContext.Operations;
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        public IEnumerable<OperaionsTypes> GetAllOperaionsTypes()
        {
            try
            {
                return _dbContext.OperaionsTypes.ToList();
            }
            catch (Exception ee)
            {
                throw;
            }
        }
        public float Addition(float No1, float No2)
        {
            try
            {
                return No1 + No2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public float Subtraction(float No1, float No2)
        {
            try
            {
                return No1 - No2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public float Division(float No1, float No2)
        {
            try
            {
                return No1 / No2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public float Multiplication(float No1, float No2)
        {
            try
            {
                return No1 * No2;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
