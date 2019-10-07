using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarbearia.Models
{
    class ModelPromocao
    {
        public int ID { get; set; }
        public string status { get; set; }
        public string nome_promocao { get; set; }
        public string descricao { get; set; }
        public string tempo { get; set; }
        public string valor { get; set; }
    }
}
