namespace GPSTesT
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
            this.components = new System.ComponentModel.Container();
            this.ComPort1 = new System.IO.Ports.SerialPort(this.components);
            this.MainBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FilterBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilterButton = new System.Windows.Forms.Button();
            this.mapButton = new System.Windows.Forms.Button();
            this.cloudButton = new System.Windows.Forms.Button();
            this.setIntervallButton = new System.Windows.Forms.Button();
            this.rateBox = new System.Windows.Forms.TextBox();
            this.divisorBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ComPort1
            // 
            this.ComPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.ComPort1_DataReceived);
            // 
            // MainBox
            // 
            this.MainBox.Location = new System.Drawing.Point(12, 12);
            this.MainBox.Multiline = true;
            this.MainBox.Name = "MainBox";
            this.MainBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MainBox.Size = new System.Drawing.Size(448, 193);
            this.MainBox.TabIndex = 0;
            this.MainBox.TextChanged += new System.EventHandler(this.MainBox_TextChanged);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(469, 49);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(100, 20);
            this.portBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(481, 75);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(481, 104);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(481, 227);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save File";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FilterBox
            // 
            this.FilterBox.Location = new System.Drawing.Point(471, 147);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(100, 20);
            this.FilterBox.TabIndex = 6;
            this.FilterBox.Text = "GGA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter";
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(481, 173);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(75, 23);
            this.FilterButton.TabIndex = 8;
            this.FilterButton.Text = "Filter";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // mapButton
            // 
            this.mapButton.Location = new System.Drawing.Point(385, 227);
            this.mapButton.Name = "mapButton";
            this.mapButton.Size = new System.Drawing.Size(75, 23);
            this.mapButton.TabIndex = 9;
            this.mapButton.Text = "Show map";
            this.mapButton.UseVisualStyleBackColor = true;
            this.mapButton.Click += new System.EventHandler(this.mapButton_Click);
            // 
            // cloudButton
            // 
            this.cloudButton.Location = new System.Drawing.Point(288, 227);
            this.cloudButton.Name = "cloudButton";
            this.cloudButton.Size = new System.Drawing.Size(75, 23);
            this.cloudButton.TabIndex = 10;
            this.cloudButton.Text = "Show Cloud";
            this.cloudButton.UseVisualStyleBackColor = true;
            this.cloudButton.Click += new System.EventHandler(this.cloudButton_Click);
            // 
            // setIntervallButton
            // 
            this.setIntervallButton.Location = new System.Drawing.Point(183, 227);
            this.setIntervallButton.Name = "setIntervallButton";
            this.setIntervallButton.Size = new System.Drawing.Size(75, 23);
            this.setIntervallButton.TabIndex = 11;
            this.setIntervallButton.Text = "Set Intervall";
            this.setIntervallButton.UseVisualStyleBackColor = true;
            this.setIntervallButton.Click += new System.EventHandler(this.setIntervallButton_Click);
            // 
            // rateBox
            // 
            this.rateBox.Location = new System.Drawing.Point(77, 227);
            this.rateBox.Name = "rateBox";
            this.rateBox.Size = new System.Drawing.Size(100, 20);
            this.rateBox.TabIndex = 12;
            this.rateBox.Text = "001";
            // 
            // divisorBox
            // 
            this.divisorBox.Location = new System.Drawing.Point(471, 201);
            this.divisorBox.Name = "divisorBox";
            this.divisorBox.Size = new System.Drawing.Size(100, 20);
            this.divisorBox.TabIndex = 13;
            this.divisorBox.Text = "60";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 262);
            this.Controls.Add(this.divisorBox);
            this.Controls.Add(this.rateBox);
            this.Controls.Add(this.setIntervallButton);
            this.Controls.Add(this.cloudButton);
            this.Controls.Add(this.mapButton);
            this.Controls.Add(this.FilterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilterBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.MainBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		  }

		  #endregion

		  private System.IO.Ports.SerialPort ComPort1;
		  private System.Windows.Forms.TextBox MainBox;
		  private System.Windows.Forms.TextBox portBox;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.Button startButton;
		  private System.Windows.Forms.Button stopButton;
		  private System.Windows.Forms.Timer timer1;
		  private System.Windows.Forms.SaveFileDialog saveFileDialog;
		  private System.Windows.Forms.Button SaveButton;
		  private System.Windows.Forms.TextBox FilterBox;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.Button FilterButton;
		  private System.Windows.Forms.Button mapButton;
		  private System.Windows.Forms.Button cloudButton;
          private System.Windows.Forms.Button setIntervallButton;
          private System.Windows.Forms.TextBox rateBox;
          private System.Windows.Forms.TextBox divisorBox;
	 }
}

