using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPPO_Analysis
{
    public partial class Form1 : Form
    {

        static char[] limiters = { ',', '.', '(', ')', '[', ']', ':', ';', '+', '-', '*', '/', '<', '>', '@'};
        static string[] reservedWords = { "program", "var", "real", "integer", "begin", "for", "downto", "do", "begin", "end", "writeln" };
        static string allTextProgram;
        static string temp = "";
        static int type;
        static List<string> tableR = new List<string>();    //Таблица ключевых слов
        static List<string> LConv = new List<string>();     //Таблица 
        static List<string> tableI = new List<string>();    //Таблица идентификаторов
        static List<string> tableC = new List<string>();    //Таблица констант
        static List<string> tableL = new List<string>();    //Таблица разделителей

        public Form1()
        {
            InitializeComponent();
        }

        private void ClearAll()     //Отчистка всех полей
        {
            LB_Conv.Items.Clear();
            LB_Const.Items.Clear();
            LB_Ident.Items.Clear();
            LB_Key.Items.Clear();
            LB_Lim.Items.Clear();
            tableR.Clear();
            LConv.Clear();
            tableI.Clear();
            tableC.Clear();
            tableL.Clear();
            temp = "";
            type = 0;
        }

        private void анализироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearAll();

            allTextProgram = RB_Example.Text;       //Занесение текст из окна ввода в переменную

            Analysis(allTextProgram);               //Запуск Анализатора

            LB_Ident.Items.Add("Идентификаторы:");
            LB_Ident.Items.AddRange(tableI.ToArray());      //Занесение списка идентифакаторов в поле на форме
            LB_Const.Items.Add("Константы:");
            LB_Const.Items.AddRange(tableC.ToArray());
            LB_Key.Items.Add("Ключевые слова:");
            LB_Key.Items.AddRange(tableR.ToArray());
            LB_Lim.Items.Add("Разделители:");
            LB_Lim.Items.AddRange(tableL.ToArray());
            LB_Conv.Items.AddRange(LConv.ToArray());

        }

        static void Analysis(string allTextProgram)
        {
            for (int i = 0; i < allTextProgram.Length; i++)
            {
                
                if (allTextProgram[i] == '\'')                  //***********
                {                                               //Поиск апострофов в тексте. Для нахождение строковых констант
                    temp += '\'';
                    i++;
                    while (allTextProgram[i] != '\'')
                    {
                        temp += allTextProgram[i];
                        i++;
                    }
                    temp += '\'';
                    type = 2;
                    Result(temp);
                    temp = null;
                }                                              //*************
                if (allTextProgram[i] == '{')                  //Нахождение в коде комментариев, чтобы в дальнейшем их не учитывать
                {
                    int chet = 1;
                    while (chet != 0)
                    {
                        i++;
                        if (allTextProgram[i] == '{')
                            chet++;
                        if (allTextProgram[i] == '}')
                            chet--;
                    }
                }                                               //**********************

                char nextChar = allTextProgram[i];              //Присваиваем переменной следующий символ строки

                int acsiiCode = (int)nextChar; // Получаем код символа
                                               // Проверяем относится ли код символа к буквам английского алфавита и знаку нижнего подчеркивания
                if (((acsiiCode >= 65) && (acsiiCode <= 90)) || ((acsiiCode >= 97) && (acsiiCode <= 122)) || (acsiiCode == 95))
                {
                    if (temp == null)
                        type = 1;
                    temp += nextChar;
                    continue;
                }
                // Проверяем относится ли код символа к цифрам или к точке
                if (((acsiiCode >= 48) && (acsiiCode <= 57)) || (acsiiCode == 46))
                {
                    // Отдельная проверка, если код символа относиться к точке проверяем, чтобы в переменной temp было число. Если в temp число, значит теперь
                    // мы считаем его дробным, в противном случае это что-то другое
                    if (acsiiCode == 46)
                    {
                        int out_r;
                        if (!int.TryParse(temp, out out_r))
                            goto not_the_number;
                    }
                    if (temp == null)
                        type = 2;
                    temp += nextChar;
                    continue;
                }
            not_the_number:                                                         //Если символ не число
                if ((nextChar == ' ' || nextChar == '\n') && temp != null)
                {
                    Result(temp);
                    temp = null;
                    continue;
                }
                // последняя проверка на принадлежность к массиву разделителей. Так же учитываем двойные разделители «:=» и двойные условные разделители
                foreach (char c in limiters)
                {
                    if (nextChar == c)
                    {
                        if (temp != null)
                            Result(temp);
                        type = 3;
                        if (nextChar == ':' && allTextProgram[i + 1] == '=')
                        {
                            temp = nextChar.ToString() + allTextProgram[i + 1];
                            Result(temp);
                            temp = null;
                            continue;
                        }
                        if (nextChar == '<' && (allTextProgram[i + 1] == '>' || allTextProgram[i + 1] == '='))
                        {
                            temp = nextChar.ToString() + allTextProgram[i + 1];
                            Result(temp);
                            temp = null;
                            continue;
                        }
                        if (nextChar == '>' && allTextProgram[i + 1] == '=')
                        {
                            temp = nextChar.ToString() + allTextProgram[i + 1];
                            Result(temp);
                            temp = null;
                            continue;
                        }
                        temp = nextChar.ToString();
                        Result(temp);
                        temp = null;
                        continue;
                    }
                }
            }

        }


        //Метод Result, где мы определяем, что же мы нашли.
        //В самом начале проверяем переменную temp на принадлежность к ключевым словам.
        //Проверяем в начале, чтобы не перепутать найденную лексему с идентификатором.
        //Если найденное не является ключевым словом, то через switch проверяем тип таблицы, определенный заранее в методе Analysis.
        static void Result(string temp)
        {
            for (int j = 0; j < reservedWords.Length; j++)
            {
                if (temp == reservedWords[j])
                {
                    for (int i = 0; i < tableR.Count; i++)
                    {
                        if (temp == tableR[i])
                        {
                            LConv.Add("3    " + i);
                            return;
                        }
                    }
                    tableR.Add(temp);
                    LConv.Add("3    " + (tableR.Count - 1));
                    return;
                }
            }
            switch (type)
            {
                case 1:
                    for (int j = 0; j < tableI.Count; j++)
                    {
                        if (temp == tableI[j])
                        {
                            LConv.Add("1    " + j);
                            return;
                        }
                    }
                    tableI.Add(temp);
                    LConv.Add("1    " + (tableI.Count - 1));
                    break;
                case 2:
                    for (int j = 0; j < tableC.Count; j++)
                    {
                        if (temp == tableC[j])
                        {
                            LConv.Add("2    " + j);
                            return;
                        }
                    }
                    tableC.Add(temp);
                    LConv.Add("2    " + (tableC.Count - 1));
                    break;
                case 3:
                    for (int j = 0; j < tableL.Count; j++)
                    {
                        if (temp == tableL[j])
                        {
                            LConv.Add("4    " + j);
                            return;
                        }
                    }
                    tableL.Add(temp);
                    LConv.Add("4    " + (tableL.Count - 1));
                    break;
            }
        }


    }
}
