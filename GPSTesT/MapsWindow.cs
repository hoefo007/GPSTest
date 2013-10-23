using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GPSTesT
{
	 public partial class MapsWindow : Form
	 {
		  string[] rawLatitude, rawLongitude;
		  string calcLatitude, calcLongitude;
		  public MapsWindow(string latitude, string longitude)
		  {
				Uri address;
				double minLatitude, minLongitude;
				char[] splitChar = { '.' };
				InitializeComponent();
				this.rawLatitude = latitude.Split(splitChar);
				this.rawLongitude = longitude.Split(splitChar);
				minLatitude = Convert.ToDouble(rawLatitude[0].Substring(rawLatitude[0].Length - 2));
				minLongitude = Convert.ToDouble(rawLongitude[0].Substring(rawLongitude[0].Length - 2));
				calcLatitude = rawLatitude[0].Substring(0, rawLatitude[0].Length - 2);
				calcLatitude += (minLatitude / 60 + Convert.ToDouble(rawLatitude[1])/(Math.Pow(10, rawLatitude[1].Length+2))).ToString().Substring(1);
				calcLongitude = rawLongitude[0].Substring(0, rawLongitude[0].Length - 2);
				calcLongitude += (minLongitude / 60 + Convert.ToDouble(rawLongitude[1]) / (Math.Pow(10, rawLongitude[1].Length+2))).ToString().Substring(1);

				calcLatitude = calcLatitude.Remove(calcLatitude.IndexOf('.') + 7);
				calcLongitude = calcLongitude.Remove(calcLongitude.IndexOf('.') + 7);

				address = new Uri("http://maps.google.com/maps?q=loc:" + calcLatitude + "," + calcLongitude);

				webBrowser.Navigate(address);
		  }

		  private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		  {

		  }
	 }
}
