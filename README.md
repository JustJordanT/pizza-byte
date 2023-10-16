#  Pizza Byte. 
A pizza application, used for testing out different patterns in software architecture.

![DALL·E Cartoon Pizza Illustration](https://github.com/JustJordanT/pizza-byte/assets/38886930/063817f6-6a0d-4a90-80ff-0cf759ff7bfb)

To use this repo please look at the available `Branches`. ie `dotnet-aws-microservice`, `go-aws-microservice`, here you will be able to run these independently for testing.

## Pizza API Project Summary

### Purpose
The project serves as an API for a pizza ordering system, allowing customers to create accounts and place orders for pizzas.

### Database
- Uses AWS Aurora DB to store customer accounts and order records.

### Logging
- Sends logs to AWS DocumentDB for monitoring and analytics. Logging is a crucial aspect of any application for monitoring its behavior, debugging issues, and understanding usage patterns. In our Pizza API project, we're using AWS DocumentDB to store logs, which is a fully managed, MongoDB-compatible database service. 

### Notification System
- Utilizes AWS SQS (Simple Queue Service) to queue messages when a pizza order has been initiated.
- Further employs AWS SNS (Simple Notification Service) to notify users about the status of their orders.

### Technologies
- AWS Aurora DB
- AWS DocumentDB
- AWS SQS
- AWS SNS

### Features
- Account creation for customers.
- Pizza ordering functionality.
- Real-time notifications for order status.


## Architecture 

<img width="1206" alt="image" src="https://github.com/JustJordanT/pizza-byte/assets/38886930/baf37e39-5cf0-49d4-bb44-78d4e3a270cc">
