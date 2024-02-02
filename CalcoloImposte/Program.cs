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
                if(value.Length == 16)
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
            set { _comuneResidenza = value;}
        }

        public double RedditoAnnuale
        {
            get { return _redditoAnnuale; }
            set {  _redditoAnnuale = value; }
        }


        public Contribuente(string nome, string cognome, string codiceFiscale,  char sesso, string comuneResidenza, double redditoAnnuale)
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


    }
}