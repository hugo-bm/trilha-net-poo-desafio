namespace DesafioPOO.Models{
    // TODO: Herdar da classe "Smartphone"
    public class Nokia : Smartphone
    {
       

        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        public override void InstalarAplicativo(string nomeApp)
        {
            uint tamanhoTotal = 30;

            Console.WriteLine($"Preparando a instalação do app {nomeApp}");

            for (uint i = 0; i <= tamanhoTotal; i++)
            {
                // Calcular a porcentagem concluída
                uint porcentagem = (i * 100) / tamanhoTotal;

                // Atualizar a barra de carregamento
                AtualizarBarraDeCarregamento(i, tamanhoTotal, porcentagem);

                // Simular algum trabalho
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nIntalação do app {nomeApp} foi um sucesso!");
        }

        protected override void AtualizarBarraDeCarregamento(uint progresso, uint tamanhoTotal, uint porcentagem)
        {
            // Construir a barra de carregamento
            string barraDeCarregamento = "[" + new string('#', Convert.ToInt32(progresso)) + new string(' ', Convert.ToInt32(tamanhoTotal - progresso)) + "]";

            // Exibir a barra de carregamento e a porcentagem concluída
            Console.Write($"\r{barraDeCarregamento} {porcentagem}%");
        }
    }
}