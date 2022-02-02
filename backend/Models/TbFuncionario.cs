using System;
using System.Collections.Generic;

#nullable disable

namespace backend.Models
{
    public partial class TbFuncionario
    {
        public int IdFuncionario { get; set; }
        public string NmFuncionario { get; set; }
        public string DsRg { get; set; }
        public string DsCpf { get; set; }
        public string DsTelefone { get; set; }
        public string DsCelular { get; set; }
        public DateTime DtContratado { get; set; }
        public int IdCargo { get; set; }
        public int IdEstado { get; set; }

        public virtual TbCargo IdCargoNavigation { get; set; }
        public virtual TbEstado IdEstadoNavigation { get; set; }
    }
}
