using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrProject.Models;

namespace HrProject.Controllers
{
    public class EmployeeModelController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeModelController(EmployeeContext context)
        {
            _context = context;
        }
        // GET: EmployeeModel

        public IActionResult Index()
        {
            var employees = _context.employeeModels.ToList();
            return View(employees);
        }




        // Search:
        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["GetEmployeeDetails"] = searchString;
            var employee = from m in _context.employeeModels
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                employee
                    = employee.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            return View(await employee.AsNoTracking().ToListAsync());
        }


        // GET: EmployeeModel/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employeeModels
                .FirstOrDefaultAsync(m => m.PrivateId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // GET: EmployeeModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrivateId,FirstName,LastName,Sex,BirthDate,Email,Position,Status,DateOfFire")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeModel);
        }

        // GET: EmployeeModel/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employeeModels.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        // POST: EmployeeModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PrivateId,FirstName,LastName,Sex,BirthDate,Email,Position,Status,DateOfFire")] EmployeeModel employeeModel)
        {
            if (id != employeeModel.PrivateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeModelExists(employeeModel.PrivateId))
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
            return View(employeeModel);
        }

        // GET: EmployeeModel/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeModel = await _context.employeeModels
                .FirstOrDefaultAsync(m => m.PrivateId == id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return View(employeeModel);
        }

        // POST: EmployeeModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employeeModel = await _context.employeeModels.FindAsync(id);
            _context.employeeModels.Remove(employeeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeModelExists(string id)
        {
            return _context.employeeModels.Any(e => e.PrivateId == id);
        }
    }
}
