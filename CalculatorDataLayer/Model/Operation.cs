using System;
using System.ComponentModel.DataAnnotations;

namespace CalculatorDataLayer.Model
{
    public class Operation
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Liczba pierwsza jest wymagana")]
        [Display(Name = "Liczba pierwsza")]
        public double No1 { get; set; }
        [Required(ErrorMessage = "Liczba druga jest wymagana")]
        [Display(Name = "Liczba druga")]
        public double No2 { get; set; }
        [Display(Name = "Wynik")]
        public double Result { get; set; }
        [Required(ErrorMessage = "Wybierz typ operacji")]
        [Display(Name = "Typ operacji")]
        public int OperaionTypeId { get; set; }
        [Display(Name = "Data")]
        public DateTime OperationDateTime { get; set; }
    }
}
