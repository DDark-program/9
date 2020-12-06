using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_2
{
    public struct Hardware
    {
        public string core;
        public int ram;
        public string hdd;
        public string grafics;

        public static int Everage(DataGridView table)
        {
            int result = 0;
            for (int j = 0; j < table.RowCount; j++)
            {
                for (int i = 0; i < table.ColumnCount; i++)
                {
                    result = ((int)table[1, 0].Value + (int)table[1, 1].Value + (int)table[1, 2].Value + (int)table[1, 3].Value + (int)table[1, 4].Value);
                }
            }
            return result;
        }
        //Очистить таблицу
        public static void ClearTable(DataGridView hardware)
        {
            for (int j = 0; j < hardware.RowCount; j++)
            {
                for (int i = 0; i < hardware.ColumnCount; i++)
                {
                    hardware[i, j].Value = " ";
                }
            }
        }
        public static void SaveTable(DataGridView hardware)
        {
            //Создание объекта диалогового окна для сохранения
            SaveFileDialog save = new SaveFileDialog();

            //Установка стандартных свойств
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            //Если пользователь нажал ОК
            if (save.ShowDialog() == DialogResult.OK)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamWriter file = new StreamWriter(save.FileName);

                //Записываем размер матрицы в файл
                file.WriteLine(hardware.ColumnCount);
                file.WriteLine(hardware.RowCount);

                //Записываем элемент массива в файл
                for (int j = 0; j < hardware.RowCount; j++)
                {
                    for (int i = 0; i < hardware.ColumnCount; i++)
                    {
                        file.WriteLine(hardware[j, i].Value);
                    }
                }
                file.Close();
            }
        }
        public static void OpenTable(DataGridView hardware)
        {
            OpenFileDialog open = new OpenFileDialog();
            //Установка стандартных свойств
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* |Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            //Если пользователь нажал ОК
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Создаем поток для работы с файлом и указываем ему имя файла
                StreamReader file = new StreamReader(open.FileName);
                hardware.ColumnCount = Convert.ToInt32(file.ReadLine());
                for (int j = 0; j < hardware.RowCount; j++)
                {
                    for (int i = 0; i < hardware.ColumnCount; i++)
                    {
                        hardware[j, i].Value = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
        }
    }
}
