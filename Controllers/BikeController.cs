using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCNEW.Data;
using MVCNEW.Models;
using MVCNEW.Models.Domain;

namespace MVCNEW.Controllers
{
    public class BikeController : Controller
    {
        private readonly MVCDbContext mvcDbContext;

        public BikeController(MVCDbContext mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var bikes = await mvcDbContext.Bikes.ToListAsync();
            return View(bikes);
        }

        [HttpGet]
        public IActionResult AddBike()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBike(AddBikeViewModel addBikeRequest) 
        { 
            var bike = new Bike()
            {
                    Brand = addBikeRequest.Brand,
                    ModelNum = addBikeRequest.ModelNum,
                    CC = addBikeRequest.CC,
                    Bhp = addBikeRequest.Bhp,
                    Torque = addBikeRequest.Torque,
            };
           await mvcDbContext.Bikes.AddAsync(bike);
           await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var bike = await mvcDbContext.Bikes.FirstOrDefaultAsync(x => x.Id == id);

            if (bike !=null)
            {
                var viewModel = new UpdateBikeViewModel() 
                {
                    Id = bike.Id,
                    Brand = bike.Brand,
                    ModelNum = bike.ModelNum,
                    CC = bike.CC,
                    Bhp = bike.Bhp,
                    Torque = bike.Torque,
                };
                return await Task.Run(() => View("View",viewModel));
            }
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateBikeViewModel model)
        {
            var bike = await mvcDbContext.Bikes.FindAsync(model.Id);

            if (bike != null)
            {
                bike.Brand = model.Brand;
                bike.ModelNum = model.ModelNum;
                bike.CC = model.CC;
                bike.Bhp = model.Bhp;
                bike.Torque = model.Torque;

                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateBikeViewModel model)
        {
            var bike = await mvcDbContext.Bikes.FindAsync(model.Id);

            if (bike != null)
            {
                mvcDbContext.Bikes.Remove(bike);
                await mvcDbContext.SaveChangesAsync();

                return RedirectToAction("Index"); 
            }
            return RedirectToAction("Index");
        }

    }
}
