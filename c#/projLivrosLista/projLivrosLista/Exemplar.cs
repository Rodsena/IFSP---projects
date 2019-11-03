using System;
using System.Collections.Generic;
using System.Text;

namespace projLivrosLista
{
    class Exemplar
    {
        Livro livro = new Livro();
        Livro c = new Livro();


        #region Atributos

        private int tombo;
        private List<Emprestimo> emprestimos;

        #endregion

        #region Propriedades
        public int Tombo {

            get => tombo;
            set => tombo = value;
        }
        internal List<Emprestimo> Emprestimos {

            get => emprestimos;
            set => emprestimos = value;
        }

        #endregion

        #region Construtor
        public Exemplar(int tombo, List<Emprestimo> emprestimos)
        {
            this.tombo = tombo;
            this.emprestimos = emprestimos;
        }
        public Exemplar(int tombo): this(tombo, new List<Emprestimo>())
        {

        }
        public Exemplar()
        {

        }
        #endregion

        #region Métodos

        public bool emprestar()
        {
           


            return true;
        }

        public bool devolver()
        {
            return true ;
        }

        public bool disponivel()
        {
            
            
                return false;
        }

        public int qtdeEmprestimos()
        {
            livro.
            return ;
        }
        #endregion
        }
}
