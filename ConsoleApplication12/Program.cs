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
           Programm.init_quadrat();
            Console.ReadLine();

        }

        void init_quadrat()
        {
            Console.WriteLine("Bitte Punkte für das Rechteck eingeben x,y");
            Console.ReadLine();
            Double[] punkt1 = new Double[2];
            Double[] punkt2 = new Double[2];
            Double[] punkt3 = new Double[2];
            Double[] punkt4 = new Double[2];
            Double[] punkt5 = new Double[2];
            Console.WriteLine("Punkt 1 (links unten):");
            string[] punkt1_string = Console.ReadLine().Split(',');

            if (punkt1_string.Length == 2)
            {
                for (int i = 0; i < punkt1_string.Length; i++)
                {
                    double temp;
                    if (double.TryParse(punkt1_string[i], out temp))
                        punkt1[i] = temp;

                }
            }
            Console.WriteLine("Punkt 2 (rechts unten):");
            string[] punkt2_string = Console.ReadLine().Split(',');
            if (punkt2_string.Length == 2)
            {
                for (int i = 0; i < punkt2_string.Length; i++)
                {
                    double temp;
                    if (double.TryParse(punkt2_string[i], out temp))
                        punkt2[i] = temp;

                }
            }
            Console.WriteLine("Punkt 3 (rechts oben):");
            string[] punkt3_string = Console.ReadLine().Split(',');
            if (punkt3_string.Length == 2)
            {
                for (int i = 0; i < punkt3_string.Length; i++)
                {
                    double temp;
                    if (double.TryParse(punkt3_string[i], out temp))
                        punkt3[i] = temp;

                }
            }
            Console.WriteLine("Punkt 4 (links oben):");
            string[] punkt4_string = Console.ReadLine().Split(',');
            if (punkt4_string.Length == 2)
            {
                for (int i = 0; i < punkt4.Length; i++)
                {
                    double tmp;
                    if (double.TryParse(punkt4_string[i], out tmp))
                        punkt4[i] = tmp;

                }
            }
            Console.WriteLine("Prüfpunkt:");
            string[] punkt5_string = Console.ReadLine().Split(',');
            if (punkt5_string.Length == 2)
            {
                for (int i = 0; i < punkt5.Length; i++)
                {
                    double tmp;
                    if (double.TryParse(punkt5_string[i], out tmp))
                        punkt5[i] = tmp;

                }
            }
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
            quadrat.check_punkt_skalar(Punkt1, Punkt2, Punkt3, Punkt4, Punkt5);

        }
    }

        public class Quadrat
        {

        public void check_punkt_simpel(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            if(p5.X > p1.X && p5.X < p3.X && p5.Y > p1.Y && p5.Y < p3.Y)
            {
                Console.WriteLine("Punkt liegt im Rechteck");
            }
            else
            {
                Console.WriteLine("Punkt liegt nicht im Rechteck");
            }
        }
        public void check_punkt_Dreieck(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            if (p5.X > p1.X && p5.X < p3.X && p5.Y > p1.Y && p5.Y < p3.Y)
            {
                Console.WriteLine("Punkt liegt im Rechteck");
            }
            else
            {
                Console.WriteLine("Punkt liegt nicht im Rechteck");
            }
        }
        public void check_punkt_skalar(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            
            Vector v1 = Point.Subtract(p2, p1);
            Vector v2 = Point.Subtract(p3, p2);
            Vector v3 = Point.Subtract(p4, p3);
            Vector v4 = Point.Subtract(p1, p4);
            Vector vv1 = Point.Subtract(p5, p1);
            Vector vv2 = Point.Subtract(p5, p2);
            Vector vv3 = Point.Subtract(p5, p3);
            Vector vv4 = Point.Subtract(p5, p4);
            //Double skalar1 = Skalar(v1, vv1);
            //Double skalar2 = Skalar(v2, vv2);
            //Double skalar3 = Skalar(v3, vv3);
            //Double skalar4 = Skalar(v4, vv4);
            if (Skalar(v1, vv1) >= 0 && Skalar(v2, vv2) >= 0 && Skalar(v3, vv3) >= 0 && Skalar(v4, vv4) >= 0)
            {
                Console.WriteLine("Punkt liegt im Rechteck");
            }
            else
            {
                Console.WriteLine("Punkt liegt nicht im Rechteck");
            }
         }

        public Double Skalar (Vector v1, Vector v2)
        {
            Double skalar  = Vector.Multiply(v1, v2);
            return skalar;
        }
    }
}