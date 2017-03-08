using System;
using System.Collections.Generic;
using AudioManager;
using System.Diagnostics;
using Xamarin.Forms;
using System.Threading.Tasks;

//Program created by Carter Bott
//on March 1st, 2017.
//Description: A basic stop watch with the ability to time laps.
namespace Example
{
	public partial class MyPage : ContentPage
	{
		//Creates the Stopwatch
		Stopwatch sw = new Stopwatch();

		public MyPage()
		{
			InitializeComponent();
		}

		private async void start_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("noot_noot.mp3");

			//Starts the Stopwatch
			sw.Start();

			//timeLabel.TextColor = Color.Green;


			while (sw.IsRunning)
			{
				//timeLabel.Text = sw.ElapsedMilliseconds + "";
				await Task.Delay(10);
			}

		}
		private async void stop_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("sound2.mp3");

			//Pauses the Stopwatch
			sw.Stop();

			//timeLabel.TextColor = Color.Red;
		}

		private async void reset_Clicked(object sender, EventArgs e)
		{ 
			await Audio.Manager.PlaySound("noot_noot.mp3");

			//Resets the Stopwatch to 0 seconds
			sw.Reset();

			//timeLabel.TextColor(Color.Black);
			//timeLabel.Text = "0";

		}





	}
}
