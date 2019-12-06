using System;

namespace projFilaAcesso {
    class Program {

        int idAmbienteGerado = 1;
        int idUsuarioGerado = 1;
        Cadastro cadastro = new Cadastro();

        static void Main(string[] args) {
            Program proj = new Program();
            proj.carregaMenu();
        }
        public void exibeMenu() {
            Console.WriteLine(
                "----------------------------------------------" + "\n" +
                "| 0. Sair                                    |" + "\n" +
                "| 1. Cadastrar ambiente                      |" + "\n" +
                "| 2. Consultar ambiente                      |" + "\n" +
                "| 3. Excluir ambiente                        |" + "\n" +
                "| 4. Cadastrar usuario                       |" + "\n" +
                "| 5. Consultar usuario                       |" + "\n" +
                "| 6. Excluir usuario                         |" + "\n" +
                "| 7. Conceder permissão de acesso ao usuário |" + "\n" +
                "| 8. Revogar permissão de acesso ao usuário  |" + "\n" +
                "| 9. Registrar acesso                        |" + "\n" +
                "|10. Consultar logs de acesso                |" + "\n" +
                "----------------------------------------------");
        }
        public void carregaMenu() {
            Console.WriteLine("Carregando dados salvos...");

            try {
                cadastro.download();
                Console.WriteLine("Dados carregados com sucesso!");
            } catch (Exception e) {
            }

            exibeMenu();
            Console.Write("-> Digite a opção: ");
            
            try {
                int op = int.Parse(Console.ReadLine());
                opcaoDesejada(op);
            }catch(Exception e) {
                Console.WriteLine("--- Opção inválida! ---" + e.Message);
                carregaMenu();
            }
        }
        public void opcaoDesejada(int op) {
            switch(op) {
                case 0:
                    // Sair
                    saveAndClose();
                    break;
                case 1:
                    // Cadastrar ambiente 
                    cadastraAmbiente();
                    pressToContinue();
                    break;
                case 2:
                    // Consultar ambiente 
                    consultaAmbiente();
                    pressToContinue();
                    break;
                case 3:
                    // Excluir ambiente 
                    excluiAmbiente();
                    pressToContinue();
                    break;
                case 4:
                    // Cadastrar usuario 
                    cadastraUsuario();
                    pressToContinue();
                    break;
                case 5:
                    // Consultar usuario 
                    consultaUsuario();
                    pressToContinue();
                    break;
                case 6:
                    // Excluir usuario
                    excluiUsuario();
                    pressToContinue();
                    break;
                case 7:
                    //  Conceder permissão de acesso ao usuario (informar ambiente e
                    //  usuário - vincular ambiente ao usuário) 
                    concedePermissao();
                    pressToContinue();
                    break;
                case 8:
                    //  Revogar permissão de acesso ao usuario (informar ambiente e
                    //  usuário - desvincular ambiente do usuário)
                    revogaPermissao();
                    pressToContinue();
                    break;
                case 9:
                    //  Registrar acesso (informar o ambiente e o usuário - registrar o
                    //  log respectivo)
                    registraAcesso();
                    pressToContinue();
                    break;
                case 10:
                    // Consultar logs de acesso (informar o ambiente e listar os logs -
                    // filtrar por logs autorizados/ negados / todos) 
                    consultaLog();
                    pressToContinue();
                    break;
                default:
                    // Opção inválida
                    Console.WriteLine("--- Opção inválida! ---");
                    carregaMenu();
                    break;
            }
        }
        public void cadastraAmbiente() {
            // Cadastrar ambiente 
            // Perguntar o nome do ambiente, gerar o ID auto e informa-lo
            string nomeAmbiente;
            enviaMensagem(1,"nome do Ambiente", false);
            nomeAmbiente = Console.ReadLine();

            cadastro.adicionarAmbiente(new Ambiente(idAmbienteGerado, nomeAmbiente));
            enviaMensagem(2, "Ambiente", true);
            idAmbienteGerado += 1;
        }
        public void consultaAmbiente() {
            // Consultar ambiente 
            // ? talvez consulta o log de determinado ambiente
            int idAmbiente;
            enviaMensagem(1,"ID do Ambiente", false);
            idAmbiente = int.Parse(Console.ReadLine());
            Ambiente env;

            if((env = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente))) != null){
                Console.WriteLine("Ambiente encontrado!\n- Nome do ambiente: " + env.Nome);
            } else {
                if(cadastro.Ambientes.Count > 0) {
                    Console.WriteLine("Ambiente não encontrado, os ambientes existentes são:");
                    foreach(Ambiente environment in cadastro.Ambientes) {
                        Console.WriteLine(environment.Id + " - " + environment.Nome);
                    }
                } else {
                    Console.WriteLine("Nenhum ambiente foi cadastrado ainda!");
                }   
            }
        }
        public void excluiAmbiente() {
            // Excluir ambiente
            // Perguntar o id do Ambiente
            int idAmbiente;
            enviaMensagem(1,"ID do Ambiente", false);
            idAmbiente = int.Parse(Console.ReadLine());

            if(cadastro.removerAmbiente(new Ambiente(idAmbiente))) enviaMensagem(3,"Ambiente", true);
            else enviaMensagem(4, "Ambiente", true);
        }
        public void cadastraUsuario() {
            // Cadastrar usuario 
            // Perguntar o nome do usuario, gerar o ID auto e informa-lo
            string nomeUsuario;
            enviaMensagem(1, "nome do Usuário", true);
            nomeUsuario = Console.ReadLine();

            cadastro.adicionarUsuario(new Usuario(idUsuarioGerado, nomeUsuario));
            enviaMensagem(2, "Usuário", true);
            idUsuarioGerado += 1;
        }
        public void consultaUsuario() {
            // Consultar usuario 
            // Perguntar o id do Usuário
            int idUsuario;
            enviaMensagem(1, "ID do Usuário", false);
            idUsuario = int.Parse(Console.ReadLine());

            cadastro.pesquisarUsuario(new Usuario(idUsuario));
            Usuario us;

            if((us = cadastro.pesquisarUsuario(new Usuario(idUsuario))) != null) {
                Console.WriteLine("Usuário encontrado!\n- Nome do usuário: " + us.Nome);
            } else {
                if(cadastro.Usuarios.Count > 0) {
                    Console.WriteLine("Usuário não encontrado, os ambientes existentes são:");
                    foreach(Usuario user in cadastro.Usuarios) {
                        Console.WriteLine(user.Id + " - " + user.Nome);
                    }
                } else {
                    Console.WriteLine("Nenhum usuário foi cadastrado ainda!");
                }
            }
        }
        public void excluiUsuario() {
            // Excluir usuario 
            // Perguntar o id do Usuário
            int idUsuario;
            enviaMensagem(1, "ID do Usuário", false);
            idUsuario = int.Parse(Console.ReadLine());

            if(cadastro.removerUsuario(new Usuario(idUsuario))) enviaMensagem(3,"Usuário", true);
            else enviaMensagem(4, "Usuário", true);
        }
        public void concedePermissao() {
            // Conceder permissão de acesso ao usuario (informar ambiente e
            // usuário - vincular ambiente ao usuário)
            // Pesquisa usuário de acordo com o ID. Concede permissão de acordo com o ID do ambiente
            int idUsuario, idAmbiente;

            enviaMensagem(1, "ID do Ambiente", false);
            idAmbiente = int.Parse(Console.ReadLine());

            enviaMensagem(1, "ID do Usuário", false);
            idUsuario = int.Parse(Console.ReadLine());

            Usuario user = (cadastro.Usuarios.Find(u => u.Id == idUsuario));
            Ambiente ambiente = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));
            if(user.concederPermissao(ambiente)) enviaMensagem(7, "concedida", true);
            else enviaMensagem(8, "concedida", true);
        }
        public void revogaPermissao() {
            // Revogar permissão de acesso ao usuario (informar ambiente e
            // usuário - desvincular ambiente do usuário)
            // Pesquisa usuário de acordo com o ID. Revoga permissão de acordo com o ID do ambiente
            int idUsuario, idAmbiente;

            enviaMensagem(1, "ID do Ambiente", false);
            idAmbiente = int.Parse(Console.ReadLine());

            enviaMensagem(1, "ID do Usuário", false);
            idUsuario = int.Parse(Console.ReadLine());

            Usuario user = (cadastro.Usuarios.Find(u => u.Id == idUsuario));
            Ambiente ambiente = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));
            if(user.revogarPermissao(ambiente)) enviaMensagem(7, "revogada", true);
            else enviaMensagem(8, "revogada", true);
        }
        public void registraAcesso() {
            // Registrar acesso (informar o ambiente e o usuário - registrar o
            // log respectivo) 
            int idUsuario, idAmbiente;

            enviaMensagem(1, "ID do Ambiente", false);
            idAmbiente = int.Parse(Console.ReadLine());

            enviaMensagem(1, "ID do Usuário", false);
            idUsuario = int.Parse(Console.ReadLine());

            Usuario user = cadastro.pesquisarUsuario(new Usuario(idUsuario));
            Ambiente environment = cadastro.pesquisarAmbiente(new Ambiente(idAmbiente));

            // logou = true || não logou = false
            if(user.Ambientes.Contains(environment)) environment.registrarLog(new Log(DateTime.Now, true, user)); 
            else environment.registrarLog(new Log(DateTime.Now, false, user));
        }
        public void consultaLog() {
            // Consultar logs de acesso (informar o ambiente e listar os logs -
            // filtrar por logs autorizados/ negados / todos)

            int opcao; // 3 = todos, 1 = autorizados, 2 = negados
            enviaMensagem(9, "", false);
            opcao = int.Parse(Console.ReadLine());

            enviaMensagem(5,"LOG",true);
            foreach(Ambiente ambiente in cadastro.Ambientes) {
                foreach(Log log in ambiente.Logs) {
                    // exibir detalhes do log
                    switch(opcao) {
                        case 3:
                            enviaMensagem(10, log.TipoAcesso + " - " + log.Usuario.Nome + " - " + log.DtAcesso, true);
                            break;
                        case 1:
                            if(log.TipoAcesso == true) enviaMensagem(10, log.TipoAcesso + " - " + log.Usuario.Nome + " - " + log.DtAcesso, true);
                            break;
                        case 2:
                            if(log.TipoAcesso == false) enviaMensagem(10, log.TipoAcesso + " - " + log.Usuario.Nome + " - " + log.DtAcesso, true);
                            break;
                    }
                    
                }
            }
            enviaMensagem(6,"",true);
        }
        public void enviaMensagem(int opcao, String msg, bool pulaLinha) {
            switch(opcao) {
                case 1:
                    // Digite o nome do Usuário:
                    msg = "Digite o " + msg + ": ";
                    break;
                case 2:
                    // Usuário adicionado com sucesso!
                    msg = msg + " adicionado com sucesso!";
                    break;
                case 3:
                    // Usuário excluido com sucesso!
                    msg = msg + " excluido com sucesso!";
                    break;
                case 4:
                    // Não foi possível excluir o Ambiente, pois ele não existe!
                    msg = "Não foi possível excluir o " + msg + ", pois ele não existe.";
                    break;
                case 5:
                    // --------- LOG ----------
                    msg = "----------" + msg + "----------";
                    break;
                case 6:
                    // --------- LOG ----------
                    msg = "-------------------------";
                    break;
                case 7:
                    //  Permissão concedida com sucesso!
                    msg = "Permissão " + msg + " com sucesso!";
                    break;
                case 8:
                    // A permissão não pode ser concedida, pois o usuário já a possui!
                    // A permissão não pode ser revogada, pois o usuário não a possui!
                    if(msg.Substring(0,8).Equals("concedida"))
                        msg = "A permissão não pode ser " + msg + ", pois o usuário já a possui!";
                    else
                        msg = "A permissão não pode ser " + msg + ", pois o usuário não a possui!";
                    break;
                case 9:
                    msg = "Para visualizar o Log dos ambientes, escolha uma das opções" + "\n" +
                          "1 - Logs de acessos autorizados" + "\n" +
                          "2 - Logs de acessos não autorizados" + "\n" +
                          "3 - Todos os Logs de acesso" + "\n" +
                          "-> Opção: ";
                    break;
                default:
                    // nada
                    msg = msg;
                    break;
            }
            if(pulaLinha) Console.WriteLine(msg);
            else Console.Write(msg);
        }
        public void pressToContinue() {
            enviaMensagem(10, "Pressione qualquer tecla para continuar!", false);
            Console.ReadKey();
            carregaMenu();
        }
        public void saveAndClose() {
            Console.WriteLine("Aguarde! Salvando registros...");
            cadastro.upload();
            Console.WriteLine("Os registros foram salvos com sucesso!");
        }
    }
}
