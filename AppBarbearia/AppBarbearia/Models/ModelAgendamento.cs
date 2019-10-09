using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarbearia.Models
{
    public class ModelAgendamento
    {
        public int ID { get; set; }
        public string nome_cliente { get; set; }
        public double nome_funcionario { get; set; }
        public string servico { get; set; }
        public string horario { get; set; }
        public string duracao { get; set; }
        public string data { get; set; }
    }
}
