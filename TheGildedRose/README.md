## The Gilded Rose Expands - Take-Home Assignment (Server)

- [3a.] Choice of data format (+ samples)? Json; it's light weight and platform agnostic. Samples below.
- [3b.] Choice of Authentication method and why? I used a custom handler (APIKeyAuthorizationHandler) for several reasons; This is a B2B scenario so OAuth is likely not required. Additionally, an API gateway could be used to handle Authentication and Authorization.

**Request Headers:**
```
Content-Type	:	application/json
APIKEY		:	52212679-87F3-484B-893B-C7329F74876A
```
**API Endpoint:**
http://localhost:50156/api/inventory (GET)

**Sample Response:**
```
[
    {
        "Id": "344dd455-691d-4bbb-89a6-a67588db3173",
        "Name": "Chrysaor",
        "Description": "Golden sword of Sir Artegal.",
        "Price": 29.99
    },
    {
        "Id": "344dd455-691d-4bbb-89a6-a67588db3174",
        "Name": "Flaming Sword",
        "Description": "Sword glowing with flame by some supernatural power.",
        "Price": 15.95
    }
	... truncated ...
]
```
**API Endpoint:**
http://localhost:50156/api/order (POST)

**Sample Request:**
```
{
  "MerchantId": "244dd455-691d-4cbb-11a6-a675822b3144",
  "ItemId": "344dd455-691d-4bbb-89a6-a67588db3173",
  "Quantity": 3
}
```
**Sample Response:**
```
{
    "OrderId": "b9512d8c-c137-4fcb-955d-5bdc5e4c8338",
    "OrderTotal": 89.97
}
```
## Notes
- Solution was created in Visual Studio 2017 w/ .Net Framework 4.6.1
- I used a simple Repository pattern and Unity IoC to inject the repo's into the controllers.
- Code was analyzed with NDepends and shows no critical, major or minor issues.
