# Clean_Code_Project

AS A REFACTORING PROJECT THIS PROGRAM DID NOT ADD ERROR-HANDLING AS THEY WERE NOT THERE FROM THE START.

NAMING:
It first started with putting searchable names on variables. A longer name that tells its purpose has been preferred. 
The naming of the functions followed the Clean Code rule that they should be verbs or derived from verbs, 
while the names of classes were based on the overview.

FUNCTIONS/METHODS
The functions have been split up where they perform a purpose and are thus easier to follow and only have one reason to change.

COMMENTS:
Comments were removed as the purpose of Clean Code is to ensure that the code is self-explanatory.

CLASSES:
After dividing the program into functions and setting clear names, 
it was time to divide classes and create a loose connection between them using dependency dnjections.

TESTS:
The idea of ​​TDD is to always start with testing, but with unstructured code, 
the first step was to make the code readable and understandable without changing its function of course.
The tests were performed before the implementation of new methods or techniques. 
An example of that was instead of the nested "for-loops" to use a HashSet where there are guaranteed unique digits that the program was built on.
Tool for testing has been MSTest with Moq especially for dependency injections.
The files were tested with Moq where the memory stream acted as the file path.
There was no error handling beyond avoiding returning null.
However, there is a folder called "NotReusableTest" where non-reusable tests are located.
This folder and these tests were done before concepts of the idea and purpose of Unit testing.
Testable features are considered tested.
For the first part of the project, SOLID principles were used.
The same tests on the first part also applied for the second part.

SECOND PART OF THE PROJECT:
It was named SecondGame.
Strategy Pattern, Observer Pattern and Factory Pattern were used.
The lack of creativity has led to the new game working almost the same. 
Here, user has to guess 6 digits which do not have to be unique unlike the first game.
When the user has finished playing a round, in addition to asking if he wants to continue, 
the game asks if the user wants to change games.
To achieve that, the Strategy Pattern was used where both games implement the same interface.
Since the user's results must be saved in separate files depending on the game being run, 
the Observer Pattern was used with the file manager as Observer and the Controller as Subject. 
When a change of game takes place, it notifies the file manager who then changes path.
To read from both files when displaying result table, 
an array of string is used where it loops through the GameResult directory and reads from them.
To avoid creating a lot of instances despite Dependency Injections,
the Factory Pattern was used with a class that is static with static methods that return the class you want to create.
However, there are Library classes that are not lifted there, such as Random and List.
Streamwriter and StreamReader are not included there but were lifted out to an innerface IFileManager.
The interface has two methods named StreamWriter and StreamReader which in turn return new StreamWriter and StreamReader. 
This made it easier to perform tests as the MemoryStream could be injected instead of creating a file on disk.
