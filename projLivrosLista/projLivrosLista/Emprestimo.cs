using System;
using System.Collections.Generic;
using System.Text;

namespace projLivrosLista
{
    class Emprestimo
    {
        #region Atributos
        private DateTime dtEmprestimo;
        private DateTime dtDevolucao;

        #endregion

        #region Propriedades

        public DateTime DtEmprestimo {

            get => dtEmprestimo;
            set => dtEmprestimo = value;
        }
        public DateTime DtDevolucao {

            get => dtDevolucao;
            set => dtDevolucao = value;
        }
        #endregion

        #region Construtor
        public Emprestimo()
        {

        }
        public Emprestimo(DateTime dtEmprestimo, DateTime dtDevolucao)
        {
            this.dtEmprestimo = dtEmprestimo;
            this.dtDevolucao = dtDevolucao;
        }
        
        #endregion


    }
}
