using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models;

public class ExpenseViewModel
{
    [Required]
    public string Title { get; set; }

    [Required]
    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Category { get; set; }
}