using System.ComponentModel.DataAnnotations;

namespace EPOSProject.Models;
public class Professor 
{

    public int Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Firstname { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Lastname { get; set; }

    public Professor() {
        
    }

    public Professor(string firstname, string lastname) {
        this.Firstname = firstname;
        this.Lastname = lastname;
    }

}