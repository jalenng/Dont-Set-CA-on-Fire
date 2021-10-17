## Context
This repository contains all the source code and assets for our SCEhacks 2021 "Code for California" hackathon project.

## Inspiration
We wanted to create something that anyone could understand, and we wanted to make it interactive. Our goal was to encourage social and behavioral changes by educating and bring awareness to issues. Ultimately, we decided on making a game, as we saw it as a fun and unique way to realize our goals. 

Having witnessed red skies and ashy air during wildfire season in California, we chose to focus on the wildfire crisis because of the lacking awareness of the crisis's severity.

## What it does
Our project is a game that quizzes and educates players on wildfire trivia.

## How we built it
We used Microsoft Whiteboard, Unity, Azure SQL, Flask, and art software to design and implement our project.

* Microsoft Whiteboard helped us ideate, collaborate, and design our project.
* Unity served as the game engine powering our game, and we used C# to code our game scripts.
* Azure SQL stores statistics about player choices, which the game retrieves and presents to the player at the end of the game. 
* Flask served as the backend server that interfaces with Azure SQL and provides an API endpoint for our Unity game.
* Aseprite and Adobe Photoshop were used to create game sprites.

Unity sends POST and GET requests to our Flask server. The Flask server has a direct connection to the Azure SQL database to execute SQL queries. Flask then returns the data to Unity.

## Challenges we ran into
Our first challenge was working with Azure SQL, given that we had little experience with Azure and cloud computing. Connecting the Flask backend to the SQL server involved heavy server configuration and special Python libraries, and it was difficult trying to figure those things out. Once we successfully established a connection, however, we struggled to use SQL queries to retrieve and change the data. 

Furthermore, we had trouble communicating between Unity and the Flask server. Unity's HTTP request module proved much more complicated than the JavaScript's fetch function that we were used to. For example, working with JSON data in Unity proved to be a wrestle.
 
Lastly, we overestimated the game design complexity. The art and game logic took up more time than anticipated, and we found ourselves rushing to address our bugs as we approached the deadline.

## Accomplishments that we're proud of
Given that this hackathon was our first, we are proud to have participated. Furthermore, we are proud of the playable and testable prototype we have achieved in our two days of work.

## What we learned
As this was our first hackathon, we learned a lot about project design and rapid prototyping. Also with the limited time, we learned how to communicate our successes and struggles with one another. We learned the basics of what Azure has to offer, and specifically how its databases work. Also, we learned a lot more about how to use Unity, and server communication within Unity.

## What's next for "Don't Set California on Fire!"
We can expand our game to feature other topics relevant to California, as well as include call-to-actions at the end of the game. We can also implement various question and answer types--ranking, matching, and text input, to name a few. 

Additionally, building our game for other platforms like iOS and Android will allow us to reach more people, and increasing the art quality can enhance the player experience.