using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Punktberechnung
{
    class Program
    {
        static void Main(string[] args)
        {
           Program Programm = new Program();
           Programm.Init_quadrat();
            Console.ReadLine();
        }

        void Init_quadrat()
        {
            Console.WriteLine("Bitte Punkte für das Rechteck eingeben x,y");
            Console.ReadLine();
            Console.WriteLine("Punkt 1 (links unten):");
            string[] punkt1_string = Console.ReadLine().Split(',');
            double[] punkt1 = Array.ConvertAll(punkt1_string, double.Parse);
            Console.WriteLine("Punkt 2 (rechts unten):");
            string[] punkt2_string = Console.ReadLine().Split(',');
            double[] punkt2 = Array.ConvertAll(punkt2_string, double.Parse);
            Console.WriteLine("Punkt 3 (rechts oben):");
            string[] punkt3_string = Console.ReadLine().Split(',');
            double[] punkt3 = Array.ConvertAll(punkt3_string, double.Parse);
            Console.WriteLine("Punkt 4 (links oben):");
            string[] punkt4_string = Console.ReadLine().Split(',');
            double[] punkt4 = Array.ConvertAll(punkt4_string, double.Parse);
            Console.WriteLine("Prüfpunkt:");
            string[] punkt5_string = Console.ReadLine().Split(',');
            double[] punkt5 = Array.ConvertAll(punkt5_string, double.Parse);
            //Point Struct initialisierung
            Point Punkt1 = new Point(punkt1[0], punkt1[1]);
            Point Punkt2 = new Point(punkt2[0], punkt2[1]);
            Point Punkt3 = new Point(punkt3[0], punkt3[1]);
            Point Punkt4 = new Point(punkt4[0], punkt4[1]);
            Point Punkt5 = new Point(punkt5[0], punkt5[1]);
            Console.WriteLine("Punkt1: " + Punkt1);
            Console.WriteLine("Punkt2: " + Punkt2);
            Console.WriteLine("Punkt3: " + Punkt3);
            Console.WriteLine("Punkt4: " + Punkt4);
            Console.WriteLine("Prüfpunkt: " + Punkt5);
            Console.ReadLine();
            Quadrat quadrat = new Quadrat();
            Console.WriteLine("Methode: " + "1:Simpel 2:Dreieck 3:Skalar 4:Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    quadrat.Simpel(Punkt1, Punkt2, Punkt3, Punkt4, Punkt5);
                    break;
                case "2":
                    quadrat.Dreieck(Punkt1, Punkt2, Punkt3, Punkt4, Punkt5);
                    break;
                case "3":
                    quadrat.Skalar(Punkt1, Punkt2, Punkt3, Punkt4, Punkt5);
                    break;
                default:
                    Console.WriteLine("Applikation wird beendet");
                    Console.ReadLine();
                    Environment.Exit(0);
                    break;
            }
        }
    }

        public class Quadrat
        {

        public void Simpel(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            if(p5.X > p1.X && p5.X < p3.X && p5.Y > p1.Y && p5.Y < p3.Y)
            {Console.WriteLine("Punkt liegt im Rechteck");}
            else
            {Console.WriteLine("Punkt liegt nicht im Rechteck");}
        }
        public void Dreieck(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            double denom = ((p2.Y - p3.Y) * (p1.X - p3.X) + (p3.X - p2.X) * (p1.Y - p3.Y));
            double nom_a = ((p2.Y - p3.Y) * (p5.X - p3.X) + (p3.X - p2.X) * (p5.Y - p3.Y));
            double nom_b = ((p3.Y - p1.Y) * (p5.X - p3.X) + (p1.X - p3.X) * (p5.Y - p3.Y));
                double a = nom_a / denom;
                double b = nom_b / denom;
                double c = 1 - a - b;
            Console.WriteLine(0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1);
        }
        public void Skalar(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            //C# Vector Struct initialisierung
            Vector v1 = Point.Subtract(p2, p1);
            Vector v2 = Point.Subtract(p3, p2);
            Vector v3 = Point.Subtract(p4, p3);
            Vector v4 = Point.Subtract(p1, p4);
            Vector vv1 = Point.Subtract(p5, p1);
            Vector vv2 = Point.Subtract(p5, p2);
            Vector vv3 = Point.Subtract(p5, p3);
            Vector vv4 = Point.Subtract(p5, p4);
            if (Skalar(v1, vv1) >= 0 && Skalar(v2, vv2) >= 0 && Skalar(v3, vv3) >= 0 && Skalar(v4, vv4) >= 0)
            {Console.WriteLine("Punkt liegt im Rechteck");}
            else
            {Console.WriteLine("Punkt liegt nicht im Rechteck");}
         }

        public double Skalar (Vector v1, Vector v2)
        {
            double skalar  = Vector.Multiply(v1, v2);
            return skalar;
        }
    }
}
