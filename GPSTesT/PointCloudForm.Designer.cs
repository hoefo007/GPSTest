namespace GPSTesT
{
	 partial class PointCloudForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCenterNS = new System.Windows.Forms.ComboBox();
            this.latCenterBox = new System.Windows.Forms.TextBox();
            this.longCenterBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCenterEW = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.zoomBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.longLabel = new System.Windows.Forms.Label();
            this.latLabel = new System.Windows.Forms.Label();
            this.takeButton = new System.Windows.Forms.Button();
            this.labelNS = new System.Windows.Forms.Label();
            this.labelEW = new System.Windows.Forms.Label();
            this.centerButton = new System.Windows.Forms.Button();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(520, 411);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Center";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Latitude";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbCenterNS
            // 
            this.cbCenterNS.FormattingEnabled = true;
            this.cbCenterNS.Items.AddRange(new object[] {
            "North",
            "South"});
            this.cbCenterNS.Location = new System.Drawing.Point(541, 67);
            this.cbCenterNS.Name = "cbCenterNS";
            this.cbCenterNS.Size = new System.Drawing.Size(106, 21);
            this.cbCenterNS.TabIndex = 4;
            // 
            // latCenterBox
            // 
            this.latCenterBox.Location = new System.Drawing.Point(541, 41);
            this.latCenterBox.Name = "latCenterBox";
            this.latCenterBox.Size = new System.Drawing.Size(106, 20);
            this.latCenterBox.TabIndex = 5;
            this.latCenterBox.Text = "47.085338";
            // 
            // longCenterBox
            // 
            this.longCenterBox.Location = new System.Drawing.Point(541, 123);
            this.longCenterBox.Name = "longCenterBox";
            this.longCenterBox.Size = new System.Drawing.Size(106, 20);
            this.longCenterBox.TabIndex = 6;
            this.longCenterBox.Text = "7.146609";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Longitude";
            // 
            // cbCenterEW
            // 
            this.cbCenterEW.FormattingEnabled = true;
            this.cbCenterEW.Items.AddRange(new object[] {
            "East",
            "West"});
            this.cbCenterEW.Location = new System.Drawing.Point(541, 150);
            this.cbCenterEW.Name = "cbCenterEW";
            this.cbCenterEW.Size = new System.Drawing.Size(106, 21);
            this.cbCenterEW.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zoom";
            // 
            // zoomBox
            // 
            this.zoomBox.Location = new System.Drawing.Point(541, 209);
            this.zoomBox.Name = "zoomBox";
            this.zoomBox.Size = new System.Drawing.Size(106, 20);
            this.zoomBox.TabIndex = 11;
            this.zoomBox.Text = "5000000";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(558, 235);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 14;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // longLabel
            // 
            this.longLabel.AutoSize = true;
            this.longLabel.Location = new System.Drawing.Point(567, 307);
            this.longLabel.Name = "longLabel";
            this.longLabel.Size = new System.Drawing.Size(54, 13);
            this.longLabel.TabIndex = 15;
            this.longLabel.Text = "Longitude";
            // 
            // latLabel
            // 
            this.latLabel.AutoSize = true;
            this.latLabel.Location = new System.Drawing.Point(567, 294);
            this.latLabel.Name = "latLabel";
            this.latLabel.Size = new System.Drawing.Size(45, 13);
            this.latLabel.TabIndex = 16;
            this.latLabel.Text = "Latitude";
            // 
            // takeButton
            // 
            this.takeButton.Location = new System.Drawing.Point(558, 323);
            this.takeButton.Name = "takeButton";
            this.takeButton.Size = new System.Drawing.Size(75, 23);
            this.takeButton.TabIndex = 17;
            this.takeButton.Text = "Center on";
            this.takeButton.UseVisualStyleBackColor = true;
            this.takeButton.Click += new System.EventHandler(this.takeButton_Click);
            // 
            // labelNS
            // 
            this.labelNS.AutoSize = true;
            this.labelNS.Location = new System.Drawing.Point(554, 294);
            this.labelNS.Name = "labelNS";
            this.labelNS.Size = new System.Drawing.Size(15, 13);
            this.labelNS.TabIndex = 18;
            this.labelNS.Text = "N";
            // 
            // labelEW
            // 
            this.labelEW.AutoSize = true;
            this.labelEW.Location = new System.Drawing.Point(555, 307);
            this.labelEW.Name = "labelEW";
            this.labelEW.Size = new System.Drawing.Size(14, 13);
            this.labelEW.TabIndex = 19;
            this.labelEW.Text = "E";
            // 
            // centerButton
            // 
            this.centerButton.Location = new System.Drawing.Point(558, 352);
            this.centerButton.Name = "centerButton";
            this.centerButton.Size = new System.Drawing.Size(75, 23);
            this.centerButton.TabIndex = 20;
            this.centerButton.Text = "Center";
            this.centerButton.UseVisualStyleBackColor = true;
            this.centerButton.Click += new System.EventHandler(this.centerButton_Click);
            // 
            // loadFileButton
            // 
            this.loadFileButton.Location = new System.Drawing.Point(558, 400);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(75, 23);
            this.loadFileButton.TabIndex = 21;
            this.loadFileButton.Text = "Load file";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // PointCloudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 435);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.centerButton);
            this.Controls.Add(this.labelEW);
            this.Controls.Add(this.labelNS);
            this.Controls.Add(this.takeButton);
            this.Controls.Add(this.latLabel);
            this.Controls.Add(this.longLabel);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.zoomBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbCenterEW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.longCenterBox);
            this.Controls.Add(this.latCenterBox);
            this.Controls.Add(this.cbCenterNS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Name = "PointCloudForm";
            this.Text = "PointCloudForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		  }

		  #endregion

		  private System.Windows.Forms.PictureBox pictureBox;
		  private System.Windows.Forms.Label label1;
		  private System.Windows.Forms.Label label2;
		  private System.Windows.Forms.ComboBox cbCenterNS;
		  private System.Windows.Forms.TextBox latCenterBox;
		  private System.Windows.Forms.TextBox longCenterBox;
		  private System.Windows.Forms.Label label3;
		  private System.Windows.Forms.ComboBox cbCenterEW;
		  private System.Windows.Forms.Label label4;
		  private System.Windows.Forms.TextBox zoomBox;
		  private System.Windows.Forms.Button applyButton;
		  private System.Windows.Forms.Timer timer1;
		  private System.Windows.Forms.Label longLabel;
		  private System.Windows.Forms.Label latLabel;
		  private System.Windows.Forms.Button takeButton;
		  private System.Windows.Forms.Label labelNS;
		  private System.Windows.Forms.Label labelEW;
		  private System.Windows.Forms.Button centerButton;
          private System.Windows.Forms.Button loadFileButton;
          private System.Windows.Forms.OpenFileDialog openFileDialog1;
	 }
}