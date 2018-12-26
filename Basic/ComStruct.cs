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


        public struct Dept
        {
            public int Deptid;
            public string DeptName;
            public int Terminated;
            public int Canceled;
            public string Note;
        }
    }
}
