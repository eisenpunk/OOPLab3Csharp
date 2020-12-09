using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3Csharp
{
    class Edition
    {
        private string edname;
        private DateTime edtime;
        int circulation;

        public Edition(string EdName, DateTime EdTime, int Circulation)
        {
            edname = EdName;
            edtime = EdTime;
            circulation = Circulation;
        }
        public Edition()
        {
            edname = "Default Edition Name";
            edtime = new DateTime(1111, 1, 11);
            circulation = 9238;
        }

        public string EdName { get; set; }
        public DateTime EdTime { get; set; }
        public int Circulation
        {
            get { return circulation; }
            set
            {
                try
                {
                    circulation = value;
                    if (circulation < 0) throw new ArgumentException();
                }
                catch (ArgumentException) { Console.WriteLine("Circulation cannot be < 0!"); }

            }
        }

        public object DeepCopy()
        {
            Edition other = (Edition)MemberwiseClone();
            other.EdName = String.Copy(EdName);
            other.EdTime = EdTime;
            other.Circulation = Circulation;
            return other;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Edition ed = (Edition)obj;    //preobr ot obj k person
            if (this.EdName == ed.EdName && this.EdTime == ed.EdTime && this.Circulation == ed.Circulation)
            { return true; }
            else { return false; }
        }
        public override int GetHashCode()
        {
            return string.Format("{0}_{1}_{2}", EdName, EdTime, Circulation).GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("{0}, from {1}, circulation {2} ", EdName, EdTime.ToShortDateString(), Circulation);
        }

    }
}
