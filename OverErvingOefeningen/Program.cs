using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverErvingOefeningen
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Oefeningen = new List<string>();

            //string[] Oefeningen = ne
            Oefeningen = new List<string>();
            Oefeningen.Add("Exit");
            Oefeningen.Add("Ziekenhuis");
            Oefeningen.Add("Dierentuin");
            Oefeningen.Add("Bookmark Manager");
            Oefeningen.Add("Bank");
            Oefeningen.Add("Pokemon");
            Oefeningen.Add("Bookmark Manager Extra");
            Oefeningen.Add("Book");
            Oefeningen.Add("Pokemon");
            Oefeningen.Add("MoneyMoney");
            Oefeningen.Add("GeometricFigures");
            Oefeningen.Add("Dierentuin");
            bool bExit = false;
            while (!bExit)
            {
                switch (SelectMenu(true,Oefeningen.ToArray())-1)
                {
                    case 0: bExit = true; break;
                    case 1: Ziekenhuis(); break;
                    case 2: Dierentuin(); break;
                    case 3: BookmarkManagar(); break;
                    case 4: Bank(); break;
                    case 5: Pokemon(); break;
                    case 6: BookMarkExtra(); break;
                    case 7: Book(); break;
                    case 8: Pokemon(); break;
                    case 9: MoneyMoney(); break;
                    case 10: GeometricFigures(); break;
                    case 11: Dierentuin(); break;
                    //case 5: Pokemon(); break;
                    //case 5: Pokemon(); break;
                    //case 5: Pokemon(); break;
                    default:
                        break;
                }
            }

            

            
            Console.ReadLine();


            void Ziekenhuis()
            {
                Console.Clear();
                Patient patient = new Patient();
                VerzekerdePatient verzekerdePatient = new VerzekerdePatient();
                
                patient.Naam = "niet verzekerde patient";
                patient.AantalUren = 100;
                patient.ToonInfo();
                Console.WriteLine();
                verzekerdePatient.Naam = "verzekerde patient";
                verzekerdePatient.AantalUren = 100;
                verzekerdePatient.ToonInfo();
                Console.ReadKey();
            }

            void BookmarkManagar()
            {
                Console.Clear();

                List<HiddenBookmark> bookmarks = new List<HiddenBookmark>();
                bool exit = false;

                for (int i = 0; i < 5; i++)
                    bookmarks.Add(new HiddenBookmark());

                while (!exit)
                    switch (SelectMenu(true, "Bookmark aanmaken/aanpassen", "Bookmark verwijderen", "Bookmark openen", "exit"))
                    {
                        case 1:
                            {
                                int iAntw = 0;
                                bool overschrijven = false;
                                while (!overschrijven)
                                {
                                    if (iAntw != 0)
                                    {
                                        Console.WriteLine("Gelieve een andere bookmark te kiezen");
                                        Console.ReadKey(false);
                                        iAntw = 0;
                                    }
                                    while (iAntw > 5 || iAntw < 1)
                                    {
                                        Console.Clear();
                                        int.TryParse(InputChr("Welke bookmark wil je veranderen? (1 tot 5)").ToString(), out iAntw);
                                    }
                                    Console.WriteLine(iAntw);
                                    if ((bookmarks[iAntw - 1].Naam != "") && (bookmarks[iAntw - 1].Naam != null))
                                        overschrijven = InputBool($"Bookmark {bookmarks[iAntw - 1].Naam} overschrijven?");
                                    else overschrijven = true;
                                }
                                bookmarks[iAntw - 1].Naam = InputStr("Naam: ");
                                bookmarks[iAntw - 1].URL = InputStr("URL: ");
                                Console.WriteLine($"Bookmark {bookmarks[iAntw - 1].Naam} bewaard");
                            }
                            break;
                        case 2:
                            {
                                List<string> bookmarkName = new List<string>();
                                foreach (HiddenBookmark bookmark in bookmarks)
                                    if ((bookmark.Naam != "") && (bookmark.Naam != null)) bookmarkName.Add(bookmark.Naam);
                                bookmarkName.Add("Exit");
                                string teVerwijderen = bookmarkName[SelectMenu(true,bookmarkName.ToArray()) - 1];
                                bool verwijderd = false;
                                foreach (HiddenBookmark bookmark in bookmarks)
                                    if (bookmark.Naam == teVerwijderen)
                                    {
                                        bookmark.VerwijderGegevens();
                                        verwijderd = true;
                                        break;
                                    }
                                Console.WriteLine(verwijderd ? $"Bookmark {teVerwijderen} is verwijderd." : $"Niet gelukt om {teVerwijderen} te verwijderen.");
                                Console.ReadLine();
                            }
                            break;
                        case 3:
                            {
                                List<string> bookmarkName = new List<string>();
                                foreach (HiddenBookmark bookmark in bookmarks)
                                    if ((bookmark.Naam != "") && (bookmark.Naam != null)) bookmarkName.Add(bookmark.Naam);
                                bookmarkName.Add("Exit");
                                string bookmarkOpenen = bookmarkName[SelectMenu(true,bookmarkName.ToArray()) - 1];
                                foreach (HiddenBookmark bookmark in bookmarks)
                                    if (bookmark.Naam == bookmarkOpenen)
                                    {
                                        bookmark.OpenSite();
                                        break;
                                    }
                            }
                            break;
                        default: exit = true; break;
                    }
            }

            void Bank()
            {
                Console.Clear();
                bool exit = false;
                List<Rekening> rekeningen = new List<Rekening>();
                rekeningen.Add(new DebitRekening(10000, "Kenny", "1221 5456 5465 5466"));

                while (!exit)
                {
                    Console.Clear();
                    foreach (Rekening rekening in rekeningen)
                        rekening.Overzicht();
                    Console.WriteLine("\n\nRekening:");
                    switch (SelectMenu(false, "Overschrijven", "Aanmaken", "Verwijderen","Exit"))
                    {
                        case 1: // -- overschrijven
                            {
                                List<string> rekeningNrs = new List<string>();
                                foreach(Rekening rekening in rekeningen)
                                    if ((rekening != null) && (rekening.Naam != "")) rekeningNrs.Add(rekening.RekeningNr);
                                double overTeSchrijven = InputDbl("Bedrag om over te schrijven: ");
                                Console.WriteLine("Van rekening:");
                                string sourceRekening = rekeningNrs[SelectMenu(false, rekeningNrs.ToArray())-1];
                                Console.WriteLine("Naar rekening (geen = void):");
                                rekeningNrs.Add("geen");
                                string targetRekening = rekeningNrs[SelectMenu(false, rekeningNrs.ToArray())-1];
                                if (targetRekening == "geen")
                                    foreach (Rekening rekening in rekeningen)
                                    {
                                        if (rekening.RekeningNr == sourceRekening)
                                        {
                                            Console.WriteLine(rekening.Afhalen(overTeSchrijven) +" afgehaald"); 
                                            break;
                                        }
                                    }
                                else
                                    foreach (Rekening rekening in rekeningen)
                                        if (rekening.RekeningNr == sourceRekening)
                                        {
                                            foreach (Rekening tRekening in rekeningen)
                                                if (tRekening.RekeningNr == targetRekening)
                                                {
                                                    tRekening.Storten(rekening.Afhalen(overTeSchrijven));
                                                    break;
                                                }
                                            break;
                                        }
                            }
                            break;
                        case 2: // -- aanmaken
                            {
                                Rekening nieuweRekening = null;
                                switch (SelectMenu(false, "Credit rekening", "Debit rekening", "Spaar rekening","exit"))
                                {
                                    case 1: 
                                        nieuweRekening = new CreditRekening();
                                        break;
                                    case 2:
                                        nieuweRekening = new DebitRekening();
                                        break;
                                    case 3:
                                        nieuweRekening = new SpaarRekening();
                                        break;
                                    case 4: break;
                                }
                                if (nieuweRekening != null)
                                {
                                    double dBedrag = 0;
                                    if (InputBool("Bedrag toevoegen j/n?"))
                                        dBedrag = InputDbl("Bedrag: ");
                                    nieuweRekening.OpenRekening(bedrag: dBedrag);
                                    rekeningen.Add(nieuweRekening);
                                }
                            }
                            break;
                        case 3: // -- verwijderen
                            {
                                List<string> rekeningNrs = new List<string>();
                                foreach (Rekening rekening in rekeningen)
                                    if ((rekening != null) && (rekening.Naam != "")) rekeningNrs.Add(rekening.RekeningNr);
                                rekeningNrs.Add("exit");

                                string rekToDelete = rekeningNrs[SelectMenu(true, rekeningNrs.ToArray()) - 1];
                                int indexToRemove = -1;
                                foreach (Rekening rekening in rekeningen)
                                    if (rekening.RekeningNr == rekToDelete) indexToRemove = rekeningen.IndexOf(rekening);
                                if (indexToRemove != -1) rekeningen.RemoveAt(indexToRemove);
                            }
                            break;
                        default: exit = true; break;
                    }
                }
                Console.ReadKey();
            }

            // -- advanced oefeningen

            void Pokemon()
            {
                Console.Clear();

                Pokemon[] mijnPokemons = new Pokemon[10];

                for (int i = 0; i < mijnPokemons.GetLength(0); i++)
                {
                    bool Aangemaakt = false;
                    mijnPokemons[i] = new Pokemon();
                    switch (i)
                    {
                        case 0:
                            {
                                mijnPokemons[i].Naam = "Bulbasaur";
                                mijnPokemons[i].Nummer = 1;
                                mijnPokemons[i].HP_Base = 45;
                                mijnPokemons[i].Attack_Base = 49;
                                mijnPokemons[i].Defense_Base = 49;
                                mijnPokemons[i].SpecialAttack_Base = 65;
                                mijnPokemons[i].SpecialDefense_Base = 65;
                                mijnPokemons[i].Speed_Base = 45;
                                Aangemaakt = true;
                            }
                            break;
                        case 1:
                            {
                                mijnPokemons[i].Naam = "Ivysaur";
                                mijnPokemons[i].Nummer = 2;
                                mijnPokemons[i].HP_Base = 60;
                                mijnPokemons[i].Attack_Base = 62;
                                mijnPokemons[i].Defense_Base = 63;
                                mijnPokemons[i].SpecialAttack_Base = 80;
                                mijnPokemons[i].SpecialDefense_Base = 80;
                                mijnPokemons[i].Speed_Base = 60;
                                Aangemaakt = true;
                            }
                            break;
                        case 2:
                            {
                                mijnPokemons[i].Naam = "Venusaur";
                                mijnPokemons[i].Nummer = 3;
                                mijnPokemons[i].HP_Base = 80;
                                mijnPokemons[i].Attack_Base = 82;
                                mijnPokemons[i].Defense_Base = 83;
                                mijnPokemons[i].SpecialAttack_Base = 100;
                                mijnPokemons[i].SpecialDefense_Base = 100;
                                mijnPokemons[i].Speed_Base = 80;
                                Aangemaakt = true;
                            }
                            break;
                        default: break;
                    }
                    if (Aangemaakt)
                    {
                        Console.WriteLine($"Pokemon {mijnPokemons[i].Naam} aangemaakt.\nGemiddelde score: {mijnPokemons[i].Average}\nTotaal score: {mijnPokemons[i].Total}");
                        Console.WriteLine(mijnPokemons[i].ToString());
                    }
                }
                Console.ReadKey();

            }

            void BookMarkExtra()
            {
                Console.Clear();

                HiddenBookmark hbm = new HiddenBookmark();
                hbm.Naam = "Google";
                hbm.URL = "www.google.be";
                Bookmark bm = new Bookmark();
                bm.Naam = "Microsoft";
                bm.URL = "www.microsoft.com";

                Console.WriteLine(hbm);
                Console.WriteLine(bm);
                Console.ReadKey();

            }

            void Book()
            {
                Console.Clear();

                Book boek = new Book();
                boek.Title = "The Shining";
                boek.Author = "Stephen King";
                boek.ISBN = "11101110111";
                boek.Price = 20;

                TextBook textbook = new TextBook();
                textbook.Title = "Mijn tekstboek";
                textbook.Author = "Kenny Bruwier";
                textbook.ISBN = "11101110111";
                textbook.Price = 10;

                CoffeeTableBook coffeeTableBook = new CoffeeTableBook();
                coffeeTableBook.Title = "Mijn koffie-table-boek";
                coffeeTableBook.Author = "Kenny Bruwier";
                coffeeTableBook.ISBN = "11101110111";
                coffeeTableBook.Price = 20;

                Console.WriteLine(boek);
                Console.WriteLine(textbook);
                textbook.Price = 50;
                Console.WriteLine(textbook);
                Console.WriteLine(coffeeTableBook);
                coffeeTableBook.Price = 70;
                Console.WriteLine(coffeeTableBook);
                Console.WriteLine("boek.Equals(textbook) = ");
                Console.Write(boek.Equals(textbook));
                Console.ReadKey();

            }

            void MoneyMoney()
            {
                Console.Clear();

                mRekening bankRekening = new mBankRekening(500);
                mRekening spaarRekening = new mSpaarRekening(10000);
                mRekening proRekening = new mProRekening(10000);

                Console.WriteLine($"Bank rekening\tsaldo: {bankRekening.Saldo}\trente: {bankRekening.BerekenRente()}");
                Console.WriteLine($"Spaar rekening\tsaldo: {spaarRekening.Saldo}\trente: {spaarRekening.BerekenRente()}");
                Console.WriteLine($"Pro rekening\tsaldo: {proRekening.Saldo}\trente: {proRekening.BerekenRente()}");
                Console.ReadKey();

            }

            void GeometricFigures()
            {
                Console.Clear();

                int hoogte = 10;
                int breedte = 5;
                GeometricFigure rechthoek = new Rechthoek(hoogte, breedte);
                GeometricFigure vierkant = new Vierkant(hoogte);
                GeometricFigure vierkant2 = new Vierkant(hoogte, breedte);
                GeometricFigure driehoek = new Driehoek(hoogte, breedte);

                Console.WriteLine($"Oppervlakte (hoogte: {hoogte},breedte: {breedte}):\n");
                Console.WriteLine("Rechthoek: " + rechthoek.BerekenOppervlakte());
                Console.WriteLine("Vierkant met één parameter: " + vierkant.BerekenOppervlakte());
                Console.WriteLine("Vierkant met twee verschillende parameters: " + vierkant2.BerekenOppervlakte());
                Console.WriteLine("Driehoek: " + driehoek.BerekenOppervlakte());
                Console.ReadKey();

            }

            void Dierentuin()
            {

                bool exit = false;
                string[] dierenNamen = { "Kat", "Hond", "Vis", "Koe", "q" };
                List<Dier> dieren = new List<Dier>();

                while (!exit)
                {
                    bool toevoegen = true;
                    while (toevoegen)
                    {
                        Console.Clear();
                        foreach (Dier dier in dieren)
                            dier.OverZicht();
                        Dier nieuwDier = null;
                        Console.WriteLine("\n\nDieren toevoegen:");
                        switch (SelectMenu(false, dierenNamen))
                        {
                            case 1: 
                                nieuwDier = new Kat();
                                break;
                            case 2: 
                                nieuwDier = new Hond();
                                break;
                            case 3: 
                                nieuwDier = new Vis();
                                break;
                            case 4: 
                                nieuwDier = new Koe();
                                break;
                            case 5: 
                                toevoegen = false;
                                break;
                            default: exit = true; break;
                        }
                        if (nieuwDier != null)
                        {
                            nieuwDier.Naam = InputStr("Naam: ");
                            nieuwDier.Gewicht = InputInt("Gewicht: ");
                            dieren.Add(nieuwDier);
                        }
                    }
                    
                    bool opnieuw = true;
                    while (opnieuw)
                    {
                        if (dieren != null)
                        foreach (Dier dier in dieren)
                            dier.OverZicht();
                        Console.WriteLine("\n\nMenu:");
                        switch (SelectMenu(false,"Dier verwijderen","Gemiddelde gewicht","Dier praten","Opnieuw beginnen", "Exit") )
                        {
                            case 1:
                                {
                                    bool delete = true;
                                    while (delete)
                                    {
                                        List<string> dierNamen = new List<string>();
                                        foreach (Dier dier in dieren)
                                        {
                                            if ((dier.Naam != null) && (dier.Naam != ""))
                                                dierNamen.Add(dier.Naam);
                                        }
                                        dierNamen.Add("Exit");
                                        string dierToDelete = dierNamen[SelectMenu(true, dierNamen.ToArray()) - 1];
                                        if (dierToDelete == "Exit") delete = false;
                                        else
                                        {
                                            int indexToRemove = -1;
                                            foreach (Dier dier in dieren)
                                                if (dier.Naam == dierToDelete) indexToRemove = dieren.IndexOf(dier);
                                            if (indexToRemove != -1) dieren.RemoveAt(indexToRemove);
                                        }
                                    }
                                }break;
                            case 2:
                                {
                                    List<int> gewicht = new List<int>();
                                    foreach (Dier dier in dieren)
                                        if (dier.Gewicht != 0) gewicht.Add(dier.Gewicht);
                                    Console.WriteLine("Gemiddeld gewicht van al de dieren: " + Math.Round(gewicht.Average(),1));
                                }
                                break;
                            case 3:
                                {
                                    foreach (Dier dier in dieren)
                                    {
                                        Console.Write(dier.Naam + " zegt ");
                                        dier.Zegt();
                                    }
                                }
                                break;
                            case 4:
                                {
                                    opnieuw = false;
                                    dieren = new List<Dier>();
                                }
                                break;
                            case 5:
                                {
                                    opnieuw = false;
                                    exit = true;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    
                }


                Console.ReadKey();
            }

            int SelectMenu(bool clearScreen = true, params string[] menu)
            {
                int selection = 1;
                int cursTop = Console.CursorTop;
                int cursLeft = Console.CursorLeft;
                bool selected = false;
                ConsoleColor selectionForeground = Console.BackgroundColor;
                ConsoleColor selectionBackground = Console.ForegroundColor;

                if (clearScreen)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.Clear();
                } else
                {
                    cursTop = Console.CursorTop;
                    cursLeft = Console.CursorLeft;
                    Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.CursorVisible = false;

                while (!selected)
                {
                    for (int i = 0; i < menu.Length; i++)
                    {
                        if (selection == i + 1)
                        {
                            Console.ForegroundColor = selectionForeground;
                            Console.BackgroundColor = selectionBackground;
                        }
                        Console.WriteLine(string.Format("{0,5}:{1,-40}",i + 1,menu[i]));
                        Console.ResetColor();
                    }
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            selection--;
                            break;
                        case ConsoleKey.DownArrow:
                            selection++;
                            break;
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1: selection = 1; break;
                        case ConsoleKey.D2:
                        case ConsoleKey.NumPad2: selection = 2; break;
                        case ConsoleKey.D3:
                        case ConsoleKey.NumPad3: selection = 3 <= menu.Length ? 3 : menu.Length; break;
                        case ConsoleKey.D4:
                        case ConsoleKey.NumPad4: selection = 4 <= menu.Length ? 4 : menu.Length; break;
                    }
                    selection = Math.Min(Math.Max(selection, 1), menu.Length);
                    if (clearScreen)
                        Console.SetCursorPosition(0, 0);
                    else Console.SetCursorPosition(cursLeft, cursTop);
                }
                Console.Clear();
                Console.CursorVisible = true;
                return selection;
            }
            string InputStrFormat(string inputFormat = "  :    :    :", int fixedLength = 14, char charStart = '0', char charEnd = '9')
            {
                string toReturn = inputFormat;
                bool exit = false;
                int cursX = Console.CursorLeft;
                int cursY = Console.CursorTop;
                int count = 0;

                foreach(char c in toReturn)
                {
                    if (c == ' ')
                    {

                    }
                }
                while ((toReturn.Length<fixedLength)&&(!exit))
                {
                    Console.CursorLeft = cursX;
                    Console.CursorTop = cursY;
                    Console.WriteLine(toReturn,fixedLength);
                    char input = Console.ReadKey(true).KeyChar;
                    if ((input >= charStart) && (input <= charEnd))
                    {
                        //toReturn[0] = input;
                    }
                }

                return toReturn;
            }
            char InputChr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    Console.WriteLine(tekst[i]);
                return Console.ReadKey(true).KeyChar;
            }
            string InputStr(params string[] tekst)
            {
                for (int i = 0; i < tekst.GetLength(0); i++)
                    if (tekst.GetLength(0) == 1) Console.Write(tekst[i]);
                    else Console.WriteLine(tekst[i]);
                return Console.ReadLine();
            }
            bool InputBool(string tekst = "j/n", bool Cyes = true, bool Cno = false)
            {
                Console.WriteLine(tekst);
                switch (Char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case 'y':
                    case 'j': return Cyes;
                    case 'n': return Cno;
                }
                return false;
            }
            int InputInt(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return int.Parse(Console.ReadLine());
            }
            double InputDbl(string tekst = "Getal: ")
            {
                Console.Write(tekst);
                return double.Parse(Console.ReadLine());
            }

            //static int ToonMenuEnum(Enum aEnum, int x = -1, int y = -1, int beginIndex = 0, ConsoleKey aVerlatenKey = ConsoleKey.Escape)
            //{
            //    string[] tmpArr = Enum.GetNames(aEnum.GetType());

            //    return ToonMenu(tmpArr, x, y, beginIndex, aVerlatenKey);
            //}
        }
    }
}
