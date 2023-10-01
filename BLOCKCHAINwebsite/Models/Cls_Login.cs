using EmployeeTracking.Models.App_Code;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;


namespace BLOCKCHAINwebsite.Models
{
    public class Cls_Login : DataEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }

        public DataTable ValidateUserAccount(string userid, string password)
        {
            return ExecuteDataSetFN("fn_validate_masteruseraccount", userid, password).Tables[0];
        }
    }
}
