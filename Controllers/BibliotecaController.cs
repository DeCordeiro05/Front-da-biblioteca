using BibliotecaDeLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BibliotecaDeLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private static List<BibliotecaModels> Biblioteca = new List<BibliotecaModels>
        {
            new BibliotecaModels
            {
                Id = 1,
                Titulo = "Dom Casmurro",
                Autor = "Machado de Assis",
                Ano = 1899,
                Quantidade = 2

            },
            new BibliotecaModels
            {
                Id = 2,
                Titulo = "Grande Sertão: Veredas",
                Autor = "João Guimarães Rosa",
                Ano = 1956,
                Quantidade = 3,
            },
            new BibliotecaModels
            {
                Id = 3,
                Titulo = "Grande Sertão: Veredas",
                Autor = "João Guimarães Rosa",
                Ano = 1956,
                Quantidade = 4
            },
            new BibliotecaModels
            {
                Id = 4,
                Titulo = "O Cortiço",
                Autor = "Aluísio Azevedo",
                Ano = 1890,
                Quantidade = 4
            },
            new BibliotecaModels
            {
                Id = 5,
                Titulo = "Iracema",
                Autor = "José de Alencar",
                Ano = 1865,
                Quantidade = 1
            },
            new BibliotecaModels
            {
                Id = 6,
                Titulo = "Macunaíma",
                Autor = "Mário de Andrade",
                Ano = 1928,
                Quantidade = 11
            },
            new BibliotecaModels
            {
                Id = 7,
                Titulo = "Capitães da Areia",
                Autor = "Jorge Amado",
                Ano = 1937,
                Quantidade = 2
            },
            new BibliotecaModels
            {
                Id = 8,
                Titulo = "Vidas Secas",
                Autor = "Graciliano Ramos",
                Ano = 1938,
                Quantidade = 9
            },
            new BibliotecaModels
            {
                Id = 9,
                Titulo = "A Moreninha",
                Autor = "Joaquim Manuel de Macedo",
                Ano = 1844,
                Quantidade = 2
            },
            new BibliotecaModels
            {
                Id = 10,
                Titulo = "O Tempo e o Vento",
                Autor = "Erico Verissimo 1949",
                Ano = 1949,
                Quantidade = 1
            },
            new BibliotecaModels
            {
                Id = 11,
                Titulo = "O Quinze",
                Autor = "Rachel de Queiroz",
                Ano = 1930,
                Quantidade = 1
            },
            new BibliotecaModels
            {
                Id = 12,
                Titulo = "Menino do Engenho",
                Autor = "José Lins do Rego",
                Ano = 1932,
                Quantidade = 5
            },
            new BibliotecaModels
            {
                Id = 13,
                Titulo = "Sagarana",
                Autor = "João Guimarães Rosa",
                Ano = 1946,
                Quantidade = 3
            },
            new BibliotecaModels
            {
                Id = 14,
                Titulo = "Fogo Morto",
                Autor = "José Lins do Rego",
                Ano = 1943,
                Quantidade = 1
            },
            new BibliotecaModels
            {
                Id = 15,
                Titulo = "Memórias Póstumas de Brás Cubas",
                Autor = "Machado de Assis",
                Ano = 1881,
                Quantidade = 3
            }
        };

        [HttpGet]
        public ActionResult<List<BibliotecaModels>> VerTodosLivros()
        {
            return Ok(Biblioteca);
        }

        [HttpPut("alugar/{id}")]
        public ActionResult<List<BibliotecaModels>> AlugarLivro(int id)
        {
            var livro = Biblioteca.Find(x => x.Id == id);

            if (livro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado!");
            }

            if (livro.Quantidade > 0)
            {
                return BadRequest("Não há exemplares disponíveis para aluguel.");
            }

            livro.Quantidade--;

            return Ok($"Livro {livro.Titulo} alugado com sucesso! Quantidade atual: {livro.Quantidade}");
        }

        [HttpGet("devolucao/{id}")]
        public ActionResult<List<BibliotecaModels>> DevolverLivro(int id)
        {
            var devLivro = Biblioteca.Find(x => x.Id == id);

            if (devLivro == null)
            {
                return NotFound($"Livro com ID {id} não encontrado!");
            }

            devLivro.Quantidade++;

            return Ok($"Livro {devLivro.Titulo} devolvido com sucesso! Quantidade atual: {devLivro.Quantidade}");
        }


        [HttpGet("titulo/{titulo}")]
        public ActionResult<List<BibliotecaModels>> NomeLivro(string titulo)
        {
            var nomeLivro = Biblioteca.Find(x => x.Titulo == titulo);

            if (nomeLivro is null) return NotFound("Livro não encontrado!");

            return Ok(nomeLivro);
        }


    }
}