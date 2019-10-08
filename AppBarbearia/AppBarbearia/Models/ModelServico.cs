using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarbearia.Models
{
    public class ModelServico
    {
        public int ID { get; set; }
        public string status { get; set; }
        public string nome_servico { get; set; }
        public string descricao { get; set; }
        public string tempo { get; set; }
        public string valor { get; set; }
    }
}
