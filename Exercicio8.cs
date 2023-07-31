using System;

namespace Questao8

{
    class Program
    {
        static void Main(string[] args)
        {
            // cria objetos
            Investimento investimento1 = new Investimento(1000, 0.3);
            Investimento investimento2 = new Investimento(5500, 0.248);
            Investimento investimento3 = new Investimento(12000, 0.2);

            double tempoAnos = 8.33333333 / 12;

            // calcular e mostrar a tabela com resgate no 5º mês
            Console.WriteLine("Entrada\t\tTaxa\t\tRendimento Futuro\tRendimento até 4º mês\tResgate 5º mês");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(investimento1.CalcularTabelaComResgate(tempoAnos, 5));
            Console.WriteLine(investimento2.CalcularTabelaComResgate(tempoAnos, 5));
            Console.WriteLine(investimento3.CalcularTabelaComResgate(tempoAnos, 5));
        }
    }

    class Investimento
    {
        private double entrada;
        private double taxa;
        private double saldoAcumulado;

        public Investimento(double entrada, double taxa)
        {
            this.entrada = entrada;
            this.taxa = taxa;
            this.saldoAcumulado = entrada;
        }

        public double CalcularRendimentoFuturo(double tempoAnos)
        {
            double montante = saldoAcumulado * Math.Pow((1 + taxa), tempoAnos);
            return montante;
        }

        public double CalcularRendimentoAteMes(double tempoAnos, int mes)
        {
            double tempoMeses = tempoAnos * 12;
            double montante = saldoAcumulado;
            for (int i = 0; i < mes; i++)
            {
                montante *= (1 + taxa / 12);
            }
            return montante;
        }

        public double ResgatarRendimento(double tempoAnos, int mesResgate)
        {
            double rendimentoAteMes = CalcularRendimentoAteMes(tempoAnos, mesResgate - 1);
            double rendimentoNoResgate = CalcularRendimentoAteMes(tempoAnos, mesResgate);
            return rendimentoNoResgate - rendimentoAteMes;
        }

        public string CalcularTabelaComResgate(double tempoAnos, int mesResgate)
        {
            double rendimentoFuturo = CalcularRendimentoFuturo(tempoAnos);
            double rendimentoAte4Meses = CalcularRendimentoAteMes(tempoAnos, 4);
            double resgate = ResgatarRendimento(tempoAnos, mesResgate);
            double rendimentoAteMesResgate = CalcularRendimentoAteMes(tempoAnos, mesResgate - 1);

            double saldoAposResgate = saldoAcumulado + resgate;
            double rendimentoAposResgate = rendimentoFuturo - saldoAposResgate;
            
            return $"{entrada:C}\t\t{taxa:P}\t\t{rendimentoFuturo:C}\t\t{rendimentoAte4Meses:C}\t\t{resgate:C}";
        }
    }
}
