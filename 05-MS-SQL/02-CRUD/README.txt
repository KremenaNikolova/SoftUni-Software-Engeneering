Exercises: CRUD

This document defines the exercise assignments for the "Databases Basics - MSSQL" course @ Software University. 
You can check your solutions in the Judge system.
1.	Examine the Databases
Download and get familiar with the SoftUni, Diablo and Geography database schemas and tables. You will use them in the current and the following exercises to write queries.
Part I – Queries for SoftUni Database
2.	Find All the Information About Departments
Create a SQL query that finds all the available information about the Departments.
Example
DepartmentID	Name	ManagerID
1	Engineering	12
2	Tool Design	4
3	Sales	273
…	…	…
3.	Find all Department Names
Create a SQL query that finds all Department names.
Example
Name
Engineering
Tool Design
Sales
…
4.	Find Salary of Each Employee
Create a SQL query that finds the first name, last name and salary for each employee.
Example
FirstName	LastName	Salary
Guy	Gilbert	12500.00
Kevin	Brown	13500.00
Roberto	Tamburello	43300.00
…	…	…
5.	Find Full Name of Each Employee
Create a SQL query that finds the first, middle and last name for each employee.
Example
FirstName	MiddleName	LastName
Guy	R	Gilbert
Kevin	F	Brown
Roberto	NULL	Tamburello
…	…	…
6.	Find Email Address of Each Employee
Create a SQL query that finds the email address of each employee by their first and last name. Consider that the email domain is softuni.bg. Emails should look like "John.Doe@softuni.bg". The produced column should be named "Full Email Address".
Example
Full Email Address
Guy.Gilbert@softuni.bg
Kevin.Brown@softuni.bg
Roberto.Tamburello@softuni.bg
…
7.	Find All Different Employees' Salaries
Create a SQL query that finds all different salaries of the employees. Display the salaries only in one column, named "Salary".
Example
Salary
9000.00
9300.00
9500.00
…
8.	Find All Information About Employees
Create a SQL query that finds all information about the employees whose job title is "Sales Representative".
Example
ID	First
Name	Last
Name	Middle
Name	Job Title	DeptID	Mngr
ID	HireDate	Salary	AddressID
275	Michael	Blythe	G	Sales Representative	3	268	…	23100.00	60
276	Linda	Mitchell	C	Sales Representative	3	268	…	23100.00	170
277	Jillian	Carson	NULL	Sales Representative	3	268	…	23100.00	61
…	…	…	…	…	…	…	…	…	…
9.	Find Names of All Employees by Salary in Range
Create a SQL query to find the first name, last name and job title for all employees whose salary is in a range between 20000 and 30000.
Example
FirstName	LastName	JobTitle
Rob	Walters	Senior Tool Designer
Thierry	D'Hers	Tool Designer
JoLynn	Dobney	Production Supervisor
…	…	…
10.	Find Names of All Employees
Create a SQL query that finds the full name of all employees whose salary is exactly 25000, 14000, 12500 or 23600. The result should be displayed in a column, named "Full Name", which is a combination of the first, middle and last names, separated by a single space.
Example
Full Name
Guy R Gilbert
Thierry B D'Hers
JoLynn M Dobney
11.	Find All Employees Without a Manager
Create a SQL query that finds the first and last names of those employees who do not have a manager.
Example
FirstName	LastName
Ken	Sanchez
Svetlin	Nakov
…	…
12.	Find All Employees with a Salary More Than 50000
Create a SQL query that finds the first name, last name and salary for employees with a salary higher than 50000. Order the result in decreasing order by salary.
Example
FirstName	LastName	Salary
Ken	Sanchez	125500.00
James	Hamilton	84100.00
…	…	…
13.	Find 5 Best Paid Employees.
Create a SQL query that finds the first and last names of the 5 best-paid Employees, ordered descending by their salary.
Example
FirstName	LastName
Ken	Sanchez
James	Hamilton
…	…
14.	Find All Employees Except Marketing
Create a SQL query that finds the first and last names of all employees whose department ID is not 4.
Example
FirstName	LastName
Guy	Gilbert
Roberto	Tamburello
Rob	Walters
15.	Sort Employees Table
Create a SQL query that sorts all the records in the Employees table by the following criteria:
•	By salary in decreasing order
•	Then by the first name alphabetically
•	Then by the last name descending
•	Then by middle name alphabetically

