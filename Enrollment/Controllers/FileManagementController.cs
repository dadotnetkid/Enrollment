using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using Helpers;
using Microsoft.AspNet.Identity.Owin;
using Models;
using Models.Repository;
using Models.Startups;

namespace Enrollment.Controllers
{
    [RoutePrefix("file-management")]
    public class FileManagementController : Controller
    {
        public ApplicationUserManager UserManager =>
            HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();



        private UnitOfWork unitOfWork = new UnitOfWork();


        [OnUserAuthorization("Semesters")]
        public ActionResult Semesters()
        {
            return PartialView();
        }
        [OnUserAuthorization("Courses")]
        public ActionResult Courses()
        {
            return PartialView();
        }
        [OnUserAuthorization("Subjects")]
        public ActionResult Subjects()
        {
            return PartialView();
        }
        [OnUserAuthorization("SchoolYears")]
        public ActionResult SchoolYears()
        {
            return PartialView();
        }

        public ActionResult AvailableCourses()
        {
            return View();
        }
        public ActionResult Students()
        {
            return View();
        }


        public ActionResult StudentTabPartials()
        {
            return PartialView();
        }
        public ActionResult StudentProfileTabPartials(int? courseId, string studentId)
        {
            ViewBag.CourseId = courseId;
            ViewBag.StudentId = studentId;

            return PartialView();
        }

        public ActionResult AddEditStudentPartial(string studentId)
        {
            var model = unitOfWork.UserDetailsRepo.Find(m => m.Id == studentId);
            return PartialView(model);
        }
        #region school year

        public ActionResult AddEditSchoolYearPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? schoolYearId)
        {
            var model = unitOfWork.SchoolYearsRepo.Find(m => m.Id == schoolYearId);
            return PartialView(model);
        }

