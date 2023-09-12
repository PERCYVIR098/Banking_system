using System;

class Account
{
    private int accountNumber;
    private double balance;

    public int AccountNumber
    {
        get { return accountNumber; }
    }

    public double Balance
    {
        get { return balance; }
    }

    public Account(int accountNumber)
    {
        this.accountNumber = accountNumber;
        this.balance = 0;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Deposited ${amount} into Account {AccountNumber}. New balance: ${Balance}");
        }
    }

    public virtual void Withdraw(double amount)
    {
        if (amount > 0 && balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn ${amount} from Account {AccountNumber}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds to withdraw from Account {AccountNumber}.");
        }
    }
}

class SavingsAccount : Account
{
    private double interestRate;

    public double InterestRate
    {
        get { return interestRate; }
    }

    public SavingsAccount(int accountNumber, double interestRate) : base(accountNumber)
    {
        this.interestRate = interestRate;
    }

    public void CalculateInterest()
    {
        double interest = Balance * (interestRate / 100);
        Deposit(interest);
        Console.WriteLine($"Interest of ${interest} earned in Savings Account {AccountNumber}. New balance: ${Balance}");
    }
}

class CheckingAccount : Account
{
    private double overdraftLimit;

    public double OverdraftLimit
    {
        get { return overdraftLimit; }
    }

    public CheckingAccount(int accountNumber, double overdraftLimit) : base(accountNumber)
    {
        this.overdraftLimit = overdraftLimit;
    }

    public override void Withdraw(double amount)
    {
        if (amount > 0 && (Balance - amount) >= -overdraftLimit)
        {
            base.Withdraw(amount);
        }
        else
        {
            Console.WriteLine($"Withdrawal not allowed from Checking Account {AccountNumber}. Exceeds overdraft limit.");
        }
    }
}

class Program
{
    static void DisplayAccountDetails(Account account)
    {
        Console.WriteLine($"Account Type: {account.GetType().Name}");
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Balance: ${account.Balance}");
    }

    static void Main(string[] args)
    {
        SavingsAccount savingsAccount = new SavingsAccount(101, 2.5);
        CheckingAccount checkingAccount = new CheckingAccount(201, 1000);

        savingsAccount.Deposit(500);
        savingsAccount.CalculateInterest();

        checkingAccount.Deposit(800);
        checkingAccount.Withdraw(300);
        checkingAccount.Withdraw(1500); // Attempt to withdraw beyond overdraft limit

        Console.WriteLine("\nSavings Account Details:");
        DisplayAccountDetails(savingsAccount);

        Console.WriteLine("\nChecking Account Details:");
        DisplayAccountDetails(checkingAccount);
    }
}
