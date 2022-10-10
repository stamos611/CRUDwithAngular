using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDwithAngular.Models;

namespace CRUDwithAngular.Controllers
{
    public class HomeController : Controller
    {
        db_Accerss_Layer.db dbLayer = new db_Accerss_Layer.db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show_Data()
        {
            return View();
        }
        public ActionResult Update_Data(int id)
        {
            return View();
        }
        public JsonResult Add_record(register rs)
        {
            string res = string.Empty;
            try
            {                
                dbLayer.Add_record(rs);
                res = "Inserted";
            }
            catch (Exception)
            {
                res = "Failed";                
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_Data()
        {
            DataSet ds = dbLayer.get_record();
            List<register> listrs = new List<register>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                listrs.Add(new register
                {
                    Sr_no = Convert.ToInt32(dr["Sr_no"]),

                    Email = dr["Email"].ToString(),

                    Password = dr["Password"].ToString(),

                    Name = dr["Name"].ToString(),

                    Address = dr["Address"].ToString(),

                    City = dr["City"].ToString()
                });
            }
            return Json(listrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Get_databyid(int id)

        {

            DataSet ds = dbLayer.get_recordbyid(id);

            List<register> listrs = new List<register>();

            foreach (DataRow dr in ds.Tables[0].Rows)

            {

                listrs.Add(new register

                {

                    Sr_no = Convert.ToInt32(dr["Sr_no"]),

                    Email = dr["Email"].ToString(),

                    Password = dr["Password"].ToString(),

                    Name = dr["Name"].ToString(),

                    Address = dr["Address"].ToString(),

                    City = dr["City"].ToString()

                });

            }

            return Json(listrs, JsonRequestBehavior.AllowGet);

        }

        public JsonResult update_record(register rs)

        {

            string res = string.Empty;

            try

            {

                dbLayer.update_record(rs);

                res = "Updated";

            }

            catch (Exception)

            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }

        // Delete record

        public JsonResult delete_record(int id)

        {

            string res = string.Empty;

            try

            {

                dbLayer.deletedata(id);

                res = "data deleted";

            }

            catch (Exception)

            {

                res = "failed";

            }

            return Json(res, JsonRequestBehavior.AllowGet);



        }
    }
}