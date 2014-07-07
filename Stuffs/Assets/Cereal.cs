/* Roger M. 
 * Started: 7-5-2014
 * Serial Port connection to COM4, enables you to control things connected to 
 * an Arduino board (I tested this out on Arduino Uno)
 * 
 * So far, this code enables you to write an integer via serial port 
 * and via the Arduino code, this will make an LED emit light! :D
 * 
 * INSTRUCTIONS FOR USE:
 * 1. Open up CerealP Arduino program
 * 2. Open up Unity4 Seereel Scene
 * 3. Make sure there is an LED connected to pin 13 (recommended) 
 * on an Arduino board (Uno preferably?)
 * 4. Connect board and run CerealP
 * 5. Go to Seereel and hit the "play" button
 * 6. This should work!
 * 
 * DISCLAIMER: 
 * Sorry if this isn't the most awesome code ever,
 * I was just screwing around on a Saturday afternoon/evening
 * /DISCLAIMER
*/

using UnityEngine;
using System.Collections;
//import for connecting to the serial port -- but first before importing IO.Ports,
//go to file->build settings->player settings and select .NET 2.0, not the other one
using System.IO.Ports;
using System.Threading;
//I imported this quickly for the bit converter
using System;

public class Cereal : MonoBehaviour {

	//declare a serialport for "COM4" so that it is connected 
	//to the same port as the Arduino board
	SerialPort roger = new SerialPort("COM4",9600,Parity.None, 8, StopBits.One);

	//adding future functionality
	public bool working = false;

	void Start()
	{
		//immediately open connection to serial port
		if(!roger.IsOpen)
		{
			//if not open, open it!
			roger.Open();
			//print out indication that it's open
		}
	}


	//GUI!
	void OnGUI()
	{
		//all of the other buttons will open up if port is open
		if(roger.IsOpen)
		{
			Debug.Log ("connection is open now!");

			/*Okay,so I want the Arduino to take in integer values
				 * but OH NOES, I only know how to write string values
				 * to the serial port via C#! :(
				 * That is why I used a GetBytes function so that I can 
				 * write my number to the serial port
				 */
			/*
			//if(working)
			if(GUI.Button(new Rect(100,200,100,50),"Write!"))
			{

				int num = 10;
				byte[] b = BitConverter.GetBytes(num);
				roger.Write(b,0,4);
				//print out indication
				Debug.Log ("wrote 10 to COM4 (hopefully or else the LED wouldn't light up!)");
				//v this next line is still in progress v
				//working = !working;
			}
			*/
			if(GUI.Button(new Rect(100,200,50,50),"Red!"))
			{
				byte[] b = BitConverter.GetBytes(20);
				roger.Write(b,0,4);
				Debug.Log ("wrote 20 to COM4 (hopefully or else the LED wouldn't light up!)");
			}
			if(GUI.Button(new Rect(150,200,50,50),"Yellow!"))
			{
				byte[] b = BitConverter.GetBytes(40);
				roger.Write(b,0,4);
				Debug.Log ("wrote 40 to COM4 (hopefully or else the LED wouldn't light up!)");
			}
			//GUI button to restart level
			if(GUI.Button(new Rect(100,250,100,25),"Reset >:D"))
			{
				Application.LoadLevel(0);
			}
		}

	}
}