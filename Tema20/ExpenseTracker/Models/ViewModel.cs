using System;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models;

public class ExpenseViewModel
{
    [Required]
    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public DateTime Date { get; set; }
}