Example
ID	First
Name	Last
Name	Middle
Name	Job Title	DeptID	Mngr
ID	HireDate	Salary	AddressID
109	Ken	Sanchez	J	Chief Executive Officer	16	NULL	…	125500.00	177
148	James	Hamilton	R	Vice President of Production	7	109	…	84100.00	158
273	Brian	Welcker	S	Vice President of Sales	3	109	…	72100.00	134
…	…	…	…	…	…	…	…	…	…
16.	Create View Employees with Salaries
Create a SQL query that creates a view " " with first name, last name and salary for each employee.
Example
FirstName	LastName	Salary
Guy	Gilbert	12500.00
Kevin	Brown	13500.00
…	…	…
17.	Create View Employees with Job Titles
Create a SQL query that creates a view "V_EmployeeNameJobTitle" with a full employee name and a job title. When the middle name is NULL replace it with an empty string ('').
Example
Full Name	Job Title
Guy R Gilbert	Production Technician
Kevin F Brown	Marketing Assistant
Roberto  Tamburello	Engineering Manager
…	…
18.	Distinct Job Titles
Create a SQL query that finds all distinct job titles.
Example
JobTitle
Accountant
Accounts Manager
Accounts Payable Specialist
…
19.	Find First 10 Started Projects
Create a SQL query that finds the first 10 projects which were started, select all the information about them and order the result by starting date, then by name.
Example
ID	Name	Description	StartDate	EndDate
6	HL Road Frame	Research, design and development of HL Road …	1998-05-02 00:00:00	2003-06-01 00:00:00
2	Cycling Cap	Research, design and development of C…	2001-06-01 00:00:00	2003-06-01 00:00:00
5	HL Mountain Frame	Research, design and development of HL M…	2001-06-01 00:00:00	2003-06-01 00:00:00
…	…	…	…	…
20.	Last 7 Hired Employees
Create a SQL query that finds the last 7 hired employees, select their first, last name and hire date. Order the result by hire date descending.
Example
FirstName	LastName	HireDate
Rachel	Valdez	2005-07-01 00:00:00
Lynn	Tsoflias	2005-07-01 00:00:00
Syed	Abbas	2005-04-15 00:00:00
…	…	…
21.	Increase Salaries
Create a SQL query that increases salaries by 12% for all employees that work in one of the following departments – Engineering, Tool Design, Marketing or Information Services. As a result, select and display only the "Salaries" column from the Employees table. After this, you should restore the database to the original data.
Example
Salary
12500.00
15120.00
48496.00
33376.00
…
Part II – Queries for Geography Database
22.	All Mountain Peaks
Display all the mountain peaks in alphabetical order.
Example
PeakName
Aconcagua
Banski Suhodol
Batashki Snezhnik
…
23.	Biggest Countries by Population
Find the 30 biggest countries by population, located in Europe. Display the "CountryName" and "Population". Order the results by population (from biggest to smallest), then by country alphabetically.
Example
CountryName	Population
Russia	140702000
Germany	81802257
France	64768389
…	…
24.	*Countries and Currency (Euro / Not Euro)
Find all the countries with information about their currency. Display the "CountryName", "CountryCode", and information about its "Currency": either "Euro" or "Not Euro". Sort the results by country name alphabetically.

Hint: Use CASE … WHEN.
Example
CountryName	CountryCode	Currency
Afghanistan	AF	Not Euro
Åland	AX	Euro
Albania	AL	Not Euro
…	…	…

Part III – Queries for Diablo Database
25.	All Diablo Characters
Display all characters in alphabetical order.
Example
Name
Amazon
Assassin
Barbarian
…

