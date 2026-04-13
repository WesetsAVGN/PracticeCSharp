using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using System;
using System.Linq;

namespace ExpenseTracker.Controllers;

public class ExpensesController : Controller
{
    private readonly IExpenseService _service;

    public ExpensesController(IExpenseService service)
    {
        _service = service;
    }

    public IActionResult Index(DateTime? from, DateTime? to)
    {
        var data = _service.GetAll();

        if (from.HasValue && to.HasValue)
        {
            data = data
                .Where(e => e.Date >= from && e.Date <= to)
                .ToList();

            ViewBag.Total = _service.GetTotalByPeriod(from.Value, to.Value);
        }

        return View(data);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ExpenseViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var expense = new Expense
        {
            Title = model.Title,
            Amount = model.Amount,
            Date = model.Date,
            Category = model.Category
        };

        _service.Add(expense);

        TempData["Success"] = "Расход добавлен";

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }

    public IActionResult FilterByDate(DateTime? from, DateTime? to)
    {
        var data = _service.GetAll();

        if (from.HasValue)
            data = data.Where(e => e.Date >= from.Value).ToList();

        if (to.HasValue)
            data = data.Where(e => e.Date <= to.Value).ToList();

        return View("Index", data);
    }
}