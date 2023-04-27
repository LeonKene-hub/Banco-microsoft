using Banco_microsoft;

var conta = new bankAccounts("Pedro", 1000);
Console.WriteLine($"A conta {conta.Numero} foi criada por {conta.Dono} com {conta.Balance}");

conta.FazerSaque(500, DateTime.Now, "Pagamento do aluguel");
Console.WriteLine(conta.Balance);
conta.FazerDeposito(100, DateTime.Now, "Meu amigo acabou de pagar uma divida");
Console.WriteLine(conta.Balance);

//teste de saldo inicial negativo, deve ser positivo
bankAccounts invalidAccount;
try
{
    invalidAccount = new bankAccounts("Invalido", -55);
}
catch (System.Exception e)
{
    Console.WriteLine($"Teste te pegou criando uma conta com saldo negativo");
    Console.WriteLine(e.ToString());
    return;
}

try
{
    conta.FazerSaque(750, DateTime.Now, "teste de sque acima do saldo");
}
catch (System.Exception e)
{
    Console.WriteLine($"Exception capturou tentando sacar um valor maior que o saldo");
    Console.WriteLine(e.ToString());
}


Console.WriteLine(conta.HistoricoDaConta());