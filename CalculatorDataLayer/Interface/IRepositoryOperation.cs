using System.Threading.Tasks;
using System.Collections.Generic;

namespace CalculatorDataLayer.Interface
{
    public interface IRepositoryOperation<T>
    {
        public Task<T> Create(T _object);
        public IEnumerable<T> GetAll();
        public void Delete(T _object);
        public float Addition(float No1, float No2);
        public float Subtraction(float No1, float No2);
        public float Division(float No1, float No2);
        public float Multiplication(float No1, float No2);
    }
}
