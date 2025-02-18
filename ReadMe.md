**VerrakiBank API**
The VerrakiBank API is a lightweight and simple banking API built using ASP.NET Core Minimal APIs. It provides basic banking operations such as deposits, withdrawals,
and balance inquiries using mock data. This API is designed to be easy to set up and use for testing and demonstration purposes.

Features
Deposit Funds: Add funds to a bank account.

Withdraw Funds: Deduct funds from a bank account.

Get Balance: Retrieve the current balance of a bank account.

Technologies Used
ASP.NET Core Minimal APIs: Lightweight and efficient API development.

Mock Data: In-memory data for testing purposes.

Swagger: For API documentation and testing.

Getting Started
Follow these steps to set up and run the VerrakiBank API on your local machine.

Prerequisites
.NET 7.0 SDK

Visual Studio 2022 (or any code editor like VS Code)

Step 1: Clone the Repository
Clone the repository to your local machine:


git clone https://github.com/faruq2021/VerrakiBank.git
cd verraki-bank-api
Step 2: Run the Application
Build and run the application:


dotnet build
dotnet run
The API will start running at https://localhost:5001 (or http://localhost:5000).

Open the Swagger UI in your browser:

Go to https://localhost:5001/swagger to explore and test the API endpoints.

Step 3: Test the API
Use the Swagger UI or tools like Postman to test the API endpoints. Here are some examples:

Deposit Funds
POST /deposit

Request Body:

json
Copy
{
    "accountNumber": "123456789",
    "amount": 200
}
Withdraw Funds
POST /withdraw

Request Body:

json

{
    "accountNumber": "123456789",
    "amount": 100
}
Get Balance
GET /balance/123456789

API Endpoints
Method	Endpoint	Description
POST	/deposit	Deposit funds into an account.
POST	/withdraw	Withdraw funds from an account.
GET	/balance/{accountNumber}	Get the balance of an account.

Mock Data
The API uses the following mock data for testing:


public static class MockData
{
    public static List<BankAccount> Accounts = new List<BankAccount>
    {
        new BankAccount("123456789", "John Doe", 1000.00m),
        new BankAccount("987654321", "Jane Smith", 500.00m)
    };
}
Account Numbers:

123456789: John Doe (Balance: 1000.00)

987654321: Jane Smith (Balance: 500.00)

