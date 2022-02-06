using System;
using System.Collections.Generic;

#nullable disable
namespace backend.Models
{
    public partial class TbCargo
    {
        public TbCargo()
        {
            TbFuncionarios = new HashSet<TbFuncionario>();
        }

        public int IdCargo { get; set; }
        public string DsCargo { get; set; }
        public decimal VlSalario { get; set; }
        public TimeSpan HrEntrada { get; set; }
        public TimeSpan HrSaida { get; set; }

        public virtual ICollection<TbFuncionario> TbFuncionarios { get; set; }
    }
}
