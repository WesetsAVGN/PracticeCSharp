using ExpenseTracker.Models;
using System;
using System.Collections.Generic;

namespace ExpenseTracker.Services;

public interface IExpenseService
{
    void Add(Expense expense);
    void Delete(int id);
    void Update(Expense expense);
    Expense GetById(int id);
    List<Expense> GetAll();
    decimal GetTotalByPeriod(DateTime from, DateTime to);
}