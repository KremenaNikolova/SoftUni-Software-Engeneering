Database Basics MS SQL Exam – 16 Oct 2021
Exam problems for the "Database Basics" course @ SoftUni. 
Submit your solutions in the SoftUni Judge system at judge.


Section 1. DDL (30 pts)
You have been given the E/R Diagram of the CigarShop
 
Create a database called CigarShop. You need to create 7 tables:
•	Sizes – contains information about the cigar's length and ring range.
•	Tastes – contains information about the cigar's taste type, taste strength, and image of the taste.
•	Brands – contains information about the cigar's brand name and brand description.
•	Cigars – contains information for every single cigar.
•	Addresses – contains information about the clients' address details.
•	Clients – contains information about the customers that buy cigars.
•	ClientsCigars – mapping table between clients and cigars.
Sizes
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity
Length	Integer from 0 to 2,147,483,647.	Length should be between 10 cm. and 25 cm, null is not allowed.
RingRange	Decimal number with two-digit precision.	RingRange should be between 1.5 cm. and 7.5 cm, null is not allowed.

Tastes
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity
TasteType	String up to 20 symbols.	Null is not allowed.
TasteStrength	String up to 15 symbols.	Null is not allowed.
ImageURL	String up to 100 symbols, Unicode.	Null is not allowed.

Brands
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity
BrandName	String up to 30 symbols.	Unique, Null is not allowed.
BrandDescription	String with maximum length.	Null is allowed.

Cigars
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity
CigarName	String up to 80 symbols.	Null is not allowed.
BrandId	Integer from 0 to 2,147,483,647.	Relationship with table Brands. Null is not allowed.
TastId	Integer from 0 to 2,147,483,647.	Relationship with table Tastes. Null is not allowed.
SizeId	Integer from 0 to 2,147,483,647.	PK, Relationship with table Sizes. Null is not allowed.
PriceForSingleCigar	A decimal number used for money calculations.	Null is not allowed.
ImageURL	String up to 100 symbols, Unicode.	Null is not allowed.

Addresses
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity.
Town	String up to 30 symbols.	Null is not allowed.
Country	String up to 30 symbols, Unicode	Null is not allowed.
Streat	String up to 100 symbols, Unicode	Null is not allowed.
ZIP	String up to 20 symbols.	Null is not allowed.

Clients
Column Name	Data Type	Constraints
Id	Integer from 0 to 2,147,483,647.	PK, Unique table identification, Identity.
FirstName	String up to 30 symbols, Unicode.	Null is not allowed.
LastName	String up to 30 symbols, Unicode.	Null is not allowed.
Email	String up to 50 symbols, Unicode.	Null is not allowed.
AddressId	Integer from 0 to 2,147,483,647	Relationship with table Addresses. Null is not allowed.

ClientsCigars
Column Name	Data Type	Constraints
ClientId	Integer from 0 to 2,147,483,647	PK, Unique table identification, Relationship with table Clients,  Required
CigarId	Integer from 0 to 2,147,483,647	PK, Unique table identification, Relationship with table Cigars, Required
N.B: Keep in mind that Judge doesn’t accept “ALTER” statement and square brackets naming, when the names are not keywords.


1.	Database design
Submit all of yours create statements to Judge (only creation of tables).


Section 2. DML (10 pts)
Before you start you have to import "01-DDL-Data-Seeder.sql ". If you have created the structure correctly the data should be successfully inserted.
In this section, you have to do some data manipulations:


2.	Insert
Let us insert some sample data into the database. Write a query to add the following records into the corresponding tables. All IDs should be auto-generated.
Cigars
CigarName	BrandId	TastId	SizeId	PriceForSingleCigar	ImageURL
COHIBA ROBUSTO	9	1	5	15.50	cohiba-robusto-stick_18.jpg
COHIBA SIGLO I	9	1	10	410.00	cohiba-siglo-i-stick_12.jpg
HOYO DE MONTERREY LE HOYO DU MAIRE	14	5	11	7.50	hoyo-du-maire-stick_17.jpg
HOYO DE MONTERREY LE HOYO DE SAN JUAN	14	4	15	32.00	hoyo-de-san-juan-stick_20.jpg
TRINIDAD COLONIALES	2	3	8	85.21	trinidad-coloniales-stick_30.jpg

Addresses
Town	Country	Streat	ZIP
Sofia	Bulgaria	18 Bul. Vasil levski	1000
Athens	Greece	4342 McDonald Avenue	10435
Zagreb	Croatia	4333 Lauren Drive	10000


3.	Update
We’ve decided to increase the price of some cigars by 20%. Update the table Cigars and increase the price of all cigars, which TasteType is "Spicy" by 20%. Also add the text "New description" to every brand, which does not has BrandDescription.


4.	Delete
In table Addresses, delete every country which name starts with 'C', keep in mind that could be foreign key constraint conflicts.


Section 3. Querying (40 pts)
You need to start with a fresh dataset, so recreate your DB and import the sample data again (01-DDL-Data-Seeder.sql).


