Database Basics MS SQL Exam – 12 Feb 2023

Exam problems for the "Database Basics" course @ SoftUni
Submit your solutions in the SoftUni Judge system at Judge


Section 1. DDL (30 pts)
You have been given the E/R Diagram of the Boardgames database.
 
Create a database called Boardgames. You need to create 7 tables:
•	Categories  – contains information about the boardgame's category name;
•	Addresses – contains information about the addresses of the boardgames' publishers;
•	Publishers – contains information about the boardgames' publishers;
•	PlayersRanges – contains information about the min and max count of players for each game;
•	Creators – contains information about the creators of the boardgames;
•	Boardgames – contains information about each boardgame;
•	CreatorsBoardgames – mapping table between creators and boardgames.

NOTE: Keep in mind that Judge doesn't accept "ALTER" statement and square brackets naming (when the names are not keywords).

You have been tasked to create the tables in the database by the following models:
Categories
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
Name	String up to 50 symbols	Null is not allowed

Addresses
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
StreetName	String up to 100 symbols, Unicode	Null is not allowed
StreetNumber	Integer from 0 to 2,147,483,647	Null is not allowed
Town	String up to 30 symbols	Null is not allowed
Country	String up to 50 symbols	Null is not allowed
ZIP	Integer from 0 to 2,147,483,647	Null is not allowed

Publishers
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
Name	String up to 30 symbols	Unique, Null is not allowed.
AddressId	Integer from 0 to 2,147,483,647	Relationship with table Addresses, Null is not allowed
Website	String up to 40 symbols, Unicode	Null is allowed
Phone	String up to 20 symbols, Unicode	Null is allowed

PlayersRanges
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
PlayersMin	Integer from 0 to 2,147,483,647	Null is not allowed
PlayersMax	Integer from 0 to 2,147,483,647	Null is not allowed

Boardgames
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
Name	String up to 30 symbols, Unicode	Null is not allowed
YearPublished	Integer from 0 to 2,147,483,647	Null is not allowed
Rating	Decimal number with two-digit precision	Null is not allowed
CategoryId	Integer from 0 to 2,147,483,647	Relationship with table Categories, Null is not allowed
PublisherId	Integer from 0 to 2,147,483,647	Relationship with table Publishers, Null is not allowed
PlayersRangeId	Integer from 0 to 2,147,483,647	Relationship with table PlayersRanges, Null is not allowed

Creators
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647	PK, Unique table identification, Identity
FirstName	String up to 30 symbols, Unicode	Null is not allowed
LastName	String up to 30 symbols, Unicode	Null is not allowed
Email	String up to 30 symbols, Unicode	Null is not allowed

CreatorsBoardgames
Column Name	Data Type	Constraints
CreatorId	Integer from 0 to 2,147,483,647	PK, Unique table identification, Relationship with table Creators,  Null is not allowed
BoardgameId	Integer from 0 to 2,147,483,647	PK, Unique table identification, Relationship with table Boardgames, Null is not allowed


1.	Database design
Submit all of yours CREATE statements to Judge (only the creation of tables).


Section 2. DML (10 pts)
Before you start, you have to import "Dataset.sql ". If you have created the structure correctly, the data should be successfully inserted.
In this section, you have to do some data manipulations:


2.	Insert
Let's insert some sample data into the database. Write a query to add the following records into the corresponding tables. All IDs should be auto-generated.

Boardgames
Name	YearPublished	Rating	CategoryId	PublisherId	PlayersRangeId
Deep Blue	2019	5.67	1	15	7
Paris	2016	9.78	7	1	5
Catan: Starfarers	2021	9.87	7	13	6
Bleeding Kansas	2020	3.25	3	7	4
One Small Step	2019	5.75	5	9	2


Publishers
Name	AddressId	Website	Phone
Agman Games	5	www.agmangames.com	+16546135542
Amethyst Games	7	www.amethystgames.com	+15558889992
BattleBooks	13	www.battlebooks.com	+12345678907


3.	Update
We've decided to increase the maximum count of players for the boardgames with 1. Update the table PlayersRanges and increase the maximum players of the boardgames, which have a range of players [2,2].
Also, you have to change the name of the boardgames that were issued after 2020 inclusive. You have to add "V2" to the end of their names.


