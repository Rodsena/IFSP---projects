using System;
using System.Collections.Generic;

namespace projLivrosLista
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Livros osLivros = new Livros();
            Livro oLivro = new Livro();
            Exemplar oExemplar = new Exemplar();
            Emprestimo oEmprestimo = new Emprestimo();




            Console.WriteLine("---------------------------------------\n" +
                              "|   0. Sair                            |\n" +
                              "|   1. Adicionar livro                 |\n" +
                              "|   2. Pesquisar livro (sintético)     |\n" +
                              "|   3. Pesquisar livro (analítico)     |\n" +
                              "|   4. Adicionar exemplar              |\n" +
                              "|   5. Registrar empréstimo            |\n" +
                              "|   6. Registrar devolução             |\n" +
                              "---------------------------------------\n\n\n");

            // variavel opção  para o While

            int opcao = 1000;

            while (opcao != 0)
            {
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {   //OPÇÃO 1 CADASTRAR LIVRO
                    case 1:
                        Console.Write("Insira os dados do Livro (isbn, titulo, autor, editora e exemplar(tombo e exemplar):");
                        oLivro.Isbn =int.Parse(Console.ReadLine());
                        oLivro.Titulo = Console.ReadLine();
                        oLivro.Autor = Console.ReadLine();
                        oLivro.Editora = Console.ReadLine();
                        oLivro.Exemplares.Add(new Exemplar(oExemplar.Tombo = int.Parse(Console.ReadLine())));
                        osLivros.adicionar(new Livro(oLivro.Isbn, oLivro.Titulo, oLivro.Autor, oLivro.Editora, oLivro.Exemplares));
                        

                        break;

                    case 2:
                        // OPÇÃO 2 - PESQUISAR LIVRO SINTÉTICO
                        Console.Write("\nInsira o ISBN do livro para pesquisar: ");
                        int isbnPesquisado = int.Parse(Console.ReadLine());
                        Livro livro;                      
                        livro = osLivros.pesquisar(new Livro(isbnPesquisado));

                        if (livro.Isbn == isbnPesquisado)
                            {
                                Console.WriteLine("\nIsbn: " + oLivro.Isbn + 
                                                  "\nTitulo :" + oLivro.Titulo +
                                                  "\nAutor: " + oLivro.Autor +
                                                  "\nEdiora: " + oLivro.Editora + 
                                                  "\nExemplares: " + oLivro.qtdeExemplares() +" | Disponíveis: "+ oLivro.qtdeDisponiveis() +
                                                  " | Empréstimos: " + oLivro.qtdeEmprestimos() + " | % dsponiblidade: "+ oLivro.percDisponibilidade());
                            }
                        Console.ReadKey();
                        break;

                    case 3:
                        // OPÇÃO 3 - PESQUISAR LIVRO ANALÍTICO

                        Console.Write("\nInsira o ISBN do livro para pesquisar: ");
                        isbnPesquisado = int.Parse(Console.ReadLine());
                        
                        livro = osLivros.pesquisar(new Livro(isbnPesquisado));

                        if (livro.Isbn == isbnPesquisado)
                        {
                            Console.WriteLine("\nIsbn: " + oLivro.Isbn +
                                              "\nTitulo :" + oLivro.Titulo +
                                              "\nAutor: " + oLivro.Autor +
                                              "\nEdiora: " + oLivro.Editora +
                                              "\nExemplares: " + oLivro.qtdeExemplares() + " | Disponíveis: " + oLivro.qtdeDisponiveis() +
                                              " | Empréstimos: " + oLivro.qtdeEmprestimos() + " | % dsponiblidade: " + oLivro.percDisponibilidade() +
                                              "\n\n ");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("\nInsira o ISBN do livro para adicionar: ");
                        opcao = int.Parse(Console.ReadLine());
                        osLivros.compara(opcao);
                        break;

                    case 5:

                        livro = new Livro();
                        Livros livros = new Livros();
                        

                        Console.Write("\nInsira o ISBN do livro para empréstimo: ");
                        isbnPesquisado = int.Parse(Console.ReadLine());
                        livro.Isbn = isbnPesquisado;
                       if(osLivros.pesquisar(livro).Isbn == oLivro.Isbn)
                        {
                            Console.Write("\nInsira o Tombo do livro para empréstimo: ");
                            int tomboPesquisado = int.Parse(Console.ReadLine());
                           
                            foreach(Exemplar o in livros.Acervo[isbnPesquisado].Exemplares)
                            if(oExemplar.Tombo == tomboPesquisado)
                            {
                                   if(oEmprestimo.DtEmprestimo < oEmprestimo.DtDevolucao)
                                    {
                                        oEmprestimo.DtEmprestimo = DateTime.Now;
                                        oExemplar.emprestar();
                                    }
                                   
                            }

                        }
                        Console.ReadKey();
                       
                        break;

                    case 6:
                        livro = new Livro();
                        livros = new Livros();

                        Console.Write("\nInsira o ISBN do livro para empréstimo: ");
                        isbnPesquisado = int.Parse(Console.ReadLine());
                        livro.Isbn = isbnPesquisado;
                        if (osLivros.pesquisar(livro).Isbn == oLivro.Isbn)
                        {
                            Console.Write("\nInsira o Tombo do livro para empréstimo: ");
                            int tomboPesquisado = int.Parse(Console.ReadLine());

                            foreach (Exemplar o in livros.Acervo[isbnPesquisado].Exemplares)
                                if (oExemplar.Tombo == tomboPesquisado)
                                {
                                    if (oEmprestimo.DtEmprestimo > DateTime.Now)
                                    {
                                        oEmprestimo.DtDevolucao = DateTime.Now;
                                        oExemplar.devolver();
                                    }

                                }

                        }
                        Console.ReadKey();
                        break;

                    

                }


            }

        }
    }
}
