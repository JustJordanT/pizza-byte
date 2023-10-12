#  Pizza Byte. 
A pizza application, used for testing out different patterns in software architecture.

![](https://images.unsplash.com/photo-1560302014-f44964f3e8b7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=3262&q=80)

To use this repo please look at the available `Branches`. ie `dotnet-aws-microservice`, `go-aws-microservice`, here you will be able to run these independently for testing.

## Pizza API Project Summary

### Purpose
The project serves as an API for a pizza ordering system, allowing customers to create accounts and place orders for pizzas.

### Database
- Uses AWS Aurora DB to store customer accounts and order records.

### Logging
- Sends logs to AWS DocumentDB for monitoring and analytics.

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
