using System.ComponentModel.DataAnnotations;

namespace EPOSProject.Models;
public class Student 
{

    public int Id { get; set; }

    [Required]
    [MaxLength(9)]
    public string? Index { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Firstname { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Lastname { get; set; }

    public Student() {
        
    }

    public Student(string index, string firstname, string lastname) {
        this.Index = index;
        this.Firstname = firstname;
        this.Lastname = lastname;
    }

}