# WanderRoots-Backend

### API documentation

##### Get articles by country

route: article/country/{countryName}
method: GET
returns: list of articles


![alt text](image.png)

##### Get all countries

route: article/countries
method: GET
returns: list of countries

![alt text](image-1.png)

##### Get article by id

route: article/{id}
method: GET
returns: article

![alt text](image-2.png)

##### Get reviews by article id

route: review/article/{id}
method: GET
returns: list of reviews

![alt text](image-5.png)

##### review by article id and uuid

route: review/article/{articleId}
method: POST
returns: list of reviews

![alt text](image-6.png)

##### Create review

route: review
method: POST
returns: review

![alt text](image-4.png)

##### Update review

route: review/{id}
method: PUT
returns: review
body: {
    "rate": 5,
    "content": "This is a test review",
    "articleId": 1,
    "uuid": "123e4567-e89b-12d3-a456-426614174000"
}

![alt text](image-7.png)
