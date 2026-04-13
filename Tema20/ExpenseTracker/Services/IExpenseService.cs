using ExpenseTracker.Models;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.Services;

public interface IExpenseService
{
    void Add(Expense expense);
    List<Expense> GetAll();
    decimal GetTotalByPeriod(DateTime from, DateTime to);
}