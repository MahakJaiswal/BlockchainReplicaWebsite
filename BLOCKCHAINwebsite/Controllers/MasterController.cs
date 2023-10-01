using BLOCKCHAINwebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace BLOCKCHAINwebsite.Controllers
{
    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            Cls_Master person = new Cls_Master();
            return View(person);
           
        }
        [HttpPost]
        public IActionResult Index(Cls_Master obj)
        {
            Cls_Master person = new Cls_Master();
            DataTable dt = person.PostUserDetails(obj);
            /* string username = null;
             if (dt.Rows.Count > 0)
             {
                 username = dt.Rows[0]["emailid"].ToString();
             }
             return RedirectToAction("SignupForm", new { username = person.username });*/
            return RedirectToAction("SignupForm", new { username = obj.username }); 
        }
        public IActionResult SignupForm(string username)
        {
            Cls_Master user =new Cls_Master();
            DataTable dts = new DataTable();
            dts = user.GetUserDetails(username);
            DataTable dt = user.Select_CountryDropDown();
            user.CountryDDL = BindCountry(dt);
            if (dts != null && dts.Rows.Count > 0)
            {
                foreach (DataRow dr in dts.Rows)
                {
                    user.userId = Convert.ToInt32(dr["userid"].ToString());
                    user.username = dr["emailid"].ToString();
                    user.password = dr["password"].ToString();
                    user.country = dr["country"].ToString();
                    user.confirmpassword = dr["confirmpassword"].ToString();
                   

                }
            }

            return PartialView("SignupForm", user);
        }


        [HttpPost]
        public ActionResult SignupForm(Cls_Master _objCM, string Save, string Update,string username)
        {

            if (ModelState.IsValid)
            {
                //string syssessionid = "0";
                //syssessionid = string.Join(",", _objCM.userId);

                if (!string.IsNullOrEmpty(Save))
                {
                //_objCM.lineid = 0;
                    DataTable dtSave = _objCM.CreateUserAccount(_objCM);
                    if (dtSave != null && dtSave.Rows.Count > 0)
                    {
                        if (dtSave.Rows[0][0].ToString() == "True")
                        {
                            ViewBag.Message = "Account Registered Successfully";
                            // TempData["Message"] = "Account Registered Successfully";
                        }
                        else
                        {
                            ViewBag.Message = "Account Registered Successfully";
                            ModelState.Clear();
                        }
                        ViewBag.Message = dtSave.Rows[0][0].ToString();
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "An error occurred.";
                        ModelState.Clear();

                    }
                }
            }

            DataTable dt2 = _objCM.Select_CountryDropDown();
            _objCM.CountryDDL = BindCountry(dt2);
            DataTable dts = _objCM.GetUserDetails(username);
            _objCM.userlist = BindUser(dts);


            return RedirectToAction("Index", _objCM);
            
           
        }
       
        public List<Cls_Master> BindUser(DataTable dt)
        {
            List<Cls_Master> lst = new List<Cls_Master>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {

                    lst.Add(new Cls_Master()
                    {

                        username = dr["emailid"].ToString(),
                        password = dr["password"].ToString(),
                        confirmpassword = dr["confirmpassword"].ToString(),
                        country = dr["country"].ToString(),
                        userId = Convert.ToInt32(dr["userid"].ToString()),


                    });
                }
            }
            return lst;
        }
        public List<SelectListItem> BindCountry(DataTable dt)
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    countryList.Add(new SelectListItem
                    {
                        Text = dr["text"].ToString(),
                        Value = dr["text"].ToString(),
                        Selected = true

                    });
                }
            }
            return countryList;
        }

    }
}
