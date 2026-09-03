using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADSPortEx2
{

    class VideoGame : IComparable
    {
        private string title;
        private string developer;
        private int releaseyear;
        public VideoGame()
        {
            title = "";
            developer = "";
            releaseyear = 0;
        }

        public VideoGame(string title, string developer, int releaseyear)
        {
            Title = title;
            Developer = developer;
            Releaseyear = releaseyear;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Developer
        {
            get { return developer; }
            set { developer = value; }
        }

        public int Releaseyear
        {
            get { return releaseyear;}
            set { releaseyear = value; }
        }

        public int CompareTo(object obj)
        {
            VideoGame other = (VideoGame)obj;
            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{Title} - {Developer} ({Releaseyear})";
        }

    }
}
