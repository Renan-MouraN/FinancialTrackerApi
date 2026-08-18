using System.ComponentModel.DataAnnotations;

public class CreateBudgetDto
{

    public int UserId {get;set;}
    public DateTime Month {get;set;}
    public decimal Limit {get;set;}

}