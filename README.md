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

## Exploring the API

We will be using data from "An API of Ice and Fire" - https://anapioficeandfire.com/

This API provides information about the Game Of Thrones books.

Documentation can be found here: https://anapioficeandfire.com/Documentation

The "Resources" section may be of help in completing this challenge.

Go to the "API of Ice and Fire" site (https://anapioficeandfire.com/) and you will see example URLs to use e.g. click on the links /books/1, /characters/583 etc.

These can be found just under the first text field. This will show you the data being returned from the endpoints.

This data is being returned in a serialization format known as JSON.

### Introduction to JSON

Go to the "API of Ice and Fire" site (https://anapioficeandfire.com/) and click on /houses/378.

This will return the data found at: https://anapioficeandfire.com/api/houses/378

Take a moment to examine the data. It is fairly readable to humans. JSON uses key value pairs.

A string example
```
"region": "The Crownlands"
```

The key is `"region"` and the value is `"The Crownlands"`.

An array of strings is contained withing square brackets - "[" and "]"
```
"titles": [
  "King of the Andals, the Rhoynar and the First Men",
  "Lord of the Seven Kingdoms",
  "Prince of Summerhall"
]
```

In JSON Objects are contained in brackets - `"{"` and `"}"`. It is possible for the value to be an object. This API does not seem to use them.

To see an example of an object as the value you can open this URL in a browser: https://postman-echo.com/get?foo1=bar1&foo2=bar2

```
"args": {
  "foo1": "bar1",
  "foo2": "bar2"
}
```
That shows a key of `"args"` with a value being a nested JSON object. That object has two keys: `"foo1"` and `"foo2"`. The values of those keys are simple strings.

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

Going back to the original example (api/houses/378), we can see the entire response is actually one big JSON object.

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


### Using the browser to fetch data from the API

Placing a URL into the address bar and pressing `ENTER` results in the browser making a "GET" request to the server. The server processes the request and returns the results.

Open Chrome and copy some of the API urls into the address bar and press `ENTER`:

- https://anapioficeandfire.com/api/books/1
- https://anapioficeandfire.com/api/characters/583
- https://anapioficeandfire.com/api/houses/378

These URLs retrieve a single resource e.g. one book.

If the results are not being shown in a readable format, you may want to add a Chrome extension that can format JSON, e.g. JSONView - https://chrome.google.com/webstore/detail/jsonview/chklaanhfefbnpoihckbnefhakgolnmc

### Using Postman to fetch data from the API

Postman is a tool that can be used to make API requests. You can download it from here: https://www.getpostman.com/apps

This page explains how to make requests: https://www.getpostman.com/docs/v6/postman/launching_postman/sending_the_first_request

Perform "GET" requests on these URLs

- https://anapioficeandfire.com/api/books
- https://anapioficeandfire.com/api/characters
- https://anapioficeandfire.com/api/houses

Note how the URLs are different here. They are retrieving a list of resources, not just a specific one.

### Using curl to fetch data from the API

Curl is a command line tool, often used by developers to make quick calls to APIs. To try this out open Git Bash, and copy this line into it:

```
curl https://anapioficeandfire.com/api/houses/1
```
For a pretty (formatted) output try:

```
curl https://anapioficeandfire.com/api/houses/1 | json_pp
```

This was a GET request, but you can perform all the HTTP requests with curl e.g. POST, PUT, DELETE etc

## Using C# to fetch data from the API

When making a request in C# it is common for response to be returned as a string. This string contains the JSON response.

JSON is serialized data. To use this in C# we need to convert the JSON string into a C# object - this is known as deserialization.

### Deserialize JSON

There are numerous libraries that can be used to deserialize JSON. Json.Net (https://www.newtonsoft.com/json) is one of the most popular libraries. This can be installed through NuGet Package manager.

You can see an example here:

- https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
- https://www.newtonsoft.com/json/help/html/ParseJsonObject.htm
- https://www.newtonsoft.com/json/help/html/DeserializeWithLinq.htm

These are tutorials showing how to use Json.NET to deserialize JSON.

- https://www.c-sharpcorner.com/UploadFile/manas1/json-serialization-and-deserialization-using-json-net-librar/
- https://community.jivesoftware.com/thread/282037

### Making the request

There are a number of different ways to make requests in C#. This write explains some of the popular C# approaches: https://code-maze.com/different-ways-consume-restful-api-csharp/#HttpWebRequest

Notice the use of `JArray` from Json.Net in those examples. That shows a convenient way of deserializing a JSON array.

Make sure that you read a few of the options there before you decide which to try first.

## Reading and Writing Files in C#

This tutorial shows how to read and write to files in C# - http://csharp.net-tutorials.com/file-handling/reading-and-writing/


#### GoT Trivia

The TV show is called 'A Game of Thrones', while the original book series is called 'A song of Ice and Fire' and the first book it titled 'A Game of Thrones.