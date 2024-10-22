using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.Model
{
    public class DataBase : DbContext
    {
        private readonly string filename;

        public DataBase() { }
        public DataBase(string filename)
            => this.filename = filename;

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Marks> Marks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Database");
            Directory.CreateDirectory(path);
            var fileName = $"{path}\f{filename}";
            if (!File.Exists(fileName))
                File.Create(fileName);
            optionsBuilder.UseSqlite($"Data Source = {fileName}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
