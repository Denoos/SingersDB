namespace SingersDB.MVVM.Model
{
    public class Marks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public bool IsRespone{ get; set; }
    }
}