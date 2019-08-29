using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirthdayBuddyFW.Models;

public class BuddyInfoController : Controller
{
    // GET: Home
    public ActionResult Index()
    {
        BirthDayBuddyDb1 entities = new BirthDayBuddyDb1();
        List<BuddyInfo> BuddyInfoes = entities.BuddyInfoes.ToList();

        //Add a Dummy Row.
        BuddyInfoes.Insert(0, new BuddyInfo());
        return View(BuddyInfoes);
    }

    [HttpPost]
    public JsonResult InsertBuddy(BuddyInfo BuddyInfo)
    {
        using (BirthDayBuddyDb1 entities = new BirthDayBuddyDb1())
        {
            entities.BuddyInfoes.Add(BuddyInfo);
            entities.SaveChanges();
        }

        return Json(BuddyInfo);
    }

    public ViewResult About()
    {
        return View();
    }

    //[HttpPost]
    //public ActionResult UpdateBuddy(BuddyInfo BuddyInfo)
    //{
    //    using (BirthDayBuddyDb1 entities = new BirthDayBuddyDb1())
    //    {
    //        BuddyInfo updatedBuddyInfo = (from c in entities.BuddyInfoes
    //                                      where c.ID == BuddyInfo.ID
    //                                      select c).FirstOrDefault();
    //        updatedBuddyInfo.NAME = BuddyInfo.NAME;
    //        updatedBuddyInfo.BIRTHDAY = BuddyInfo.BIRTHDAY;
    //        updatedBuddyInfo.BUDDYNAME = BuddyInfo.BUDDYNAME;
    //        entities.SaveChanges();
    //    }

    //    return new EmptyResult();
    //}

    //[HttpPost]
    //public ActionResult DeleteBuddy(int ID)
    //{
    //    using (BirthDayBuddyDb1 entities = new BirthDayBuddyDb1())
    //    {
    //        BuddyInfo buddyInfo = (from c in entities.BuddyInfoes
    //                               where c.ID == ID
    //                               select c).FirstOrDefault();
    //        entities.BuddyInfoes.Remove(buddyInfo);
    //        entities.SaveChanges();
    //    }

    //    return new EmptyResult();
    //}
}