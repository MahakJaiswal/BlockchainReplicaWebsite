using BLOCKCHAINwebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace BLOCKCHAINwebsite.Controllers
{
    public class LoginFormController : Controller
    {
        public ActionResult LoginForm()
        {
            Cls_Login user = new Cls_Login();
            return View(user);
        }

        [HttpPost]
        public ActionResult LoginForm(Cls_Login person)
        {
            try
            {
                Cls_Login _Login = new Cls_Login();
                //var UserLower = person.UserName.ToLower();
                var validate = _Login.ValidateUserAccount(person.UserName, person.Password);
                //if (person.UserName == "Admin" && person.Password == "123")

                if (validate.Rows.Count > 0)
                {
                    //HttpContext.Session.SetString("sysaccountuuid", validate.Rows[0]["sysaccountuuid"].ToString());
                    //HttpContext.Session.SetString("FirstName", validate.Rows[0]["FirstName"].ToString());
                   // HttpContext.Session.SetString("FullName", validate.Rows[0]["FullName"].ToString());
                   // HttpContext.Session.SetString("accounttype", validate.Rows[0]["accounttype"].ToString());
                    //HttpContext.Session.SetString("LocationName", validate.Rows[0]["LocationName"].ToString());
                    //HttpContext.Session.SetString("CompanyLogo", validate.Rows[0]["CompanyLogo"].ToString());

                    return RedirectToAction("Index", "Master");
                }
                else
                {
                    ViewBag.Message = "Invalid username or password!! Please try again.";
                    return View(person);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "An Error Occurred!!";
                return View(person);
            }
        }
        public ActionResult Logout()
        {
            //HttpContext.Session.SetString("UserID", null);
            //HttpContext.Session.Clear();
            Cls_Login _obj = new Cls_Login();
            return View("LoginForm", _obj);
        }

    }
}
