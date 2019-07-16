using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppSalesMVC.Data;
using WebAppSalesMVC.Models;

namespace WebAppSalesMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentsController(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Department.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var department = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
                return NotFound();

            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var department = await _context.Department.FindAsync(id);
            if (department == null)
                return NotFound();

            return View(department);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Department department)
        {
            if (id != department.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
                        return NotFound();

                    throw;
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var department = await _context.Department.FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
                return NotFound();

            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department = await _context.Department.FindAsync(id);
            _context.Department.Remove(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}