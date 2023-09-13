using Accounts;

public class Program{

public static void Main(){
    SavingsAccount savingsAccount=new SavingsAccount(1001,5);
    savingsAccount.Deposit(1500);
    savingsAccount.DisplayAccountDetails();
    savingsAccount.CalculatedInterest();
    savingsAccount.DisplayAccountDetails();

    Console.WriteLine();

    CheckingAccount checkingAccount=new CheckingAccount(2001,500);
    checkingAccount.Deposit(1200);
    checkingAccount.DisplayAccountDetails();
    checkingAccount.Withdraw(1500);
    checkingAccount.DisplayAccountDetails();
}
}


