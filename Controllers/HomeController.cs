using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_Operation_using_Code_First.Models;

namespace CRUD_Operation_using_Code_First.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StudentDbContext _StudentDB;

    //public HomeController(ILogger<HomeController> logger)
    //{
    //    _logger = logger;
    //}
    public HomeController(StudentDbContext _StudentDB)
    {
        this._StudentDB = _StudentDB;
    }

    // Show the Student List 
    public IActionResult Index()
    {
        var student_list = _StudentDB.Student_List.ToList();
        return View(student_list);
    }

    // Add the new Student 

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
   
    [ValidateAntiForgeryToken]    // for security reason no one from outside can use it  
    public async Task<IActionResult> Create(Student std)
    {
        if (ModelState.IsValid)
        {
            await _StudentDB.Student_List.AddAsync(std);
            await _StudentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View();
    }

    // Show more details of the student 

    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            NotFound();
        }
        var std = _StudentDB.Student_List.FirstOrDefault(x => x.id == id);
        if (std == null)
        {
            NotFound();
        }

        return View(std);
    }

    // Edit the student detials 

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            NotFound();
        }
        var std = await _StudentDB.Student_List.FindAsync(id);

        return View(std);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]    // for security reason no one from outside can use it  
    public async Task<IActionResult> Edit(int id, Student std)
    {
        if (id != std.id)
        {
            NotFound();
        }
        if (ModelState.IsValid)
        {
             _StudentDB.Student_List.Update(std);
            await _StudentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View();
    }


    // Delete the student for the database 

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            NotFound();
        }
        var std =  _StudentDB.Student_List.FirstOrDefault(x=>x.id==id);
        if (std == null)
        {
            NotFound();
        }

        return View(std);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]    // for security reason no one from outside can use it  
    public async Task<IActionResult> Delete(int id)
    {

        var std = await _StudentDB.Student_List.FindAsync(id);
        if (std!=null)
        {
            _StudentDB.Student_List.Remove(std);
            await _StudentDB.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View();
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
