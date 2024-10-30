using System.ComponentModel.DataAnnotations.Schema;

namespace SingersDB.MVVM.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; } 
        public DateOnly Birthay { get; set; }
        public bool IsMan { get; set; }
        public List<Marks> Marks { get; set; }
    }
}