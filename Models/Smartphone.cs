using System.Text.RegularExpressions;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        private string numero;
        private string _IMEI;

        protected string Modelo{ get; set;}

        private int memoria;
        protected int Memoria
        {
            get { return memoria; }
            set { memoria = value; }
        }
        

        public string IMEI { 
            get => _IMEI;
            set {
                if (ValidarIMEI(value)){
                    
                    _IMEI = Regex.Replace(value, @"[^\d]", "");// Limpando os caracteres especiais
                }
                else
                {
                    throw new FormatException("Este não é um número IMEI válido!");
                }
            } 
        }

        public string Numero {
            get => numero; 
            set {
                if (ValidacaoNumeroNoFormatoBrasileiro(value)){
                    
                    numero = Regex.Replace(value, @"[^\d]", "");// Limpando os caracteres especiais
                }
                else
                {
                    throw new FormatException("Este não é um número de telefone Brasileiro válido");
                }
            }
        }


        private static bool ValidacaoNumeroNoFormatoBrasileiro(string numero){
            return Regex.IsMatch(numero,@"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$");
        }
        private static bool ValidarIMEI(string imei){
            imei = Regex.Replace(imei, @"\D", "");//Mantendo apenas dígitos!
            if (!Regex.IsMatch(imei, @"^\d{15}$"))// Verificando se mantém apenas dígitos númericos!
            {
                return false;
            }
            // Calculando o dígito de verificação
            int soma = 0;
            for (int i = 0; i < 14; i++)
            {
                int digito = int.Parse(imei[i].ToString());
                if (i % 2 == 0)
                {
                    soma += digito;
                }
                else
                {
                    soma += digito * 2 / 10 + digito * 2 % 10;
                }
            }
            
            int digitoVerificacao = (10 - (soma % 10)) % 10;
            
            // Verificar se o dígito de verificação corresponde ao último dígito do IMEI
            return digitoVerificacao == int.Parse(imei[14].ToString());
        }
        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }
        public Smartphone(string numero, string imei)
        {
            Numero = numero;
            IMEI = imei;
        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
        protected abstract void AtualizarBarraDeCarregamento(uint progresso, uint tamanhoTotal, uint porcentagem);
    }
}