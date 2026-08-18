using System.ComponentModel.DataAnnotations;

public class CreateUserDto
{
    [Required(ErrorMessage = "Username is required")]
    public string FullName {get;set;} = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid format")]
    public string Email {get;set;} = String.Empty;

}