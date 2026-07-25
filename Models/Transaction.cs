public class Transaction
{
    public int UserId {get;set;}
    public decimal Value {get;set;}
    public int TransactionId {get;set;}
    public string TransactionType {get;set;}
    public int CategoryId {get;set;}
    public Category Category {get;set;}
    public User User { get; set; }

}