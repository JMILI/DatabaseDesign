using JMWeb04.Model.JMdataSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JMWeb04.Access
{
    public class AdministratorAccess
    {
        #region  辅助对象
        public static Student users = new Student();
        #endregion

        #region  添加新储户
        public void AddData(Student student)
        {
            using (var dbContext = new studentofjmContext())
            {
                dbContext.Add(student);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region  查询储户信息
        public Student QueryStudentData(Student student)
        {
            using (var dbContext = new studentofjmContext())
            {
                users = dbContext.Student.FirstOrDefault(a => a.StudentId == student.StudentId);
            }
            return users;
        }
        #endregion

        #region  冻结储户账户
        public void DeleteData(string StudentId)
        {
            using (var dbContext = new studentofjmContext())
            {
                dbContext.Remove(dbContext.Student.FirstOrDefault(a => a.StudentId == StudentId));
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region  添加管理员
        //public void AddData(Student student)
        //{
        //    using (var dbContext = new studentofjmContext())
        //    {
        //        dbContext.Add(student);
        //        dbContext.SaveChanges();
        //    }
        //}
        #endregion

        #region  修改自己的密码
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
        #endregion

        #region  辅助函数
        #endregion
    }
}
