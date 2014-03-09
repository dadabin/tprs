using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
  public class UserEntity
    {
      /// <summary>
      /// 用户ID
      /// </summary>
        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
      /// <summary>
      /// 角色ID
      /// </summary>
        private int roleID;

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }
      /// <summary>
      /// 管理者
      /// </summary>
        private string admin;

        public string Admin
        {
            get { return admin; }
            set { admin = value; }
        }
      /// <summary>
      /// 用户姓名
      /// </summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
      /// <summary>
      /// 用户登陆名
      /// </summary>
        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
      /// <summary>
      /// 用户密码
      /// </summary>
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
      /// <summary>
      /// 单位名称
      /// </summary>
        private string unitName;

        public string UnitName
        {
            get { return unitName; }
            set { unitName = value; }
        }
      /// <summary>
      /// 法人联系人
      /// </summary>
        private string legalRepre;

        public string LegalRepre
        {
            get { return legalRepre; }
            set { legalRepre = value; }
        }
      /// <summary>
      /// 业务联系人
      /// </summary>
        private string businessContact;

        public string BusinessContact
        {
            get { return businessContact; }
            set { businessContact = value; }
        }
      /// <summary>
      /// 电话
      /// </summary>
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
      /// <summary>
      /// 区县
      /// </summary>
        private string area;

        public string Area
        {
            get { return area; }
            set { area = value; }
        }
      /// <summary>
      /// 注册资金
      /// </summary>
        private string  registMoney;

        public string  RegistMoney
        {
            get { return registMoney; }
            set { registMoney = value; }
        }
      /// <summary>
      /// 注册地址
      /// </summary>
        private string registArea;

        public string RegistArea
        {
            get { return registArea; }
            set { registArea = value; }
        }
      /// <summary>
      /// 营业范围
      /// </summary>
        private string businessArea;

        public string BusinessArea
        {
            get { return businessArea; }
            set { businessArea = value; }
        }
      /// <summary>
      /// 邮箱
      /// </summary>
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
      /// <summary>
      /// 办公室电话
      /// </summary>
        private string officePhone;

        public string OfficePhone
        {
            get { return officePhone; }
            set { officePhone = value; }
        }
        private string operateUser;

     /// <summary>
     /// 操作人---为日志服务
     /// </summary>
        public string OperateUser
        {
            get { return operateUser; }
            set { operateUser = value; }
        }


    }
}
