# Parking WebAPI application
WebAPI application that emulates the operation of parking

Please, see the detailed documentation regarding API methods

<h2>Car Service</h2>

**Get All Cars**

URL: {{URL}}/car<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/car' 
```

**Get Car Details**

URL: {{URL}}/car/{id}<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/car/ee220f9f-a5b2-4355-a1c9-33701155995a' 
```

**Add the car**

URL: {{URL}}/car<br/>
Method: POST<br/>
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
Supported Car Types are:<br/>
1 - Passenger,<br/>
2 - Truck,<br/>
3 - Bus,<br/>
4 - Motorcycle<br/>
*Example:*
```
  curl --request POST \
  --url '{{URL}}/api/car' \
  --header 'Content-Type: application/json' \
  --data '{"Balance": 1000, "Type": 2}'
```

**Remove the car**

URL: {{URL}}/car/{id}<br/>
Method: DELETE<br/>
*Example:*
```
 curl --request DELETE \
  --url '{{URL}}/api/car/ee220f9f-a5b2-4355-a1c9-33701155995a' 
```

<h2>Parking Service</h2>

**Get Available Places For Parking**

URL: {{URL}}/parking/GetAvailablePlaces<br/>
Method: GET<br/>
*Example:*
```
  curl --request GET \
  --url '{{URL}}/api/parking/GetAvailablePlaces'  
```

**Get Occupied Places For Parking**

URL: {{URL}}/parking/GetOccupiedPlaces<br/>
Method: GET<br/>
*Example:*
```
  curl --request GET \
  --url '{{URL}}/api/parking/GetOccupiedPlaces'  
```

**Get Parking Revenue**<br/>
URL: {{URL}}/parking/GetRevenue<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/parking/GetRevenue'
```

<h2>Transaction Service</h2>

**Show Transaction Log**

URL: {{URL}}/transaction/ShowTransactionLog<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/transaction/ShowTransactionLog'
```

**Get All Transaction For Previous Minute**

URL: {{URL}}/transaction/GetCurrentTransactions<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url '{{URL}}/api/transaction/GetCurrentTransactions'
```

**Get All Transaction For Previous Minute For Specific Car**

URL: {{URL}}/transaction/GetCurrentTransactions/{id}<br/>
Method: GET<br/>
*Example:*
```
 curl --request GET \
  --url 'http://localhost:58801/api/transaction/GetCurrentTransactions/28a6d88f-b386-4123-9166-a44cf45a6b0e' 
```

**AddFunds**

URL: {{URL}}/transaction/AddFunds/{id}<br/>
Method: PUT<br/>
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
