using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_2
{
    public class Hardware
    {
        //Автоматическое заполнение Таблицы
        public static void HardwareFill(DataGridView hardware)
        {
            Random rnd = new Random();
            for (int j = 0; j < hardware.RowCount; j++)
            {
                hardware[0, 0].Value = "Номер ПК";
                hardware[0, 1].Value = "1 ПК";
                hardware[0, 2].Value = "2 ПК";
                hardware[0, 3].Value = "3 ПК";
                hardware[0, 4].Value = "4 ПК";
                hardware[0, 5].Value = "5 ПК";
                for (int i = 0; i < hardware.ColumnCount; i++)
                {
                    hardware[1, 0].Value = "Тип процессора";
                    hardware[2, 0].Value = "Объем памяти(гб)";
                    hardware[3, 0].Value = "HDD";
                    hardware[4, 0].Value = "Видео";
                    //Ячейки типа процессора
                    hardware[1, 1].Value = "AMD Ryzen Threadripper PRO 3995WX";
                    hardware[1, 2].Value = "Intel Xeon W-2265";
                    hardware[1, 3].Value = "Intel Core i9-10920X";
                    hardware[1, 4].Value = "Intel Core i7-10700K";
                    hardware[1, 5].Value = "Intel Core i5-9400KF";
                    //Ячейки памяти заполняются автоматически в промежутке от 0 до 10240 (гб)
                    hardware[2, 1].Value = rnd.Next(7168, 10240);
                    hardware[2, 2].Value = rnd.Next(5120, 7168);
                    hardware[2, 3].Value = rnd.Next(3072, 5120);
                    hardware[2, 4].Value = rnd.Next(1024, 3072);
                    hardware[2, 5].Value = rnd.Next(0, 1024);
                    //Ячейки HDD
                    hardware[3, 1].Value = "Western Digital Blue";
                    hardware[3, 2].Value = "Seagate";
                    hardware[3, 3].Value = "Samsung";
                    hardware[3, 4].Value = "Western Digital Green";
                    hardware[3, 5].Value = "Western Digital Red";
                    //Ячейки Видео
                    hardware[4, 1].Value = "NVIDIA GeForce RTX 3090";
                    hardware[4, 2].Value = "NVIDIA Titan RTX";
                    hardware[4, 3].Value = "AMD Radeon RX 6800 XT";
                    hardware[4, 4].Value = "NVIDIA GeForce GTX 1660 Ti";
                    hardware[4, 5].Value = "NVIDIA GeForce GTX 1060 6GB";
                }
            }
        }
        //Расчитывание среднего значения памяти ПК
        public static int Average(DataGridView hardware)
        {
            int result = 0;
            for (int j = 0; j < hardware.RowCount; j++)
            {
                for (int i = 0; i < hardware.ColumnCount; i++)
                {
                    result = ((int)hardware[2, 1].Value + (int)hardware[2, 2].Value + (int)hardware[2, 3].Value + (int)hardware[2, 4].Value + (int)hardware[2, 5].Value)/5;
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