5.	Cigars by Price
Select all cigars ordered by price (ascending) then by cigar name  (descending). 
Required columns:
•	CigarName
•	PriceForSingleCigar
•	ImageURL

Example:
CigarName	PriceForSingleCigar	ImageURL
H.UPMANN NO. 2	5.45	h-upmann-magnum-50_6_4_1_9.png
EL-REY-DEL-MUNDO DEMI TASSE	11.45	EL-REY-DEL-MUNDO-magnum-50_6_4_1_9.jpg
VEGUEROS TAPADOS	15.62	VEGUEROS-open-junior_1_1_2_1_1_1_4_1_1_1_1_1_1_1_1_2_4_1_9.jpg
BOLIVAR CORONAS JUNIOR	17.34	bolivar-coronas-junior.jpg
…	…	…


6.	Cigars by Taste
Select all cigars with "Earthy" or "Woody" tastes. Order results by PriceForSingleCigar (descending).
Required columns:
•	Id
•	CigarName
•	PriceForSingleCigar
•	TasteType
•	TasteStrength

Example:
Id	CigarName	PriceForSingleCigar	TasteType	TasteStrength
18	TRINIDAD CASILDA COLECCION HABANOS 2019	756.82	Woody	Medium
25	RAMON ALLONES SMALL CLUB CORONAS	567.34	Earthy	Medium to Full
39	MONTECRISTO OPEN MASTER TUBOS	555.45	Earthy	Medium to Full
38	MONTECRISTO OPEN JUNIOR	545.45	Woody	Medium
…	…	…	…	…


7.	Clients without Cigars
Select all clients without cigars. Order them by name (ascending).
Required columns:
•	Id
•	ClientName – customer’s first and last name, concatenated with space
•	Email

Example:
Id	ClientName	Email
8	Brenda Wallace	Wallace.khan@gmail.com
10	Harry Jones	5ornob.Jones@gmail.com
7	Jason Hamilton	nob.Jason@gmail.com


8.	First 5 Cigars
Select the first 5 cigars that are at least 12cm long and contain "ci" in the cigar name or price for a single cigar is bigger than $50 and ring range is bigger than 2.55. Order the result by cigar name (ascending), then by price for a single cigar (descending).
Required columns:
•	CigarName
•	PriceForSingleCigar
•	ImageURL

Example:
CigarName	PriceForSingleCigar	ImageURL
COHIBA 1966 EDICION LIMITADA 2011	19.45	cohiba-siglo-i-stick_18.png
COHIBA BEHIKE 54	254.09	cohiba-esplendidos-stick.jpg
FONSECA NO. 1	76.34	FONSECA-50_6_4_1_9.jpg
HOYO-DE-MONTERREY EPICURE ESPECIAL	98.89	HOYO-DE-MONTERREY-siglo-i-stick_18.jpg
HOYO-DE-MONTERREY EPICURE NO. 2	78.57	HOYO-DE-MONTERREY-siglo-i-stick_18.jpg


9.	Clients with ZIP Codes
Select all clients which have addresses with ZIP code that contains only digits, and display they're the most expensive cigar. Order by client full name ascending.
Required columns:
•	FullName
•	Country
•	ZIP
•	CigarPrice – formated as "${CigarPrice}"

Example:
FullName	Country	ZIP	CigarPrice
Betty Wallace	Turkey	13760	$555.45
Joan Peters	Japan	06511	$543.23
Rachel Bishop	Andorra	08043	$555.45


10.	Cigars by Size
Select all clients which own cigars. Select their last name, average length, and ring range (rounded up to the next biggest integer) of their cigars. Order the results by average cigar length (descending).
Example:
LastName	CiagrLength	CiagrRingRange
Miller	20	5
Riley	19	3
Ramirez	18	5
…	…	


Section 4. Programmability (20 pts)


11.	Client with Cigars
Create a user-defined function, named udf_ClientWithCigars(@name) that receives a client’s first name.
The function should return the total number of cigars that the client has:

Example:
Query
SELECT dbo.udf_ClientWithCigars('Betty')
Output
5


12.	Search for Cigar with Specific Taste
Create a stored procedure, named usp_SearchByTaste(@taste), that receives taste type. The procedure must print full information about all cigars with the given tastes: CigarName, Price, TasteType, BrandName, CigarLength, CigarRingRange. Add "$" at the beginning of the price and "cm" at the end of both CigarLength and CigarRingRange. Order them by CigarLength (ascending), and CigarRingRange (descending).

Example:
Query
EXEC usp_SearchByTaste 'Woody'
Output
CigarName	Price	TasteType	BrandName	CigarLength	CigarRingRange
BOLIVAR PETIT CORONAS	$18.76	Woody	BOLIVAR	10 cm	2.90 cm
DAVIDOFF MILLENNIUM BLEND ROBUSTO	$86.45	Woody	DAVIDOFF	11 cm	5.30 cm
H.UPMANN MAGNUM 50 TUBOS	$23.66	Woody	H.UPMANN	11 cm	4.30 cm
…	…	…	…	…	…


