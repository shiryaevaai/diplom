using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace diplom
{
    public partial class Form1 : Form
    {
        // анализируемый файл, вычисление порядков спектра, критерий длительностей, критерий высоты
        public string file_path, file_character, file_interval, file_pitch, l_str;
        public int i, j, pos, arr_len, level1 = 0, alfa = 1;
        public bool found;
        public string[] lines;

        public Form1()
        {            
            InitializeComponent();
        }

        // Открыть файл
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_File = new OpenFileDialog();
            if (Open_File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                file_path = Open_File.FileName;
            
            file_character = file_path.Substring(0, file_path.Length-4) + "_character.txt";
            file_interval = file_path.Substring(0, file_path.Length - 4) + "_interval.txt";
            file_pitch = file_path.Substring(0, file_path.Length - 4) + "_pitch.txt";

            richTextBox1.Text = Open_File.FileName;
            richTextBox2.Text = file_character;
            richTextBox3.Text = file_interval;
            richTextBox4.Text = file_pitch;
        }

        // подсчет уровней
        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(file_path))
            {
                //Считывание файла построчно в массив
                lines = System.IO.File.ReadAllLines(file_path);
                arr_len = lines.Length;

                i = 1;		//Начальный уровень
                pos = 0;	//Начальная позиция устанавливается на 0

                System.IO.File.WriteAllText(file_character, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("", "");

                while ((pos + i) < arr_len)
                {
                    found = false;		                    //Переменная состояния поиска по словарю (найдено/не найдено)				  
                    l_str = "";
                    for (j = 0; j < i; j++)		            //Считывается левая часть, начиная с позиции pos
                        l_str += lines[pos + j];	        //Правила длиной i символов


                    /*В словаре ищется левая часть правила. Если считанная часть не найдена, то добавляется новое правило вида 
                    "считанная левая часть -> следующий за ней код из массива".Если левая часть найдена, то правая часть 
                    найденного правила сравнивается со следующим кодом в массиве после считанной последовательности.
                    Если они совпадают, то порядок увеличивается на 1 и проход по массиву начинается с начала, в противном 
                    случае позиция считывания последовательности увеличивается на одну и проход по массиву продолжается*/

                    //поиск по словарю
                    foreach (string str in dict.Keys)
                        if (str == l_str)
                            found = true;

                    //если не найдено
                    if (!(found))
                    {
                        dict.Add(l_str, lines[pos + i]);
                        pos++;
                    }
                    //если найдено и правые части совпадают
                    else if (dict[l_str] != lines[pos + i])
                    {
                        //вывод максимальной длины последовательности для текущего порядка
                        System.IO.File.AppendAllText(file_character, "Порядок: " + i.ToString() + " - " + (pos + i - j).ToString() + "\n",
                            Encoding.GetEncoding(1251));
                        level1 += i * (pos + i - j);
                        i++;
                        pos = 0;
                        //очистка словаря для экономии памяти и уменьшения количества сравниваемых элементов
                        dict.Clear();
                    }
                    //если не совпадают
                    else pos++;

                }
                //вывод максимальной длины последовательности для последнего порядка
                System.IO.File.AppendAllText(file_character, "Порядок: " + i.ToString() + " - " + (pos + i - j).ToString() + "\n" + "\n",
                               Encoding.GetEncoding(1251));
                level1 += i * (pos + i - j);
                System.IO.File.AppendAllText(file_character, "Значение 0 уровня: " + i.ToString() + "\n",
                                    Encoding.GetEncoding(1251));
                System.IO.File.AppendAllText(file_character, "Значение 1 уровня: " + level1 + "\n",
                                    Encoding.GetEncoding(1251));

                MessageBox.Show("Успех!");

            }
            else
            {
                MessageBox.Show("Выберите файл для анализа");
            }
        }

        // длительности
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                //Dictionary<string, int> interval_dict = new Dictionary<string, int>();
                
                //interval_dict.Add("1", 0);
                //interval_dict.Add("1/2", 0);
                //interval_dict.Add("1/4", 0);
                //interval_dict.Add("1/8", 0);
                //interval_dict.Add("1/16", 0);
                //interval_dict.Add("1/32", 0);

                //for (int i = 0; i < lines.Length; i++)
                //{
                //    if (double.Parse(lines[i])%6 == 0)
                //    {
                //        interval_dict["1"]++;
                //    }
                //    else if (double.Parse(lines[i]) % 6 == 1)
                //    {
                //        interval_dict["1/2"]++;
                //    }
                //    else if (double.Parse(lines[i]) % 6 == 2)
                //    {
                //        interval_dict["1/4"]++;
                //    }
                //    else if (double.Parse(lines[i]) % 6 == 3)
                //    {
                //        interval_dict["1/8"]++;
                //    }
                //    else if (double.Parse(lines[i]) % 6 == 4)
                //    {
                //        interval_dict["1/16"]++;
                //    }
                //    else 
                //    {
                //        interval_dict["1/32"]++;
                //    }

                //}

                //System.IO.File.WriteAllText(file_interval, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));

                //foreach (var interval in interval_dict)
                //{
                //    System.IO.File.AppendAllText(file_interval, "Длительность: " + interval.Key
                //        + "   Число нот: " + interval.Value.ToString()
                //        + "   Доля от общего числа нот: " + Math.Round((double)interval.Value / arr_len * 100, 2).ToString() + "%"
                //        + "\n",
                //        Encoding.GetEncoding(1251));
                //}

                FuncHelper.IntervalsForAlfa1(lines, file_interval, arr_len);
                MessageBox.Show("Успех!");
            }
            else if (this.radioButton2.Checked)
            {
                FuncHelper.IntervalsForAlfa2(lines, file_interval, arr_len);
                MessageBox.Show("Успех!");
            }
     
        }

        // принадлежность к октавам
        private void button4_Click(object sender, EventArgs e)
        {
            //// alfa 1
            if (this.radioButton1.Checked)
            {
                FuncHelper.OctsForAlfa1(lines, file_pitch, arr_len);
                MessageBox.Show("Успех!");
            }
            else if (this.radioButton2.Checked)
            {
                FuncHelper.OctsForAlfa2(lines, file_pitch, arr_len);
                MessageBox.Show("Успех!");
            }
            else
            {
                MessageBox.Show("Ничего не выбрано");
            }

            ////создание словаря для подсчёта вхождений каждой ноты и установка счётчиков в 0
            ////создание массива для поиска по нему
            //Dictionary<string, int> oct_dict = new Dictionary<string, int>();
            //int notes = 0;

            //oct_dict.Add("Большая", 0);
            //oct_dict.Add("Малая", 0);
            //oct_dict.Add("Первая", 0);
            //oct_dict.Add("Вторая", 0);
            //oct_dict.Add("Третья", 0);
            //oct_dict.Add("Четвертая", 0);
            //oct_dict.Add("Пятая", 0);

            //for (i = 0; i < lines.Length; i++)
            //{
            //    if ((int.Parse(lines[i]) >= 0) && (int.Parse(lines[i]) <= 131))
            //    {
            //        oct_dict["Большая"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 263)
            //    {
            //        oct_dict["Малая"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 395)
            //    {
            //        oct_dict["Первая"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 527)
            //    {
            //        oct_dict["Вторая"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 659)
            //    {
            //        oct_dict["Третья"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 791)
            //    {
            //        oct_dict["Четвертая"]++;
            //        notes++;
            //    }
            //    else if (int.Parse(lines[i]) <= 802)
            //    {
            //        oct_dict["Пятая"]++;
            //        notes++;
            //    }

            //}

            //System.IO.File.WriteAllText(file_pitch, "Количество символов: " + arr_len + "\n", Encoding.GetEncoding(1251));
            //System.IO.File.AppendAllText(file_pitch, "Число нот: " + notes + "\n", Encoding.GetEncoding(1251));

            //foreach (var oct in oct_dict)
            //{
            //    System.IO.File.AppendAllText(file_pitch, "Октава: " + oct.Key
            //        + "   Число входящих в нее нот: " + oct.Value.ToString()
            //        + "   Доля от общего числа нот: " + Math.Round(((double)oct.Value / (double)notes) * 100, 2).ToString() + "%"
            //        + "\n",
            //        Encoding.GetEncoding(1251));

            //}
            
        }

        
    }
}
