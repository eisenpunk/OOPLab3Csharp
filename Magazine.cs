using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab3Csharp
{
    class Magazine : Edition, IRateAndCopy
    {
        Frequency Freq;
        List<Article> ArtList;
        System.Collections.ArrayList AuthList;

        public Magazine(string magname, Frequency freq, DateTime releasedate, int kolvo, Article[] artlist)
        {
            EdName = magname;
            Freq = freq;
            EdTime = releasedate;
            Circulation = kolvo;
            ArtList = new List<Article>();
        }

        public Magazine()
        {
            EdName = "Default Magazine Name";
            Freq = Frequency.Yearly;
            EdTime = new DateTime(1999, 01, 01);
            Circulation = 1337;
            ArtList = new List<Article>();
        }

        public double Rating { get { return AvgRating; } }

        public string GSMagName
        {
            get { return EdName; }
            set { EdName = value; }
        }

        public Frequency GSFreq
        {
            get { return Freq; }
            set { Freq = value; }
        }
        public DateTime GSReleaseDate
        {
            get { return EdTime; }
            set { EdTime = value; }
        }
        public int GSKolvo
        {
            get { return Circulation; }
            set { Circulation = value; }
        }
        public List<Article> GSArtList
        {
            get { return ArtList; }
            set { ArtList = value; }
        }

        public System.Collections.ArrayList GSAuthList
        {
            get { return AuthList; }
            set { AuthList = value; }
        }

        public double AvgRating
        {
            get
            {
                double sum = 0;
                if (ArtList.Count > 0)
                {
                    foreach (Article a in ArtList)
                    {
                        sum += a.Rating;
                    }
                    return sum / ArtList.Count;
                }
                else return 0;
            }
        }

        public bool this[Frequency freq]
        {
            get
            {
                return freq == Freq;
            }
        }
        public void AddArticles(params Article[] articles)
        {
            ArtList.AddRange(articles.ToList());
        }
        public void AddAuthors(params Person[] authors)
        {
            AuthList.AddRange(authors.ToList());
        }
        public override string ToString()
        {
            return String.Format("{0}, from {1}, copies {2} , Articles:\n {3}", EdName, EdTime.ToShortDateString(), Circulation, string.Join("\n\n", ArtList));
        }

        public virtual string ToShortString()
        {
            return String.Format("{0}, from {1}, copies {2} , AVG RATE: {3}", EdName, EdTime.ToShortDateString(), Circulation, AvgRating);

        }

        public new object DeepCopy()
        {
            Magazine other = (Magazine)this.MemberwiseClone();
            other.EdName = String.Copy(EdName);
            other.Freq = Freq;
            other.EdTime = EdTime;
            other.Circulation = Circulation;
            other.ArtList = ArtList;
            return other;
        }

        public IEnumerable GetRate(double rate)
        {

            foreach (Article a in ArtList)
            {
                if (a.Rating >= rate)
                    yield return a;
            }
        }
        public IEnumerable GetTitle(string titl)
        {

            foreach (Article a in ArtList)
            {
                if (a.Title.IndexOf(titl) > -1)
                    yield return a;
            }
        }
        public Edition CreateEdit
        {
            get
            {
                return new Edition(this.EdName, this.EdTime, this.Circulation);
            }
            set
            {
                this.EdName = value.EdName;
                this.EdTime = value.EdTime;
                this.Circulation = value.Circulation;
            }
        }



    }
}
