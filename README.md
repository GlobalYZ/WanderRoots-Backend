# WanderRoots-Backend

### API documentation

##### Get articles by country

route: article/country/{countryName}
method: GET
returns: list of articles

![alt text](imgs/image-9.png)

##### Get all countries

route: article/countries
method: GET
returns: list of countries

![alt text](imgs/image.png)


##### Get article by id

route: article/detail/{id}
method: GET
returns: article

![alt text](imgs/image_10.png)

##### Get reviews by article id

route: review/article/{id}
method: GET
returns: list of reviews

![alt text](imgs/image-11.png)

##### review by article id and uuid

route: review/article/{articleId}
method: POST
returns: list of reviews

![alt text](imgs/image-7.png)


##### Create review

route: review
method: POST
returns: review

![alt text](imgs/image-4.png)


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

![alt text](imgs/image-5.png)



##### delete review

route: review/{id}
method: DELETE
returns: 204 no content

![alt text](imgs/image-8.png)

##### Get article image by id

route: article/{id}/image
method: GET
returns: article image

![alt text](imgs/image-1.png)