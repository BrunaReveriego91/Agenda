using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Agenda.Domain;
using Dapper;

namespace Agenda.DAL
{
    public class Contatos
    {
        private string _strCon { get; set; }


        public Contatos()
        {
            _strCon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        }


        public void Adicionar(Contato contato)
        {
            using (var con = new SqlConnection(_strCon))
            {

                con.Execute("insert into Contato(Id,Nome) values (@Id,@Nome)", contato);

                //con.Open();
                //var sql = String.Format();
                //var cmd = new SqlCommand(sql, con);
                //cmd.ExecuteNonQuery();
            }


        }

        public Contato Obter(Guid id)
        {
            Contato contato;
            using (var con = new SqlConnection(_strCon))
            {
                contato = con.QueryFirst<Contato>("Select Id, Nome from Contato where Id = @Id", new { Id = id });

                //con.Open();
                //string sql = String.Format("Select Id, Nome from Contato where Id = '{0}' ;", id);
                //SqlCommand cmd = new SqlCommand(sql, con);


                //var sqlDataReader = cmd.ExecuteReader();
                //sqlDataReader.Read();

                //contato = new Contato()
                //{
                //    Id = Guid.Parse(sqlDataReader["Id"].ToString()),
                //    Nome = sqlDataReader["Nome"].ToString()
                //};


            }

            return contato;

        }

        public List<Contato> ObterTodos()
        {
            var contatos = new List<Contato>();

            using (var con = new SqlConnection(_strCon))
            {
                contatos = con.Query<Contato>("Select Id, Nome from Contato;").ToList();

            }



            return contatos;
        }


    }
}
