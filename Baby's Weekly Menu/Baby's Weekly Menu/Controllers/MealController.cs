﻿using BabysWeeklyMenu.API.Data;
using BabysWeeklyMenu.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BabysWeeklyMenu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly WeeklyMenuContext _context;

        public MealController(WeeklyMenuContext context)
        {
            _context = context ?? throw new ArgumentNullException();
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("/api/meals")]
        public async Task<ActionResult> GetAllMeals()
        {
            var meals = await _context.Meals.ToListAsync();
            if (meals == null)
            {
                return NotFound();
            }

            return new JsonResult(meals);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetMeal(int id)
        {
            var selectedMeals = await _context.Meals.FindAsync(id);
            if (selectedMeals == null)
            {
                return NotFound();
            }

            return new JsonResult(selectedMeals);
        }

        [HttpPost]
        public async Task<ActionResult> PostMeal(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();

            return new JsonResult(meal);
        }

    }
}