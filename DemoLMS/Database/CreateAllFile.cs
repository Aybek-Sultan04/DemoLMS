using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLMS.Database
{
    public class CreateAllFile
    {
        static CreateAllFile()
        {
            Create();
        }
        private static void Create()
        {
            using (FileStream stream = new FileStream("Teachers.txt", FileMode.OpenOrCreate)) { stream.Close(); }
            using (FileStream stream = new FileStream("Students.txt", FileMode.OpenOrCreate)) { stream.Close(); }
        }
    }
}
