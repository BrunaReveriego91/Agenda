using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Agenda.Domain;

namespace Agenda.DAL.Test
{

    [TestFixture]
    public class ContatosTest
    {

        Contatos _contatos;


        [SetUp]
        public void SetUp()
        {
            _contatos = new Contatos();

        }

        //IncluirContatoTest



        [Test]
        public void AdicionarContatoTest()
        {
            //Monta

            var contato = new Contato()
            {

                Id = Guid.NewGuid(),
                Nome = "Marcos"
            };



            //Executa
            _contatos.Adicionar(contato);


            //Verifica

            Assert.True(true);

        }

        //ObterContatoTest

        [Test]
        public void ObterContatoTest()
        {
            //Monta
            var contato = new Contato()
            {

                Id = Guid.NewGuid(),
                Nome = "Maria"
            };


            Contato contatoResultado;

            //Executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            //Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);

        }

        [Test]
        public void ObterTodosContatosTest()
        {
            //Monta
            var contato1 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            var contato2 = new Contato() { Id = Guid.NewGuid(), Nome = "Maria" };
            //Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var lstContato = _contatos.ObterTodos();
            var contatoResultado = lstContato.Where(o => o.Id == contato1.Id).FirstOrDefault();

            //Verifica

            Assert.IsTrue(lstContato.Count() > 1);
            Assert.AreEqual(contato1.Id, contatoResultado.Id);
            Assert.AreEqual(contato1.Nome, contatoResultado.Nome);



        }



        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }


    }
}
