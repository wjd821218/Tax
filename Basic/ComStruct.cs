using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvoiceBill.Basic
{
    public class ComStruct
    {
        public const int selInvType = 0; //发票类型
        public const int selDr = 1;     //路线
        public const int selBillMode = 2;    //开票模式
        public const int selBuyer = 3;    //采购员
        public const int selSeller = 4;    //业务员
        public const int selCustomer = 5;    //业务员
        public const int selDept = 6;    //部门

        public static string sInfoSellerBankAccount = "中国工商银行沭阳支行营业部 1116060009000212818";
        public static string sInfoSellerAddressPhone = "江苏省沭阳县昆山路2号科技创业园 0527-83584777";


        public struct Dept
        {
            public int Deptid;
            public string DeptName;
            public int Terminated;
            public int Canceled;
            public string Note;
        }
        public struct UserInfo
        {
            public int UserId;
            public string UserName;
            public string UserCode;
            public string PassWord;
            public string PermsDept;
            public string PermsRole;
        }

        public struct ToJsonMy
        {
            public string result { get; set; }  //属性的名字，必须与json格式字符串中的"key"值一样。
            public string data { get; set; }
        }
    }
}
