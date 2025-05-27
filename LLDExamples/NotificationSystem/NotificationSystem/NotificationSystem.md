# Notification System
- This is an example of Bridge design pattern.
- Bridge is structural design pattern.
- Bridge applies whenever we have nXm ways.
- Decouple an abstraction(this is not class type e.g. , just mean type) from its implementation so that the two can vary independently.

## Requirement
- We have n types of notification e.g. Text, QR, etc
- We have m types of methods e.g. Whatsapp, SMS, Email, etc.

## Entities
- IMessageSender - Method to send message. Implemented by WhatsappSender, EmailSender, SmsSender.
- Notification - base class for type of message, has object of IMessageSender. extended by QRNotification and TextNotification.


### Disclaimer:
This example is primarily intended to demonstrate the Bridge Design Pattern, rather than to serve as a complete NotificationSystem application. 
In a full implementation, you would typically include additional classes. For a comprehensive solution, it's recommended to refer to a more complete example.

## Reference
1. https://www.youtube.com/watch?v=SiUSGGUCWDU
2. ChatGpt