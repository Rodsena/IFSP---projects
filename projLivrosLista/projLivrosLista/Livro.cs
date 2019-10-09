using System;
using System.Collections.Generic;
using System.Text;

namespace projLivrosLista
{
    class Livro
    {
        #region Atributos

        private int isbn;
        private string titulo;
        private string autor;
        private string editora;
        private List<Exemplar> exemplares;

        #endregion

        #region Propriedades

        public int Isbn {
            get => isbn;
            set => isbn = value;
        }
        public string Titulo {
            get => titulo;
            set => titulo = value;
        }
        public string Autor {
            get => autor;
            set => autor = value;
        }
        public string Editora {
            get => editora;
            set => editora = value;
        }
        internal List<Exemplar> Exemplares {
            get => exemplares;
            set => exemplares = value;
        }


        #endregion

        #region Construtor

        public Livro(int isbn, string titulo, string autor, string editora, List<Exemplar> exemplares)
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.exemplares = exemplares;
        }

        public Livro(int isbn): this(isbn, "", "", "", new List<Exemplar> ())
        {
          
        }

        public Livro() 
        {

        }

        #endregion

        #region Metodos

        public void adicionarExemplar(Exemplar exemplar)
        {
            this.exemplares.Add(exemplar);

        }

        public int qtdeExemplares()
        {
            int qtdeExemplares = 0;
            Livro livro = new Livro();
            foreach (Exemplar e in this.exemplares)
            {
                qtdeExemplares++;
            }
            return qtdeExemplares;
        }

        public int qtdeDisponiveis()
        {
            int qtdeDisponíveis = 0;
            qtdeDisponíveis = qtdeEmprestimos() - qtdeExemplares();
            return qtdeDisponíveis;
            
        }

        public int qtdeEmprestimos()
        {
            return;
        }

        public double percDisponibilidade()
        {
            return;
        }

        #endregion
    }
}
