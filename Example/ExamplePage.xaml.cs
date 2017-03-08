using Xamarin.Forms;
using System;
using System.Collections.Generic;
using AudioManager;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Example

{
	public partial class ExamplePage : ContentPage
	{
		//Creates the Stopwatch
		Stopwatch sw = new Stopwatch();

		public ExamplePage()
		{
			InitializeComponent();
		}

		async public void start_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("noot_noot.mp3");

			//Starts the Stopwatch
			sw.Start();

			timeLabel.TextColor = Color.Green;


			while (sw.IsRunning)
			{
				timeLabel.Text = sw.Elapsed + "";
				await Task.Delay(10);
			}

		}

		async public void stop_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("sound2.mp3");

			//Pauses the Stopwatch
			sw.Stop();

			timeLabel.TextColor = Color.Red;
		}

		async public void reset_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("noot_noot.mp3");

			//Resets the Stopwatch to 0 seconds
			sw.Reset();

			timeLabel.TextColor = Color.Black;
			timeLabel.Text = "0";
		}

	}
}
