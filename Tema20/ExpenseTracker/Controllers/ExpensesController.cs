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

    public IActionResult Index()
    {
        return View(_service.GetAll());
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
            Amount = model.Amount,
            Category = model.Category,
            Date = model.Date
        };

        _service.Add(expense);

        TempData["Success"] = "Расход добавлен";

        return RedirectToAction("Index");
    }

    public IActionResult Filter(string category)
    {
        var filtered = _service.GetAll()
            .Where(e => e.Category != null && e.Category.ToLower() == category.ToLower())
            .ToList();

        return View(filtered);
    }
}