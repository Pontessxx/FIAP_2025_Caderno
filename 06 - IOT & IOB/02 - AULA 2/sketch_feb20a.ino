#include <DHT.h>
#include <ArduinoJson.h>

#define DHTPIN 2
#define DHTTYPE DHT11
#define TRIG 7
#define ECHO 8

DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(9600);
  dht.begin();
  
  pinMode(TRIG, OUTPUT);
  pinMode(ECHO, INPUT);
}

void loop() {
  float temp = readTemperature();
  float umi = readHumidity();
  float dist = readDistance();

  StaticJsonDocument<200> json;

  json["Temperatura"] = temp;
  json["Umidade"] = umi;
  json["Distancia"] = dist;

  serializeJson(json, Serial);
  Serial.println(); // Quebra de linha para facilitar a leitura
  delay(2000); // Aguarda 2 segundos entre leituras
}

float readTemperature() {
  return dht.readTemperature();
}

float readHumidity() {
  return dht.readHumidity();
}

float readDistance() {
  digitalWrite(TRIG, LOW);
  delayMicroseconds(2);
  digitalWrite(TRIG, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIG, LOW);

  long duration = pulseIn(ECHO, HIGH);
  float distance = duration * 0.034 / 2; // Converte para cm
  return distance;
}
