### 1.	Student System
Your task is to create a database for the StudentSystem, using the EF Core Code First approach. It should look like this:
 
 ![StudentSystemDiagram](https://user-images.githubusercontent.com/106489962/222900674-30d41882-3f79-44b3-869d-0a7707fdfccf.png)
 
Constraints
Your namespaces should be:
-	P01_StudentSystem – for your Startup class, if you have one
-	P01_StudentSystem.Data – for your DbContext
-	P01_StudentSystem.Data.Models – for your models
Your models should be:
-	StudentSystemContext – your DbContext

o	Student
-	StudentId
-	Name – up to 100 characters, unicode
-	PhoneNumber – exactly 10 characters, not unicode, not required
-	RegisteredOn
-	Birthday – not required

o	Course
-	CourseId
-	Name – up to 80 characters, unicode
-	Description – unicode, not required
-	StartDate
-	EndDate
-	Price

o	Resource
-	ResourceId
-	Name – up to 50 characters, unicode
-	Url – not unicode
-	ResourceType – enum, can be Video, Presentation, Document or Other
-	CourseId

o	Homework
-	HomeworkId
-	Content – string, linking to a file, not unicode
-	ContentType - enum, can be Application, Pdf or Zip
-	SubmissionTime
-	StudentId
-	CourseId

o	StudentCourse – mapping between Students and Courses

Table relations:	
-	One student can have many Courses 
-	One student can have many Homeworks 
-	One course can have many Students
-	One course can have many Resources
-	One course can have many Homeworks
You will need a constructor, accepting DbContextOptions to test your solution in Judge!