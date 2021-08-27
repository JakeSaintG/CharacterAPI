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

## Special Thanks
- Health Catalyst for the chance to learn so much from this challening coding assessment!
- Peter McClanahan for answering my many questions!

## Known Issues
- POST Requests

## Areas of Improvement
- Utilizing SQL for a database of People