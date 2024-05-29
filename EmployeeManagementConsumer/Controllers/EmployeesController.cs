// EmployeesController.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using EmployeeManagementMvc.Services;
using employeeManagementAPP.Models;

namespace EmployeeManagementMvc.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeApiService _employeeApiService;

        public EmployeesController(EmployeeApiService employeeApiService)
        {
            _employeeApiService = employeeApiService;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeApiService.GetEmployeesAsync();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _employeeApiService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,Phone,Email,Designation,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeApiService.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeApiService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,Email,Designation,Salary")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _employeeApiService.UpdateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeApiService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeApiService.DeleteEmployeeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
