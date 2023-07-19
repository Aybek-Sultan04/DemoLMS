using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLMS.Manager
{
    internal class CheckUsers
    {
        public static bool CheclTeacher(string login,string password)
        {
            using (StreamReader reader = new StreamReader("Teachers.txt"))
            {
                string[] fielsd = new string[2];
                while (!reader.EndOfStream)
                {
                    fielsd =reader.ReadLine().Split(",");
                    if (fielsd[0] == login && fielsd[1]==password)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
                return false;
        }
        public static bool CheckStudents(string login,string password)
        {
            using (StreamReader reader = new StreamReader("Students.txt"))
            {
                string[] field = new string[2];
                while (!reader.EndOfStream)
                {
                    field= reader.ReadLine().Split(",");
                    if (field[0] == login && field[1]==password)
                    {
                        reader.Close();
                        return true;
                    }
                }
            }
                return false;
        }
    }
}
