using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

string mensagemBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDeBandas = new List<string>{"U2", "AC/DC", "Red Hot"};

//Criando um dicionario vazio
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("AC/DC", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine("\n"+mensagemBoasVindas);
}

void ExibirMenuDeOpcoes()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite sua opção: ");
    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmabanda();
            break;
        case 4: MediaAvaliacao();
            break;
        case 0: Console.WriteLine("Voce escolheu sair do programa a opcao: "+opcao);
            break;
        
        default: Console.WriteLine("Opcao invalida!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine();
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrado com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo as bandas registradas");

    // for (int i = 0; i < listaDeBandas.Count; i++)
    // {
    //     Console.WriteLine($"Banda: {listaDeBandas[i]}");
    // }

    foreach (string banda in bandasRegistradas.Keys) 
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenuDeOpcoes();
}

void ExibirTituloDaOpcao(string titulo)
{
    int qtdLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qtdLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmabanda()
{
    //digite qual banda deseja avaliar
    //se a banda existir no dicionario  >> atribuir uma nota
    //senao, volta ao menu principal
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine());
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada para a banda {nomeDaBanda}.");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine($"\nA bnanda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }

}

void MediaAvaliacao()
{
    Console.Clear();
    ExibirTituloDaOpcao("Nota Média de Avaliação");
    Console.Write("Informe o nome da banda que deseja ver a média de avaliação: ");
    string nomeDaBanda = Console.ReadLine();

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        double notaMediaBanda = bandasRegistradas[nomeDaBanda].Average();
        Console.WriteLine($"A Avaliação média da banda {nomeDaBanda} é: {notaMediaBanda}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
    else
    {
        Console.WriteLine($"\nA bnanda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirMenuDeOpcoes();
    }
}

ExibirMenuDeOpcoes();