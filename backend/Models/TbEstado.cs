using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TbEstado
    {
        public TbEstado()
        {
            TbFuncionarios = new HashSet<TbFuncionario>();
        }

        public int IdEstado { get; set; }
        public string NmEstado { get; set; }

        public virtual ICollection<TbFuncionario> TbFuncionarios { get; set; }
    }
}
