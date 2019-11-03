using System;
using System.Collections.Generic;
using System.Text;

namespace projLivrosLista
{
    
    class Livros

    {
        Livro oLivro = new Livro();
        Exemplar oExemplar = new Exemplar();

        #region Atributo


        private List<Livro> acervo;


        #endregion

        #region Propriedade
        internal List<Livro> Acervo {
            get => acervo;
            set => acervo = value;
        }
        #endregion

        #region Construtor
        public Livros()
        {
            this.acervo = new List<Livro>();
        }

        #endregion


        #region Metodos

        public void adicionar(Livro livro)
        {
            this.acervo.Add(livro);
        }

        public Livro pesquisar(Livro livro)
        {
            Livro livroAchado = new Livro();
            foreach (Livro l in this.acervo)
                if (l.Equals(livro))
                    livroAchado = l;
            return livroAchado;
        }

        #endregion
       public void compara(int opcao)
        {
            foreach (Livro l in this.acervo)
            {
                if (oLivro.Isbn.Equals(opcao))
                    Console.Write("\nInsira os dados do Exemplar (tombo): ");
                oExemplar.Tombo = int.Parse(Console.ReadLine());
                                   
            }
                        
    }
}
}
