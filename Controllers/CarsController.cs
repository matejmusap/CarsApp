using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarsApp.Data;
using CarsApp.Models;
using cloudscribe.Pagination.Models;

namespace CarsApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsAppContext _context;

        public CarsController(CarsAppContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string sortOrder, string searchString, int pageNumber = 1, int pageSize = 4)
        {
            ViewBag.ManufacturerSortParm = String.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            ViewBag.WidthSortParm = sortOrder == "Width" ? "Width_desc" : "Width";
            ViewBag.LengthSortParm = sortOrder == "Length" ? "Length_desc" : "Length";
            ViewBag.HeightSortParm = sortOrder == "Height" ? "Height_desc" : "Height";
            ViewBag.OriginCountrySortParm = String.IsNullOrEmpty(sortOrder) ? "OriginCountry_desc" : "OriginCountry";
            ViewBag.ClassOfCarSortParm = String.IsNullOrEmpty(sortOrder) ? "ClassOfCar_desc" : "ClassOfCar";
            ViewBag.CurrentSortOrder = sortOrder;
            ViewBag.CurrentFilter = searchString; int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var cars = from s in _context.Car
                           select s;

            var carCount = cars.Count();

            if (!String.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Manufacturer.Contains(searchString));
                carCount = cars.Count();
            }

            switch (sortOrder)
            {
                case "manufacturer_desc":
                    cars = cars.OrderByDescending(s => s.Manufacturer);
                    break;
                case "Width":
                    cars = cars.OrderBy(s => s.Width);
                    break;
                case "Width_desc":
                    cars = cars.OrderByDescending(s => s.Width);
                    break;
                case "Length":
                    cars = cars.OrderBy(s => s.Length);
                    break;
                case "Length_desc":
                    cars = cars.OrderByDescending(s => s.Length);
                    break;
                case "Height":
                    cars = cars.OrderBy(s => s.Height);
                    break;
                case "Height_desc":
                    cars = cars.OrderByDescending(s => s.Height);
                    break;
                case "OriginCountry":
                    cars = cars.OrderBy(s => s.OriginCountry);
                    break;
                case "OriginCountry_desc":
                    cars = cars.OrderByDescending(s => s.OriginCountry);
                    break;
                case "ClassOfCar":
                    cars = cars.OrderBy(s => s.ClassOfCar);
                    break;
                case "ClassOfCar_desc":
                    cars = cars.OrderByDescending(s => s.ClassOfCar);
                    break;
                default:
                    cars = cars.OrderBy(s => s.Manufacturer);
                    break;
            }

            cars = cars.Skip(ExcludeRecords).Take(pageSize);

            var result = new PagedResult<Car>
            {
                Data = await cars.AsNoTracking().ToListAsync(),
                TotalItems = carCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };


            return View(result);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DisplayName,Manufacturer,ModelOfCar,ClassOfCar,OriginCountry,Height,Length,Width")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DisplayName,Manufacturer,ModelOfCar,ClassOfCar,OriginCountry,Height,Length,Width")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
