//modification to serial port example -Roger
//literally it's me changing a few things
//around with the serial port example
//so that an LED lights up on input
int cereal = 0;
int red=13;
int yellow=12;

void setup()
{
 Serial.begin(9600); 
 pinMode(red,OUTPUT);
 pinMode(yellow,OUTPUT);
}

void loop()
{
     //sending value
     //int val = 2;
     //Serial.write(val);
     //delay(1000);
  
    if(Serial.available() > 0)
    {
          //read incoming byte
         cereal = Serial.read();
          if(cereal == 20)
          {
             digitalWrite(red,HIGH); 
             digitalWrite(yellow,LOW);
             //Stuff();
          }
          else
          {
           digitalWrite(red,LOW); 
          }
          if(cereal == 40)
          {
             digitalWrite(yellow,HIGH); 
             digitalWrite(red,LOW);
             //Stuff();
          }
          else
          {
           digitalWrite(yellow,LOW); 
          }
    }
}

/*
void Stuff()
{
   //do stuff here! :D 
   /this function will be work on later
}
*/
