using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingersDB.MVVM.Model
{
    public class DB
    {
        //Pattern Block
        private static DB inst;
        public static DB Instance
        {
            get => inst ??= new DB();
        }

        //DataBase Block
        readonly DataBaseContext dataBase = new("db");
        public DB()
           => dataBase.Database.EnsureCreated();

        //Methods Block
        public async Task AddMark(Marks mark)
        {
            if (mark.CreateDate == default)
                mark.CreateDate = DateTime.Now;
            mark.LastUpdateDate = DateTime.Now;

            await dataBase.Marks.AddAsync(mark);
            await dataBase.SaveChangesAsync();
        }
        public async Task AddPerson(Person person)
        {
            var dt = DateTime.Now;
            if (person.Birthay == default)
                person.Birthay = new(dt.Year, dt.Month, dt.Day);

            await dataBase.Persons.AddAsync(person);
            await dataBase.SaveChangesAsync();
        }
        public async Task DeleteMark(Marks mark)
        {
            await Task.Delay(100);
            dataBase.Marks.Remove(mark);
            await dataBase.SaveChangesAsync();
        }
        public async Task DeletePerson(Person person)
        {
            await Task.Delay(100);
            dataBase.Persons.Remove(person);
            await dataBase.SaveChangesAsync();
        }
        public async Task UpdateMark(Marks mark)
        {
            await Task.Delay(200);
            var m = await SearchMarkById(mark.Id);
            dataBase.Marks.Update(m);
            await dataBase.SaveChangesAsync();
        }
        public async Task UpdatePerson(Person person)
        {
            await Task.Delay(200);
            var p = await SearchPersonById(person.Id);

            foreach (var m in p.Marks)
                await UpdateMark(m);

            dataBase.Persons.Update(p);
            await dataBase.SaveChangesAsync();
        }
        public async Task<Marks> SearchMarkById(int id)
        {
            await Task.Delay(400);
            var mk = dataBase.Marks.FirstOrDefault(s => s.Id == id);
            bool isNull = mk == null;
            return isNull ? new Marks() : mk;
        }
        public async Task<Person> SearchPersonById(int id)
        {
            await Task.Delay(400);
            var pers = dataBase.Persons.FirstOrDefault(s => s.Id == id);
            bool isNull = pers == null;
            return isNull ? new Person() : pers;
        }
        public async Task<List<Marks>> GetAllMarks()
        {
            await Task.Delay(100);
            return new List<Marks>(dataBase.Marks);
        }
        public async Task<List<Person>> GetAllPersons()
        {
            await Task.Delay(100);
            return new List<Person>(dataBase.Persons);
        }

        //Login Block
        public async Task Registraition(string login, string password)
        {
            dataBase.Users.Add(new User() { Name = login, Password = password });
            await dataBase.SaveChangesAsync();
        }
        public async Task<bool> Authorization(string login, string password) => await dataBase.Users.FirstOrDefaultAsync(s => s.Name == login && s.Password == password) != null;
    }
}
