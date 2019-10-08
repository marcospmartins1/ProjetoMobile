using System;
using System.Collections.Generic;
using System.Text;

using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Funcionario
    {
        public List<ModelFuncionario> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelFuncionario>("SELECT * FROM funcionario");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }

        public bool Inserir(string nome, string cpf, string data, Picker sexo, string email, string telefone, Picker horario)
        {
            try
            {
                var query = $"INSERT INTO funcionario (nome_funcionario, cpf, data_nascimento, sexo, email, telefone_celular, horario_atendimento) VALUES ('{nome}', {cpf}, '{data}', '{sexo}', '{email}', '{telefone}', '{horario}') ";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }

        }

        public bool Update(string nome, string cpf, string data, Picker sexo, string email, string telefone, Picker horario, int id)
        {
            try
            {
                var query = $"UPDATE funcionario SET nome_funcionario = '{nome}', cpf = {cpf}, data_nascimento = '{data}', sexo = '{sexo}', email = '{email}', telefone_celular = '{telefone}', horario_atendimento = '{horario}' WHERE ID = {id}";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao atualizar.\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteAll()
        {
            try
            {
                var query = $"DELETE FROM funcionario";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar a lista.\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteItem(int id)
        {
            try
            {
                var query = $"DELETE FROM funcionario WHERE ID = {id}";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao deletar os dados.\nDetalhes:" + ex.Message);
            }

        }
    }
}
