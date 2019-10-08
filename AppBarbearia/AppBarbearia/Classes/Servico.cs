using System;
using System.Collections.Generic;
using System.Text;

using AppBarbearia.Classes;
using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Servico
    {
        public List<ModelServico> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelServico>("SELECT * FROM servico");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }

        public bool Inserir(Picker status, string nome, string descricao, Picker tempo, string valor)
        {
            try
            {
                var query = $"INSERT INTO servico (status, nome_servico, descricao, tempo, valor) VALUES ('{status}', {nome}, '{descricao}', '{tempo}', '{valor}')";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }
        }

        public bool Update(Picker status, string nome, string descricao, Picker tempo, string valor, int id)
        {
            try
            {
                var query = $"UPDATE servico SET status = '{status}', nome_servico = {nome}, descricao = '{descricao}', tempo = '{tempo}', valor = '{valor}' WHERE ID = {id}";
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
                var query = $"DELETE FROM servico";
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
                var query = $"DELETE FROM servico WHERE ID = {id}";
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

