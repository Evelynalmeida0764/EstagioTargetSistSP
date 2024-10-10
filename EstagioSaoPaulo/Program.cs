using estagio_riberão_preto;
using estagio_são_paulo;
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Selecine uma opção:");
Console.WriteLine("A) Exercicio 2");
Console.WriteLine("B) Exercicio 3");
Console.WriteLine("C) Exercicio 4");
Console.WriteLine("D) Exercicio 5");
Console.WriteLine("X) Sair");
var resposta = Console.ReadLine().ToLower();


switch (resposta)
{
    case "a":
        var fibonacci = new SequenciaFibonacci();
        Console.WriteLine("Qual o numero? ");
        var n = Int32.Parse(Console.ReadLine());
        Console.Clear();
        var sequencia = fibonacci.Calcular(n);
        foreach (var item in sequencia)
        {
            Console.WriteLine(item);
        }
        if (sequencia.Contains(n))
        {
            Console.WriteLine("O numero digitado esta na sequencia de Fibonacci");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("O numero digitado não esta na sequencia de Fibonacci");
            Console.ReadLine();
        }
        break;

    case "b":
        Console.Clear();
        var faturamentoDiario = new FaturamentoDiarioDistribuidora();
        faturamentoDiario.RegistrarFaturamento();
        Console.Clear();
        faturamentoDiario.CalcularEListarFaturamento();
        break;

    case "c":
        Console.Clear();
        var porcentualEstado = new PorcentualPorEstadoDistribuidora();
        porcentualEstado.CalcularPorcentual();
        break;

    case "d":
        Console.Clear();
        Console.WriteLine("Qual a frase que voce gostaria de ter invertida? ");
        string original = Console.ReadLine();

        // o C# tem o método Reverse na classe string que já reverte a string, e usa-se como abaixo:
        //string invertida = new string(original.Reverse().ToArray());


        var invertida = StringHelper.InverterString(original);
        Console.WriteLine(invertida);
        Console.ReadLine();
        break;

    case "x":
        Console.WriteLine("Voce escolheu sair.");
        Console.ReadLine();
        break;

}

