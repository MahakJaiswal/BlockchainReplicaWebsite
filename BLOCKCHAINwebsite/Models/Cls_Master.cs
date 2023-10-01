using EmployeeTracking.Models.App_Code;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace BLOCKCHAINwebsite.Models
{
    public class Cls_Master:DataEntity
    {
        public string username { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string emailid { get; set; }
        public string country { get; set; }
        public int userId { get; set; }
        public List<Cls_Master> userlist { get; set; }

        public List<SelectListItem> CountryDDL { get; set; }
        public DataTable Select_CountryDropDown()
        {
            return ExecuteDataSetFN("Fn_Get_MasterCountryDD").Tables[0];
        }
        public DataTable PostUserDetails(Cls_Master _obj)
        {
            return ExecuteDataTableFN("fn_postmasteruserdetails", _obj.username);
        }
        public DataTable CreateUserAccount(Cls_Master _obj)
        {
            return ExecuteDataTableFN("fn_createuseraccount", _obj.username,_obj.password,_obj.country);
        }
        public DataTable GetUserDetails(string username)
        {
            return ExecuteDataSetFN("fn_getmasteruserdetails",username).Tables[0];
        }

    }
}
