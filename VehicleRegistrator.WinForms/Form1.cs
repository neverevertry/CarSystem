using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VehicleRegistrator.Bussines;

namespace VehicleRegistrator.WinForms
{
    public partial class Form1 : Form
    {
        CarCheckingSystem ccs = new CarCheckingSystem();    
        CancellationTokenSource cts;

        public Form1()
        {
            InitializeComponent();
            ccs.HandlerInfoCar += CarInfo;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TaskFactory tf = new TaskFactory();
            cts = new CancellationTokenSource();
            tf.StartNew(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    ccs.StartSystem();
                    Thread.Sleep(100);
                }
            }, cts.Token);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cts.Cancel();
            Reporter report = ccs.StopSystem();
            ListOfOffenders(report);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void CarInfo (AVehicle car, string report)
        {
            richTextBox1.Invoke(new Action(() => richTextBox1.Text += car.ShowInfo() + report));
        }

        private void ListOfOffenders(Reporter report)
        {
            textBox2.Text = "Кол-во легковых машин " + report.CarCount + " Кол-во грузовых автомобилей: " + report.CargoCount
            + " Кол-во автобусов: " + report.BusCount + " Общее кол-во машин: " + report.TotalPassedCars + " Кол-во машин нарувшие скоростной режим: " + report.TotalSpeedViolatedCars
            + " Кол-во машин зафиксированных в угоне: " + report.CountOfStolenCars + "\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IReadToListAvehicle rtla = new ReadIntoDBToListAvehicle();
            ccs.ImportNumberStoleCars(rtla);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IReadToListAvehicle rtla = new ReadIntoFileToListAvehicle();
            ccs.ImportNumberStoleCars(rtla);
        }
    }
}