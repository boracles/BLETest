#include <SoftwareSerial.h>     // 소프트웨어 시리얼 통신 라이브러리 호출

SoftwareSerial BTSerial(7, 8);  // 소프트웨어 시리얼포트 (TX, RX)

#define TRIG 3  // TRIG 핀 설정 초음파 보내는 핀 
#define ECHO 2  // ECHO 핀 설정 초음파 받는 핀 

void setup()
{
  Serial.begin(9600);   // 컴퓨터와의 시리얼 통신 초기화
  BTSerial.begin(38400); // 블루투스 모듈과의 시리얼 통신 초기화

  pinMode(TRIG, OUTPUT);
  pinMode(ECHO, INPUT);
}

void loop() 
{
  float duration, distance;
  digitalWrite(TRIG, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIG, LOW);

  duration = pulseIn(ECHO, HIGH);             // ECHO 핀이 HIGH를 유지한 시간을 저장
  distance = ((float)(340*duration)/10000)/2; // ECHO 핀이 HIGH였을 때 초음파가 나갔다가 돌아온 시간을 가지고 거리 계산 

  Serial.println(distance);                   // cm단위
  BTSerial.println(distance);

  delay(200);
}
