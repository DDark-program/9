using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_2;

namespace _9
{
    public partial class Form1 : Form
    {
        Hardware[] hw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Стандартные значения для загрузки
            hw = new Hardware[9];
            Table.ColumnCount = 4;
            Table.RowCount = 5;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //Вывод среднего объема памяти
            MessageBox.Show("Средний объем памяти = " + " " + Hardware.Everage(Table).ToString() + " " + "гб");
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            //Заполнить таблицу
            int pos = (int)numericUpDown1.Value;
            hw[pos].core = (textBox1.Text);
            hw[pos].ram = Convert.ToInt32(textBox2.Text);
            hw[pos].hdd = (textBox3.Text);
            hw[pos].grafics = (textBox4.Text);
            Table[0, pos].Value = textBox1.Text;
            Table[1, pos].Value = textBox2.Text;
            Table[2, pos].Value = textBox3.Text;
            Table[3, pos].Value = textBox4.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Hardware.SaveTable(Table);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Hardware.OpenTable(Table);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил программист Подъяблонский Д.В + \n" +
                "Практическая работа №8. Задание: \n" +
                "Заполнить таблицу с аппаратными средствами на 5 компьютеров с полями: \n" +
                "тип процессор, память, HDD, видео.Вывести результат на экран. \n" +
                "Вывести средний объем памяти.");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hardware.SaveTable(Table);
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hardware.OpenTable(Table);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выполнил программист Подъяблонский Д.В + \n" +
                "Практическая работа №8. Задание: \n" +
                "Заполнить таблицу с аппаратными средствами на 5 компьютеров с полями: \n" +
                "тип процессор, память, HDD, видео.Вывести результат на экран. \n" +
                "Вывести средний объем памяти.");
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Очистить таблицу
            Hardware.ClearTable(Table);
        }
    }
}
