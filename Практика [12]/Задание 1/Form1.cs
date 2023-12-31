﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Задание_1
{
    public partial class Form1 : Form
    {
        // Вариант 10.
        private double[,] A = new double[6, 2]{ { 0.0, 6.0 },
                                                { 0.2, 3.0 },
                                                { 0.4, 2.0 },
                                                { 0.6, 6.0 },
                                                { 0.8, 2.0 },
                                                { 1.0, 5.0 } };
        
        private Random rnd = new Random();
        ChartArea area = new ChartArea();
        Chart chart;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "x";
            dataGridView1.Columns[0].Width = 79;
            dataGridView1.Columns[1].HeaderText = "y";
            dataGridView1.Columns[1].Width = 78;
            
            for (int i=0; i<6; i++)
            for (int j=0; j<2; j++)
                dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(A[i,j]);
            
            dataGridView2.RowCount = 2;
            dataGridView2.ColumnCount = 3;
            dataGridView2.Columns[0].HeaderText = "Матрица";
            dataGridView2.Columns[0].Width = 78;
            dataGridView2.Columns[1].HeaderText = "Системы 1";
            dataGridView2.Columns[1].Width = 81;
            dataGridView2.Columns[2].HeaderText = "Столбец свободных членов";
            dataGridView2.Columns[2].Width = 78;
            
            dataGridView3.RowCount = 2;
            dataGridView3.ColumnCount = 2;
            dataGridView3.Columns[0].HeaderText = "Коэффициент";
            dataGridView3.Columns[0].Width = 79;
            dataGridView3.Columns[1].HeaderText = "Значение";
            dataGridView3.Columns[1].Width = 78;
            
            dataGridView4.RowCount = 3;
            dataGridView4.ColumnCount = 4;
            dataGridView4.Columns[0].HeaderText = "Матрица";
            dataGridView4.Columns[0].Width = 79;
            dataGridView4.Columns[1].HeaderText = "Системы";
            dataGridView4.Columns[1].Width = 79;
            dataGridView4.Columns[2].HeaderText = "2";
            dataGridView4.Columns[2].Width = 79;
            dataGridView4.Columns[3].HeaderText = "Столбец свободных членов";
            dataGridView4.Columns[3].Width = 80;
            
            dataGridView5.RowCount = 3;
            dataGridView5.ColumnCount = 2;
            dataGridView5.Columns[0].HeaderText = "Коэффициент";
            dataGridView5.Columns[0].Width = 79;
            dataGridView5.Columns[1].HeaderText = "Значение";
            dataGridView5.Columns[1].Width = 78;
            
            chart = new Chart();
            chart.Parent = this;
            chart.SetBounds(12, 184, 486, 206);
            
            area.Name = "001";
            area.AxisX.Minimum = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
            area.AxisX.Maximum = Convert.ToDouble(dataGridView1.Rows[5].Cells[0].Value);
            area.AxisX.MajorGrid.Interval = 0.2;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.Minimum = 0.0;
            area.AxisY.Maximum = 7.0;
            area.AxisY.MajorGrid.Interval = 1;
            chart.ChartAreas.Add(area);
            Legend legend = new Legend();
            chart.Legends.Add(legend);
            
            var graph = new Series() {
                LegendText = " ",
                ChartType = SeriesChartType.Point,
                Color = Color.White,
            };
            chart.Series.Add(graph);
            graph.Points.AddXY(0.1, 0.5);

        }
        
        // Подсчёт системы №1 (Сделать)
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows[0].Cells[0].Value = dataGridView1.Rows[0].Cells[0].Value;
            dataGridView3.Rows[0].Cells[1].Value =
                (Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value) + Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value)) / 2;
            dataGridView3.Rows[1].Cells[0].Value = dataGridView1.Rows[5].Cells[0].Value;
            dataGridView3.Rows[1].Cells[1].Value = 
                (Convert.ToDouble(dataGridView1.Rows[4].Cells[1].Value) + Convert.ToDouble(dataGridView1.Rows[5].Cells[1].Value)) / 2;
            
            button1.Enabled = false;
            button4.Enabled = true;
        }
        
        // Подсчёт системы №2 (Сделать)
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView5.Rows[0].Cells[0].Value = dataGridView3.Rows[0].Cells[0].Value;
            dataGridView5.Rows[0].Cells[1].Value = Convert.ToDouble(dataGridView3.Rows[0].Cells[1].Value) - 0.5;
            dataGridView5.Rows[1].Cells[0].Value =
                (Convert.ToDouble(dataGridView1.Rows[2].Cells[0].Value) + Convert.ToDouble(dataGridView1.Rows[3].Cells[0].Value)) / 2 - 0.01;
            dataGridView5.Rows[1].Cells[1].Value =
                (Convert.ToDouble(dataGridView1.Rows[2].Cells[1].Value) + Convert.ToDouble(dataGridView1.Rows[3].Cells[1].Value)) / 2 + 0.5;
            dataGridView5.Rows[2].Cells[0].Value = dataGridView3.Rows[1].Cells[0].Value;
            dataGridView5.Rows[2].Cells[1].Value = Convert.ToDouble(dataGridView3.Rows[1].Cells[1].Value) - 0.5;
            
            button2.Enabled = false;
            button5.Enabled = true;
        }
        
        // Добавление на график начальных точек (Готово)
        private void button3_Click(object sender, EventArgs e)
        {
            var xySeries = new Series() {
                LegendText = "Начальные данные",
                ChartType = SeriesChartType.Point,
                Color = Color.Blue,
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 10
            };
            chart.Series.Add(xySeries);
            for (int i = 0; i < 6; i++)
                xySeries.Points.AddXY(A[i,0], A[i,1]);
            button3.Enabled = false;
        }

        // Добавление на график точек с системы 1 (Готово)
        private void button4_Click(object sender, EventArgs e)
        {
            var poly1 = new Series() {
            LegendText = "Полином первой степени",
            ChartType = SeriesChartType.Line,
            Color = Color.DarkRed,
            BorderWidth = 2
            };
            chart.Series.Add(poly1);
            for (int i = 0; i < 2; i++)
                poly1.Points.AddXY(double.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString()));
            area.AxisX.MajorGrid.Interval = 0.2;
            button4.Enabled = false;
        }

        // Добавление на график точек с системы 2 (Готово)
        private void button5_Click(object sender, EventArgs e)
        {
            var poly2 = new Series() {
                LegendText = "Полином второй степени",
                ChartType = SeriesChartType.Spline,
                Color = Color.DarkGoldenrod,
                BorderWidth = 2
            };
            chart.Series.Add(poly2);
            for (int i = 0; i < 3; i++)
                poly2.Points.AddXY(double.Parse(dataGridView5.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));
            area.AxisX.MajorGrid.Interval = 0.2;
            button5.Enabled = false;
        }
         
        
        // (DEBUG) Функция изменения варианта
        private void button6_Click(object sender, EventArgs e)
        {
            switch (textBox1.Text)
            {
                case "1":
                    A = new double[6, 2]{   { 0.0, 3.0 },
                                            { 0.2, 6.0 },
                                            { 0.4, 3.0 },
                                            { 0.6, 6.0 },
                                            { 0.8, 4.0 },
                                            { 1.0, 3.0 }};
                    break;
                case "2":
                    A = new double[6, 2]{   { 0.0, 5.0 },
                                            { 0.2, 5.0 },
                                            { 0.4, 4.0 },
                                            { 0.6, 4.0 },
                                            { 0.8, 6.0 },
                                            { 1.0, 6.0 }};
                    break;
                case "3":
                    A = new double[6, 2]{   { 3.0, 2.0 },
                                            { 3.2, 3.0 },
                                            { 3.4, 3.0 },
                                            { 3.6, 3.0 },
                                            { 3.8, 2.0 },
                                            { 4.0, 4.0 }};
                    break;
                case "4":
                    A = new double[6, 2]{   { 3.0, 6.0 },
                                            { 3.2, 2.0 },
                                            { 3.4, 6.0 },
                                            { 3.6, 4.0 },
                                            { 3.8, 3.0 },
                                            { 4.0, 4.0 }};
                    break;
                case "5":
                    A = new double[6, 2]{   { 5.0, 2.0 },
                                            { 5.2, 4.0 },
                                            { 5.4, 4.0 },
                                            { 5.6, 3.0 },
                                            { 5.8, 3.0 },
                                            { 6.0, 3.0 }};
                    break;
                case "6":
                    A = new double[6, 2]{   { 4.0, 4.0 },
                                            { 4.2, 3.0 },
                                            { 4.4, 6.0 },
                                            { 4.6, 6.0 },
                                            { 4.8, 4.0 },
                                            { 5.0, 4.0 }};
                    break;
                case "7":
                    A = new double[6, 2]{   { 1.0, 2.0 },
                                            { 1.2, 6.0 },
                                            { 1.4, 4.0 },
                                            { 1.6, 4.0 },
                                            { 1.8, 2.0 },
                                            { 2.0, 5.0 }};
                    break;
                case "8":
                    A = new double[6, 2]{   { 5.0, 3.0 },
                                            { 5.2, 2.0 },
                                            { 5.4, 5.0 },
                                            { 5.6, 2.0 },
                                            { 5.8, 2.0 },
                                            { 6.0, 3.0 }};
                    break;
                case "9":
                    A = new double[6, 2]{   { 2.0, 4.0 },
                                            { 2.2, 2.0 },
                                            { 2.4, 4.0 },
                                            { 2.6, 2.0 },
                                            { 2.8, 5.0 },
                                            { 3.0, 2.0 }};
                    break;
                default:
                    A = new double[6, 2]{   { 0.0, 6.0 },
                                            { 0.2, 3.0 },
                                            { 0.4, 2.0 },
                                            { 0.6, 6.0 },
                                            { 0.8, 2.0 },
                                            { 1.0, 5.0 }};
                    break;

            }
            for (int i=0; i<6; i++)
            for (int j=0; j<2; j++)
                dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(A[i,j]);
        }
    }
}