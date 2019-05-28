using JMWeb04.Access;
using JMWeb04.Model.JMdataSql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JMWeb04.Service
{
    public class AdministratorService
    {
        #region 辅助属性
        public static AccessData access = new AccessData();//待改成管理员
        public static Student user = new Student();
        #endregion

        #region  添加新储户
        public void AddService(Student student)
        {
            access.AddData(student);
        }
        #endregion

        #region  查询储户信息
        public Student QueryStudentService(Student student)
        {
            user = access.QueryStudentData(student);
            return user;

        }
        #endregion

        #region  冻结储户账户
        public void DeleteService(string StudentId)
        {
            access.DeleteData(StudentId);
        }
        #endregion

        #region  添加管理员
        //public void AddService(Student student)
        //{
        //    access.AddData(student);
        //}
        #endregion

        #region  修改自己的密码
        public Student UpdateService(Student student)
        {
            return access.UpdateData(student);
        }
        #endregion

        #region  辅助函数
        #endregion





    }
}
