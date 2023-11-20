using MediSynthFinals.Data;
using MediSynthFinals.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace MediSynthFinals.Controllers
{
    public class DoctorController : Controller
    {
        // Db Context
        private readonly MediDbContext _dbContext;

        public DoctorController(MediDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IActionResult Index()
        {
            return View(_dbContext.UserCredentials.Where(x => x.userRole == "Staff"));
        }

        public IActionResult Details(int id) {
            UserCredentials doc = _dbContext.UserCredentials.FirstOrDefault(x => x.userId == id);
            
            if (doc != null)
            {
                dynamic model = new ExpandoObject();
                model.UserCredentials = _dbContext.UserCredentials;
                model.DoctorSchedule = _dbContext.DoctorSchedules;
                {
                    if (model != null)
                    {
                        ViewBag.DoctorId = id;
                        return View(model);
                    }
                }
            }

            //return View(_dbContext.DoctorCredentials);
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //Search for the doctor whose id matches the given id
            UserCredentials? doc = _dbContext.UserCredentials.FirstOrDefault(UserCredentials => UserCredentials.userId == Id);

            if (doc != null)
            {
                return View(doc);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(UserCredentials ChangeDocCredentials)
        {
            UserCredentials? doctor = _dbContext.UserCredentials.FirstOrDefault(UserCredentials => UserCredentials.userId == ChangeDocCredentials.userId);
            if (doctor != null)
            {
                doctor.userId = ChangeDocCredentials.userId;
                doctor.username = ChangeDocCredentials.username;
                doctor.password = ChangeDocCredentials.password;
                doctor.fName = ChangeDocCredentials.fName;
                doctor.lName = ChangeDocCredentials.lName;
                doctor.email = ChangeDocCredentials.email;
                doctor.contactNum = ChangeDocCredentials.contactNum;
                doctor.department = ChangeDocCredentials.department;
                doctor.userRole = ChangeDocCredentials.userRole;

            }

            return View("Index", _dbContext.UserCredentials);
        }

        [HttpGet]
        public IActionResult AddSchedule(int Id)
        {
            //Search for the doctor whose id matches the given id
            UserSchedule? docsched = _dbContext.userSchedules.FirstOrDefault(UserSchedule => UserSchedule.scheduleId == Id);

            if (docsched != null)
            {
                return View(docsched);
            }
            return NotFound();

        }

        [HttpPost]
        public IActionResult Addsche(UserSchedule Changesched)
        {
            UserSchedule? changdocsched = _dbContext.userSchedules.FirstOrDefault(UserSchedule => UserSchedule.scheduleId == Changesched.scheduleId);
            if (Changesched != null)
            {
                Changesched.scheduleId = Changesched.scheduleId;
                Changesched.scheduleInfo = Changesched.scheduleInfo;
                Changesched.scheduleDate = Changesched.scheduleDate;

            }

            return View("Index", _dbContext.userSchedules);
        }

    }


}
