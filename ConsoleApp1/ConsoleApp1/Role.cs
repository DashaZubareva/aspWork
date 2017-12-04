using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Role
    {
        public string Name { get; set; }
        public Permission Permis =new Permission();

        public override string ToString()
        {
            return "Name is " + Name + 
                "\nPermis are =" + Permis;
        }
    }         
   
}
