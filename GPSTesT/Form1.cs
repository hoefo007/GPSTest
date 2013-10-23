using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Collections;

namespace GPSTesT
{
	 public partial class Form1 : Form
	 {
		  private string Data, defaultLoc, fileLoc;
		  delegate void SetTextCallback(string text);
		  private Queue<string> receiveQueue;
		  private Queue<string> sendQueue;
		  private Queue<string> dataQueue;
		  private Queue<string> displayQueue;
		  private Queue<string> ggaQueue;
		  private Queue<string> filteredQueue;
		  private SerialHandler Sender;
		  private ArrayList entries;
		  private DataHandler dataHandler;

		  public Form1()
		  {
				InitializeComponent();
                fileLoc = "";
				Data = "";
				defaultLoc = "C:\\Users\\Jan\\Desktop";	  //Default location for file
				receiveQueue = new Queue<string>();
				sendQueue = new Queue<string>();
				dataQueue = new Queue<string>();
				displayQueue = new Queue<string>();
				ggaQueue = new Queue<string>();
				Sender = new SerialHandler(receiveQueue, sendQueue);
				entries = new ArrayList();
				dataHandler = new DataHandler(displayQueue, receiveQueue, ggaQueue);
		  }

		  private void ComPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		  {
				
		  }

		  private void settingButton_Click(object sender, EventArgs e)
		  {
              if (fileLoc == "")
              {
                  MainBox.Text = "No file specified";
              }
              else
              {
                  Sender.Open("COM" + portBox.Text, 4800);
                  timer1.Start();
                    dataHandler.GetFiltered(FilterBox.Text);
              }
		  }

		  private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		  {
				ComPort1.Close();
				timer1.Stop();
		  }

		  private void MainBox_TextChanged(object sender, EventArgs e)
		  {
			
				MainBox.ScrollToCaret();	 //Scroll to newest data
		  }

		  private void button1(object sender, EventArgs e)
		  {
				
		  }

		  private void timer1_Tick(object sender, EventArgs e)
		  {
				if (receiveQueue.Count != 0)	  //If new data available
				{
					 dataHandler.Add();			  //Proceed data
					 for (int a = 0; a < displayQueue.Count; a++)	 //Display new data
					 {
						  MainBox.AppendText(displayQueue.Dequeue());
					 }
				}
		  }

		  private void stopButton_Click(object sender, EventArgs e)
		  {
              dataHandler.CloseFile();
			  Sender.Close();
		  }

		  private void saveFileDialog_FileOk(object sender, CancelEventArgs e)	  //Save file
		  {
              dataHandler.SetFileName(saveFileDialog.FileName);
              fileLoc = saveFileDialog.FileName;
                /*StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
				writer.Write(MainBox.Text);
				writer.Close();*/
		  }

		  private void SaveButton_Click(object sender, EventArgs e)	  //Show fileSave dialog
		  {
				saveFileDialog.InitialDirectory = defaultLoc;
				saveFileDialog.ShowDialog();
		  }

		  private void FilterButton_Click(object sender, EventArgs e) //Filter all data
		  {
				//ArrayList result = new ArrayList();
				dataHandler.GetFiltered(FilterBox.Text);	 //Get filtered data
				MainBox.Text = "";											 //Clear MainBox
				/*for (int a = 0; a < result.Count; a++)					 //Write filtered data in MainBox
				{
					 MainBox.AppendText((string)result[a]);
				}*/
		  }

		  private void mapButton_Click(object sender, EventArgs e)
		  {
				MapsWindow testForm = new MapsWindow("4708.5494", "00714.6265");
				testForm.Show();
		  }

		  private void cloudButton_Click(object sender, EventArgs e)
		  {
				PointCloudForm testForm2 = new PointCloudForm(ggaQueue);
				testForm2.Show();
		  }

          private short getCheckSum(string input)
          {
              //char[] inputArray = input.ToArray<char>;
              short checkSum = 0;
              for (int a = 0; a < input.Length; a++)
              {
                  checkSum = (short)( checkSum ^ input[a]);
              }
              checkSum = (short)(checkSum & (0x8000-1));
              return checkSum;
          }


          private void setIntervallButton_Click(object sender, EventArgs e)
          {
              string sendString = "PSRF103,00,01," + rateBox.Text + ",01";
              //string sendString = "GPGGA,074253.984,,,,,0,00,,,M,0.0,M,,0000";
              sendString = sendString + "*" + getCheckSum(sendString).ToString("X");
              sendString = "$" + sendString + "\xB0\xB3";
              //sendString = sendString;

              sendQueue.Enqueue(sendString);
              Sender.Send();
             // Sender.Send(sendString);
          }


	 }
}
