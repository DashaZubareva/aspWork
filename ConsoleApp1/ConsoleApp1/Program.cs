using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Role admin = new Role();
            admin.Name = "vasia";
            admin.Permis.SetAllTrue();

            Role guest=new Role();
            guest.Permis.Read = true;

            Role user = new Role();
            user.Permis.Read = true;
            user.Permis.Update = true;

            Console.WriteLine(admin.ToString());
            Console.WriteLine(guest);
            Console.ReadKey();
        }
    }
}
