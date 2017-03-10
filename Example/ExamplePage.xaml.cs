using Xamarin.Forms;
using System;
using System.Collections.Generic;
using AudioManager;
using System.Diagnostics;
using System.Threading.Tasks;

//Program created by Carter Bott
//on March 6th, 2017
//Description: A basic stopwatch that allows you to start, stop, and clear the current time.

namespace Example

{
	public partial class ExamplePage : ContentPage
	{
		//Creates the Stopwatch
		Stopwatch sw = new Stopwatch();

		//Stores current time before second button click
		TimeSpan interval = TimeSpan.Zero;
			
		public ExamplePage()
		{
			InitializeComponent();
		}

		async public void start_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("button.mp3");

			//Starts the Stopwatch
			sw.Start();

			//Sets the time label colour to green
			timeLabel.TextColor = Color.Green;

			//Sets lapTime equal to the current time minus the time since the start button was pressed
			TimeSpan lapTime = sw.Elapsed - interval;

			//Displays previous lap time to the lap label
			lapLabel.Text = "Previous Lap: " + lapTime;

			//Sets the interval equal to the current time
			interval = sw.Elapsed;

			while (sw.IsRunning)
			{
				//Displays the elapsed time to the time label and waits 10ms
				timeLabel.Text = sw.Elapsed + "";
				await Task.Delay(10);  
			}

		}

		async public void stop_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("button.mp3");

			//Pauses the Stopwatch
			sw.Stop(); 

			//Sets the time label colour to red
			timeLabel.TextColor = Color.Red;
		}

		async public void reset_Clicked(object sender, EventArgs e)
		{
			await Audio.Manager.PlaySound("button.mp3");

			//Resets the Stopwatch to 0 seconds
			sw.Reset();

			//Sets the time label colour to red
			timeLabel.TextColor = Color.Black;

			//Changes the time label to show zero elapsed time
			timeLabel.Text = "00.00.00.000";
		}

	}
}
