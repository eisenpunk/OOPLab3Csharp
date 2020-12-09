using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3Csharp
{
    class Person
    {
        private string name;
        private string surname;
        private DateTime birth;

        public override string ToString()
        {
            return "Person: " + Name + " " + Surname + " " + Birth;
        }
        public virtual string ToShortString()
        {
            return "Person: " + Name + " " + Surname;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Birth
        {
            get { return birth; }
            set { birth = value; }
        }


        public Person(string firstName, string lastName, DateTime bBirth)
        {
            name = firstName;
            surname = lastName;
            birth = bBirth;
        }

        public Person()
        {
            name = "SerGay";
            surname = "Surname";
            birth = new DateTime(1932, 1, 12);

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Person person = (Person)obj;    //preobr ot obj k person
            if (this.Name == person.Name && this.Surname == person.Surname && this.Birth == person.Birth)
            { return true; }
            else { return false; }
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if ((p1.Name == p2.Name) && (p1.Surname == p2.Surname) && (p1.Birth == p2.Birth))
                return true;
            return false;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            if ((p1.Name != p2.Name) || (p1.Surname != p2.Surname) || (p1.Birth != p2.Birth))
                return true;
            return false;
        }
        public object DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.Name = String.Copy(Name);
            other.Surname = String.Copy(Surname);
            other.Birth = Birth;
            return other;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
