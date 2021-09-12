namespace VehicleRegistrator.WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.StolenCar = new System.Windows.Forms.RichTextBox();
            this.IntruderCar = new System.Windows.Forms.RichTextBox();
            this.DataUpload = new System.Windows.Forms.ComboBox();
            this.CurrentCarWindow = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonStartSystem);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonStopSystem);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(299, 324);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(749, 23);
            this.textBox2.TabIndex = 10;
            // 
            // StolenCar
            // 
            this.StolenCar.Location = new System.Drawing.Point(12, 261);
            this.StolenCar.Name = "StolenCar";
            this.StolenCar.Size = new System.Drawing.Size(206, 256);
            this.StolenCar.TabIndex = 7;
            this.StolenCar.Text = "";
            this.StolenCar.TextChanged += new System.EventHandler(this.WindowStolenCar);
            // 
            // IntruderCar
            // 
            this.IntruderCar.Location = new System.Drawing.Point(299, 391);
            this.IntruderCar.Name = "IntruderCar";
            this.IntruderCar.Size = new System.Drawing.Size(749, 167);
            this.IntruderCar.TabIndex = 8;
            this.IntruderCar.Text = "";
            this.IntruderCar.TextChanged += new System.EventHandler(this.WindowIntruderCar);
            // 
            // DataUpload
            // 
            this.DataUpload.FormattingEnabled = true;
            this.DataUpload.Items.AddRange(new object[] {
            "1.File",
            "2.DataBase"});
            this.DataUpload.Location = new System.Drawing.Point(60, 535);
            this.DataUpload.Name = "DataUpload";
            this.DataUpload.Size = new System.Drawing.Size(121, 23);
            this.DataUpload.TabIndex = 9;
            this.DataUpload.SelectedIndexChanged += new System.EventHandler(this.SelectDataUpload);
            // 
            // CurrentCarWindow
            // 
            this.CurrentCarWindow.FormattingEnabled = true;
            this.CurrentCarWindow.ItemHeight = 15;
            this.CurrentCarWindow.Location = new System.Drawing.Point(299, 53);
            this.CurrentCarWindow.Name = "CurrentCarWindow";
            this.CurrentCarWindow.Size = new System.Drawing.Size(749, 229);
            this.CurrentCarWindow.TabIndex = 11;
            this.CurrentCarWindow.SelectedIndexChanged += new System.EventHandler(this.CurrentCarWindow_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Current Cars";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 364);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Inject Cars";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = " ";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1127, 590);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CurrentCarWindow);
            this.Controls.Add(this.DataUpload);
            this.Controls.Add(this.IntruderCar);
            this.Controls.Add(this.StolenCar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox StolenCar;
        private System.Windows.Forms.RichTextBox IntruderCar;
        private System.Windows.Forms.ComboBox DataUpload;
        private System.Windows.Forms.ListBox CurrentCarWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

