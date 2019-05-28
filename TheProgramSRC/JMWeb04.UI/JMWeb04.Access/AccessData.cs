using JMWeb04.Model.JMdataSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JMWeb04.Access
{
    public class AccessData
    {
        public static Student users = new Student();
        public Student QueryStudentData(Student student)
        {
            using (var dbContext = new studentofjmContext())
            {
                users = dbContext.Student.FirstOrDefault(a => a.StudentId == student.StudentId);
            }
            return users;
        }
        public void AddData(Student student)
        {
            using (var dbContext = new studentofjmContext())
            {
                dbContext.Add(student);
                dbContext.SaveChanges();
            }
        }
        public Student UpdateData(Student user)
        {
            using (var dbContext = new studentofjmContext())
            {
                users = dbContext.Student.FirstOrDefault(a => a.StudentId == user.StudentId);
                users.Name = user.Name;
                users.ClassCode = user.ClassCode;
                users.Password = user.Password;
                dbContext.SaveChanges();
            }
            //users = dbContext.Student.FirstOrDefault(a => a.StudentId == student.StudentId);
            return users;
        }
        public void DeleteData(string StudentId)
        {
            using (var dbContext = new studentofjmContext())
            {
                dbContext.Remove(dbContext.Student.FirstOrDefault(a => a.StudentId == StudentId));
                dbContext.SaveChanges();
            }
        }

        #region  添加新储户
        #endregion

        #region  查询储户信息
        #endregion

        #region  冻结储户账户
        #endregion

        #region  修改自己的密码
        #endregion

        #region  辅助函数
        #endregion

    }
}
