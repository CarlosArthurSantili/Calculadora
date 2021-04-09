using System;

namespace CalculadoraConsoleApp
{       
    class Program
    {
        //1) Somar dois números OK
        //2) Várias operações OK
        //3) Fazer as 4 operações aritméticas OK (soma, subtração, multiplicação, divisão)
        //4) Validar a opções do menu OK
        //5) BUG: Não permitir divisão por zero OK
        //6) Mostrar histórico de operações OK
        static void Main(string[] args)
        {
            double resultado = 0;
            string opcao = "";
            string historico = "";
            do
            {
                Console.WriteLine("Calculadora 1.5.1");
                Console.WriteLine("Histórico:");
                Console.WriteLine($"{historico}");
                Console.WriteLine("\n");

                Console.WriteLine("Menu:");
                Console.WriteLine("Digite 1 para somar ");
                Console.WriteLine("Digite 2 para subtrair ");
                Console.WriteLine("Digite 3 para multiplicar ");
                Console.WriteLine("Digite 4 para divisão ");
                Console.WriteLine("Digite S para sair");
                opcao = Console.ReadLine();

                if ((opcao == "s") || (opcao == "S"))
                {
                    break;
                }
                else if ((opcao == "1") || (opcao == "2") || (opcao == "3") || (opcao == "4"))
                {
                    Console.WriteLine("Digite o primeiro número:");
                    string strPrimeiroNumero = Console.ReadLine();
                    double primeiroNumero = Convert.ToDouble(strPrimeiroNumero);

                    Console.WriteLine("Digite o segundo número:");
                    string strSegundoNumero = Console.ReadLine();
                    double segundoNumero = Convert.ToDouble(strSegundoNumero);
                    

                    if ((opcao == "4") && (segundoNumero == 0))
                    {
                        Console.WriteLine("Não foi possível realizar a operação divisão, pois não existe divisão por zero");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else 
                    {
                        resultado = CalculaResultado(opcao, primeiroNumero, segundoNumero);
                        historico += AdicionaHistorico(opcao, primeiroNumero, segundoNumero);
                        ExibirResultado(resultado);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Opção Inválida");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            while (!opcao.Equals("S",StringComparison.OrdinalIgnoreCase));

        }

        private static double CalculaResultado(string opcao, double primeiroNumero, double segundoNumero)
        {
            double resultado;
            switch (opcao)
            {
                case "1": resultado = primeiroNumero + segundoNumero; break;
                case "2": resultado = primeiroNumero - segundoNumero; break;
                case "3": resultado = primeiroNumero * segundoNumero; break;
                case "4": resultado = primeiroNumero / segundoNumero; break;
                default: //teoricamente, nunca deve cair aqui por verificação anterior a chamada da função
                    { resultado = 0; Console.WriteLine("Opcao Invalida"); break; }
            }

            return resultado;
        }

        private static string AdicionaHistorico(string opcao, double primeiroNumero, double segundoNumero)
        {
            string historico;
            switch (opcao)
            {
                case "1": historico = ($"{primeiroNumero} + {segundoNumero} = {primeiroNumero + segundoNumero} \n");
                    break;
                case "2": historico = ($"{primeiroNumero} - {segundoNumero} = {primeiroNumero - segundoNumero} \n");
                    break;
                case "3": historico = ($"{primeiroNumero} * {segundoNumero} = {primeiroNumero * segundoNumero} \n");
                    break;
                case "4": historico = ($"{primeiroNumero} / {segundoNumero} = {primeiroNumero / segundoNumero} \n");
                    break;
                default: //teoricamente, nunca deve cair aqui por verificação anterior a chamada da função
                    { historico = ""; Console.WriteLine("Opcao Invalida"); break; }
            }

            return historico;
        }

        private static void ExibirResultado(double resultado)
        {
            Console.Write("Resultado: ");
            Console.WriteLine(resultado);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
