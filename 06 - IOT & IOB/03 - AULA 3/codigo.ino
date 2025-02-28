#include<ArduinoJson.h>

#define trigger 7
#define echo 8
#define led 2
int dist = 0;

void setup() {
  Serial.begin(9600);
  pinMode(trigger, OUTPUT);
  pinMode(echo, INPUT);
  pinMode(led, OUTPUT);
}

void loop() {
  digitalWrite(trigger, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigger, LOW);

  dist = pulseIn(echo, HIGH);
  dist /= 58;

  StaticJsonDocument<100>json;

  json["Distancia"] = dist;

  serializeJson(json, Serial); 
  Serial.println();

  if(Serial.available()>0){
    char comando = Serial.read();
    if(comando == '1'){
      digitalWrite(led, HIGH);
    }else if(comando == '0'){
      digitalWrite(led, LOW);
    }
  }




}