using System.Security.Cryptography.X509Certificates;

namespace CalcoloImposte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel calcolo dell'imposta");

            string nome, cognome, dd, mm, yyyy, codiceFiscale, comuneResidenza;
            char sesso;

            do
            {
                Console.Write("Inserisci il tuo nome: ");
                nome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nome));

            do
            {
                Console.Write("Inserisci il tuo cognome: ");
                cognome = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(cognome));

            do
            {
                Console.Write("Inserisci giorno nascita: ");
                dd = Console.ReadLine();
            } while (!VerificaGiorno(dd));

            do
            {
                Console.Write("Inserisci mese nascita: ");
                mm = Console.ReadLine();
            } while (!VerificaMese(mm));

            do
            {
                Console.Write("Inserisci anno nascita: ");
                yyyy = Console.ReadLine();
            } while (!VerificaAnno(yyyy));

            string dataNascita = $"{dd}/{mm}/{yyyy}";

            do
            {
                Console.Write("Inserisci il tuo codice fiscale (16 caratteri): ");
                codiceFiscale = Console.ReadLine().ToUpper();
            } while (!VerificaCodiceFiscale(codiceFiscale));

            do
            {
                Console.Write("Inserisci il tuo sesso ('M' o 'F'): ");
                char.TryParse(Console.ReadLine().ToUpper(), out sesso);
            } while (sesso != 'M' && sesso != 'F');

            do
            {
                Console.Write("Inserisci il tuo comune di residenza: ");
                comuneResidenza = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(comuneResidenza));


            Console.Write("Inserisci il tuo reddito annuale: ");
            double redditoAnnuale = double.Parse(Console.ReadLine());

            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);
            double impostaDaVersare = contribuente.CalcoloImposta();
            Console.Clear();


            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE");
            Console.WriteLine($"Contribuente: {char.ToUpper(nome[0]) + nome.Substring(1)} {char.ToUpper(cognome[0]) + cognome.Substring(1)},");
            Console.WriteLine($"nato il {dataNascita} ({sesso}),");
            Console.WriteLine($"residente a {char.ToUpper(comuneResidenza[0]) + comuneResidenza.Substring(1)}");
            Console.WriteLine($"codice fiscale: {codiceFiscale}");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"reddito dichiarato: € {redditoAnnuale:N2}");
            Console.WriteLine($"IMPOSTA DA VERSARE: € {impostaDaVersare:N2}");
        }

        static bool VerificaGiorno(string giorno)
        {
            if (int.TryParse(giorno, out int giornoInt) && giornoInt >= 1 && giornoInt <= 31)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Giorno non valido. Inserisci un numero tra 1 e 31.");
                return false;
            }
        }

        static bool VerificaMese(string mese)
        {
            if (int.TryParse(mese, out int meseInt) && meseInt >= 1 && meseInt <= 12)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Mese non valido. Inserisci un numero tra 1 e 12.");
                return false;
            }
        }

        static bool VerificaAnno(string anno)
        {
            if (int.TryParse(anno, out int annoInt) && annoInt >= 1900 && annoInt <= DateTime.Now.Year)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Anno non valido. Inserisci un numero tra 1900 e {DateTime.Now.Year}.");
                return false;
            }
        }

        static bool VerificaCodiceFiscale(string codiceFiscale)
        {
            if (codiceFiscale.Length == 16)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Codice fiscale non valido. Inserisci 16 caratteri.");
                return false;
            }
        }
    }
}



public class Contribuente
{
    private string _nome;
    private string _cognome;
    private string _dataNascita;
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

    public string DataNascita
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

    public Contribuente(string nome, string cognome, string dataNascita, string codiceFiscale, char sesso, string comuneResidenza, double redditoAnnuale)
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
