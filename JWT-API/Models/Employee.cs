using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JWT_API.Models;

[Table("employee")]
public class Employee
{
    [Key]
    public int id { get; set; }

    public string name { get; set; }
   public int age { get; set; }
    public string photo { get; set; }

    public Employee(string name, int age, string photo)
    {
        this.name = name;
        this.age = age;
        this.photo = photo;
    }
}