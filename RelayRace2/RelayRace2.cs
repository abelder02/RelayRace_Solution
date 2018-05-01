using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTasksDLL;

namespace RelayRace2
{
    class RelayRace2
    {
        static void Main(string[] args)
        {
            CT.Header(out CT.LengthOfTopLine, "Relay Race", "to add up the times of the relay race");

            double addToSec;
            double addToMin;

            DateTime leg1 = AskUserForRelayTime("the first leg time (mm.ss.ff)");
            DateTime leg2 = AskUserForRelayTime("the second leg time (mm.ss.ff)");
            DateTime leg3 = AskUserForRelayTime("the third leg time (mm.ss.ff)");
            DateTime leg4 = AskUserForRelayTime("the fourth leg time (mm.ss.ff)");

            double amtOfMilSec = GetTotalMilSec(out addToSec, leg1, leg2, leg3, leg4);
            double amtOfSec = GetTotalSec(out addToMin, addToSec, leg1, leg2, leg3, leg4);
            int amtOfMin = GetTotalMin(addToMin, leg1, leg2, leg3, leg4);

            DateTime finalRelayTime = new DateTime();
            finalRelayTime = finalRelayTime.AddMinutes(amtOfMin).AddSeconds(amtOfSec).AddMilliseconds(amtOfMilSec);
            Console.Write("\nThe Final Relay Time is: ");
            CT.Color("green");
            string displayInitial = finalRelayTime.ToString("mm.ss.fff");
            string display = displayInitial.Remove(6, 1);
            Console.WriteLine(display);

            CT.Footer();

        }

        public static DateTime AskUserForRelayTime(string x)
        {
            CT.Color("");
            Console.Write("\nPlease enter {0} ", x);
            CT.Color("green");
            CultureInfo provider = CultureInfo.InvariantCulture;
            string leg1 = Console.ReadLine();

            for (int i = 0; i < 1; i++)
            {

                try
                {
                    DateTime test = DateTime.ParseExact(leg1, "mm.ss.ff", provider, DateTimeStyles.AllowWhiteSpaces);
                }
                catch (Exception)
                {
                    CT.Color("");
                    Console.Write("\nYou knucklehead! \nPlease type it in the correct format: \"mm.ss.ff\" ");
                    CT.Color("green");
                    leg1 = Console.ReadLine();
                    CT.Color("");
                    i--;
                }

            }

            CT.Color("");
            int startIndex = leg1.IndexOf(".");
            int startIndex2 = leg1.LastIndexOf(".");
            int leg1min = Convert.ToInt32(leg1.Substring(0, startIndex));
            string leg1sec = leg1.Substring(startIndex + 1, startIndex2 - startIndex);
            string leg1milsec = leg1.Substring(startIndex2 + 1, 2);
            int l1min = Convert.ToInt32(leg1min);
            double l1sec = Convert.ToDouble(leg1sec);
            double l1milsec = Convert.ToDouble(leg1milsec);


            DateTime Leg = new DateTime(6);
            Leg = Leg.AddMinutes(l1min).AddSeconds(l1sec).AddMilliseconds(l1milsec);

            return Leg;
        }

        public static double GetTotalMilSec(out double x, DateTime a, DateTime b, DateTime c, DateTime d)
        {
            double aa = a.Millisecond, bb = b.Millisecond, cc = c.Millisecond, dd = d.Millisecond;
            double totalMilSec = aa + bb + cc + dd;
            int finalMilSec = (int)(totalMilSec % 60);
            x = (totalMilSec - finalMilSec) / 60;
            return finalMilSec;
        }

        public static double GetTotalSec(out double x, double y, DateTime a, DateTime b, DateTime c, DateTime d)
        {
            double aa = a.Second, bb = b.Second, cc = c.Second, dd = d.Second;
            double totalSec = aa + bb + cc + dd + y;
            int finalSec = (int)(totalSec % 60);
            x = (totalSec - finalSec) / 60;
            return finalSec;
        }

        public static int GetTotalMin(double y, DateTime a, DateTime b, DateTime c, DateTime d)
        {
            double aa = a.Minute, bb = b.Minute, cc = c.Minute, dd = d.Minute;
            double totalSec = aa + bb + cc + dd + y;
            int finalSec = Convert.ToInt32(totalSec);
            return finalSec;
        }
    }
}
