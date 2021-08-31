# PeopleAPI
## _A WebAPI Project_

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

## Dependencies
- ASP.NET Core Runtime 5.0.0

## To Run
- Navigate to your terminal of choice (PowerShell, Git Bash, and Visual Studio were all tested)
- Enter the below line:
```sh
dotnet run
```
- The API service is now hosted on "http://localhost:5000/people"
-- Use Postman or your API tester of choice to make GET and POST requests.
- Use "CTRL+C" to quit

## Examples GET
- "http://localhost:5000/people/paul"
-- Will pull information on Paul McCartney and Paul Revere
- "http://localhost:5000/people/mccartney"
-- Will pull information on just Paul McCartney
- "http://localhost:5000/people"
-- Will pull information for all people that are GETable.

## Examples POST
- In an application like Postman, send a POST request with the following body:
```sh
{"name":"janis joplin","birthDate":"1943-01-19T00:00:00","address":{"street":"635 ashbury street","city":"san francisco","state":"California","zip":94117},"interests":["painting","reading","poetry"]}
```
- You should then be able to GET the information with "http://localhost:5000/people/janis"

## Special Thanks
- Health Catalyst for the chance to learn so much from this challening coding assessment!
- Peter McClanahan and Robyn Cute for answering my questions!

## Known Issues
- Unable to POST an image currently.

## Areas of Improvement
- Utilizing SQL for a database of People