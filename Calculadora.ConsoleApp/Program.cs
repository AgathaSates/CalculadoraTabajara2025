namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static int operacoes = 0;    //atributos staticos//para utilizar em toda a classe, o valor ser alterado mesmo dentro do metodo e não morrer la dentro
        static string[] historico = new string[50];

        static void Main(string[] args)
        {
            while (true)
            {
                int opcao = Menu();

                if (Sair(opcao))
                    break;

                else if (opcao == 5)
                    MostrarTabuada();

                else if (opcao == 6)
                    MostrarHistorico();
                
                else
                    Resultado(Operacoes(opcao));

                Console.Write(" -> Deseja Realizar outra operação? (S/N): "); // ao final de cada operação volta ao menu
                string continuar = Console.ReadLine()!.ToUpper(); //"!" parar o aviso de warning

                while (continuar != "S" && continuar != "N") //validação
                {
                    Console.Write("-> (X) Opção inválida! Digite novamente: ");
                    continuar = Console.ReadLine()!.ToUpper(); //"!" parar o aviso de warning 
                }

                if (continuar == "N")  //quebra o loop
                {
                    Console.Clear();
                    Console.WriteLine("---------------------");
                    Console.WriteLine(" Até a próxima!  0/ ");
                    Console.WriteLine("---------------------");
                    break;
                }
            }
           
            static int Menu() // alterado para int para validação
            {
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("    Calculadora Tabajara 2025");
                Console.WriteLine("--------------------------------");
                Console.WriteLine(" 1 - Somar");
                Console.WriteLine(" 2 - Subtrair");
                Console.WriteLine(" 3 - Multiplicação");
                Console.WriteLine(" 4 - Divisão");
                Console.WriteLine(" 5 - Tabuada");
                Console.WriteLine(" 6 - Histórico de Operações");
                Console.WriteLine(" 7 - Sair"); // alterado para facilitar a validação de entrada
                Console.WriteLine("--------------------------------");
                Console.Write(" -> Digite uma opção: ");

                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 7) // validação com tryparse pois nao sabemos o valor a ser inserido ao certo (convert se usa quando tem certeza que será colocado o tipo dele))
                    Console.Write(" -> (X) Opção inválida! Digite novamente: ");
                return opcao;
            }

            static bool Sair(int opcao) //alterados para int por conta da validação
            {
                bool Sair = opcao == 7; //se ele digitou é verdadeiro então faz a função seguinte aonde ele foi chamado(menu)
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine(" Até a próxima!  0/ ");
                Console.WriteLine("---------------------"); //texto adeus
                return Sair;
            }          

            static void MostrarTabuada()
            {
                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine("            Tabuada");
                Console.WriteLine("--------------------------------");

                Console.Write(" -> Digite o número: ");
                double numero;                                                                 // alterado para double para realizar tabuada de numeros com virgula
                while (!double.TryParse(Console.ReadLine()!.Replace(".",","), out numero))   //validação de entrada com replace
                    Console.Write(" -> (X) Opção inválida! Digite novamente: ");

                Console.Clear();
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"      Tabuada do {numero}");             // titulo
                Console.WriteLine("--------------------------------");

                for (double contador = 1; contador <= 10; contador++)
                {
                    double resultadoTabuada = numero * contador;
                    Console.WriteLine($" {numero} x {contador} = {resultadoTabuada}");
                }
                Console.WriteLine("--------------------------------");
            }

            static void MostrarHistorico()
            {
                Console.Clear();
                Console.WriteLine("----- Histórico de operações -----"); //titulo
                if (historico[0] == null)
                {
                    Console.WriteLine();
                    Console.WriteLine(" (X) Não há operações registradas.");
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("-----------------------");
                    foreach (string operacao in historico)  //foreach
                    {
                        if (operacao != null)   //apenas para arrays com informação
                        {
                            Console.WriteLine(operacao);          // imprime cada operação              
                        }
                    }
                    Console.WriteLine("-----------------------");
                }
            }

            static string Operacoes(int opcao) //alterado para retorno string e parametro int por conta da validação
            {
                Console.Clear();
                Console.WriteLine(" --- Digite os valores para realizar a operação ---"); //titulo
                Console.WriteLine();

                Console.Write(" -> Digite o primeiro número: ");
                double primeiroNumero;
                while (!double.TryParse(Console.ReadLine()!.Replace(".",","), out primeiroNumero)) //validaçao de entrada
                    Console.Write(" -> (X) Número inválido! Digite novamente: ");

                Console.Write(" -> Digite o segundo número: ");
                double segundoNumero;
                while (!double.TryParse(Console.ReadLine()!.Replace(".", ","), out segundoNumero)) //validaçao de entrada
                    Console.Write(" -> (X) Número inválido! Digite novamente: ");

                Console.WriteLine("-----------------------------");

                double resultado = 0;
                string sinal = "";

                switch (opcao)        //switch case para diminuir e melhorar o entendimento do codigo
                {
                    case 1:                       
                        resultado = primeiroNumero + segundoNumero; //resultado orriginal
                        sinal = "+";
                        break;

                    case 2:
                        resultado = primeiroNumero - segundoNumero;
                        sinal = "-";
                        break;

                    case 3:
                        resultado = primeiroNumero * segundoNumero;
                        sinal = "x";
                        break;

                    case 4:
                        while (segundoNumero == 0)
                        {
                            Console.Write(" (X) Não é possível dividir por zero. Digite um número novamente: ");
                            while (!double.TryParse(Console.ReadLine(), out segundoNumero) && segundoNumero>0)  //validaçao de entrada e confere novamente se é zero
                                Console.Write(" -> (X) Número inválido ou 0! Digite novamente: ");
                        }
                        resultado = primeiroNumero / segundoNumero;
                        sinal = "÷";
                        break;
                }

                string resultadoInteiro = $" {primeiroNumero} {sinal} {segundoNumero} = {resultado.ToString("F2")}";//reformulei o resultado para mostrar toda a operação

                historico[operacoes] = $" {resultadoInteiro}"; //guarda no array a operação criando o historico

                operacoes++; //pula para preencher o proximo bloco array

                return resultadoInteiro;
            }

            static string Resultado(string resultadointeiro) //alterado para string
            {
                Console.WriteLine($" -> Resultado:{resultadointeiro}");
                Console.WriteLine("-----------------------------");

                return resultadointeiro;
            }
        }
    }
}

