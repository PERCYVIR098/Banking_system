namespace Accounts{
    public class CheckingAccount : Account{

        public double OverdraftLimit {get;}

        public CheckingAccount(int AccountNumber, double OverdraftLimit) : base(AccountNumber){
            this.OverdraftLimit=OverdraftLimit;
        }
                public override void Withdraw(double amount){
                        if(amount>OverdraftLimit && Balance >= OverdraftLimit){
                Balance-=amount;
                Console.WriteLine($"Withdrawn ${amount}.\nNew Balance ${Balance}");
            }
            else{
                Console.WriteLine("Insufficient Balance or OverdraftLimit has been reached.");
            }
        }
    }
}