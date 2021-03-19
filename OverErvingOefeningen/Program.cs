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
            Bank();

            Console.ReadLine();


            void Ziekenhuis()
            {
                Patient patient = new Patient();
                VerzekerdePatient verzekerdePatient = new VerzekerdePatient();

                patient.Naam = "niet verzekerde patient";
                patient.AantalUren = 100;
                patient.ToonInfo();
                Console.WriteLine();
                verzekerdePatient.Naam = "verzekerde patient";
                verzekerdePatient.AantalUren = 100;
                verzekerdePatient.ToonInfo();
            }

            void BookmarkManagar()
            {
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
                        Console.WriteLine((i + 1) + ": " + menu[i]);
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
            string InputStrFormat(string inputFormat = "", int fixedLength = 0, char charStart = 'a', char charEnd = 'z')
            {
                string toReturn = "";
                bool exit = false;
                int cursX = Console.CursorLeft;
                int cursY = Console.CursorTop;
                while ((toReturn.Length<fixedLength)&&(!exit))
                {
                    Console.WriteLine(toReturn,fixedLength);
                    char input = Console.ReadKey().KeyChar;
                    if ((input >= charStart) && (input <= charEnd))
                    {
                        toReturn += input;
                        if (toReturn.Length <= inputFormat.Length)
                        {
                            if (inputFormat[toReturn.Length - 1] != ' ')
                                toReturn += inputFormat[toReturn.Length - 1];
                        }
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
        }

        
    }
}