4.	Delete
In table Addresses, delete every country, which has a Town, starting with the letter 'L'. Keep in mind that there could be foreign key constraint conflicts.


Section 3. Querying (40 pts)
You need to start with a fresh dataset, so recreate your DB and import the sample data again ("Dataset.sql").


5.	Boardgames by Year of Publication
Select all boardgames, ordered by year of publication (ascending), then by name (descending). 
Required columns:
•	Name
•	Rating

Example
Name	Rating
Battle Line: Medieval	7.73
The Castles of Tuscany	7.39
Santa Monica	7.54
KeyForge: Mass Mutation	8.27
…	…


6.	Boardgames by Category
Select all boardgames with "Strategy Games" or "Wargames" categories. Order results by YearPublished (descending).
Required columns:
•	Id
•	Name
•	YearPublished
•	CategoryName

Example
Id	Name	YearPublished	CategoryName
6	Polis	2022	Wargames
7	Pan Am	2022	Strategy Games
1	Beyond the Sun	2021	Strategy Games
4	Blue Skies	2021	Strategy Games
…	…	…	…


7.	Creators without Boardgames
Select all creators without boardgames. Order them by name (ascending).
Required columns:
•	Id
•	CreatorName (creators's first and last name, concatenated with space)
•	Email

Example
Id	CreatorName	Email
5	Corey Konieczka	corey@konieczka.com
7	Jamey Stegmaier	jamey@stegmaier.com


8.	First 5 Boardgames
Select the first 5 boardgames that have rating, bigger than 7.00 and containing the letter 'a' in the boardgame name or the rating of a boardgame is bigger than 7.50 and the range of the min and max count of players is [2;5]. Order the result by boardgames name (ascending), then by rating (descending).
Required columns:
•	Name
•	Rating
•	CategoryName

Example
Name	Rating	CategoryName
Abandon All Artichokes	7.12	Family Games
Alma Mater	7.68	Strategy Games
Ankh: Gods of Egypt	7.20	Strategy Games
Azul: Summer Pavilion	7.83	Abstract Games
Battle Line: Medieval	7.73	Strategy Games


9.	Creators with Emails
Select all of the creators that have emails, ending in ".com", and display their most highly rated boardgame. Order by creator full name (ascending).
Required columns:
•	FullName
•	Email
•	Rating

Example
FullName	Email	Rating
Alexander Pfister	alexander@pfister.com	8.58
Bruno Cathala	bruno@cathala.com	8.58
Emerson Matsuuchi	emerson@matsuuchi.com	8.60


10.	Creators by Rating
Select all creators, who have created a boardgame. Select their last name, average rating (rounded up to the next biggest integer) and publisher's name. Show only the results for creators, whose games are published by "Stonemaier Games". Order the results by average rating (descending).

Example
LastName	AverageRating	PublisherName
Leacock	9	Stonemaier Games
Matsuuchi	9	Stonemaier Games
Pfister	8	Stonemaier Games
…	…	
Section 4. Programmability (20 pts)


11.	Creator with Boardgames
Create a user-defined function, named udf_CreatorWithBoardgames(@name) that receives a creator's first name.
The function should return the total number of boardgames that the creator has created.

Example
Query
SELECT dbo.udf_CreatorWithBoardgames('Bruno')
Output
13


12.	Search for Boardgame with Specific Category
Create a stored procedure, named usp_SearchByCategory(@category) that receives category. The procedure must print full information about all boardgames with the given category: Name, YearPublished, Rating, CategoryName, PublisherName, MinPlayers and MaxPlayers. Add " people" at the end of the min and max count of people. Order them by PublisherName (ascending) and YearPublished (descending).

Example
Query
EXEC usp_SearchByCategory 'Wargames'
Output
Name	YearPublished	Rating	CategoryName	PublisherName	MinPlayers	MaxPlayers
Verdun 1916: Steel Inferno	2020	8.60	Wargames	Gamewright	4 people	5 people
Brief Border Wars	2020	7.54	Wargames	Lookout Games	3 people	3 people
…	…	…	…	…	…	…

