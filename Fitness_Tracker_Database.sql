CREATE DATABASE Fitness_Tracker;
GO

USE Fitness_Tracker;


CREATE TABLE Coach (
    CoachID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
	Email VARCHAR(50),
	ExperienceYears INT,
	Fees DECIMAL(5,2),
	Telephone VARCHAR(30)
);

CREATE TABLE Nutritionist (
    NutritionistID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
	Email VARCHAR(50),
	ExperienceYears INT,
	Fees DECIMAL(5,2),
	Telephone VARCHAR(30)
);
GO
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(50) NOT NULL,
	Email VARCHAR(50),
	Age INT,
	Gender VARCHAR(10),
	Telephone VARCHAR(30),
	CoachID INT,
	NutritionistID INT,
	WPlanID INT,
	MPlanID INT,
	FOREIGN KEY (CoachID) REFERENCES Coach(CoachID),
	FOREIGN KEY (NutritionistID) REFERENCES Nutritionist(NutritionistID)
);
GO
USE Fitness_Tracker
CREATE TABLE Admin(
	UserID INT IDENTITY(1,1)  PRIMARY KEY,
	Username VARCHAR(50) NOT NULL UNIQUE,
	Password VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Progress_Log (
    LogNum INT IDENTITY(1,1) PRIMARY KEY,
    LogDate DATE NOT NULL,
	Weight DECIMAL(5, 2),
	BFP INT,
	Measurements VARCHAR(100),
	GoalWeight DECIMAL(5, 2), 
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Workout_Log (
    LogNum INT IDENTITY(1,1) PRIMARY KEY,
    LogDate DATE NOT NULL,
	Comments VARCHAR(200),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Meal_Log (
    LogNum INT IDENTITY(1,1) PRIMARY KEY,
    LogDate DATE NOT NULL,
	MealType VARCHAR(10),
	TimeEaten TIME,
	Feedback VARCHAR(200),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Food_Item (
    FoodID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(30) NOT NULL UNIQUE,
	Category VARCHAR(30),
    Calories DECIMAL(5, 2) NOT NULL,
    Fats DECIMAL(5, 2) NOT NULL,
    Carbs DECIMAL(5, 2) NOT NULL,
    Protein DECIMAL(5, 2) NOT NULL
);

CREATE TABLE Exercises (
    ExerciseID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(30) NOT NULL UNIQUE,
	TargetMuscle VARCHAR(30),
	Equipment VARCHAR(30),
	VideoURL VARCHAR(200),
	Alternative VARCHAR(30),
	FOREIGN KEY (Alternative) REFERENCES Exercises(Name)
);
GO
CREATE TABLE Workout_Plan (
    PlanID INT IDENTITY(1,1) PRIMARY KEY,
	NumOfDays INT,
    CoachID INT NOT NULL,
    FOREIGN KEY (CoachID) REFERENCES Coach(CoachID)
);

CREATE TABLE Meal_Plan (
    PlanID INT,
    DayOfWeek INT NOT NULL,
    Breakfast VARCHAR(30) NOT NULL,
    Lunch VARCHAR(30) NOT NULL,
    Dinner VARCHAR(30) NOT NULL,
	Snacks VARCHAR(30),
    NutritionistID INT NOT NULL,
    PRIMARY KEY (PlanID, DayOfWeek),
    FOREIGN KEY (NutritionistID) REFERENCES Nutritionist(NutritionistID),
	FOREIGN KEY (Breakfast) REFERENCES Food_Item(Name),
	FOREIGN KEY (Lunch) REFERENCES Food_Item(Name),
	FOREIGN KEY (Dinner) REFERENCES Food_Item(Name),
	FOREIGN KEY (Snacks) REFERENCES Food_Item(Name)
);

CREATE TABLE Medical_Notes (
    NoteNum INT IDENTITY(1,1) PRIMARY KEY,
    CreationDate DATE NOT NULL,
	Injuries VARCHAR(200),
	HealthConcerns VARCHAR(200),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Grocery_List (
    ListID INT IDENTITY(1,1) PRIMARY KEY,
    CreationDate DATE NOT NULL,
	List VARCHAR(400),
    UserID INT NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Workout_Log_Consists_Of (
    LogNum INT,
    ExerciseID INT,
	Sets INT,
	Reps INT,
    PRIMARY KEY (LogNum, ExerciseID),
    FOREIGN KEY (LogNum) REFERENCES Workout_Log(LogNum),
    FOREIGN KEY (ExerciseID) REFERENCES Exercises(ExerciseID)
);

CREATE TABLE Meal_Log_Consists_Of (
    LogNum INT,
    FoodID INT,
    PRIMARY KEY (LogNum, FoodID),
    FOREIGN KEY (LogNum) REFERENCES Meal_Log(LogNum),
    FOREIGN KEY (FoodID) REFERENCES Food_Item(FoodID)
);

CREATE TABLE Workout_Plan_Consists_Of (
    PlanID INT,
    ExerciseID INT,
	Sets INT,
	Reps INT,
	DayNum INT,
    PRIMARY KEY (PlanID, ExerciseID),
    FOREIGN KEY (PlanID) REFERENCES Workout_Plan(PlanID),
    FOREIGN KEY (ExerciseID) REFERENCES Exercises(ExerciseID)
);
