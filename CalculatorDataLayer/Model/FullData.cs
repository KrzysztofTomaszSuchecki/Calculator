using System;

namespace CalculatorDataLayer.Model
{
    public class FullData
    {
        public int Id { get; set; }
        public double No1 { get; set; }
        public double No2 { get; set; }
        public double Result { get; set; }
        public string Name { get; set; }
        public DateTime OperationDateTime { get; set; }
    }
}
