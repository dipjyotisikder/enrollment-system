using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnrollMent_00.Data;
using EnrollMent_00.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using EnrollMent_00.HelpClass;

namespace EnrollMent_00.Controllers
{
    public class StudentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;


        public StudentsController(ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {

            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }





//--------< Upload_ImageFile() >--------
        [HttpPost]

        public async Task<IActionResult> Create(IFormFile file, Student student)

        {

            if (ModelState.IsValid)
            {

                if (file == null || file.Length == 0) return Content("file not selected");

                string path_Root = _appEnvironment.WebRootPath;

                string path_to_Images = path_Root + "\\Uploads\\Images\\" + file.FileName;

                using (var stream = new FileStream(path_to_Images, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                    string revUrl = Reverse.reverse(path_to_Images);
                    int count = 0;
                    int flag = 0;

                    for (int i = 0; i < revUrl.Length; i++)
                    {
                        if (revUrl[i] == '\\')
                        {
                            count++;

                        }
                        if (count == 3)
                        {
                            flag = i;
                            break;
                        }
                    }

                    string sub = revUrl.Substring(0, flag + 1);
                    string finalString = Reverse.reverse(sub);

                    string f = finalString.Replace("\\","/");
                    student.ImageUrl = f;

                }


                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            else
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors);
            }

            ViewBag.Image = student.ImageUrl;
            return View(student);
        }
//--------</ Upload_ImageFile() >--------







        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,RegNo,Session,Faculty,FathersName,MothersName,Address,Mobile,Email,Nationality,Tribe,HallName,BorderNo,RoomNumber,ImageUrl")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {





                    var files = HttpContext.Request.Form.Files;
                    foreach (var Image in files)
                    {
                        if (Image != null && Image.Length > 0)
                        {
                            var file = Image;
                            //There is an error here
                            var uploads = Path.Combine(_appEnvironment.WebRootPath, "Uploads");
                            if (file.Length > 0)
                            {
                                var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                                using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                }

                            }
                        }
                    }







                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
