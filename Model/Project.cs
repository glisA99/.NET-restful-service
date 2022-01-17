using System.ComponentModel.DataAnnotations;

namespace EPOSProject.Models;
public class Project 
{

    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Title { get; set; }

    public Nullable<int> Score { get; set; }

    [Required]
    public bool Finished { get; set; }

    [Required]
    public ICollection<Student>? Students { get; set; }

    [Required]
    public Professor? Professor { get; set; }

    public Project() {

    }

    public Project(string title, bool finished,ICollection<Student> students, Professor professor,int? score) {
        this.Title = title;
        this.Finished = finished;
        this.Students = students;
        this.Professor = professor;
        this.Finished = finished;
        if (finished) {
            if (score is null) throw new System.Exception("Finished project must have score");
            this.Score = score;
        }else if (score is not null) throw new System.Exception("Unfinished project must not have score");
    }

}