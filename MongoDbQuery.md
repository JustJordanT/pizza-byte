# Example Queries

Below are some example queries that could be useful for monitoring and analytics in your Pizza API project.

### Find All Logs for a Specific User
```javascript
db.logs.find({ "userId": "12345" })
```

### Find All Error Logs
```javascript
db.logs.find({ "logType": "ERROR" })
```

### Find Logs Within a Date Range
```javascript
db.logs.find({
  "timestamp": {
    "$gte": ISODate("2023-01-01T00:00:00.000Z"),
    "$lt": ISODate("2023-01-02T00:00:00.000Z")
  }
})
```

### Count Number of Pizza Orders
```javascript
db.logs.find({ "action": "ORDER_PIZZA" }).count()
```

### Find Logs Related to a Specific Pizza Type
```javascript
db.logs.find({ "details.pizzaType": "Margherita" })
```

### Aggregate Logs by Log Type
```javascript
db.logs.aggregate([
  { "$group": { "_id": "$logType", "count": { "$sum": 1 } } }
])
```

### Find Logs with Specific Errors and Sort Them by Timestamp
```javascript
db.logs.find({ "logType": "ERROR" }).sort({ "timestamp": -1 })
```

### Find the Last 10 Logs for Monitoring
```javascript
db.logs.find().sort({ "timestamp": -1 }).limit(10)
```

### Set Up an Alert for Critical Errors (Hypothetical)
If you integrate with a service like AWS Lambda, you could trigger a function based on a query like this:
```javascript
db.logs.find({ "logType": "CRITICAL" })
```

These are just examples and can be tailored to fit the specific logging schema and requirements of your Pizza API project.
