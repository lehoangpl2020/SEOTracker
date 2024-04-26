# SEO Tracker

This project is a SEO tracker application that allows users to track the ranking positions of URLs in search engine results.

## Prerequisites

Before running the application, make sure you have the following prerequisites installed:

- .NET 6 SDK
- Node.js
- SQL Server Express

## Running the API

1. Clone this repository to your local machine.

2. Navigate to the `SEOTracker.API` directory.

3. Open `appsettings.json` and update the connection string to point to your SQL Express database.

4. Open a terminal window and run the following commands:
dotnet restore
dotnet run


5. The API should now be running on `https://localhost:7127`.

## Running the SPA

1. Navigate to the `SEOTracker.SPA` directory.

2. Open a terminal window and run the following commands:
npm install
npm run dev

3. The SPA should now be running on `http://localhost:5173`.

## Usage

Once both the API and SPA are running, you can access the SPA in your web browser and start using the SEO tracker application.

