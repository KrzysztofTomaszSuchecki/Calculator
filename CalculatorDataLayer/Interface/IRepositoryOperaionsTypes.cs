using System.Collections.Generic;

namespace CalculatorDataLayer.Interface
{
    public interface IRepositoryOperaionsTypes<T>
    {
        public IEnumerable<T> GetAllOperaionsTypes();
    }
}
