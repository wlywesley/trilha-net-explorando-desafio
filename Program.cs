using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;


// Instância a classe Suite e Reserva.
Suite suite = new Suite();
Reserva reserva = new Reserva();

// Escolha da suíte através do menu, onde chama o método da classe Reserva(CadastrarSuite) para salvar as informações.
Console.WriteLine("Escolha o tipo da suíte. \n");

Console.Write( "1 - Suite Padrão. Capacidade: 2. Valor da diária: 50R$ \n" +  
               "2 - Suite Média. Capacidade: 5. Valor da diária: 70R$ \n" + 
               "3 - Suíte Grande. Capacidade: 8. Valor da diária: 90R$ \n");         
int escolhamenu = Convert.ToInt32(Console.ReadLine());

Console.Clear();

switch(escolhamenu)
{
case 1:
        suite = new Suite(tipoSuite: "Padrão", capacidade: 2, valorDiaria: 50);
        reserva.CadastrarSuite(suite);
        break;
case 2: 
        suite = new Suite(tipoSuite: "Média", capacidade: 5, valorDiaria: 70);
        reserva.CadastrarSuite(suite);
        break;
case 3:
        suite = new Suite(tipoSuite: "Padrão", capacidade: 8, valorDiaria: 90);
        reserva.CadastrarSuite(suite);
        break;
default:
        Console.WriteLine("Opção inválida.");
        Environment.Exit(0);
        break;
}

// Salva a quantidade de dias reservados na propriedade da classe Reserva = DiasReservados.
Console.Write("Quantos dias pretende reservar? \n");
reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());

Console.Clear();

// Tratativas de valor e capacidade na quantirdade de hóspedes.
int hospedesNumero;
do
{
    Console.Write($"Digite o número de hóspedes. (Maximo de {suite.Capacidade} pessoas.) \n");
    hospedesNumero = Convert.ToInt32(Console.ReadLine());

    if (hospedesNumero > suite.Capacidade)
    {
        Console.WriteLine("Capacidade de hóspedes maior que o permitido, favor digitar novamente.");
    }

    if (hospedesNumero <= 0)
    {
        Console.WriteLine("Valor inválido.");
    }
}
while (hospedesNumero > suite.Capacidade || hospedesNumero <= 0);

Console.Clear();

// Pergunta o nome dos hóspedes e salva na lista.
List<Pessoa> hospedes = new List<Pessoa>();

for (int i = 0; i < hospedesNumero; i++)
{
    hospedes.Add(new Pessoa(i.ToString()));

    Console.Write($"Digite o nome do {i + 1}° hóspede \n ");
    hospedes[i].Nome = Console.ReadLine();  
    Console.Clear(); 
}

reserva.CadastrarHospedes(hospedes);

// Exibe os hóspedes e as informações da reserva.
int cont = 1;
foreach (Pessoa pessoa in hospedes)
{
        Console.WriteLine($"Hóspede {cont++}: {pessoa.Nome}");
}
Console.WriteLine($"Tipo da suíte: {suite.TipoSuite}. Valor da diária: {suite.ValorDiaria.ToString("C")} \n" +
                  $"Dias reservados: {reserva.DiasReservados} \n" +
                  $"Valor total das diárias: {reserva.CalcularValorDiaria()}");