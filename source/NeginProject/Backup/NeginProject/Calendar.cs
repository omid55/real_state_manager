using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeginProject
{
    public class Calendar
    {
        private int year;
        private int month;
        private int day;
        private int mode;
        private Month[] solarMonthes = new Month[12];
        private Month[] jalaliMonthes = new Month[12];

        public const int Solar_Date = 1;
        public const int Jalali_Date = 2;
        public const int English_Lang = 1;
        public const int Farsi_Lang = 2;


        public Calendar()
        {
            initMonthes();
        }

        public Calendar(int y, int m, int d, int mode)
        {
            initMonthes();
            year = y;
            month = m;
            day = d;
            this.mode = mode;
        }

        public Calendar(string date, int mode)
        {
            initMonthes();
            parse(date, ref year, ref month, ref day);
            this.mode = mode;
        }

        public Calendar(Calendar c)
        {
            initMonthes();
            year = c.year;
            month = c.month;
            day = c.day;
            mode = c.mode;
        }

        public void initMonthes()
        {
            for (int i = 0; i < 12; i++)
            {
                solarMonthes[i] = new Month();
                jalaliMonthes[i] = new Month();
            }
            solarMonthes[0].englishName = "January";
            solarMonthes[0].farsiName = "ژانويه";
            solarMonthes[0].days = 31;
            solarMonthes[1].englishName = "February";
            solarMonthes[1].farsiName = "فوريه";
            solarMonthes[1].days = 28;
            solarMonthes[2].englishName = "March";
            solarMonthes[2].farsiName = "مارچ";
            solarMonthes[2].days = 31;
            solarMonthes[3].englishName = "April";
            solarMonthes[3].farsiName = "آپريل";
            solarMonthes[3].days = 30;
            solarMonthes[4].englishName = "May";
            solarMonthes[4].farsiName = "مي";
            solarMonthes[4].days = 31;
            solarMonthes[5].englishName = "June";
            solarMonthes[5].farsiName = "ژوئن";
            solarMonthes[5].days = 30;
            solarMonthes[6].englishName = "July";
            solarMonthes[6].farsiName = "جولاي";
            solarMonthes[6].days = 31;
            solarMonthes[7].englishName = "August";
            solarMonthes[7].farsiName = "آگوست";
            solarMonthes[7].days = 31;
            solarMonthes[8].englishName = "September";
            solarMonthes[8].farsiName = "سپتامبر";
            solarMonthes[8].days = 30;
            solarMonthes[9].englishName = "October";
            solarMonthes[9].farsiName = "اکتبر";
            solarMonthes[9].days = 31;
            solarMonthes[10].englishName = "November";
            solarMonthes[10].farsiName = "نوامبر";
            solarMonthes[10].days = 30;
            solarMonthes[11].englishName = "December";
            solarMonthes[11].farsiName = "دسامبر";
            solarMonthes[11].days = 31;
            jalaliMonthes[0].englishName = "Farvardin";
            jalaliMonthes[0].farsiName = "فروردين";
            jalaliMonthes[0].days = 31;
            jalaliMonthes[1].englishName = "Ordibehesht";
            jalaliMonthes[1].farsiName = "ارديبهشت";
            jalaliMonthes[1].days = 31;
            jalaliMonthes[2].englishName = "Khordaad";
            jalaliMonthes[2].farsiName = "خرداد";
            jalaliMonthes[2].days = 31;
            jalaliMonthes[3].englishName = "Tir";
            jalaliMonthes[3].farsiName = "تير";
            jalaliMonthes[3].days = 31;
            jalaliMonthes[4].englishName = "Mordaad";
            jalaliMonthes[4].farsiName = "مرداد";
            jalaliMonthes[4].days = 31;
            jalaliMonthes[5].englishName = "Shahrivar";
            jalaliMonthes[5].farsiName = "شهريور";
            jalaliMonthes[5].days = 31;
            jalaliMonthes[6].englishName = "Mehr";
            jalaliMonthes[6].farsiName = "مهر";
            jalaliMonthes[6].days = 30;
            jalaliMonthes[7].englishName = "Abaan";
            jalaliMonthes[7].farsiName = "آبان";
            jalaliMonthes[7].days = 30;
            jalaliMonthes[8].englishName = "Azar";
            jalaliMonthes[8].farsiName = "آذر";
            jalaliMonthes[8].days = 30;
            jalaliMonthes[9].englishName = "Dey";
            jalaliMonthes[9].farsiName = "دي";
            jalaliMonthes[9].days = 30;
            jalaliMonthes[10].englishName = "Bahman";
            jalaliMonthes[10].farsiName = "بهمن";
            jalaliMonthes[10].days = 30;
            jalaliMonthes[11].englishName = "Esfand";
            jalaliMonthes[11].farsiName = "اسفند";
            jalaliMonthes[11].days = 29;
        }

        public int getYear() { return year; }
        public void setYear(int x) { year = x; }
        public int getMonth() { return month; }
        public void setMonth(int x) { month = x; }
        public int getDay() { return day; }
        public void setDay(int x) { day = x; }
        public int getMode() { return mode; }
        public void setMode(int x) { mode = x; }

        public void parse(string date, ref int y, ref int m, ref int d)
        {
            /*y = m = d = 0;
            int counter = 0;
            for (int i = 0; i < (int)date.Length; i++)
            {
                if (date[i] != '/')
                {
                    switch (counter)
                    {
                        case 0:
                            y = date[i] - '0' + y * 10;
                            break;

                        case 1:
                            m = date[i] - '0' + m * 10;
                            break;

                        case 2:
                            d = date[i] - '0' + d * 10;
                            break;

                        default:
                            y = m = d = -1;   // it means error had been occurred
                            break;
                    }
                }
                else
                {
                    counter++;
                }
            }*/

            DateTime da = DateTime.Parse(date);
            y = da.Year;
            m = da.Month;
            d = da.Day;
        }

        public string int2str(int num)
        {
            string result = "";
            while (num != 0)
            {
                int r = num % 10;
                result = (char)(r + '0') + result;
                num /= 10;
            }
            return result;
        }

        public string getDate()
        {
            string result = int2str(year) + "/" + int2str(month) + "/" + int2str(day);
            return result;
        }

        public bool isLeapYear(int y, int mo)    // is it (y) a leap year ?
        {
            if (mo == Jalali_Date)
            {
                int r = y % 33;
                //1-5-9-13-17-22-26-30
                if (r == 1 || r == 5 || r == 9 || r == 13 || r == 17 || r == 22 || r == 26 || r == 30)
                {
                    return true;
                }
                return false;
            }
            else   // Solar_Date
            {
                int r = y % 4;
                if (r != 0)
                {
                    return false;
                }
                if (y % 100 == 0 && y % 400 != 0)
                {
                    return false;
                }
                return true;
            }
        }

        public void calcOtherMode(ref int y, ref int m, ref int d)
        {
            const long differenceBetweenDays = 226899;
            const long differenceBetweenYears = 621;
            if (mode == Solar_Date)   // so it must convert to Jalali Date Format  (Miladi . Shamsi) 
            {
                long s = (year - 1) * 365;
                for (int i = 0; i < month - 1; i++)
                {
                    s += solarMonthes[i].days;
                }
                if (isLeapYear(year, Solar_Date))
                {
                    s++;
                }
                s += day;
                int nl = year / 4;  // number of leap years
                s += nl;
                s -= differenceBetweenDays;  // diff Days
                if (month > 3 || (month == 3 && day >= 21))
                {
                    y = year - (int)differenceBetweenYears;
                }
                else
                {
                    y = year - ((int)differenceBetweenYears + 1);
                }
                nl = y / 4;
                s -= nl;
                int ye = (int)s / 365;
                ye++;
                /*if (y != ye)
                {
                    y = m = d = -1;   // it means error had been occurred
                    return;
                }*/
                s -= (y - 1) * 365;
                int co;
                for (co = 0; co < 12; co++)
                {
                    if (s <= jalaliMonthes[co].days)
                    {
                        break;
                    }
                    s -= jalaliMonthes[co].days;
                }
                co++;
                m = co;
                d = (int)s;
            }
            else if (mode == Jalali_Date)   // so it must convert to Solar Date Format  (Shamsi . Miladi) 
            {
                long s = (year - 1) * 365;
                for (int i = 0; i < month - 1; i++)
                {
                    s += jalaliMonthes[i].days;
                }
                s += day;
                int nl = year / 4;
                s += nl;
                s += differenceBetweenDays;
                if (month < 10 || (month == 10 && day < 11))
                {
                    y = year + (int)differenceBetweenYears;
                }
                else
                {
                    y = year + (int)differenceBetweenYears + 1;
                }
                nl = y / 4;
                s -= nl;
                int ye = (int)s / 365;
                ye++;
                /*if (y != ye)
                {
                    y = m = d = -1;   // it means error had been occurred
                    return;
                }*/
                s -= (y - 1) * 365;
                int co;
                for (co = 0; co < 12; co++)
                {
                    if (co == 1)   // february
                    {
                        if (isLeapYear(y, Solar_Date))
                        {
                            if (s <= solarMonthes[co].days + 1)
                            {
                                break;
                            }
                            s -= (solarMonthes[co].days + 1);
                        }
                        else
                        {
                            if (s <= solarMonthes[co].days)
                            {
                                break;
                            }
                            s -= solarMonthes[co].days;
                        }
                    }
                    else
                    {
                        if (s <= solarMonthes[co].days)
                        {
                            break;
                        }
                        s -= solarMonthes[co].days;
                    }
                }
                co++;
                m = co;
                d = (int)s;
            }
            else
            {
                y = m = d = -1;    // it means error had been occurred
            }
        }

        public string calcOtherModeNumeric()
        {
            int y, m, d;
            y = m = d = -1;
            calcOtherMode(ref y, ref m, ref d);
            string result = int2str(y) + "/" + int2str(m) + "/" + int2str(d);
            return result;
        }

        public string calcOtherModeSentence(int lang)
        {
            int y, m, d;
            y = m = d = -1;
            calcOtherMode(ref y, ref m, ref d);
            string result;
            string enmonthname, famonthname;
            enmonthname = famonthname = "";
            switch (mode)
            {
                case Jalali_Date:   // then other is Solar_Date
                    enmonthname = solarMonthes[m - 1].englishName;
                    famonthname = solarMonthes[m - 1].farsiName;
                    break;

                case Solar_Date:    // then other is Jalali_Date
                    enmonthname = jalaliMonthes[m - 1].englishName;
                    famonthname = jalaliMonthes[m - 1].farsiName;
                    break;

                default:
                    result = "ERROR In Mode .";
                    break;
            }
            switch (lang)
            {
                case English_Lang:
                    result = "Year " + int2str(y) + " And Month " + enmonthname + " And Day " + int2str(d);
                    break;

                case Farsi_Lang:
                    result = int2str(y) + " سال " + famonthname + " ماه " + int2str(d) + " روز";
                    break;

                default:
                    result = "ERROR IN Lang .";
                    break;
            }
            return result;
        }

    }
}
