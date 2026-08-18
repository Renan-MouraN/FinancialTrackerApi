using System.ComponentModel.DataAnnotations;

public class UpdateTransactionDto
{
    public decimal Value {get;set;}
    public string TransactionType {get;set;}
    public int CategoryId {get;set;}

}