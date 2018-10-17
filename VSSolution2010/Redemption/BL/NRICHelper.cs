using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Redemption
{
    class NRICHelper
    {
        public enum CheckType { NRICFIN = 0, NRIC = 1, FIN = 2 };
        public static bool checkNRICFIN(string aString)
        {
            return check(aString, CheckType.NRICFIN);
        }
        public static bool checkNRIC(string aString)
        {
            return check(aString, CheckType.NRIC);
        }
        public static bool checkFIN(string aString)
        {
            return check(aString, CheckType.FIN);
        }
        public static bool check(string nric, CheckType aCheckType)
        {
            // bool isNricFin = false;
            try
            {
                //precondition nric must be 9 digits
                if (nric.Length == 9)
                {
                    //checksum correct
                    //first letter correct
                    nric = nric.ToUpper();
                    int d1, d2, d3, d4, d5, d6, d7;
                    string a1, a2;
                    a1 = nric.Substring(0, 1);

                    d1 = Convert.ToInt32(nric.Substring(1, 1));
                    d2 = Convert.ToInt32(nric.Substring(2, 1));
                    d3 = Convert.ToInt32(nric.Substring(3, 1));
                    d4 = Convert.ToInt32(nric.Substring(4, 1));
                    d5 = Convert.ToInt32(nric.Substring(5, 1));
                    d6 = Convert.ToInt32(nric.Substring(6, 1));
                    d7 = Convert.ToInt32(nric.Substring(7, 1));

                    a2 = nric.Substring(8, 1);
                    //first letter must be:			
                    // "S" to "T" and "F" to "G" 

                    switch ((int)aCheckType)
                    {
                        case (int)CheckType.NRICFIN:
                            if ((validFinCheckSum(a1,d1, d2, d3, d4, d5, d6, d7, a2) || validNricCheckSum(a1, d1, d2, d3, d4, d5, d6, d7, a2))
                                && (checkFinFirstLetter(a1) || checkNricFirstLetter(a1)))
                                return true;
                            else
                                return false;
                        case (int)CheckType.NRIC:
                            if ((validNricCheckSum(a1, d1, d2, d3, d4, d5, d6, d7, a2)) && checkNricFirstLetter(a1))
                                return true;
                            else
                                return false;
                        case (int)CheckType.FIN:
                            if ((validFinCheckSum(a1, d1, d2, d3, d4, d5, d6, d7, a2)) && checkFinFirstLetter(a1))
                                return true;
                            else
                                return false;
                        default:
                            if ((validFinCheckSum(a1, d1, d2, d3, d4, d5, d6, d7, a2) || validNricCheckSum(a1, d1, d2, d3, d4, d5, d6, d7, a2))
                             && (checkFinFirstLetter(a1) || checkNricFirstLetter(a1)))
                                return true;
                            else
                                return false;

                    }

                }
                else
                    return false;
            }
            catch (Exception ee)
            {
              //  logger.log(ee, HttpContext.Current.Request, HttpContext.Current.Server);
                return false;
            }
            //return isNricFin;

        }

        public static int intCheck(string nric)
        {
            int isNricFin = 0;
            //precondition nric must be 9 digits
            if (nric.Length == 9)
            {
                //checksum correct
                //first letter correct
                nric = nric.ToUpper();
                int d1, d2, d3, d4, d5, d6, d7;
                string a1, a2;
                a1 = nric.Substring(0, 1);
                a2 = nric.Substring(8, 1);
                d1 = Convert.ToInt32(nric.Substring(1, 1));
                d2 = Convert.ToInt32(nric.Substring(2, 1));
                d3 = Convert.ToInt32(nric.Substring(3, 1));
                d4 = Convert.ToInt32(nric.Substring(4, 1));
                d5 = Convert.ToInt32(nric.Substring(5, 1));
                d6 = Convert.ToInt32(nric.Substring(6, 1));
                d7 = Convert.ToInt32(nric.Substring(7, 1));
                //first letter must be:			
                // "S" to "T" and "F" to "G" 
                isNricFin = modNum(d1, d2, d3, d4, d5, d6, d7);
            }
            return isNricFin;
        }
        private static  int modNum(int d1, int d2, int d3, int d4, int d5, int d6, int d7)
        {
            return (2 * d1 + 7 * d2 + 6 * d3 + 5 * d4 + 4 * d5 + 3 * d6 + 2 * d7) % 11;
        }
        private static bool validNricCheckSum(string a1, int d1, int d2, int d3, int d4, int d5, int d6, int d7, string a2)
        {
            //weight 2 7 6 5 4 3 2 G5837449R
            //		Digit = [ (d1 d2 d3 d4 d5 6 d7) . (2 7 6 5 4 3 2)] mod 11
            //      =  (2d1 + 7d2 + 6d3 + 5d4 + 4d5 + 3d6 + 2d7) mod 11
            int offset = 0;
            if (a1.Equals("T") || a1.Equals("t"))
                offset = 4;
            int checkSum = (offset+(2 * d1 + 7 * d2 + 6 * d3 + 5 * d4 + 4 * d5 + 3 * d6 + 2 * d7)) % 11;
            string lastAlpha = "@";
            //lookup table
            //Digit     10 9 8 7 6 5 4 3 2 1 0
            //Alphabet   A B C D E F G H I Z J
            switch (checkSum)
            {
                case 10:
                    lastAlpha = "A";
                    break;
                case 9:
                    lastAlpha = "B";
                    break;
                case 8:
                    lastAlpha = "C";
                    break;
                case 7:
                    lastAlpha = "D";
                    break;
                case 6:
                    lastAlpha = "E";
                    break;
                case 5:
                    lastAlpha = "F";
                    break;
                case 4:
                    lastAlpha = "G";
                    break;
                case 3:
                    lastAlpha = "H";
                    break;
                case 2:
                    lastAlpha = "I";
                    break;
                case 1:
                    lastAlpha = "Z";
                    break;
                case 0:
                    lastAlpha = "J";
                    break;
                default:
                    lastAlpha = "@";
                    return false;
            }

            if (a2.Equals(lastAlpha))
                return true;
            else
                return false;
        }

        private static bool validFinCheckSum(string a1, int d1, int d2, int d3, int d4, int d5, int d6, int d7, string a2)
        {
            //weight 2 7 6 5 4 3 2 G5837449R
            //		Digit = [ (d1 d2 d3 d4 d5 6 d7) . (2 7 6 5 4 3 2)] mod 11
            //      =  (2d1 + 7d2 + 6d3 + 5d4 + 4d5 + 3d6 + 2d7) mod 11
            int offset = 0;
            if (a1.Equals("G") || a1.Equals("g"))
                offset = 4;
            int checkSum = (offset+(2 * d1 + 7 * d2 + 6 * d3 + 5 * d4 + 4 * d5 + 3 * d6 + 2 * d7)) % 11;
            string lastAlpha = "@";
            //lookup table
            //Digit     10 9 8 7 6 5 4 3 2 1 0
            //Alphabet  T  U W X K L M N P Q R
            //y("X","W","U","T","R","Q","P","N","M","L","K");
            switch (checkSum)
            {
                case 10:
                    lastAlpha = "K";
                    break;
                case 9:
                    lastAlpha = "L";
                    break;
                case 8:
                    lastAlpha = "M";
                    break;
                case 7:
                    lastAlpha = "N";
                    break;
                case 6:
                    lastAlpha = "P";
                    break;
                case 5:
                    lastAlpha = "Q";
                    break;
                case 4:
                    lastAlpha = "R";
                    break;
                case 3:
                    lastAlpha = "T";
                    break;
                case 2:
                    lastAlpha = "U";
                    break;
                case 1:
                    lastAlpha = "W";
                    break;
                case 0:
                    lastAlpha = "X";
                    break;
                default:
                    lastAlpha = "@";
                    return false;
            }

            if (a2.Equals(lastAlpha))
                return true;
            else
                return false;
        }
        private static bool checkNricFirstLetter(string a1)
        {
            if (a1.Equals("S") || a1.Equals("T") || a1.Equals("s") || a1.Equals("t"))
                return true;
            else
                return false;
        }
        private static bool checkFinFirstLetter(string a1)
        {
            if (a1.Equals("F") || a1.Equals("G") || a1.Equals("f") || a1.Equals("g"))
                return true;
            else
                return false;
        }
    }
}
