using System;
using Gtk;
using OxyPlot;

partial class MainWindow
{
    //private System.ComponentModel.IContainer components = null;

    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.textNB = new System.Windows.Forms.TextBox();
        this.label9 = new System.Windows.Forms.Label();
        this.textB = new System.Windows.Forms.TextBox();
        this.label8 = new System.Windows.Forms.Label();
        this.textA = new System.Windows.Forms.TextBox();
        this.label7 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.label10 = new System.Windows.Forms.Label();
        this.label11 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.label12 = new System.Windows.Forms.Label();
        this.label13 = new System.Windows.Forms.Label();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.textI = new System.Windows.Forms.TextBox();
        this.label14 = new System.Windows.Forms.Label();
        this.panel1 = new System.Windows.Forms.Panel();
        this.trackBarI = new System.Windows.Forms.TrackBar();
        this.button3 = new System.Windows.Forms.Button();
        this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)(this.trackBarI)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
        //this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(1264, 271);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(0, 25);
        this.label1.TabIndex = 3;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(1273, 567);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(0, 25);
        this.label2.TabIndex = 4;
        // 
        // textBox1
        // 
        this.textBox1.Location = new System.Drawing.Point(1183, 78);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(227, 31);
        this.textBox1.TabIndex = 1;
        this.textBox1.Text = "x * pi + 2^4";
        this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(1174, 39);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(228, 25);
        this.label3.TabIndex = 6;
        this.label3.Text = "1. Enter an expression";
        this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label4
        // 
        this.label4.Location = new System.Drawing.Point(1178, 254);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(236, 57);
        this.label4.TabIndex = 10;
        this.label4.Text = "3. Size of intervals";
        this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label5
        // 
        this.label5.AutoSize = true;
        this.label5.Location = new System.Drawing.Point(1194, 404);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(184, 25);
        this.label5.TabIndex = 11;
        this.label5.Text = "number of points :";
        // 
        // textNB
        // 
        this.textNB.BackColor = System.Drawing.SystemColors.Menu;
        this.textNB.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textNB.CausesValidation = false;
        this.textNB.Cursor = System.Windows.Forms.Cursors.Default;
        this.textNB.Location = new System.Drawing.Point(1202, 435);
        this.textNB.Name = "textNB";
        this.textNB.ReadOnly = true;
        this.textNB.Size = new System.Drawing.Size(156, 24);
        this.textNB.TabIndex = 12;
        this.textNB.TabStop = false;
        this.textNB.Text = "11";
        // 
        // label9
        // 
        this.label9.AutoSize = true;
        this.label9.Location = new System.Drawing.Point(1399, 192);
        this.label9.Name = "label9";
        this.label9.Size = new System.Drawing.Size(18, 25);
        this.label9.TabIndex = 25;
        this.label9.Text = "]";
        this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // textB
        // 
        this.textB.BackColor = System.Drawing.SystemColors.Menu;
        this.textB.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textB.Location = new System.Drawing.Point(1324, 193);
        this.textB.Name = "textB";
        this.textB.Size = new System.Drawing.Size(69, 24);
        this.textB.TabIndex = 3;
        this.textB.Text = "10.5";
        this.textB.TextChanged += new System.EventHandler(this.textB_TextChanged);
        // 
        // label8
        // 
        this.label8.AutoSize = true;
        this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label8.Location = new System.Drawing.Point(1302, 186);
        this.label8.Name = "label8";
        this.label8.Size = new System.Drawing.Size(26, 37);
        this.label8.TabIndex = 23;
        this.label8.Text = ",";
        this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // textA
        // 
        this.textA.BackColor = System.Drawing.SystemColors.Menu;
        this.textA.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textA.Location = new System.Drawing.Point(1236, 193);
        this.textA.Name = "textA";
        this.textA.Size = new System.Drawing.Size(71, 24);
        this.textA.TabIndex = 2;
        this.textA.Text = "0.5";
        this.textA.TextChanged += new System.EventHandler(this.textA_TextChanged);
        // 
        // label7
        // 
        this.label7.AutoSize = true;
        this.label7.Location = new System.Drawing.Point(1183, 193);
        this.label7.Name = "label7";
        this.label7.Size = new System.Drawing.Size(47, 25);
        this.label7.TabIndex = 21;
        this.label7.Text = "I = [";
        this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label6
        // 
        this.label6.AutoSize = true;
        this.label6.Location = new System.Drawing.Point(1178, 155);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(204, 25);
        this.label6.TabIndex = 20;
        this.label6.Text = "2. Choose a domain";
        this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // label10
        // 
        this.label10.AutoSize = true;
        this.label10.Location = new System.Drawing.Point(1178, 121);
        this.label10.Name = "label10";
        this.label10.Size = new System.Drawing.Size(285, 25);
        this.label10.TabIndex = 26;
        this.label10.Text = "---------------------------------------";
        // 
        // label11
        // 
        this.label11.AutoSize = true;
        this.label11.Location = new System.Drawing.Point(1178, 232);
        this.label11.Name = "label11";
        this.label11.Size = new System.Drawing.Size(285, 25);
        this.label11.TabIndex = 27;
        this.label11.Text = "---------------------------------------";
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(1183, 517);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(227, 53);
        this.button1.TabIndex = 5;
        this.button1.Text = "Generate curve";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(1183, 651);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(227, 53);
        this.button2.TabIndex = 6;
        this.button2.Text = "Rectangle rule";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // label12
        // 
        this.label12.AutoSize = true;
        this.label12.Location = new System.Drawing.Point(1178, 476);
        this.label12.Name = "label12";
        this.label12.Size = new System.Drawing.Size(285, 25);
        this.label12.TabIndex = 28;
        this.label12.Text = "---------------------------------------";
        // 
        // label13
        // 
        this.label13.Location = new System.Drawing.Point(1183, 585);
        this.label13.Name = "label13";
        this.label13.Size = new System.Drawing.Size(236, 57);
        this.label13.TabIndex = 29;
        this.label13.Text = "Compute area using :";
        this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // button4
        // 
        this.button4.Location = new System.Drawing.Point(1183, 769);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(227, 53);
        this.button4.TabIndex = 8;
        this.button4.Text = "Simpson\'s rule";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.button4_Click);
        // 
        // button5
        // 
        this.button5.Location = new System.Drawing.Point(1183, 710);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(227, 53);
        this.button5.TabIndex = 7;
        this.button5.Text = "Trapezoidal rule";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.button5_Click);
        // 
        // textI
        // 
        this.textI.BackColor = System.Drawing.SystemColors.Menu;
        this.textI.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textI.Location = new System.Drawing.Point(1290, 362);
        this.textI.Name = "textI";
        this.textI.Size = new System.Drawing.Size(120, 24);
        this.textI.TabIndex = 4;
        this.textI.Text = "1.0";
        this.textI.TextChanged += new System.EventHandler(this.textI_TextChanged);
        // 
        // label14
        // 
        this.label14.AutoSize = true;
        this.label14.Location = new System.Drawing.Point(1194, 362);
        this.label14.Name = "label14";
        this.label14.Size = new System.Drawing.Size(94, 25);
        this.label14.TabIndex = 33;
        this.label14.Text = "interval :";
        // 
        // panel1
        // 
        this.panel1.Location = new System.Drawing.Point(1199, 909);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(200, 25);
        this.panel1.TabIndex = 36;
        // 
        // trackBarI
        // 
        this.trackBarI.Cursor = System.Windows.Forms.Cursors.Hand;
        this.trackBarI.Location = new System.Drawing.Point(1174, 309);
        this.trackBarI.Maximum = 10000;
        this.trackBarI.Minimum = 1;
        this.trackBarI.Name = "trackBarI";
        this.trackBarI.Size = new System.Drawing.Size(236, 90);
        this.trackBarI.TabIndex = 37;
        this.trackBarI.TabStop = false;
        this.trackBarI.Value = 1000;
        this.trackBarI.Scroll += new System.EventHandler(this.trackBarI_Scroll);
        // 
        // button3
        // 
        this.button3.Location = new System.Drawing.Point(1183, 828);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(158, 53);
        this.button3.TabIndex = 38;
        this.button3.Text = "Newton";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.button3_Click);
        // 
        // numericUpDown1
        // 
        this.numericUpDown1.Location = new System.Drawing.Point(1343, 840);
        this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
        this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
        this.numericUpDown1.Name = "numericUpDown1";
        this.numericUpDown1.Size = new System.Drawing.Size(67, 31);
        this.numericUpDown1.TabIndex = 39;
        this.numericUpDown1.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
        // 
        // Form1
        // 
        /*this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;
        this.ClientSize = new System.Drawing.Size(1442, 964);
        this.Controls.Add(this.numericUpDown1);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.button5);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.label13);
        this.Controls.Add(this.label12);
        this.Controls.Add(this.label11);
        this.Controls.Add(this.label10);
        this.Controls.Add(this.label9);
        this.Controls.Add(this.textB);
        this.Controls.Add(this.label8);
        this.Controls.Add(this.textA);
        this.Controls.Add(this.label7);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.textNB);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.label14);
        this.Controls.Add(this.textI);
        this.Controls.Add(this.trackBarI);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Form1";
        this.Text = "Viewermageddon";
        this.Load += new System.EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)(this.trackBarI)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();*/

    }

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox textNB;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox textB;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox textA;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.TextBox textI;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TrackBar trackBarI;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.NumericUpDown numericUpDown1;
}

