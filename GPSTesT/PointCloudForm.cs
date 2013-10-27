using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace GPSTesT
{
	 public partial class PointCloudForm : Form
	 {
		  private Queue<string> ggaQueue;
		  private ArrayList coordArray, dopArray;
		  private double centerLong, centerLat, zoom;
		  private String heightRegion, latRegion;
		  private Graphics drawBoard;
		  private int numberOfRecords, ringSize;
		  private int offsetX, offsetY;
		  private Point mouseStart;

		  public struct Coordinate
		  {
				public double Latitude;
				public double Longitude;
				public double DOP;
				public int hour;
				public int minute;
				public int second;

				public Coordinate(double Latitude, double Longitude, double DOP, int hour, int minute, int second)
				{
					 this.Latitude = Latitude;
					 this.Longitude = Longitude;
					 this.DOP = DOP;
					 this.hour = hour;
					 this.minute = minute;
					 this.second = second;
				}
		  }

		  public PointCloudForm(Queue<string> ggaQueue)
		  {
				InitializeComponent();
				this.ggaQueue = ggaQueue;
				coordArray = new ArrayList();
				heightRegion = "North";
				latRegion = "East";
				centerLong = centerLat = 0;
				numberOfRecords = 0;
				ringSize = 1;
				timer1.Start();
				cbCenterNS.SelectedIndex = 0;
				cbCenterEW.SelectedIndex = 0;
				offsetX = 0;
				offsetY = 0;
				mouseStart = new Point();

				drawBoard = pictureBox.CreateGraphics();

		  }

         private void importFile(string fileName){      //Import data from file
             StreamReader reader = new StreamReader(fileName);
             string line = reader.ReadLine();
             while(reader.EndOfStream == false){        //As long as file not finished
                 line = reader.ReadLine();              //Read a line
                 while((line == "")&&(reader.EndOfStream==false)){  //Remove empty lines
                     line = reader.ReadLine();
                 }
                if(line.Contains("GGA")==true){         //If line is a GGA message
                    ggaQueue.Enqueue(line);             //Save line
                }
                 if(ggaQueue.Count >= 100)              //After 100 messages
                 {
                     addItems();                        //Add messages to display to prevent memory usage overflow
                 }
             }
             reader.Close();                            //When finished, close Reader
             addItems();                                //Add resting messages
         }

		  private void label2_Click(object sender, EventArgs e)
		  {

		  }

          private Color getColor(Coordinate input)      //Return a different color for each hour
          {
              switch (input.hour)
              {
                  case (0): return Color.Blue;
                  case (1): return Color.BlueViolet;
                  case (2): return Color.Violet;
                  case (3): return Color.PaleVioletRed;
                  case (4): return Color.Red;
                  case (5): return Color.OrangeRed;
                  case (6): return Color.Orange;
                  case (7): return Color.Yellow;
                  case (8): return Color.YellowGreen;
                  case (9): return Color.Green;
                  case (10): return Color.LightSeaGreen;
                  case (11): return Color.LightSkyBlue;
                  case (12): return Color.Blue;
                  case (13): return Color.BlueViolet;
                  case (14): return Color.Violet;
                  case (15): return Color.PaleVioletRed;
                  case (16): return Color.Red;
                  case (17): return Color.OrangeRed;
                  case (18): return Color.Orange;
                  case (19): return Color.Yellow;
                  case (20): return Color.YellowGreen;
                  case (21): return Color.Green;
                  case (22): return Color.LightSeaGreen;
                  case (23): return Color.LightSkyBlue;
                  default: return Color.White;
              }
          }

		  private int getDotSize(double dop)		//Return circle size according do DOP value
		  {
				int size;
				if (dop < 2)
				{
					 size = 2;
				}
				else if ((dop >= 2) && (dop < 5))
				{
					 size = 4;
				}
				else if ((dop >= 5) && (dop < 10))
				{
					 size = 8;
				}
				else
				{
					 size = 16;
				}
				return size;
		  }

		  private void redraw(bool clear)	  //Draw map
		  {
				Coordinate actualPoint;
				Point drawPoint;
				Point centerPoint = new Point(pictureBox.Width/2, pictureBox.Height/2);
				int size;
				int offset;
				int startVal;
				int textOffset = 2;
				
				Pen drawPen = new Pen(Color.Blue, 2);				//Normal circle pen
				Pen clearPen = new Pen(Color.Gray, 2);				//
				Pen axisPen = new Pen(Color.Black, 1);				//Pen for axis and distance circles
				Pen lastPen = new Pen(Color.Red, 2);				//Newest point pen
				Brush textBrush = new SolidBrush(Color.Black);	//Text color

				//Rectangle clearRect = new Rectangle(0, 0, );
				if (clear == true)										//If total redraw
				{
					 drawBoard.Clear(Color.Silver);					//Clear graphic object
					 startVal = 0;
				}
				else
				{
					 if (numberOfRecords > 5)							//Set startpoint for redraw
					 {
						  startVal = numberOfRecords - 5;
					 }
					 else
					 {
						  startVal = 0;
					 }

				}

				for (int a = startVal; a < numberOfRecords; a++)		  //Draw the points
				{
                    drawPen = new Pen(getColor((Coordinate)coordArray[a]), 2);
					 actualPoint = (Coordinate)coordArray[a];				  //Get a point
					 drawPoint = new Point((int)((actualPoint.Longitude - centerLong) * zoom + (pictureBox.Width / 2)+ offsetX), (int)((centerLat - actualPoint.Latitude) * zoom + (pictureBox.Height / 2) + offsetY));  //calculate position on window
					 size = getDotSize(actualPoint.DOP);				  //Get size of circle
					 if (a == (numberOfRecords - 1))							  //If last point to draw, draw red
					 {
						  drawBoard.DrawEllipse(lastPen, drawPoint.X - (size / 2), drawPoint.Y - (size / 2), size, size);
					 }
					 else																  //Else blue
					 {
						  drawBoard.DrawEllipse(drawPen, drawPoint.X - (size / 2), drawPoint.Y - (size / 2), size, size);
					 }

				}
				if (clear == true)
				{
					 for (int a = 1; a < 21; a++)								  //Draw the coordinate system
					 {
						  offset = (int)((a * ringSize * zoom) / (60 * 1852));

						  drawBoard.DrawEllipse(axisPen, centerPoint.X - offset + offsetX, centerPoint.Y - offset + offsetY, 2 * offset, 2 * offset);
						  drawBoard.DrawString((a * ringSize).ToString() + "m", new Font("Microsoft Sans Serif", 8.25f), textBrush, centerPoint.X + offset + offsetX + textOffset, centerPoint.Y - 12 + offsetY);
						  drawBoard.DrawString("-" + (a * ringSize).ToString() + "m", new Font("Microsoft Sans Serif", 8.25f), textBrush, centerPoint.X - offset+ offsetX + textOffset, centerPoint.Y - 12 + offsetY);
						  drawBoard.DrawString((a * ringSize).ToString() + "m", new Font("Microsoft Sans Serif", 8.25f), textBrush, centerPoint.X + offsetX + textOffset, centerPoint.Y - offset + offsetY - 12);
						  drawBoard.DrawString("-" + (a * ringSize).ToString() + "m", new Font("Microsoft Sans Serif", 8.25f), textBrush, centerPoint.X + textOffset + offsetX, centerPoint.Y + offset + offsetY);				
					 }
					 drawBoard.DrawLine(axisPen, 0, (pictureBox.Height / 2) + offsetY, pictureBox.Width, (pictureBox.Height / 2) + offsetY);
					 drawBoard.DrawLine(axisPen, (pictureBox.Width / 2) + offsetX, 0, (pictureBox.Width / 2) + offsetX, pictureBox.Height);
				}
		  }

         private int getRingSize()
          {
              if (zoom >= 4000000)
              {
                  return 1;
              }
              else if ((zoom < 4000000) && (zoom >= 2000000))
              {
                  return 2;
              }
              else if ((zoom < 2000000) && (zoom >= 800000))
              {
                  return 5;
              }
              else if ((zoom < 800000) && (zoom >= 400000))
              {
                  return 10;
              }
              else if ((zoom < 400000) && (zoom >= 200000))
              {
                  return 20;
              }
              else if ((zoom < 200000) && (zoom >= 80000))
              {
                  return 50;
              }
              else if ((zoom < 80000) && (zoom >= 40000))
              {
                  return 100;
              }
              else if ((zoom < 40000) && (zoom >= 20000))
              {
                  return 200;
              }
              else if ((zoom < 20000) && (zoom >= 8000))
              {
                  return 500;
              }
              else
              {
                  return 1000;
              }
          }

		  private void applyButton_Click(object sender, EventArgs e)        //If apply settings button clicked
		  {
				centerLong = Convert.ToDouble(longCenterBox.Text);          //set center
				centerLat = Convert.ToDouble(latCenterBox.Text);

				if (cbCenterNS.SelectedIndex == 1)                          //Correct +/- in north/south
				{
					 centerLat = Convert.ToDouble("-" + latCenterBox.Text);
				}
				if (cbCenterEW.SelectedIndex == 1)                          //Correct +/- in east/west
				{
					 centerLong = Convert.ToDouble("-" + longCenterBox.Text);
				}

				zoom = Convert.ToDouble(zoomBox.Text);                      //Set zoom
                ringSize = getRingSize();                                   //Get coordinate System ringsize
				redraw(true);                                               //Draw everything
		  }

         private void addItems()                                //Add a GGA message to display
         {
             char[] sepChar = { ',' };
				char[] splitChar = { '.' };
				string[] splitResult, rawLatitude, rawLongitude;
				double minLatitude, minLongitude;
				int hour, minute, second;
				string calcLatitude, calcLongitude, line;
				Coordinate newPoint;
				if (ggaQueue.Count != 0)                        //If queue not empty
				{
					 for (int a = 0; a < ggaQueue.Count; a++)   //For all entries
					 {
						  line = ggaQueue.Dequeue();            //Get a message
						  splitResult = line.Split(sepChar);    //Split message
						  if (Convert.ToInt16(splitResult[6]) > 0)//If position is valid
						  {
								rawLatitude = splitResult[2].Split(splitChar);  //Get latitude
								rawLongitude = splitResult[4].Split(splitChar); //Get longitude
								minLatitude = Convert.ToDouble(rawLatitude[0].Substring(rawLatitude[0].Length - 2));    //Convert longitude and latitude format
								minLongitude = Convert.ToDouble(rawLongitude[0].Substring(rawLongitude[0].Length - 2));
								calcLatitude = rawLatitude[0].Substring(0, rawLatitude[0].Length - 2);
								calcLatitude += (minLatitude / 60 + Convert.ToDouble(rawLatitude[1]) / (60*(Math.Pow(10, rawLatitude[1].Length)))).ToString().Substring(1);
								calcLongitude = rawLongitude[0].Substring(0, rawLongitude[0].Length - 2);
								calcLongitude += (minLongitude / 60 + Convert.ToDouble(rawLongitude[1]) / (60*(Math.Pow(10, rawLongitude[1].Length)))).ToString().Substring(1);

								if ((calcLatitude.Length - calcLatitude.IndexOf('.')) > 7)      //Limit precision to 7 segments after ,
								{
									 calcLatitude = calcLatitude.Remove(calcLatitude.IndexOf('.') + 7);
								}
								if ((calcLongitude.Length - calcLongitude.IndexOf('.')) > 7)
								{
									 calcLongitude = calcLongitude.Remove(calcLongitude.IndexOf('.') + 7);
								}

								labelNS.Text = splitResult[3];                                  //Display N/S and E/W of actual position
								labelEW.Text = splitResult[5];

								longLabel.Text = calcLongitude;                                 //Display coordinates
								latLabel.Text = calcLatitude;

								if (splitResult[3] == "S")                                      //Correct N/S E/W values
								{
									 calcLatitude = "-" + calcLatitude;
								}
								if (splitResult[5] == "W")
								{
									 calcLongitude = "-" + calcLongitude;
								}
								hour = Convert.ToInt32(splitResult[1].Substring(0, 2));         //Save time
                                minute = Convert.ToInt32(splitResult[1].Substring(2, 2));
                                second = Convert.ToInt32(splitResult[1].Substring(4, 2));

								newPoint = new Coordinate(Convert.ToDouble(calcLatitude), Convert.ToDouble(calcLongitude), Convert.ToDouble(splitResult[8]), hour, minute, second); //Save coordinate
								coordArray.Add(newPoint);
								numberOfRecords++;
						  }
					 }
				}
				redraw(false);      //Draw new entries
         }
		  private void timer1_Tick(object sender, EventArgs e)
		  {
				addItems();
		  }

		  private void takeButton_Click(object sender, EventArgs e) //Sets coordinate textboxes to actual coordinate
		  {
				longCenterBox.Text = longLabel.Text;
				latCenterBox.Text = latLabel.Text;

				if (labelEW.Text == "E")
				{
					 cbCenterEW.SelectedIndex = 0;
				}
				else
				{
					 cbCenterEW.SelectedIndex = 1;
				}
				if (labelNS.Text == "N")
				{
					 cbCenterNS.SelectedIndex = 0;
				}
				else
				{
					 cbCenterNS.SelectedIndex = 1;
				}
		  }

		  private void pictureBox_MouseDown(object sender, MouseEventArgs e)    //If mouse key is pressed down
		  {
				mouseStart.X = e.X;                                             //Save actual coordinates of mouse on screen
				mouseStart.Y = e.Y;
		  }

		  private void pictureBox_MouseUp(object sender, MouseEventArgs e)      //If mouse key is released
		  {
				offsetX += (e.X - mouseStart.X);                                //Calculate translation                               
				offsetY += (e.Y - mouseStart.Y);

				redraw(true);
		  }

		  private void centerButton_Click(object sender, EventArgs e)           //If center button is clicked
		  {
				offsetX = offsetY = 0;                                          //Reset offset and draw display
				redraw(true);
		  }

          private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
          {
              importFile(openFileDialog1.FileName);
              timer1.Start();
          }

          private void loadFileButton_Click(object sender, EventArgs e)
          {
              openFileDialog1.ShowDialog();
          }
	 }
}
