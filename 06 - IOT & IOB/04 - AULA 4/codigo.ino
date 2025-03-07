#include <ArduinoJson.h>
#include <Servo.h>  // Biblioteca para o Servo

#define trigger 7
#define echo 8
#define servoPin 9  // Pino do Servo

Servo meuServo;  // Criando o objeto Servo
int angulo = 0;  // Variável para armazenar o ângulo recebido
int dist = 0;

void setup() {
  Serial.begin(9600);
  pinMode(trigger, OUTPUT);
  pinMode(echo, INPUT);
  meuServo.attach(servoPin); // Ligando o servo no pino 9
  meuServo.write(0); // Inicia o servo em 0 graus
}

void loop() {
  // ✅ Medindo a distância
  digitalWrite(trigger, LOW);
  delayMicroseconds(2);
  digitalWrite(trigger, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigger, LOW);

  long duration = pulseIn(echo, HIGH, 30000); // Timeout de 30ms
  if (duration == 0) {
    dist = -1;  // Sem eco recebido
  } else {
    dist = duration * 0.034 / 2; // Converter tempo para distância
  }
  // ✅ Verifica se há dados disponíveis na serial
  if (Serial.available() > 0) {
    String comando = Serial.readStringUntil('\n'); // Lê até o fim da linha
    angulo = comando.toInt(); // Converte para número inteiro

    // ✅ Verifica se o valor está dentro do intervalo permitido (0 a 180 graus)
    if (angulo >= 0 && angulo <= 180) {
      meuServo.write(angulo); // Move o servo para o ângulo desejado
      
      // ✅ Envia JSON com o novo ângulo
      StaticJsonDocument<100> json;
      json["Angulo_Servo"] = angulo;

      serializeJson(json, Serial);
      Serial.print("\n"); // Nova linha para o Node-RED interpretar corretamente
    }
  }


  // ✅ Enviar JSON via Serial
  StaticJsonDocument<100> json;
  json["Distancia"] = dist;

  serializeJson(json, Serial);
  Serial.print("\n");  // Garantir que o JSON fique correto

  delay(500); // Pequeno delay para evitar leituras muito rápidas
}
