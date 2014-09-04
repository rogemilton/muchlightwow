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
//for the List
using System.Collections.Generic;
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

	//hand gameobject
	public GameObject hand;

	public bool handToggle = false;

	//keep track of previous and current hand positions
	List <float> handPos = new List<float>();

	//initialized diff between new-old hand positions
	float diff = 0.0f;

	void Start()
	{
		handPos.Add (hand.transform.position.y);

		//immediately open connection to serial port
		if(!roger.IsOpen)
		{
			//if not open, open it!
			roger.Open();
			//print out indication that it's open
		}

		//moves [0] = hand.transform.position.y;
	}

	void Update()
	{
		FixList ();

	}

	//GUI!
	void OnGUI()
	{
		//all of the other buttons will open up if port is open
		if(roger.IsOpen)
		{
			//Debug.Log ("connection is open now!");

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
				roger.Write(BitConverter.GetBytes(20),0,4);
			}
			if(GUI.Button(new Rect(150,200,50,50),"Yellow!"))
			{
				roger.Write(BitConverter.GetBytes(40),0,4);
				Debug.Log ("wrote 40 to COM4 (hopefully or else the LED wouldn't light up!)");
			}
			//GUI button to restart level
			if(GUI.Button(new Rect(100,250,100,25),"Reset >:D"))
			{
				Application.LoadLevel(0);
			}
		}

	}

	void FixList()
	{
		if (GameObject.Find ("rightHand")) 
		{
			hand = GameObject.Find("rightHand");
			Debug.Log("Found r hand!");
		}

		/*
		if (GameObject.Find ("leftHand")) 
		{
			hand = GameObject.Find("leftHand");
			Debug.Log("Found l hand!");

		}
		*/


		handPos.Add(hand.transform.position.y);

		if(handPos.Count == 3)
		{
			handPos.RemoveAt (0);
		}

		//Debug.Log (" ct = " + handPos.Count);

		//Debug.Log ("hand pos 0 = " + handPos [0]);

		//Debug.Log ("pos 0 " + handPos[0]);
		//Debug.Log ("pos 1 " + handPos [1]);
				
		diff = (handPos[1] - handPos[0]);
		int angle = (int) ( (diff * (90.0f / 0.7f) ) + 90f);

		Debug.Log ("diff = " + diff + " angle = " + angle);
		if(diff > 0)
		{
			Debug.Log ("1");
			roger.Write(BitConverter.GetBytes(angle),0,4);
		}
		if(diff < 0)
		{
			Debug.Log("0 ");
			roger.Write(BitConverter.GetBytes(135),0,4);
		}

	}

}