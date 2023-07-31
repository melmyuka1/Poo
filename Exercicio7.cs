 using System;

namespace  Questao7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar objetos de investimento com valores de entrada e taxa
            Investimento investimento1 = new Investimento(1000, 0.03);
            Investimento investimento2 = new Investimento(5500, 0.0248);
            Investimento investimento3 = new Investimento(12000, 0.02);

            // Tempo em anos (8 meses e 10 dias equivale a aproximadamente 8.33333333 meses)
            double tempoAnos = 8.33333333 / 12;

            // Calcular e mostrar a tabela com resgate no 5º mês
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
            return $"{entrada:C}\t\t{taxa:P}\t\t{rendimentoFuturo:C}\t\t{rendimentoAte4Meses:C}\t\t{resgate:C}";
        }
    }
}