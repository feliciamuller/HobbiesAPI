Hämta alla personer i systemet
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/f529b121-3931-49df-bad4-8285b88dd6c6)
Response body: 
[
  {
    "peopleId": 1,
    "peopleName": "Felicia",
    "phone": "0708150336",
    "hobbyEnrollments": [
      {
        "id": 16,
        "links": [
          "hudiksvallsgk.se"
        ],
        "fkPeopleId": 1,
        "people": null,
        "fkHobbyId": 1,
        "hobby": null
      },
      {
        "id": 20,
        "links": [
          "matchi.se"
        ],
        "fkPeopleId": 1,
        "people": null,
        "fkHobbyId": 3,
        "hobby": null
      }
    ]
  },
  {
    "peopleId": 2,
    "peopleName": "Filip",
    "phone": "0707654321",
    "hobbyEnrollments": [
      {
        "id": 17,
        "links": [
          "golf.se",
          "dormy.com"
        ],
        "fkPeopleId": 2,
        "people": null,
        "fkHobbyId": 1,
        "hobby": null
      }
    ]
  },
  {
    "peopleId": 3,
    "peopleName": "Emelie",
    "phone": "0705566778",
    "hobbyEnrollments": [
      {
        "id": 19,
        "links": null,
        "fkPeopleId": 3,
        "people": null,
        "fkHobbyId": 2,
        "hobby": null
      }
    ]
  },
  {
    "peopleId": 4,
    "peopleName": "Sofie",
    "phone": "0701234567",
    "hobbyEnrollments": [
      {
        "id": 21,
        "links": null,
        "fkPeopleId": 4,
        "people": null,
        "fkHobbyId": 3,
        "hobby": null
      }
    ]
  }
]

Hämta alla intressen som är kopplade till en specifik person och hämta alla länkar som är kopplade till en specifik person
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/06e9e1ea-904f-4397-b34d-5370256fa87f)
Response body:
{
  "peopleId": 1,
  "peopleName": "Felicia",
  "phone": "0708150336",
  "hobbyEnrollments": [
    {
      "id": 16,
      "links": [
        "hudiksvallsgk.se"
      ],
      "fkPeopleId": 1,
      "people": null,
      "fkHobbyId": 1,
      "hobby": {
        "hobbyId": 1,
        "hobbyName": "Spela golf",
        "description": "Man slår en boll med en klubba och bollen ska ned i ett jättelitet hål",
        "hobbyEnrollments": [
          null
        ]
      }
    },
    {
      "id": 20,
      "links": [
        "matchi.se"
      ],
      "fkPeopleId": 1,
      "people": null,
      "fkHobbyId": 3,
      "hobby": {
        "hobbyId": 3,
        "hobbyName": "Spela padel",
        "description": "Med ett racket slår man en boll över nätet och hoppas motståndaren missar",
        "hobbyEnrollments": [
          null
        ]
      }
    }
  ]
}

Koppla en person till ett nytt intresse
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/0e3d083e-6800-4e69-96fb-d612d82e1aaf)
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/46e1d74e-574a-4bb6-a68e-9adbfaa0a552)
Response body:
{
  "id": 22,
  "links": null,
  "fkPeopleId": 4,
  "people": {
    "peopleId": 4,
    "peopleName": "Sofie",
    "phone": "0701234567",
    "hobbyEnrollments": [
      null,
      null
    ]
  },
  "fkHobbyId": 2,
  "hobby": {
    "hobbyId": 2,
    "hobbyName": "Måla",
    "description": "Man tar en pensel med färg och målar på ett blankt papper",
    "hobbyEnrollments": [
      null,
      null
    ]
  }
}


Lägga in nya länkar för en specifik person och ett specifikt intresse
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/caa5b5a4-ed16-4377-be7b-89f555322a0e)
Response body:
"clasohlson.com"
Här ser man även att länken är tillagd:
![image](https://github.com/feliciamuller/HobbiesAPI/assets/144246541/d28cc974-ed34-4919-9be3-3c064efd21ad)
Response body:
{
  "peopleId": 4,
  "peopleName": "Sofie",
  "phone": "0701234567",
  "hobbyEnrollments": [
    {
      "id": 21,
      "links": null,
      "fkPeopleId": 4,
      "people": null,
      "fkHobbyId": 3,
      "hobby": {
        "hobbyId": 3,
        "hobbyName": "Spela padel",
        "description": "Med ett racket slår man en boll över nätet och hoppas motståndaren missar",
        "hobbyEnrollments": [
          null
        ]
      }
    },
    {
      "id": 22,
      "links": [
        "clasohlson.com"
      ],
      "fkPeopleId": 4,
      "people": null,
      "fkHobbyId": 2,
      "hobby": {
        "hobbyId": 2,
        "hobbyName": "Måla",
        "description": "Man tar en pensel med färg och målar på ett blankt papper",
        "hobbyEnrollments": [
          null
        ]
      }
    }
  ]
}
