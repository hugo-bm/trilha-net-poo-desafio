namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Iphone : Smartphone
    {
        // TODO: Sobrescrever o método "InstalarAplicativo"
        public Iphone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria)
        {
        }

        public override void InstalarAplicativo(string nomeApp)
        {
            uint tamanhoTotal = 30;

            Console.WriteLine($"Preparando a instalação da Aplicação {nomeApp}");

            for (uint i = 0; i <= tamanhoTotal; i++)
            {
                // Calcular a porcentagem concluída
                uint porcentagem = (i * 100) / tamanhoTotal;

                // Atualizar a barra de carregamento
                AtualizarBarraDeCarregamento(i, tamanhoTotal, porcentagem);

                // Simular algum trabalho
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nO aplicativo {nomeApp} esta pronto para ser utilizado!");
        }

        protected override void AtualizarBarraDeCarregamento(uint progresso, uint tamanhoTotal, uint porcentagem)
        {
            // Construir a barra de carregamento
            string barraDeCarregamento = "[" + new string('O', Convert.ToInt32(progresso)) + new string(' ', Convert.ToInt32(tamanhoTotal - progresso)) + "]";

            // Exibir a barra de carregamento e a porcentagem concluída
            Console.Write($"\r{barraDeCarregamento} {porcentagem}%");
        }
    }
}