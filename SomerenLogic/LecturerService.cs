using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class LecturerService
    {
        LecturerDao lecturerdb;

        public LecturerService()
        {
            lecturerdb = new LecturerDao();
        }

        public List<Lecturer> GetLecturers()
        {
            List<Lecturer> lecturers = lecturerdb.GetAllLecturers();
            return lecturers;
        }
    }
}
