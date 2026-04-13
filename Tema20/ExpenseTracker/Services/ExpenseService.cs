using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseTracker.Services;

public class ExpenseService : IExpenseService
{
    private static List<Expense> expenses = new List<Expense>();

    public void Add(Expense expense)
    {
        expense.Id = expenses.Count + 1;
        expenses.Add(expense);
    }

    public List<Expense> GetAll()
    {
        return expenses;
    }

    public decimal GetTotalByPeriod(DateTime from, DateTime to)
    {
        return expenses
            .Where(e => e.Date >= from && e.Date <= to)
            .Sum(e => e.Amount);
    }
}