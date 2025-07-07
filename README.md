# Workout Tracker API

This project is a **Workout Tracker RESTful API** built with **ASP.NET Core Web API**. It enables users to manage their workout routines, exercises, and progress tracking securely with JWT authentication.

---

## 🔐 Authentication

- **Register** and **Login** endpoints using ASP.NET Identity.
- Generates JWT token upon login to secure the app.
- Requires `[Authorize]` on all endpoints except login and registration.

---

## 📦 Main Features

### ✅ Account Management
- `POST /api/Account/register` – Register a new user.
- `POST /api/Account/login` – Authenticate and receive a JWT token.

### 🏋️‍♂️ Exercises
- `GET /api/Exercises` – Get all exercises.
- `GET /api/Exercises/{id}` – Get a single exercise.
- `POST /api/Exercises` – Create a new exercise.
- `PUT /api/Exercises/{id}` – Update an existing exercise.
- `DELETE /api/Exercises/{id}` – Delete an exercise.

### 📝 Exercise Logs
- `GET /api/ExerciseLog` – Get all exercise logs.
- `GET /api/ExerciseLog/workoutExercise/{workoutExerciseId}` – Get logs for a specific workout exercise.
- `POST /api/ExerciseLog` – Add a log entry.
- `DELETE /api/ExerciseLog/{id}` – Delete a log entry.

### 🧠 Workouts
- `GET /api/Workout` – Get all workouts.
- `GET /api/Workout/{id}` – Get a single workout.
- `POST /api/Workout` – Create a new workout.
- `PUT /api/Workout/{id}` – Update an existing workout.
- `DELETE /api/Workout/{id}` – Delete a workout.

### 🧩 Workout Exercises
- `GET /api/WorkoutExercises` – Get all workout exercises.
- `GET /api/WorkoutExercises/{id}` – Get workout exercise by ID.
- `POST /api/WorkoutExercises` – Create a new workout exercise.
- `PUT /api/WorkoutExercises/{id}` – Update a workout exercise.
- `DELETE /api/WorkoutExercises/{id}` – Delete a workout exercise.

---
## 🛡️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- ASP.NET Identity (User Authentication)
- JWT (JSON Web Token) for Authentication
- SQL Server (or any EF Core-compatible DB)


---
## 🚀 Getting Started

Follow these steps to get the WorkoutTracker API up and running:

### 1. 📦 Clone the Repository

```bash
git clone https://github.com/ABdulrahman197/WorkoutTracker.git
cd WorkoutTracker
```


### 2. 🛠️ Configure Database Connection

Edit the `appsettings.json` file located inside the `WorkoutTracker` project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=WorkoutTrackerDb;Trusted_Connection=True;TrustServerCertificate=True;"
},
"JWT": {
  "Key": "Your_Secret_Key",
  "Issuer": "YourApp"
}
```

Replace `YOUR_SERVER_NAME` and `Your_Secret_Key` with your actual SQL Server instance and a secure key.



### 3. 🗃️ Apply Entity Framework Migrations

Make sure you have the EF Core CLI tools installed. Then run:

```bash
cd WorkoutTracker
dotnet ef database update
```

If EF tools are not installed, install them first using:

```bash
dotnet tool install --global dotnet-ef
```



### 4. ▶️ Run the Application

From the `WorkoutTracker` project directory, run:

```bash
dotnet run
```

By default, the API will be available at:

- `https://localhost:5001`
- `http://localhost:5000`



### 5. 🔍 Test the API

You can test the endpoints using:

#### ✅ Swagger UI

Navigate to:

```
https://localhost:5001/swagger
```

#### ✅ Postman

Use Postman to send HTTP requests to the API. Example:

```http
POST https://localhost:5001/api/account/register
Content-Type: application/json

{
  "username": "testuser",
  "password": "Test@123"
}
```

Make sure to include the `Authorization: Bearer <token>` header for protected endpoints.

---

  ---## Author

Developed by **Abdulrahman Sayed**
