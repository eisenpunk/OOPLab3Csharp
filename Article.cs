using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3Csharp
{
    class Article : IRateAndCopy
    {
        public Person Person { get; set; }
        public string Title { get; set; }
        public double Rating { get; set; }

        public Article(Person person, String title, double rating)
        {
            Person = person;
            Title = title;
            Rating = rating;
        }

        public Article()
        {
            Person = new Person("Petro", "Petrenko", new DateTime(1687, 11, 22));
            Title = "Default Titile";
            Rating = 0.0;
        }

        public override string ToString()
        {
            return $"{Person}, Title: {Title}, Rating: {Rating}";
        }

        public object DeepCopy()
        {
            Article other = (Article)MemberwiseClone();
            other.Person = Person;
            other.Rating = Rating;
            other.Title = Title;
            return other;
        }
    }
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
