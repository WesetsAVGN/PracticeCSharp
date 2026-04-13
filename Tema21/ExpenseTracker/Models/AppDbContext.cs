using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ExpenseTracker.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Expense> Expenses { get; set; }
}