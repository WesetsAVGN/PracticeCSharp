using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Services;

public class ExpenseService : IExpenseService
{
    private readonly AppDbContext _context;

    public ExpenseService(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Expense expense)
    {
        _context.Expenses.Add(expense);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _context.Expenses.Find(id);
        if (item != null)
        {
            _context.Expenses.Remove(item);
            _context.SaveChanges();
        }
    }

    public void Update(Expense expense)
    {
        _context.Expenses.Update(expense);
        _context.SaveChanges();
    }

    public Expense GetById(int id)
    {
        return _context.Expenses.Find(id);
    }

    public List<Expense> GetAll()
    {
        return _context.Expenses.ToList();
    }

    public decimal GetTotalByPeriod(DateTime from, DateTime to)
    {
        return _context.Expenses
            .Where(e => e.Date >= from && e.Date <= to)
            .Sum(e => e.Amount);
    }
}