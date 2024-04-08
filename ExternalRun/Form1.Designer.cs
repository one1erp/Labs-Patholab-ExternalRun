namespace ExternalRun
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.txtSdg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSmpID = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.requestRemarksBridge1 = new VB6Bridge.RequestRemarksBridge();
            this.organBridge1 = new VB6Bridge.OrganBridge();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSdg
            // 
            this.txtSdg.Location = new System.Drawing.Point(99, 28);
            this.txtSdg.Name = "txtSdg";
            this.txtSdg.Size = new System.Drawing.Size(261, 26);
            this.txtSdg.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "SDG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.organBridge1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(493, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 247);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.lblSmpID);
            this.panel3.Location = new System.Drawing.Point(126, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 106);
            this.panel3.TabIndex = 16;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(26, 34);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(239, 26);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.Value = new decimal(new int[] {
            927975,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(63, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "load SAMPLE ID ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblSmpID
            // 
            this.lblSmpID.AutoSize = true;
            this.lblSmpID.Location = new System.Drawing.Point(84, 8);
            this.lblSmpID.Name = "lblSmpID";
            this.lblSmpID.Size = new System.Drawing.Size(100, 18);
            this.lblSmpID.TabIndex = 8;
            this.lblSmpID.Text = "הזן מס צנצנצת";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(474, 26);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(186, 28);
            this.button4.TabIndex = 15;
            this.button4.Text = "load SAMPLE 0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(449, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(198, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "RefreshInitialize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "SAMPLE ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "SAMPLE ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "SAMPLE ID";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 276);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // requestRemarksBridge1
            // 
            this.requestRemarksBridge1.Location = new System.Drawing.Point(120, 127);
            this.requestRemarksBridge1.Name = "requestRemarksBridge1";
            this.requestRemarksBridge1.Size = new System.Drawing.Size(90, 50);
            this.requestRemarksBridge1.TabIndex = 1;
            // 
            // organBridge1
            // 
            this.organBridge1.Location = new System.Drawing.Point(278, 130);
            this.organBridge1.Name = "organBridge1";
            this.organBridge1.Size = new System.Drawing.Size(124, 52);
            this.organBridge1.TabIndex = 14;
            this.organBridge1.Load += new System.EventHandler(this.organBridge1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSdg);
            this.Controls.Add(this.requestRemarksBridge1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VB6Bridge.RequestRemarksBridge requestRemarksBridge1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSdg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSmpID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button3;
        private VB6Bridge.OrganBridge organBridge1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;


    }
}