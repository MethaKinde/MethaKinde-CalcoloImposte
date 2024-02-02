using System.Security.Cryptography.X509Certificates;

namespace CalcoloImposte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Contribuente
    {
        private string _nome;
        private string _cognome;
        private DateTime _dataNascita;
        private string _codiceFiscale;
        private char _sesso;
        private string _comuneResidenza;
        private double _redditoAnnuale;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }

        public DateTime DataNascita
        {
            get { return _dataNascita; }
            set { _dataNascita = value; }
        }

        public string CodiceFiscale
        {
            get { return _codiceFiscale; }
            set
            {
                if (value.Length == 16)
                {
                    _codiceFiscale = value;
                }
                else
                {
                    _codiceFiscale = string.Empty;
                }
            }
        }

        public char Sesso
        {
            get { return _sesso; }
            set
            {
                if (value == 'M' || value == 'F')
                {
                    _sesso = value;
                }
                else
                {
                    _sesso = 'X';
                }
            }
        }

        public string ComuneResidenza
        {
            get { return _comuneResidenza; }
            set { _comuneResidenza = value; }
        }

        public double RedditoAnnuale
        {
            get { return _redditoAnnuale; }
            set 
            {
                if (value < 0)
                {
                    _redditoAnnuale = 0;
                }
                else
                {
                    _redditoAnnuale = value;
                }
            }
        }


        public Contribuente(string nome, string cognome, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public Contribuente(string nome, string cognome, DateTime dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        public double CalcoloImposta()
        {
            double imposta = 0;

            switch (RedditoAnnuale)
            {
                case double reddito when reddito <= 15000:
                    imposta = reddito * 0.23;
                    break;

                case double reddito when reddito <= 28000:
                    imposta = 3450 + (reddito - 15000) * 0.27;
                    break;

                case double reddito when reddito <= 55000:
                    imposta = 6960 + (reddito - 28000) * 0.38;
                    break;

                case double reddito when reddito <= 75000:
                    imposta = 17220 + (reddito - 55000) * 0.41;
                    break;

                default:
                    imposta = 25420 + (RedditoAnnuale - 75000) * 0.43;
                    break;
            }

            return imposta;
        }
    }
}