        [ValidateInput(false)]
        public ActionResult SchoolYearsGridViewPartial()
        {
            var model = unitOfWork.SchoolYearsRepo.Get();
            return PartialView("_SchoolYearsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add School Years")]
        public ActionResult SchoolYearsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.SchoolYears item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.SchoolYearsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SchoolYearsRepo.Get();
            return PartialView("_SchoolYearsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit School Years")]
        public ActionResult SchoolYearsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.SchoolYears item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.SchoolYearsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SchoolYearsRepo.Get();
            return PartialView("_SchoolYearsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete School Years")]
        public ActionResult SchoolYearsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.SchoolYearsRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.SchoolYearsRepo.Get();
            return PartialView("_SchoolYearsGridViewPartial", model);
        }



        #endregion
        #region subject

        [ValidateInput(false)]
        public ActionResult SubjectsGridViewPartial()
        {
            var model = unitOfWork.SubjectsRepo.Get();
            return PartialView("_SubjectsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Subjects")]
        public ActionResult SubjectsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Subjects item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.SubjectsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SubjectsRepo.Get();
            return PartialView("_SubjectsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Subjects")]
        public ActionResult SubjectsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Subjects item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.SubjectsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SubjectsRepo.Get();
            return PartialView("_SubjectsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Subjects")]
        public ActionResult SubjectsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.SubjectsRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.SubjectsRepo.Get();
            return PartialView("_SubjectsGridViewPartial", model);
        }



        #endregion
        #region course
        [ValidateInput(false)]
        public ActionResult CoursesGridViewPartial()
        {
            var model = unitOfWork.CoursesRepo.Get();
            return PartialView("_CoursesGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Courses")]
        public ActionResult CoursesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Courses item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.CoursesRepo.Insert(item);
                    unitOfWork.Save();
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.CoursesRepo.Get();
            return PartialView("_CoursesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Courses")]
        public ActionResult CoursesGridViewPartialUpdate(Models.Courses item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.CoursesRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.CoursesRepo.Get();
            return PartialView("_CoursesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Courses")]
        public ActionResult CoursesGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.CoursesRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.CoursesRepo.Get();
            return PartialView("_CoursesGridViewPartial", model);
        }


        #endregion
        #region Students
        [ValidateInput(false)]
        public ActionResult StudentsGridViewPartial(int? courseId)
        {
            var model = unitOfWork.UserDetailsRepo.Fetch(m=>m.Users.UserRoles.Any(x=>x.Name=="Student"));
            if (courseId != null)
            {
                model = model.Where(m =>
                    m.Enrollments.Any(x => x.AvailableCourses.CourseId == courseId));
            }
            ViewBag.CourseId = courseId;
            return PartialView("_StudentsGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> StudentsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.UserDetails item, [ModelBinder(typeof(DevExpressEditorsBinder))]  int? courseId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    var user = new Models.Users()
                    {
                        Email = item.Users.Email,
                        UserName = item.Users.Email?.Split('@')[0],
                        UserDetails = new Models.UserDetails()
                        {
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName
                        }
                    };
  
                    await UserManager.CreateAsync(user, item.Users.Password);
                    var result = await UserManager.AddToRoleAsync(user.Id, "Student");
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.UserDetailsRepo.Fetch(m => m.Users.UserRoles.Any(x => x.Name == "Student"));
            if (courseId != null)
            {
                model = model.Where(m =>
                    m.Enrollments.Any(x => x.AvailableCourses.CourseId == courseId));
            }
            ViewBag.CourseId = courseId;
            return PartialView("_StudentsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> StudentsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.UserDetails item, [ModelBinder(typeof(DevExpressEditorsBinder))] int? courseId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model



                    var user = unitOfWork.UsersRepo.Find(m => m.Id == item.Id, includeProperties: "UserDetails,UserRoles");
                    user.Email = item.Users.Email;
                    user.UserName = item.Users.Email?.Split('@')[0];
                    user.UserDetails.FirstName = item.FirstName;
                    user.UserDetails.MiddleName = item.MiddleName;
                    user.UserDetails.LastName = item.LastName;
                    if (item.Users.Password != null)
                        await UserManager.ChangePasswordAsync(user, item.Users.Password);
                    user.UserRoles.Clear();
                    user.UserRoles.Add(unitOfWork.UserRolesRepo.Find(m => m.Name == "Student") ?? new UserRoles()
                    {
                        Name = "Student",
                        Id = Guid.NewGuid().ToString(),
                        Description = "Student"
                    });
                    unitOfWork.Save();

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.UserDetailsRepo.Fetch(m => m.Users.UserRoles.Any(x => x.Name == "Student"));
            if (courseId != null)
            {
                model = model.Where(m =>
                    m.Enrollments.Any(x => x.AvailableCourses.CourseId == courseId));
            }
            ViewBag.CourseId = courseId;
            return PartialView("_StudentsGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult StudentsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]string Id, [ModelBinder(typeof(DevExpressEditorsBinder))] int? courseId)
        {

            if (!string.IsNullOrEmpty(Id))
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    //       unitOfWork.StudentsRepo.Delete(m => m.Id == Id);
                    unitOfWork.UsersRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.UserDetailsRepo.Fetch(m => m.Users.UserRoles.Any(x => x.Name == "Student"));
            if (courseId != null)
            {
                model = model.Where(m =>
                    m.Enrollments.Any(x => x.AvailableCourses.CourseId == courseId));
            }
            ViewBag.CourseId = courseId;
            return PartialView("_StudentsGridViewPartial", model.ToList());
        }


        #endregion

        #region Enrollment

        public ActionResult CboAvailableCourse(int? schoolYearId)
        {
            var model = unitOfWork.AvailableCoursesRepo.Get(m => m.SchoolYearId == schoolYearId);
            ViewBag.SchoolYearId = schoolYearId;

            return PartialView(model);
        }
        public ActionResult AddEditEnrollmentPartial(int? enrollmentId)
        {
            var model = unitOfWork.EnrollmentsRepo.Find(m => m.Id == enrollmentId);
            ViewBag.SchoolYearId = model?.AvailableCourses?.SchoolYears.SchoolYearAndSemester;
            return PartialView(model);
        }

        [ValidateInput(false)]
        public ActionResult EnrollmentsGridViewPartial(string studentId)
        {
            var model = unitOfWork.EnrollmentsRepo.Get(m => m.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_EnrollmentsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult EnrollmentsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Enrollments item, [ModelBinder(typeof(DevExpressEditorsBinder))] string studentId)
        {
            // var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.EnrollmentsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.EnrollmentsRepo.Get(m => m.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_EnrollmentsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EnrollmentsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Enrollments item, [ModelBinder(typeof(DevExpressEditorsBinder))] string studentId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.EnrollmentsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.EnrollmentsRepo.Get(m => m.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_EnrollmentsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EnrollmentsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id, [ModelBinder(typeof(DevExpressEditorsBinder))] string studentId)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.EnrollmentsRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.EnrollmentsRepo.Get(m => m.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_EnrollmentsGridViewPartial", model);
        }


        #endregion

        #region available course

        public ActionResult AddEditAvailableCoursePartial([ModelBinder(typeof(DevExpressEditorsBinder))] int? availableCourseId)
        {
            var model = unitOfWork.AvailableCoursesRepo.Find(m => m.Id == availableCourseId);
            return PartialView(model);
        }
        [ValidateInput(false)]
        public ActionResult AvailableCourseGridViewPartial()
        {
            var model = unitOfWork.AvailableCoursesRepo.Get();
            return PartialView("_AvailableCourseGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Available Course")]
        public ActionResult AvailableCourseGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableCourses item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.AvailableCoursesRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableCoursesRepo.Get();
            return PartialView("_AvailableCourseGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Available Course")]
        public ActionResult AvailableCourseGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableCourses item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.AvailableCoursesRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableCoursesRepo.Get();
            return PartialView("_AvailableCourseGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Available Course")]
        public ActionResult AvailableCourseGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.AvailableCoursesRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.AvailableCoursesRepo.Get();
            return PartialView("_AvailableCourseGridViewPartial", model);
        }


        #endregion

        #region available subject

        public ActionResult AddEditAvailableSubjectsPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? availableSubjectId)
        {
            var model = unitOfWork.AvailableSubjectsRepo.Find(m => m.Id == availableSubjectId);
            return PartialView(model);
        }


        public ActionResult AvailableSubjects()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult AvailableSubjectsGridView()
        {
            var model = unitOfWork.AvailableSubjectsRepo.Get(includeProperties: "AvailableCourses,Subjects");
            return PartialView("_AvailableSubjectsGridView", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Available Subject")]
        public ActionResult AvailableSubjectsGridViewAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableSubjects item)
        {
            if (unitOfWork.AvailableSubjectsRepo
                .Fetch(m => m.SubjectId == item.SubjectId && m.AvailableCourseId == item.AvailableCourseId).Any())
                ModelState.AddModelError("SubjectId", "Already Added Subject to this course and school year");
            // var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model


                    var schedulesHelper = new SchedulesHelper();
                    schedulesHelper.GenerateSchedule(item);
                    unitOfWork.AvailableSubjectsRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableSubjectsRepo.Get(includeProperties: "AvailableCourses,Subjects");
            return PartialView("_AvailableSubjectsGridView", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Update Available Subject")]
        public ActionResult AvailableSubjectsGridViewUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableSubjects item)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var schedulesHelper = new SchedulesHelper();
                    schedulesHelper.UpdateSchedule(item);
                    // Insert here a code to update the item in your model
                    unitOfWork.AvailableSubjectsRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableSubjectsRepo.Get(includeProperties: "AvailableCourses,Subjects");
            return PartialView("_AvailableSubjectsGridView", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Available Subject")]
        public ActionResult AvailableSubjectsGridViewDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.AvailableSubjectsRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.AvailableSubjectsRepo.Get(includeProperties: "AvailableCourses,Subjects");
            return PartialView("_AvailableSubjectsGridView", model);
        }

        #endregion

        #region enrolled subject

        public ActionResult CboEnrolledSubjectAvailableSubjectPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? enrollmentId)
        {
            var enrollment = unitOfWork.EnrollmentsRepo.Find(m => m.Id == enrollmentId);

            var res = new UnitOfWork().AvailableSubjectsRepo.Fetch();
            if (enrollment != null)
                res = res.Where(m => m.AvailableCourseId == enrollment.AvailableCourseId);
            return PartialView(res.ToList());
        }
        public ActionResult AddEditEnrolledSubjectPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? enrolledSubjectId)
        {
            var model = unitOfWork.EnrolledSubjectRepo.Find(m => m.Id == enrolledSubjectId);
            return PartialView(model);
        }

        [ValidateInput(false)]
        public ActionResult EnrolledSubjectsGridViewPartial([ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            ViewBag.StudentId = studentId;
            var model = unitOfWork.EnrolledSubjectRepo.Get(m => m.Enrollments.StudentId == studentId, includeProperties: "AvailableSubjects,AvailableSubjects.Subjects");
            return PartialView("_EnrolledSubjectsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Enrolled Subject")]
        public ActionResult EnrolledSubjectsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.EnrolledSubject item, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            ViewBag.StudentId = studentId;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    item.Grades.Add(new Models.Grades());
                    unitOfWork.EnrolledSubjectRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.EnrolledSubjectRepo.Get(m => m.Enrollments.StudentId == studentId, includeProperties: "AvailableSubjects,AvailableSubjects.Subjects");
            return PartialView("_EnrolledSubjectsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Enrolled Subject")]
        public ActionResult EnrolledSubjectsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.EnrolledSubject item, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            ViewBag.StudentId = studentId;
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model

                    unitOfWork.EnrolledSubjectRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.EnrolledSubjectRepo.Get(m => m.Enrollments.StudentId == studentId, includeProperties: "AvailableSubjects,AvailableSubjects.Subjects");
            return PartialView("_EnrolledSubjectsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Enrolled Subject")]
        public ActionResult EnrolledSubjectsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            ViewBag.StudentId = studentId;
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.EnrolledSubjectRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.EnrolledSubjectRepo.Get(m => m.Enrollments.StudentId == studentId, includeProperties: "AvailableSubjects,AvailableSubjects.Subjects");
            return PartialView("_EnrolledSubjectsGridViewPartial", model);
        }



        #endregion

        #region Grades

        [ValidateInput(false)]
        public ActionResult GradesGridViewPartial([ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            var model = unitOfWork.GradesRepo.Get(m => m.EnrolledSubject.Enrollments.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_GradesGridViewPartial", model);
        }

        public ActionResult GradesGridViewPartialBatchUpdate([ModelBinder(typeof(DevExpressEditorsBinder))]string studentId,
            [ModelBinder(typeof(DevExpressEditorsBinder))]    MVCxGridViewBatchUpdateValues<Grades, int> updateValues)
        {
            foreach (var i in updateValues.Update)
            {
                var grades = unitOfWork.GradesRepo.Find(m => m.Id == i.Id);
                grades.Prelim = i.Prelim;
                grades.MidTerm = i.MidTerm;
                grades.FinalTerm = i.FinalTerm;
                unitOfWork.Save();
            }
            var model = unitOfWork.GradesRepo.Get(m => m.EnrolledSubject.Enrollments.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_GradesGridViewPartial", model);
        }


        [HttpPost, ValidateInput(false)]
        public ActionResult GradesGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Grades item, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.GradesRepo.Get(m => m.EnrolledSubject.Enrollments.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_GradesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GradesGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Grades item, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.GradesRepo.Get(m => m.EnrolledSubject.Enrollments.StudentId == studentId);
            ViewBag.StudentId = studentId;
            return PartialView("_GradesGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GradesGridViewPartialDelete(System.Int32 Id, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            var model = new object[0];
            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GradesGridViewPartial", model);
        }



        #endregion

        #region semester

        [ValidateInput(false)]
        public ActionResult SemesterGridViewPartial()
        {
            var model = unitOfWork.SemestersRepo.Get();
            return PartialView("_SemesterGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Semester")]
        public ActionResult SemesterGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Semesters item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.SemestersRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SemestersRepo.Get();
            return PartialView("_SemesterGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Semester")]
        public ActionResult SemesterGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Semesters item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.SemestersRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.SemestersRepo.Get();
            return PartialView("_SemesterGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Semester")]
        public ActionResult SemesterGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.SemestersRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.SemestersRepo.Get();
            return PartialView("_SemesterGridViewPartial", model);
        }


        #endregion

        #region billing

        public ActionResult CboEnrollmentPartials([ModelBinder(typeof(DevExpressEditorsBinder))]int? billingId, [ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            var model = unitOfWork.EnrollmentsRepo.Get(m => m.StudentId == studentId);
            ViewBag.Students = model;
            return PartialView(unitOfWork.BillingsRepo.Find(m => m.Id == billingId));
        }
        public ActionResult AddEditBillingPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? billingId)
        {
            var model = unitOfWork.BillingsRepo.Find(m => m.Id == billingId);
            return PartialView(model);
        }



        [OnUserAuthorization("billings")]
        public ActionResult Billings()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult BillingsGridViewPartial([ModelBinder(typeof(DevExpressEditorsBinder))]string studentId)
        {
            var model = unitOfWork.BillingsRepo.Get(includeProperties: "Enrollments");
            return PartialView("_BillingsGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Billing")]
        public ActionResult BillingsGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Billings item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.BillingsRepo.Insert(item);
                    unitOfWork.Save();

                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.BillingsRepo.Get(includeProperties: "Enrollments");
            return PartialView("_BillingsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Billing")]
        public ActionResult BillingsGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Billings item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.BillingsRepo.Get(includeProperties: "Enrollments");
            return PartialView("_BillingsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Billing")]
        public ActionResult BillingsGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))] System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.BillingsRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.BillingsRepo.Get(includeProperties: "Enrollments");
            return PartialView("_BillingsGridViewPartial", model);
        }
        #endregion



        #region miscellaneous
        [OnUserAuthorization("Miscellaneous")]
        public ActionResult Miscellaneous()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult MiscellaneousGridViewPartial()
        {
            var model = unitOfWork.MiscellaneousRepo.Get();
            return PartialView("_MiscellaneousGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult MiscellaneousGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Miscellaneous item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.MiscellaneousRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.MiscellaneousRepo.Get();
            return PartialView("_MiscellaneousGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MiscellaneousGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.Miscellaneous item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.MiscellaneousRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.MiscellaneousRepo.Get();
            return PartialView("_MiscellaneousGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult MiscellaneousGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.MiscellaneousRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.MiscellaneousRepo.Get();
            return PartialView("_MiscellaneousGridViewPartial", model);
        }

        #endregion

        #region available miscellaneous

        public ActionResult AddEditAvailableMiscellaneous([ModelBinder(typeof(DevExpressEditorsBinder))]int? availableMiscellaneousId)
        {
            var model = unitOfWork.AvailableMiscellaneousRepo.Find(m => m.Id == availableMiscellaneousId);
            return PartialView(model);
        }


        public ActionResult AvailableMiscellaneous()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult AvailableMiscellaneousGridViewPartial()
        {
            var model = unitOfWork.AvailableMiscellaneousRepo.Get();
            return PartialView("_AvailableMiscellaneousGridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AvailableMiscellaneousGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableMiscellaneous item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                    unitOfWork.AvailableMiscellaneousRepo.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableMiscellaneousRepo.Get(includeProperties: "AvailableCourses,Miscellaneous");
            return PartialView("_AvailableMiscellaneousGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AvailableMiscellaneousGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.AvailableMiscellaneous item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    unitOfWork.AvailableMiscellaneousRepo.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.AvailableMiscellaneousRepo.Get();
            return PartialView("_AvailableMiscellaneousGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AvailableMiscellaneousGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.Int32 Id)
        {

            if (Id >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.AvailableMiscellaneousRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.AvailableMiscellaneousRepo.Get();
            return PartialView("_AvailableMiscellaneousGridViewPartial", model);
        }
        #endregion

        #region Teachers

        [OnUserAuthorization("Teachers")]
        public ActionResult Teachers()
        {
            return View();
        }

        public ActionResult AddEditTeacherPartial(string userDetailId)
        {
            var model = unitOfWork.UserDetailsRepo.Find(m => m.Id == userDetailId);

            return PartialView(model);
        }
        [ValidateInput(false)]
        public ActionResult TeachersGridViewPartial()
        {
            var model = unitOfWork.UserDetailsRepo.Get(m => m.Users.UserRoles.Any(x => x.Name != "Student"));
            return PartialView("_TeachersGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Add Teachers")]
        public async Task<ActionResult> TeachersGridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Models.UserDetails item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = new Models.Users()
                    {
                        Email = item.Users.Email,
                        UserName = item.Users.Email?.Split('@')[0],
                        UserDetails = new Models.UserDetails()
                        {
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName
                        },

                    };
                    //foreach (var i in item.UserRoles)
                    //{
                    //    user.UserRoles.Add(unitOfWork.UserRolesRepo.Find(m => m.Id == i));
                    //}
                    var res = await UserManager.CreateAsync(user, item.Users.Password);
                    var result = await UserManager.AddToRolesAsync(user.Id, item.UserRoles.ToArray());
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.UserDetailsRepo.Get(m => m.Users.UserRoles.Any(x => x.Name != "Student"));
            return PartialView("_TeachersGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Edit Teachers")]
        public async Task<ActionResult> TeachersGridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Models.UserDetails item)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                    var user = unitOfWork.UsersRepo.Find(m => m.Id == item.Id, includeProperties: "UserRoles,UserDetails");
                    user.Email = item.Users.Email;
                    user.UserName = item.Users.Email?.Split('@')[0];
                    user.UserDetails.FirstName = item.FirstName;
                    user.UserDetails.MiddleName = item.MiddleName;
                    user.UserDetails.LastName = item.LastName;
                    if (item.Users.Password != null)
                        await UserManager.ChangePasswordAsync(user, item.Users.Password);
                    user.UserRoles.Clear();
                   
                    unitOfWork.Save();
                    var result = await UserManager.AddToRolesAsync(user.Id, item.UserRoles.ToArray());
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            var model = unitOfWork.UserDetailsRepo.Get(m => m.Users.UserRoles.Any(x => x.Name != "Student"));
            return PartialView("_TeachersGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        [OnUserAuthorization("Delete Teachers")]
        public ActionResult TeachersGridViewPartialDelete([ModelBinder(typeof(DevExpressEditorsBinder))]System.String Id)
        {

            if (Id != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                    unitOfWork.UsersRepo.Delete(m => m.Id == Id);
                    unitOfWork.Save();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            var model = unitOfWork.UserDetailsRepo.Get(m => m.Users.UserRoles.Any(x => x.Name != "Student"));
            return PartialView("_TeachersGridViewPartial", model);
        }
        #endregion




    }
}






























/* user.Employees.FirstName = item.Employees.FirstName;
user.Employees.MiddleName = item.Employees.MiddleName;
user.Employees.LastName = item.Employees.LastName;
user.Employees.Gender = item.Employees.Gender;
user.Employees.CivilStatus = item.Employees.CivilStatus;
user.Employees.BirthDate = item.Employees.BirthDate;
user.Employees.AddressLine1 = item.Employees.AddressLine1;
user.Employees.Religion = item.Employees.Religion;
user.Employees.Cellular = item.Employees.Cellular;
user.Employees.Citizenship = item.Employees.Citizenship;
user.Employees.Picture = item.Employees.Picture;
user.Employees.Users.Email = item.Employees.Users.Email;*/
// Insert here a code to update the item in your model
/*   
   employees.FirstName = item.FirstName;
   employees.MiddleName = item.MiddleName;
   employees.LastName = item.LastName;
   employees.Gender = item.Gender;
   employees.CivilStatus = item.CivilStatus;
   employees.BirthDate = item.BirthDate;
   employees.AddressLine1 = item.AddressLine1;
   employees.Religion = item.Religion;
   employees.Cellular = item.Cellular;
   employees.Citizenship = item.Citizenship;
   employees.Picture = item.Picture;
   employees.Users.Email = item.Users.Email;
   employees.Users.UserName = item.Users.Email?.Split('@')[0];
   unitOfWork.Save();*/
