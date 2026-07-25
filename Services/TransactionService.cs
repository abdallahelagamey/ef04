public void AddTransaction(
    string accountNumber,
    decimal amount,
    TransactionType type,
    string note)
{
    var account = _context.Accounts
        .FirstOrDefault(a => a.AccountNumber == accountNumber);

    if (account == null)
    {
        Console.WriteLine("Account Not Found.");
        return;
    }

    if (type == TransactionType.Deposit)
    {
        account.CurrentBalance += amount;
    }
    else
    {
        if (account.CurrentBalance < amount)
        {
            Console.WriteLine("Insufficient Balance.");
            return;
        }

        account.CurrentBalance -= amount;
    }

    _context.Transactions.Add(new Transaction
    {
        TransactionDate = DateTime.Now,
        Amount = amount,
        TransactionType = type,
        Note = note,
        AccountNumber = accountNumber
    });

    _context.SaveChanges();
}
