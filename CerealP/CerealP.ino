//modification to serial port example -Roger
//literally it's me changing a few things
//around with the serial port example
//so that an LED lights up on input

//import servo library just in case
#include <Servo.h>

//declare servo
Servo rotator;
//initialize serial input
int cereal = 0;
//set pin numbers
int red=13;
int yellow=12;

void setup()
{
 Serial.begin(9600); 
 //mode for LEDs (output)
 pinMode(red,OUTPUT);
 pinMode(yellow,OUTPUT);
 //set pin number for servo motor
 rotator.attach(11);
}

void loop()
{
    if(Serial.available() > 0)
    {
          //read bytes
         cereal = Serial.read();
         //if value of the data read = 20,
         //make only red light up
          if(cereal == 20)
          {
             digitalWrite(red,HIGH); 
             digitalWrite(yellow,LOW);
             Stuff(2);
          }
          else
          {
            //make sure it's off
           digitalWrite(red,LOW); 
          }
          //if value = 40, 
          //make yellow light up
          if(cereal == 40)
          {
             digitalWrite(yellow,HIGH); 
             digitalWrite(red,LOW);
          }
          else
          {
            //make sure it's off
           digitalWrite(yellow,LOW); 
          }
          while(cereal == 30)
          {
            digitalWrite(red,HIGH);
            digitalWrite(yellow,HIGH);
              Stuff(2); 
          }
    }
}

//this function will have the servo rotate n degrees
int Stuff(int n)
{

   if(cereal != 30)
     {
       return 0;
     }
    if(cereal == 30)
    {
     rotator.write(n);
     Stuff(n+1); 
    }
    if(cereal == 50)
    {
     rotator.write(n); 
     Stuff(n-1);
    }
}

