using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;

namespace diplom
{
    public class FuncHelper
    {
        public static void IntervalsForAlfa1(string[] lines, string file_interval, int arr_len)
        {
            Dictionary<string, int> interval_dict = new Dictionary<string, int>();

            interval_dict.Add("1", 0);
            interval_dict.Add("1/2", 0);
            interval_dict.Add("1/4", 0);
            interval_dict.Add("1/8", 0);
            interval_dict.Add("1/16", 0);
            interval_dict.Add("1/32", 0);

            for (int i = 0; i < lines.Length; i++)
            {
                if (double.Parse(lines[i]) % 6 == 0)
                {
                    interval_dict["1"]++;
                }
                else if (double.Parse(lines[i]) % 6 == 1)
                {
                    interval_dict["1/2"]++;
                }
                else if (double.Parse(lines[i]) % 6 == 2)
                {
                    interval_dict["1/4"]++;
                }
                else if (double.Parse(lines[i]) % 6 == 3)
                {
                    interval_dict["1/8"]++;
                }
                else if (double.Parse(lines[i]) % 6 == 4)
                {
                    interval_dict["1/16"]++;
                }
                else
                {
                    interval_dict["1/32"]++;
                }

            }

            System.IO.File.WriteAllText(file_interval, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));

            foreach (var interval in interval_dict)
            {
                System.IO.File.AppendAllText(file_interval, "Длительность: " + interval.Key
                    + "   Число нот: " + interval.Value.ToString()
                    + "   Доля от общего числа нот: " + Math.Round((double)interval.Value / arr_len * 100, 2).ToString() + "%"
                    + "\n",
                    Encoding.GetEncoding(1251));
            }

        }

        public static void IntervalsForAlfa2(string[] lines, string file_interval, int arr_len)
        {
            Dictionary<string, int> interval_dict = new Dictionary<string, int>();

            interval_dict.Add("1", 0);
            interval_dict.Add("1.", 0);
            interval_dict.Add("1/2", 0);
            interval_dict.Add("1/2.", 0);
            interval_dict.Add("1/4", 0);
            interval_dict.Add("1/4.", 0);
            interval_dict.Add("1/8", 0);
            interval_dict.Add("1/8.", 0);
            interval_dict.Add("1/16", 0);
            interval_dict.Add("1/16.", 0);
            interval_dict.Add("1/32", 0);

            for (int i = 0; i < lines.Length; i++)
            {
                if (double.Parse(lines[i]) % 11 == 0)
                {
                    interval_dict["1"]++;
                }
                else if (double.Parse(lines[i]) % 11 == 1)
                {
                    interval_dict["1."]++;
                }
                else if (double.Parse(lines[i]) % 11 == 2)
                {
                    interval_dict["1/2"]++;
                }
                else if (double.Parse(lines[i]) % 11 == 3)
                {
                    interval_dict["1/2."]++;
                }
                else if (double.Parse(lines[i]) % 11 == 4)
                {
                    interval_dict["1/4"]++;
                }
                else if (double.Parse(lines[i]) % 11 == 5)
                {
                    interval_dict["1/4."]++;
                }
                else if (double.Parse(lines[i]) % 11 == 6)
                {
                    interval_dict["1/8"]++;
                }
                else if (double.Parse(lines[i]) % 11 == 7)
                {
                    interval_dict["1/8."]++;
                }
                else if (double.Parse(lines[i]) % 11 == 8)
                {
                    interval_dict["1/16"]++;
                }
                else if (double.Parse(lines[i]) % 11 == 9)
                {
                    interval_dict["1/16."]++;
                }
                else if (double.Parse(lines[i]) % 11 == 10)
                {
                    interval_dict["1/32"]++;
                }
            }

            System.IO.File.WriteAllText(file_interval, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));

            foreach (var interval in interval_dict)
            {
                System.IO.File.AppendAllText(file_interval, "Длительность: " + interval.Key
                    + "   Число нот: " + interval.Value.ToString()
                    + "   Доля от общего числа нот: " + Math.Round((double)interval.Value / arr_len * 100, 2).ToString() + "%"
                    + "\n",
                    Encoding.GetEncoding(1251));
            }

        }

        public static void OctsForAlfa1(string[] lines, string file_pitch, int arr_len)
        {
            // alfa 1

            //создание словаря для подсчёта вхождений каждой ноты и установка счётчиков в 0
            //создание массива для поиска по нему
            Dictionary<string, int> oct_dict = new Dictionary<string, int>();
            string[] tmp = new string[366];
            int notes = 0;

            oct_dict.Add("Большая", 0);
            oct_dict.Add("Малая", 0);
            oct_dict.Add("Первая", 0);
            oct_dict.Add("Вторая", 0);
            oct_dict.Add("Третья", 0);

            for (int i = 0; i < lines.Length; i++)
            {
                if ((int.Parse(lines[i]) >= 0) && (int.Parse(lines[i]) <= 71))
                {
                    oct_dict["Большая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 143)
                {
                    oct_dict["Малая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 215)
                {
                    oct_dict["Первая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 287)
                {
                    oct_dict["Вторая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 359)
                {
                    oct_dict["Третья"]++;
                    notes++;
                }

            }

            System.IO.File.WriteAllText(file_pitch, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));
            System.IO.File.AppendAllText(file_pitch, "Число нот: " + notes + "\n", Encoding.GetEncoding(1251));

            foreach (var oct in oct_dict)
            {
                System.IO.File.AppendAllText(file_pitch, "Октава: " + oct.Key
                    + "   Число входящих в нее нот: " + oct.Value.ToString()
                    + "   Доля от общего числа нот: " + Math.Round(((double)oct.Value / (double)notes) * 100, 2).ToString() + "%"
                    + "\n",
                    Encoding.GetEncoding(1251));
            }

        }

        public static void OctsForAlfa2(string[] lines, string file_pitch, int arr_len)
        {
            //создание словаря для подсчёта вхождений каждой ноты и установка счётчиков в 0
            //создание массива для поиска по нему
            Dictionary<string, int> oct_dict = new Dictionary<string, int>();
            int notes = 0;

            oct_dict.Add("Большая", 0);
            oct_dict.Add("Малая", 0);
            oct_dict.Add("Первая", 0);
            oct_dict.Add("Вторая", 0);
            oct_dict.Add("Третья", 0);
            oct_dict.Add("Четвертая", 0);
            oct_dict.Add("Пятая", 0);

            for (int i = 0; i < lines.Length; i++)
            {
                if ((int.Parse(lines[i]) >= 0) && (int.Parse(lines[i]) <= 131))
                {
                    oct_dict["Большая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 263)
                {
                    oct_dict["Малая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 395)
                {
                    oct_dict["Первая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 527)
                {
                    oct_dict["Вторая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 659)
                {
                    oct_dict["Третья"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 791)
                {
                    oct_dict["Четвертая"]++;
                    notes++;
                }
                else if (int.Parse(lines[i]) <= 802)
                {
                    oct_dict["Пятая"]++;
                    notes++;
                }

            }

            System.IO.File.WriteAllText(file_pitch, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));
            System.IO.File.AppendAllText(file_pitch, "Число нот: " + notes + "\n", Encoding.GetEncoding(1251));

            foreach (var oct in oct_dict)
            {
                System.IO.File.AppendAllText(file_pitch, "Октава: " + oct.Key
                    + "   Число входящих в нее нот: " + oct.Value.ToString()
                    + "   Доля от общего числа нот: " + Math.Round(((double)oct.Value / (double)notes) * 100, 2).ToString() + "%"
                    + "\n",
                    Encoding.GetEncoding(1251));
            } 

        }

    }
}
