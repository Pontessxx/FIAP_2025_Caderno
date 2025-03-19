#include <ArduinoJson.h>
#include <Servo.h>  // Biblioteca para o Servo
#include <DHT.h>    // Biblioteca para o DHT

#define servoPin 9  // Pino do Servo
#define DHTPIN 2    // Pino onde o DHT11 está conectado
#define DHTTYPE DHT11 // Definindo o tipo de DHT

Servo meuServo;  // Criando o objeto Servo
DHT dht(DHTPIN, DHTTYPE); // Criando o objeto DHT

int angulo = 0;  // Variável para armazenar o ângulo recebido

void setup() {
  Serial.begin(9600);

  meuServo.attach(servoPin); // Ligando o servo no pino 9
  meuServo.write(0); // Inicia o servo em 0 graus

  dht.begin(); // Inicializa o DHT11
}

void loop() {
  //  Verifica se há dados disponíveis na serial
  if (Serial.available() > 0) {
    String comando = Serial.readStringUntil('\n'); // Lê até o fim da linha
    angulo = comando.toInt(); // Converte para número inteiro

    //  Verifica se o valor está dentro do intervalo permitido (0 a 180 graus)
    if (angulo >= 0 && angulo <= 180) {
      meuServo.write(angulo); // Move o servo para o ângulo desejado
      
      //  Envia JSON com o novo ângulo
      StaticJsonDocument<100> json;
      json["Angulo_Servo"] = angulo;

      serializeJson(json, Serial);
      Serial.println();
      // Nova linha para o Node-RED interpretar corretamente
    }
  }

  float temperatura = dht.readTemperature(); // Lê a temperatura em Celsius
  float umidade = dht.readHumidity(); // Lê a umidade



  StaticJsonDocument<200> json;
  json["Temperatura"] = temperatura;
  json["Temperatura_F"] = (temperatura * 1.8) + 32; //conta para transformar em fahrenheit
  json["Umidade"] = umidade;

  serializeJson(json, Serial);
  Serial.print("\n");  // Garantir que o JSON fique correto

  delay(3000); // Pequeno delay para evitar leituras muito rápidas
}