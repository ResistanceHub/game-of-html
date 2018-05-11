# Game of HTML

## What is the point?

This exercise will give you some experience with:
- Solving large coding problems
- Git
- C#
- JSON
- Basic HTML and CSS concepts
- Reading and\or writing files in C#
- Network APIs
- NuGet packages
- Testing
- Debugging
- Postman (optional)

## What is the goal?

The overall goal is to fetch data from a network API and then write that data into an HTML file.

Once this is done we will write a few e2e tests to verify certain aspects of the page.

## Step 1 - Fetching Data from an API

### Goal
The goal of this section is to retrieve data from an API and display this data to the console.

### Exploring the API

We will be using data from An "API of Ice and Fire" - https://anapioficeandfire.com/

This provides API provides information about the Game Of Thrones books.

Documentation can be found here: https://anapioficeandfire.com/Documentation

The "Resources" section may be of help in completing this challenge.

#### Exploring the API

Go to the "API of Ice and Fire" site and you will see example URLs to use e.g. click on the links /books/1, /characters/583 etc. This will show you the data sets being returned from the endpoints.

Not only can we view this data through the site, but we can also view the results in the browser and Postman.

#### Using the browser

Open Chrome and copy some of the API urls into the address bar and press `ENTER`:
- https://anapioficeandfire.com/api/books/1
- https://anapioficeandfire.com/api/characters/583
- https://anapioficeandfire.com/api/houses/378

These URLs retrieve a single resource e.g. one book.

If the results are not being shown in a readable format, you may want to add a Chrome extension that can format JSON, e.g. JSONView - https://chrome.google.com/webstore/detail/jsonview/chklaanhfefbnpoihckbnefhakgolnmc


#### Using Postman

Postman is a tool that can be used to make API requests. You can download it from here: https://www.getpostman.com/apps

This page explains how to make requests: https://www.getpostman.com/docs/v6/postman/launching_postman/sending_the_first_request

Perform "GET" requests on these URLs
- https://anapioficeandfire.com/api/books
- https://anapioficeandfire.com/api/characters
- https://anapioficeandfire.com/api/houses

Note how the URLs are different here. For example we are retrieving all books, not just a specific one.

#### Introduction to JSON

Placing a URL into the address bar and pressing `ENTER` results in the browser making a "GET" request to the server. The server processes the request and returns the results. These results being returned in JSON (JavaScript Object Notation).

Using this as an example: https://anapioficeandfire.com/api/houses/378

Notice the key value pairs e.g.
A simple string
```
"region": "The Crownlands"
```
An array of strings is contained withing square brackets - "[" and "]"
```
"titles": [
  "King of the Andals, the Rhoynar and the First Men",
  "Lord of the Seven Kingdoms",
  "Prince of Summerhall"
]
```
In JSON Objects are contained in brackets - "{" and "}". It is possible for the value to be an object, however this API does not seem to use them.

To see an example of an object as the value you can open this URL in a browser: https://postman-echo.com/get?foo1=bar1&foo2=bar2

```
"args": {
  "foo1": "bar1",
  "foo2": "bar2"
}
```
That shows a key of `"args"` with a value being a nested JSON object. That object has two keys: "foo1" and "foo2". The values of those keys are simple strings.

For completeness, the value can also be an array of objects.
```
"animals": [{
    "type": "cow"
    "sound": "moo",
    "id": 4
  },
  {
    "type": "elephant"
    "sound": "toot!",
    "id": 3
  },
  {
    "type": "dog",
    "sound": "woof woof",
    "id": 6
  }]
```

Going back to the original example, we can see the entire response is actually one big JSON object.
```
{  <---- start of the object
	"url": "https://anapioficeandfire.com/api/houses/378",
	"name": "House Targaryen of King's Landing",
  ...
  ...
  ...
		"https://anapioficeandfire.com/api/characters/2128"
	]
} <---- closing the object
```
This root object does not have a key. In this case it is an object but it is possible for it to be an array e.g. https://anapioficeandfire.com/api/characters

You can read more about JSON here https://www.w3schools.com/js/js_json_intro.asp.


# JSON.Net

https://www.c-sharpcorner.com/UploadFile/manas1/json-serialization-and-deserialization-using-json-net-librar/


#### GoT Trivia

The TV show is called 'A Game of Thrones', while the original book series is called 'A song of Ice and Fire' and the first book it titled 'A Game of Thrones.