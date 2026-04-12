using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace ExpenseTracker.Controllers;

public class ExpensesController : Controller
{
    private static List<Expense> expenses = new List<Expense>();

    public IActionResult Index()
    {
        return View(expenses);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(string Amount, string Category)
    {
        Amount = Amount.Replace(",", ".");

        decimal amount = decimal.Parse(Amount, CultureInfo.InvariantCulture);

        var expense = new Expense
        {
            Id = expenses.Count + 1,
            Amount = amount,
            Category = Category,
            Date = DateTime.Now
        };

        expenses.Add(expense);

        return RedirectToAction("Index");
    }

    public IActionResult Filter(string category)
    {
        var filtered = expenses
            .Where(e => e.Category != null && e.Category.ToLower() == category.ToLower())
            .ToList();

        return View(filtered);
    }
}