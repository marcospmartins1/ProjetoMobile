using System;
using System.Collections.Generic;
using System.Text;

using AppBarbearia.Classes;
using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Agendamento
    {
        public List<ModelAgendamento> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelAgendamento>("SELECT * FROM agendamento");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }

        public bool Inserir(string nomeC, string nomeF, string servico, TimePicker horario, Picker duracao)
        {
            try
            {
                var query = $"INSERT INTO agendamento (nome_cliente, nome_funcionario, servico, horario, duracao) VALUES ('{nomeC}', {nomeF}, '{servico}', '{horario}', '{duracao}')";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }
        }
        public bool Update(string nomeC, string nomeF, string servico, Picker horario, Picker duracao, int id)
        {
            try
            {
                var query = $"UPDATE agendamento SET nome_cliente = '{nomeC}', nome_funcionario = {nomeF}, servico = '{servico}', horario = '{horario}', duracao = '{duracao}' WHERE ID = {id}";
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
                var query = $"DELETE FROM agendamento";
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
                var query = $"DELETE FROM agendamento WHERE ID = {id}";
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
