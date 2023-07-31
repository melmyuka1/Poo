 using System;

 namespace Questao6{
 

    class Program
    {
        static void Main(string[] args)
        {
            Investimento investimento1 = new Investimento(1000, 0.03);
            Investimento investimento2 = new Investimento(5500, 0.0248);
            Investimento investimento3 = new Investimento(12000, 0.02);

            
            double tempoAnos = 8.33333333 / 12;

           
            Console.WriteLine("Entrada\t\tTaxa\t\tRendimento Futuro");
            Console.WriteLine("------------------------------------");
            Console.WriteLine(investimento1);
            Console.WriteLine(investimento2);
            Console.WriteLine(investimento3);
        }
    }

    class Investimento
    {
        private double entrada;
        private double taxa;

        public Investimento(double entrada, double taxa)
        {
            this.entrada = entrada;
            this.taxa = taxa;
        }

        public double CalcularRendimentoFuturo(double tempoAnos)
        {
            double valorfinal = entrada * Math.Pow((1 + taxa), tempoAnos);
            return valorfinal;
        }

        public override string ToString()
        {
            double tempoAnos = 8.33333333 / 12;
            double rendimentoFuturo = CalcularRendimentoFuturo(tempoAnos);
            return $"{entrada:C}\t\t{taxa:P}\t\t{rendimentoFuturo:C}";
        }
    }
}