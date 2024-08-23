using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    [Serializable]
    public class Person
    {
        private static readonly long serialVersionUID = 1L;

        private readonly String _name;
	    private readonly String _firstname;
	    private readonly DateTime _birthDate;

        public virtual String Name { get { return _name; } }
        public String FirstName { get { return _firstname; } }
        public String BirthDate { get { return _birthDate.ToString(); } }

        public Person(String name, String firstname, DateTime birthDate)
        {
            this._name = name;
            this._firstname = firstname;
            this._birthDate = birthDate;
        }

        
        public override String ToString()
           {
            return "Person [name = " + _name + ", firstname = " + _firstname + ", birthDate =  " + BirthDate + "]";
        }
    }
}
