using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Cadastro.Domain.Interfaces.Repositories;
using System.Runtime.InteropServices;
using Cadastro.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Domain.Tests
{
    [TestClass]
    public class CategoriaTest
    {
        private Mock<ICategoriaRepository> mock;
        private readonly ICategoriaRepository MockCategoriaRepository;


        [TestInitialize]
        public void InicializarMockObject()
        {
            IList<Categoria> categoria = new List<Categoria>()
            {
                new Categoria { IdCategoria = 1, Descricao = "CategoriaTeste1",Slug = "Categoria-Teste1" },
                new Categoria { IdCategoria = 2, Descricao = "CategoriaTeste2",Slug = "Categoria-Teste2" },
                new Categoria { IdCategoria = 3, Descricao = "CategoriaTeste3",Slug = "Categoria-Teste3" },
                new Categoria { IdCategoria = 4, Descricao = "CategoriaTeste4",Slug = "Categoria-Teste4" },
                new Categoria { IdCategoria = 5, Descricao = "CategoriaTeste5",Slug = "Categoria-Teste5" },

            };

            mock = new Mock<ICategoriaRepository>();
            mock.Setup(mr => mr.GetAll()).Returns(categoria);

            mock.Setup(mr => mr.GetId(
                It.IsAny<int>())).Returns((int i) => categoria.Where(
                x => x.IdCategoria == i).Single());

        }

        [TestMethod]
        public void Categoria_Retorno_PorId()
        {
            Categoria categoria = mock.Object.GetId(2);

            Assert.IsNotNull(categoria);
            Assert.IsInstanceOfType(categoria, typeof(Categoria));
            Assert.AreEqual("CategoriaTeste2", categoria.Descricao);
        }

        [TestMethod]
        public void Categoria_Retorna_Categorias()
        {
            IEnumerable<Categoria> categoria = mock.Object.GetAll();

            Assert.IsNotNull(categoria);
            Assert.AreEqual(5, categoria.Count());
        }

    }
}
