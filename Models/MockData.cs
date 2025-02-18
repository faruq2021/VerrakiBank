namespace VerrakiBank.Models
{
    public static class MockData
    {
        public static List<BankAccount> Accounts = new List<BankAccount>
    {
        new BankAccount("123456789", "John Doe", 1000.00m),
        new BankAccount("987654321", "Jane Smith", 500.00m)
    };
    }
}
