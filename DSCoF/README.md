## Context
This repository contains all the source code and assets for our SCEhacks 2021 "Code for California" hackathon project.

## Inspiration
We wanted to create something that anyone could understand, and we wanted to make it interactive. Our goal was to encourage social and behavioral changes by educating and bring awareness to issues. Ultimately, we decided on making a game, as we saw it as a fun and unique way to realize our goals. Specifically, we decided to focus on the wildfire crisis as it is something we have had first had experience with and believed there is a lack of knowledge about the severity of the issue

## What it does
Our project is a game that quizzes and educates players on wildfire trivia.

## How we built it
We used Microsoft Whiteboard, Unity, Azure SQL, Flask, and art software to design and implement our project.

* Microsoft Whiteboard helped us ideate, collaborate, and design our project.
* Unity served as the game engine powering our game, and we used C# to code our game scripts.
* Azure SQL stores statistics about player choices, which the game retrieves and presents to the player at the end of the game. 
* Flask served as the backend server that interfaces with Azure SQL and provides an API endpoint for our Unity game.
* Aseprite and Adobe Photoshop were used to create game sprites.
* Unity sent POST and GET requests to our Flask server. The Flask server had a direct connection to the Azure SQL database, so it executed SQL quieries. Flask would then return   the data to Unity.

## Challenges we ran into
The first challenge we had was working with Azure SQL. It was the first time any of us had used it on top of having a lack of experience with cloud computing/servers. The main difficulty was figuring out how to connect the Flask backend with the SQL server. It involved server configuration and special Python libraries for connecting to servers. Once connected, none of us knew how to use SQL queries to get and change the data. Furthermore, communicating between Unity and the Flask server was difficult as the http requests are much more complicated than JavaScript's fetch function that we were use to. Issues kept arising with Unity throwing errors when we were working with JSON data. Lastly, we overestimated the game design complexity for a gamified survey. The art and game logic took up much more time than was expected, and there were many bugs that needed to be worked out with game mechanics.

## Accomplishments that we're proud of
Given that this hackathon was our first, we are proud to have participated. Furthermore, we are proud of the playable and testable prototype we have achieved in our two days of work.

## What we learned
As this was our first hackathon, we learned a lot about project design and rapid prototyping. Also with the limited time, we learned how to clearly communicate our successes and struggles with one another. We learned the basics of what Azure has to offer, and specifically how its databases work. Also, we learned a lot more about how to use Unity, and server communication within Unity.

## What's next for "Don't Set California on Fire!"
We can expand our game to feature other topics relevant to California. We can also implement various question and answer types--ranking, matching, and text input, to name a few. 

Additionally, we can build our game for other platforms like iOS and Android to reach more people.

Also, we can increase the art quality to enhance the player experience.
