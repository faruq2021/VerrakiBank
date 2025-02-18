using Microsoft.AspNetCore.Mvc;
using VerrakiBank.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API Endpoints
app.MapPost("/deposit", ([FromBody] DepositRequest request) =>
{
    try
    {
        var account = MockData.Accounts.FirstOrDefault(a => a.AccountNumber == request.AccountNumber);
        if (account == null)
        {
            return Results.NotFound("Account not found.");
        }

        account.Deposit(request.Amount);
        return Results.Ok(new { Message = "Deposit successful.", Balance = account.Balance });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapPost("/withdraw", ([FromBody] WithdrawRequest request) =>
{
    try
    {
        var account = MockData.Accounts.FirstOrDefault(a => a.AccountNumber == request.AccountNumber);
        if (account == null)
        {
            return Results.NotFound("Account not found.");
        }

        account.Withdraw(request.Amount);
        return Results.Ok(new { Message = "Withdrawal successful.", Balance = account.Balance });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.MapGet("/balance/{accountNumber}", (string accountNumber) =>
{
    try
    {
        var account = MockData.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        if (account == null)
        {
            return Results.NotFound("Account not found.");
        }

        return Results.Ok(new { Balance = account.Balance });
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();

// Request Models
public class DepositRequest
{
    public string? AccountNumber { get; set; }
    public decimal Amount { get; set; }
}

public class WithdrawRequest
{
    public string? AccountNumber { get; set; }
    public decimal Amount { get; set; }
}