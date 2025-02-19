// atualizado com o json

#include <DHT.h>
#include <ArduinoJson.h>

#define dhtpin 2
#define dhttype DHT22
#define trigger 7
#define echo 8
#define ldrpin A0

int dist = 0;
int ldrvalor = 0;

DHT dht(dhtpin, dhttype);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  dht.begin();
  pinMode(trigger, OUTPUT);
  pinMode(echo, INPUT);
  pinMode(ldrpin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

  digitalWrite(trigger, HIGH);
  delay(10);
  digitalWrite(trigger, LOW);

  dist = (pulseIn(echo, HIGH))/58;

  int temp = dht.readTemperature();
  int umi = dht.readHumidity();

  ldrvalor = analogRead(ldrpin);

  Serial.println(dist);
  Serial.println(temp);
  Serial.println(umi);
  Serial.println(ldrvalor);
  delay(2000);

  StaticJsonDocument<100>jsao;
  jsao ["Distancia"] = dist;
  jsao ["Temperatura"] = temp;
  jsao ["Umidade"] = umi;

  serializeJson(jsao, Serial);
  Serial.println();
  delay(2000);

}
