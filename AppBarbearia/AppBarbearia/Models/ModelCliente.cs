using System;
using System.Collections.Generic;
using System.Text;

namespace AppBarbearia.Models
{
    public class ModelCliente
    {
        public int ID { get; set; }
        public string nome_cliente { get; set; }
        public double cpf { get; set; }
        public string data_nascimento { get; set; }
        public string sexo { get; set; }
        public string email { get; set; }
        public double telefone_celular { get; set; }
        public string observacao { get; set; }

    }
}
