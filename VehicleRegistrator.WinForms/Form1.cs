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
            ccs.HandlerIntruderCar += CarIntrudedInfo;
            button2.Enabled = false;
        }

        private void buttonStartSystem(object sender, EventArgs e)
        {
            TaskFactory tf = new TaskFactory();
            cts = new CancellationTokenSource();
            tf.StartNew(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    ccs.StartSystem();
                    Thread.Sleep(1000);
                }
            }, cts.Token);
            button2.Enabled = true;
            button1.Enabled = false;
        }

        private void buttonStopSystem(object sender, EventArgs e)
        {
            cts.Cancel();
            Reporter report = ccs.StopSystem();
            ListOfOffenders(report);
        }

        private void CarInfo(AVehicle car, string report)
        {
            CurrentCarWindow.Invoke(new Action(() => {
                if (CurrentCarWindow.Items.Count > 100)
                    CurrentCarWindow.Items.Clear();
                CurrentCarWindow.Items.Add(car.ShowInfo() + report + "\r");
                }  ));
        } 

        private void ListOfOffenders(Reporter report)
        {
            textBox2.Text = "Кол-во легковых машин " + report.CarCount + " Кол-во грузовых автомобилей: " + report.CargoCount
            + " Кол-во автобусов: " + report.BusCount + " Общее кол-во машин: " + report.TotalPassedCars + " Кол-во машин нарувшие скоростной режим: " + report.TotalSpeedViolatedCars
            + " Кол-во машин зафиксированных в угоне: " + report.CountOfStolenCars + "\n";
        }

        private void WindowIntruderCar(object sender, EventArgs e)
        {

        }

        private void CarIntrudedInfo(AVehicle car, string report)
        {
            IntruderCar.Invoke(new Action(() =>
            {
                IntruderCar.Text += car.ShowInfo() + report + "\r";
                IntruderCar.Find(car.RegistrationNumb);
                IntruderCar.SelectionColor = Color.Red;
            } ));
        }

        private void SelectDataUpload(object sender, EventArgs e)
        {
            if (DataUpload.SelectedIndex == 0)
            {
                IReadToListAvehicle rtla = new ReadIntoFileToListAvehicle();
                ccs.ImportNumberStoleCars(rtla);
                MessageBox.Show("Complit");
            }
            else if (DataUpload.SelectedIndex == 1)
            {
                IReadToListAvehicle rtla = new ReadIntoDBToListAvehicle();
                ccs.ImportNumberStoleCars(rtla);
                MessageBox.Show("Complit");
            }
            UploadStolenCar();
        }

        private void UploadStolenCar()
        {
            for (int i = 0; i < ccs.NumStolenCars.Count; i++)
                StolenCar.Text += ccs.NumStolenCars[i].ToString() + "\n";
        }

        private void WindowStolenCar(object sender, EventArgs e)
        {

        }

        private void CurrentCarWindow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}