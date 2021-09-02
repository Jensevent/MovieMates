# S3 IPS

Hello reader, welcome to my git! I will quickly give a rundown of my project and a quick overview over the files.


# Introduction

Within this Git you will find the files for MovieMates. MovieMates is a web application to help you (and your friend(s)) to choose a movie to watch. This works using a sort of 'tinder' card. After you like a movie, you will see them on your My Movies Page. Here you can mark the movie as watched (after you watch it of course).
Last but not least, you have the group page. Here you can make a group, join a group and/or see the movies from the users that have joined the group.


## Folders



| Folder         |Explanation                                                  
|----------------|------------------------------------|         
|MovieMates_Backend|This is my main project. Within this folder you will also find my `MovieMates_Backend.sln` file.|
|MovieMates_BackendTests| Within this folder you will find my unit tests. |
|MovieMates_Backend_IntegrationTests| Within this folder you will find my integration tests.|
|MovieMates_Backend_E2ETest| Within this folder you will find my end-2-end tests.|
|MovieMates_frontend|Within this folder you can find my React frontend.|
 
> **Note:** The folder  **MovieMates EFCore** is a version of my project using Entity Framework Core. This was test, but I kept it in to show my progress.
> **Note:** The **WebsiteTest** is a project within i tried a couple of different things (signal R, ajax calls). This was test, but I kept it in to show my progress.


## Run

**Frontend**
To run the frontend, all you need to do is go into the `moviemates_frontend` folder and run the command `npm start`. 
> **Note:** If this does not work, make sure you have note installed. 
> If this does not work, then first run the `npm install` command within the folder, then the `npm start` command.


**Backend**
To run the backend, you have 2 options:
1. Follow the path `MovieMates_Backend\bin\Debug\netcoreapp3.1\` and run the file `MovieMates_Backend.exe`.
> **Note:** Make sure the `axios.defaults.baseURL` is set to `http://localhost:5000/` when using this method. You can change this within the **App.js** file in the frontend folder.
2. Start up the `MovieMates_Backend.sln` file and run it using Visual Studio.
> **Note:** Make sure the `axios.defaults.baseURL` is set to `https://localhost:44356/` when using this method. You can change this within the **App.js** file in the frontend folder.


## Contact
If you have any problems with this project, please contact me using git!