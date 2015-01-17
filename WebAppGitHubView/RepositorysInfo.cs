using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppGitHubView
{
    public class RepositorysInfo
    {
        string[] firstColum = { "NAME", "FULLNAME", "DESCRIPTION", "URL", "ID", "DATE" };
        string[] secondColum = null;

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set;}
        public string Url { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string[] SecondColum
        {
            get { return secondColum; }
        }
        public string[] FirstColum
        {
            get { return firstColum; }
        }

        public RepositorysInfo(string[] secondColum)
        {
            this.secondColum = secondColum;
        }
        public RepositorysInfo(string name, string fullName, string description, string url, int id, DateTime date)
        {
            this.Name = name;
            this.FullName = fullName;
            this.Description = description;
            this.Url = url;
            this.Id = id;
            this.Date = date;
            CreateSecondColum();
        }

        void CreateSecondColum()
        {
            if (SecondColum == null)
            {
                secondColum = new string[firstColum.Length];
                secondColum[0] = Name;
                secondColum[1] = FullName;
                secondColum[2] = Description;
                secondColum[3] = Url;
                secondColum[4] = Id.ToString();
                secondColum[5] = Date.ToString();
            }
        }
    }
}

