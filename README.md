# Parking WebAPI application
WebAPI application that emulates the operation of parking

Please, see the detailed documentation regarding API methods

**Car Service**

Get All Cars

URL: {{URL}}/car
Method: GET
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/car' 
```

Get Car Details

URL: {{URL}}/car/{id}
Method: GET
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/car/ee220f9f-a5b2-4355-a1c9-33701155995a' 
```

Add the car

URL: {{URL}}/car
Method: POST
Headers:
```
Content-Type	application/json
```
Body:
```
{
   "Balance": 1000, 
   "Type": 1
}
```
Supported Car Types are:
1 - Passenger,
2 - Truck,
3 - Bus,
4 - Motorcycle
*Example:*
```
  curl --request POST \
  --url '{{URL}}/api/car' \
  --header 'Content-Type: application/json' \
  --data '{"Balance": 1000, "Type": 2}'
```

Remove the car
URL: {{URL}}/car/{id}
Method: DELETE
*Example:*
```
 curl --request DELETE \
  --url '{{URL}}/api/car/ee220f9f-a5b2-4355-a1c9-33701155995a' 
```

**Parking Service**

Get Available Places For Parking
URL: {{URL}}/parking/GetAvailablePlaces
Method: GET
*Example:*
```
  curl --request GET \
  --url '{{URL}}/api/parking/GetAvailablePlaces'  
```

Get Occupied Places For Parking
URL: {{URL}}/parking/GetOccupiedPlaces
Method: GET
*Example:*
```
  curl --request GET \
  --url '{{URL}}/api/parking/GetOccupiedPlaces'  
```

Get Parking Revenue
URL: {{URL}}/parking/GetRevenue
Method: GET
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/parking/GetRevenue'
```

**Transaction Service**

Show Transaction Log
URL: {{URL}}/transaction/ShowTransactionLog
Method: GET
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/transaction/ShowTransactionLog'
```

Get All Transaction For Previous Minute
URL: {{URL}}/transaction/GetCurrentTransactions
Method: GET
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/transaction/GetCurrentTransactions'
```

Get All Transaction For Previous Minute For Specific Car
URL: {{URL}}/transaction/GetCurrentTransactions/{id}
Method: GET
*Example:*
```
 curl --request GET \
  --url 'http://localhost:58801/api/transaction/GetCurrentTransactions/28a6d88f-b386-4123-9166-a44cf45a6b0e' 
```

AddFunds
URL: {{URL}}/transaction/AddFunds/{id}
Method: PUT
Headers:
```
Content-Type	application/json
```
Body:
```
{
   "Balance": 1000
}
```
*Example:*
```
   curl --request PUT \
  --url 'http://localhost:58801/api/transaction/AddFunds/28a6d88f-b386-4123-9166-a44cf45a6b0e' \
  --header 'Content-Type: application/json' \
  --data '{"Balance": 1000}'
```
