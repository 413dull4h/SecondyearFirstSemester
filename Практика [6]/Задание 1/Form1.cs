﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_1
{
  public partial class Form1 : Form
  {
    int[] Mas = new int[15];
    public Form1()
    {
      InitializeComponent();
    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    private void button1_Click(object sender, EventArgs e)
    {
      Random rand = new Random();
      textBox1.Text = "";
      for (int i = 0; i < 15; i++)
      {
        Mas[i] = rand.Next(-50, 50);
        textBox1.Text += "Mas[" + Convert.ToString(i) + "] = "
        + Convert.ToString(Mas[i]) + Environment.NewLine;
      }
    }
    private void button2_Click(object sender, EventArgs e)
    {
      
    }

    private void button2_Click_1(object sender, EventArgs e)
    {
      int a = 0;
      textBox2.Text = "";
      for (int i = 0; i < 15; i++)
      {
        if (Mas[i] < 0) Mas[i] = 0;
        if (i % 2 == 0)
          a += Mas[i];
      }
      label3.Text = Convert.ToString(a);
    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
  }
  }
