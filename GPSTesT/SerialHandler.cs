using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace GPSTesT
{
	 class SerialHandler
	 {
		  private SerialPort ComPort;
		  private Queue<string> receiveQueue;
		  private Queue<string> sendQueue;

		  public SerialHandler(Queue<string> receiveQueue, Queue<string> sendQueue)
		  {
				this.receiveQueue = receiveQueue;
				this.sendQueue = sendQueue;
				ComPort = new SerialPort();
		  }

		  public void Open(string Port, int Baud)	//Opens new COM Port
		  {
				if (ComPort.IsOpen == false)
				{
					 ComPort.PortName = Port;				//Set ComPort
					 ComPort.BaudRate = Baud;				//Set baudrate
					 ComPort.DataBits = 8;					//Set databits
					 ComPort.StopBits = StopBits.One;		//Set stopbits
					 ComPort.Parity = Parity.None;			//Set parity
					 ComPort.Handshake = Handshake.None;	//Set handshake

					 try
					 {
						  ComPort.Open();		//Open the port
						  ComPort.DataReceived += new SerialDataReceivedEventHandler(ReceivedHandler);		//Set eventhandler
					 }
					 catch (Exception e)
					 {
						  receiveQueue.Enqueue("COMPort Exception");
					 }
				}
		  }

		  public void Close()
		  {
				if (ComPort.IsOpen == true)
				{
					ComPort.Close();
				}
		  }

		  private void ReceivedHandler(object sender, SerialDataReceivedEventArgs e)
		  {
				string data;
				if (ComPort.IsOpen == true)
				{
					 try
					 {
						  data = ComPort.ReadLine();	 //Read data
						  receiveQueue.Enqueue(data); //Write data in queue
					 }
					 catch (Exception ex)
					 {
					 }
				}
		  }

          public string invertBitOrder(string input)
          {
              string result = "";
              char actual;
              char inverted;
              for (int a = 0; a < input.Length; a++)
              {
                  inverted = '\x0';
                  actual = input[a];
                  for (int b = 0; b < 4; b++)
                  {
                      inverted |= (char)((actual & (1 << b) << (8 - b)) & (1 << (8 - b)));
                  }
                  for (int b = 4; b < 8; b++)
                  {
                      inverted |= (char)((actual & (1 << b) >> b) & (1 << (8 - b)));
                  }
                  result += inverted;
              }
              return result;
          }

		  public void Send()
		  {
				while(sendQueue.Count != 0){
					 ComPort.Write(sendQueue.Dequeue());
				}
		  }
		  
	 }
}
