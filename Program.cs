using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_1
{
    class Program
    {

        //Funktion Berechnung der Flaeche
        public static double BerechnungFlaeche(double a, double b)
        {
            double F = a * b;
            return F;
        }

        //Funktion Ausgabe der Flaeche
        public static void AusgabeErgebnis(double F)
        {
            Console.Write("Die Flaeche beträgt: ");
            Console.WriteLine(F + " mm² "); //Ausgabe Ergebnis der Fläche
        }

        //Funktion Berechnung des Volumen
        public static double BerechnungVolumen(double h, double b, double t)
        {
            double V = (h * b * t);
            return V;
        }

        //Funktion Ausgabe des Volumen
        public static void AusgabeVolumen(double V)
        {
            Console.WriteLine("Das Volumen das Rechteckes beträgt: " + V + " qmm³."); //Ausgabe Ergebnis des Volumen
        }

        //Unterprogramm zur Auswahl des Materials und der zugehörigen Dichte
        static double Auswahl()
        {
            //Auswahl Material
            double mm; //Dichte deklariert
            Console.WriteLine("Material: ");
            Console.WriteLine("Bitte geben Sie die entsprechende Zahl für das Material ein"); //Aufforderung und Eingabe der Materialauswahl
            Console.WriteLine("Aluminium (1), Stahl (2), Kupfer (3)");
            int auswahl = Convert.ToInt32(Console.ReadLine());

            //switch (Auswahl) Aussage zur Dichte zugehörig zum gewählten Material 
            switch (auswahl)
            {
                case 1:
                    mm = (0.0027);

                    Console.WriteLine("Dichte des Profils: " + mm + " g/mm³");
                    return mm;

                case 2:
                    mm = (0.00785);

                    Console.WriteLine("Dichte des Profils: " + mm + " g/mm³");
                    return mm;

                case 3:
                    mm = (0.0089);

                    Console.WriteLine("Dichte des Profils: " + mm + " g/mm³");
                    return mm;

                default:
                    Console.WriteLine("Bitte gültigen Wert angeben."); //Fehler bei Eingabe eines Wertes ungleich 1, 2 oder 3. Bei Eingabe keiner natürlichen Zahl wird das Programm abgebrochen.
                    return 0;
            }
        }

        //Funktion zur Berechnung der Masse
        public static double BerechnungMasse(double V, double D)
        {
            double gewicht = V * D;
            return gewicht; //Zurück an die Main
        }

        //Funktion zur Ausgabe des Ergebnisses der Masse
        public static void AusgabeMasse(double gewicht)
        {
            Console.WriteLine("Die Masse beträgt: " + gewicht + " g");
        }

        // Unterprogramm Flächenträgheitsmomente x ausrechnen
        static double x_Flaechentraegheitsmoment(double b, double h)
        {
            double Ix = (h * b * b * b) / 12;
            return Ix;
        }

        // Unterprogramm Flächenträgheitsmomente y ausrechnen
        static double y_Flaechentraegheitsmoment(double b, double h)
        {
            double Iy = (b * h * h * h) / 12;
            return Iy;
        }

        // Unterprogramm Flächenträgheitsmomente niedrigstes bestimmen
        static double Flaechentraegheitsmoment(double Ix, double Iy)
        {
            double I;
            if (Ix > Iy)
            {
                I = Iy;
            }
            else
            {
                I = Ix;
            }
            return I;
        }

        static void Main(string[] args)
        {

            Console.Write("Eingabe Kantenlänge a in mm: ");
            double a = Convert.ToDouble(Console.ReadLine()); //Eingabe Kantenlänge a = Höhe
            Console.Write("Eingabe Kantenlänge b in mm: ");
            double b = Convert.ToDouble(Console.ReadLine()); //Eingabe Kantenlänge b = Breite
            double F = BerechnungFlaeche(a, b); //Aufrufen der Funktion zur Berechnung der Fläche
            AusgabeErgebnis(F); //Funkion Ausgabe der Fläche

            //double a = Convert.ToDouble(Console.ReadLine());
            //double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Eingabe Kantenlänge t in mm: ");
            double t = Convert.ToDouble(Console.ReadLine()); //Eingabe Kantenlänge t = Tiefe

            double V = BerechnungVolumen(a, b, t); //Aufrufen der Funktion zur Berechnung des Volumens
            AusgabeVolumen(V); //Das Volumen wird ausgegeben

            double D = Auswahl(); //Aufrufen des Unterprogrammes zur Materialauswahl
            while (D == 0)
                D = Auswahl(); //solange eine natürliche Zahl eingeben wird, die groeßer als 3 wird das Unterprogramm Auswahl() immer wieder neu gestartet.

            double gewicht = BerechnungMasse(V, D); //Aufrufen der Funktion zur Berechnung der Masse
            AusgabeMasse(gewicht); //Ausgabe der Masse über eine Funktion

            //double a = Convert.ToDouble(a);
            //double b = Convert.ToDouble(b);

            double Ix = x_Flaechentraegheitsmoment(Convert.ToDouble(a), Convert.ToDouble(b)); // Übergabe an das Unterprogramm
            double Iy = y_Flaechentraegheitsmoment(Convert.ToDouble(a), Convert.ToDouble(b)); // Übergabe an das Unterprogramm
            double I = Flaechentraegheitsmoment(Ix, Iy); // Übergabe an das Unterprogramm

            Console.WriteLine("Das Flächenträgkeitsmoment beträgt: " + I + " mm^4."); //Ausgabe Flächenträgheitsmoment
            Console.WriteLine("Zum Beenden beliebige Taste drücken.");
            Console.ReadKey();
        }

    }
}