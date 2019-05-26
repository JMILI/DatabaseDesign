using JMWeb04.Access;
using JMWeb04.Model.JMdataSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JMWeb04.Service
{
    public class StudentService
    {
        public static AccessData access = new AccessData();
        public static Student user = new Student();
        public Student QueryStudentService(Student student)
        {
            user = access.QueryStudentData(student);
            return user;

        }
        public void AddService(Student student)
        {
            access.AddData(student);
        }
        public Student UpdateService(Student student)
        {
            return access.UpdateData(student);
        }
        public void DeleteService(string StudentId)
        {
            access.DeleteData(StudentId);
        }
    }
}
