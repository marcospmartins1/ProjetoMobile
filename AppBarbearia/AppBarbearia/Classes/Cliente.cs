using System;
using System.Collections.Generic;
using System.Text;
using AppBarbearia.Models;
using Xamarin.Forms;

namespace AppBarbearia.Classes
{
    public class Cliente
    {
        public List<ModelCliente> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<ModelCliente>("SELECT * FROM cliente");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao listar.\nDetalhes:" + ex.Message);
            }
        }

        public bool Inserir(string nome, string cpf, string data, Picker sexo, string email, string telefone, string observacao)
        {
            try
            {
                var query = $"INSERT INTO cliente (nome_cliente, cpf, data_nascimento, sexo, email, telefone_celular, observacao) VALUES ('{nome}', {cpf}, '{data}', '{sexo.SelectedItem}', '{email}', '{telefone}', '{observacao}') ";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir.\nDetalhes:" + ex.Message);
            }

        }

        public bool Update(string nome, string cpf, string data, Picker sexo, string email, string telefone, string observacao, int id)
        {
            try
            {
                var query = $"UPDATE cliente SET nome_cliente = '{nome}', cpf = {cpf}, data_nascimento = '{data}', sexo = '{sexo.SelectedItem}', email = '{email}', telefone_celular = '{telefone}', observacao = '{observacao}' WHERE ID = {id}";
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
                var query = $"DELETE FROM cliente";
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
                var query = $"DELETE FROM cliente WHERE ID = {id}";
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
