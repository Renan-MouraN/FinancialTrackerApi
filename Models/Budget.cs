public class Budget
{
    public int BudgetId {get;set;}
    public int UserId {get;set;}
    public User User {get;set;} 
    public DateTime Month {get;set;}
    public decimal Limit {get;set;}


}