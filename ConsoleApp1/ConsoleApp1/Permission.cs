using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Permission
    {
        public bool Create { get; set; } = false;
        public bool Delete { get; set; } = false;
        public bool Edit { get; set; } = false;
        public bool Update { get; set; } = false;
        public bool Read { get; set; } = false;
        public bool Archive { get; set; } = false;

        public void SetAllTrue()
        {
            Create = true;
            Delete = true;
            Edit = true;
            Update = true;
            Read = true;
            Archive = true;
        }

        public override string ToString()
        {
            return "\nCreate = \t" + Create.ToString() +
                    "\nDelete = \t" + Delete.ToString() +
                    "\nEdit = \t\t" + Edit.ToString() + 
                    "\nUpdate = \t" + Update.ToString() + 
                    "\nRead = \t\t" + Read.ToString() + 
                    "\nArchive = t\t" + Archive.ToString();
        }
    }
}
