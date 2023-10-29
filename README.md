#  Pizza Byte. 
A pizza application, used for testing out different patterns in software architecture.

![DALL·E Cartoon Pizza Illustration](https://github.com/JustJordanT/pizza-byte/assets/38886930/063817f6-6a0d-4a90-80ff-0cf759ff7bfb)

To use this repo please look at the available `Branches`. ie `dotnet-aws-modular-monolith`, `dotnet-aws-microservice`, `go-aws-modular-monolith`, `go-aws-microservice`, here you will be able to run these independently for testing.

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
- AWS Dynamo DB
- AWS SNS

### Features
- Account creation for customers.
- Pizza ordering functionality.
- Real-time notifications for order status.


## Architecture 

<img width="991" alt="image" src="https://github.com/JustJordanT/pizza-byte/assets/38886930/d60226d1-9214-4007-8cbb-e5c823b97e9c">

## Schema

<img width="463" alt="image" src="https://github.com/JustJordanT/pizza-byte/assets/38886930/c4420c96-d57c-49f2-8380-b1f78e82c67e">

- **Customers**:
   - One-to-Many relationship with `Carts` through `CustomerId` in `Carts`.
   - One-to-Many relationship with `Orders` through `CustomerId` in `Orders`.

- **Carts**:
   - Many-to-One relationship with `Customers` through `CustomerId`.
   - One-to-Many relationship with `Pizzas` through `CartId` in `Pizzas`.
   - One-to-One relationship with `Orders` through `Id` in `Orders`.

- **Orders**:
   - Many-to-One relationship with `Customers` through `CustomerId`.
   - One-to-One relationship with `Carts` through `Id`.

- **Pizzas**:
   - Many-to-One relationship with `Carts` through `CartId`.

The relationships are mainly centered around the `Customers`, `Carts`, `Orders`, and `Pizzas` tables, linking customers to their carts, orders, and the pizzas within those carts. This structure facilitates tracking of customer orders and the details of each order including the pizzas and their respective attributes.
