# GuessGameApplication
Animal Guess Game

This application is created using the MVC template that is automatically created using Visual Studio 2017. Other technologies used Bootstrap, JQuery for UI.
The various modules in the application:-
Model: The Module within the Application contains a class called QuestionAnimals (I assume there is possibility in the future that this game is extending for other things may be sports etc.) which defines just the structure of the object as needed by the View.
View: This module is responsible for displaying the questions as they are provided and perform some validations to make the game user friendly.
Controller: The HomeController class is responsible for talking to the View and BLL (Business Logic Layer) module. The medium used for the interaction are the objects defined by the Model.
BLL: The class QuestionLogic is responsible for displaying the question is certain order and performing a check based on the answers from the user and determines the animal. 

Setting:
Make sure the web.config file has a valid path for the application to find the initial set of data from the Questions.xml which is placed in XML File folder in the repository.

I could not work on the extension part of the assignment because of the logic that I used to determine the animal is kind of complicated and I suppose there should be better way of doing it. At this point the question number is dependent on the question id, this dependency needs to be removed with some better logic.
I would have used xml files for permanent storage of this data as it would be easy to store/restore data back to the objects.
Things to do:-
1)	Add unity for dependency injection. Adding interfaces to reduce dependencies between classes. 
2)	Add logging.
3)	Writing test cases
4)	Add deletion functionality.

