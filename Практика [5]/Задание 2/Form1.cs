﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_2
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      // Получаем номер выделенной строки
      int index = listBox1.SelectedIndex;
      // Считываем строку в перменную str
      string str = (string)listBox1.Items[index];
      // Узнаем количество символов в строке
      int len = str.Length;
      // Считаем, что количество пробелов равно 0
      int count = 0;
      // Устанавливаем счетчик символов в 0
      int i = 0;
      double a;
      //Организуем цикл перебора всех символов в строке
      while (i < len - 1)
      {
        // Если нашли пробел, то увеличиваем
        // счетчик пробелов на 1
        if (str[i] == ' ')
          count++;
        i++;
      }

      double b = Convert.ToDouble(count);
      double c = Convert.ToDouble(len);
             a = b / c;
      label1.Text = "Доля пробелов = " + a.ToString();
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}


// 2 5 8 11 14
