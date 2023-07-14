														Instruction:
1. Change ConnectionString configurations like "UserId" and "Password" according to your Database Configurations which is located within "StudentGrades.API/appsettings.json" and use the PostgreSQL as DataBase.   
2. Delete the migration located at "StudentGrades.Infrastructure/Persistence/Migrations."
3. In the Package Manager Console, select the "StudentGrades.Infrastructure" as the Default project.
4. Run the following command in the Package Manager Console: 'Add-Migration Initial';
5. Execute the following command in the Package Manager Console: 'Update-Database.'
Now you can run and test the application.

In order to test the project you can follow this:


											Creating the Student:
Request body:
	{
	 "name": "SampleName",
	 "birthDate": "2023-07-14T13:17:52.160Z",
	 "email": "SampleEmail"
	}

Request URL:
	https://localhost:7129/api/Students/PostStudent

Expected response: 
	Response code should be "200" after successful creating New Student.

Expected response Body: 
		{
		  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
		  "name": "SampleName",
		  "birthDate": "2023-07-14T13:17:52.160Z",
		 "email": "SampleEmail",
		  "grades": [
			{
			  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "score": 0,
			  "subjectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
			}
		  ]
		}


											 Updating the Student:
Request body:
		{
		  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
		  "name": "UpdatedSampleName",
		  "birthDate": "2023-07-14T13:37:24.241Z",
		  "email": "UpdatedSampleEmail"
		}

Request URL:
	https://localhost:7129/api/Students/UpdateStudent

Expected response: 
	Response code should be "200" after successful creating New Student.

Expected Response Body:
		{
		  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
		  "name": "string",
		  "birthDate": "2023-07-14T13:38:39.536Z",
		  "email": "string",
		  "grades": [
			{
			  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "score": 0,
			  "subjectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
			}
		  ]
		}


												Getting Student By Id:
Request URL:
	https://localhost:7129/api/Students/GetStudent?StudentId=3fa85f64-5717-4562-b3fc-2c963f66afa6

Expected response: 
	Response code should be "200" after successful getting Student.

Expected Response Body:	
		{
		  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
		  "name": "string",
		  "birthDate": "2023-07-14T13:28:43.782Z",
		  "email": "string",
		  "grades": [
			{
			  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "score": 0,
			  "subjectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
			  "studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
			}
		  ]
		}


										Getting All Students:
Request URL:
	https://localhost:7129/api/Students/GetAllStudent

Expected response: 
	Response code should be "200" after successful getting Student.

Expected Response Body:	
			[
			  {
				"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
				"name": "string",
				"birthDate": "2023-07-14T13:35:38.247Z",
				"email": "string",
				"grades": [
				  {
					"id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
					"score": 0,
					"subjectId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
					"studentId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
				  }
				]
			  }
			]