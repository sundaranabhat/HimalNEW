﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModel
{
   public class PersonnalViewModel
    {
        public int ID { get; set; }
        public int SSN { get; set; }
        public int DODID { get; set; }
        public string LOGINID { get; set; }
        public string CONTRACTID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string SUFFIX { get; set; }
        public Nullable<System.DateTime> DATEOFBIRTH { get; set; }
        public string PLACEOFBIRTH { get; set; }
        public string GENDER { get; set; }
        public string GRADE { get; set; }
        public string RATE { get; set; }
        public Nullable<int> UIC { get; set; }
        public Nullable<int> UNITID { get; set; }
        public string CLASS { get; set; }
        public string CATAGOREY { get; set; }
        public string EMAIL { get; set; }
        public Nullable<System.DateTime> REPROTEDDATE { get; set; }
        public Nullable<int> EVENTID { get; set; }
        public string ATTACHED { get; set; }
        public Nullable<int> COMMANDID { get; set; }
    }

    public class PersonnalListModel
    {
        public PersonnalListModel()
        {
            this.PersonnalList = new List<PersonnalViewModel>();
            this.vPersonnalList = new List<vPersonnalViewModel>();
        }
        public List<PersonnalViewModel> PersonnalList { get; set; }
        public List<vPersonnalViewModel> vPersonnalList { get; set; }
    }
}
