#include <SoftwareSerial.h>     // 소프트웨어 시리얼 통신 라이브러리 호출

SoftwareSerial BTSerial(7, 8);  // 소프트웨어 시리얼포트 (TX, RX)

#define PIR 3
#define LED 2

void setup()
{
  Serial.begin(9600);   // 컴퓨터와의 시리얼 통신 초기화
  BTSerial.begin(38400); // 블루투스 모듈과의 시리얼 통신 초기화

  pinMode(PIR, INPUT);
  pinMode(LED, OUTPUT);
}

void loop() 
{
  int value = digitalRead(PIR); 

  if(value == HIGH)
  {
    digitalWrite(LED, HIGH);
    Serial.println(1);
    BTSerial.println(1);
  }
  else
  {
    digitalWrite(LED, LOW);
    Serial.println(0);
    BTSerial.println(0);
  }
  delay(200);
}
