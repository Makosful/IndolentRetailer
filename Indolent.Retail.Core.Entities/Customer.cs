﻿namespace Indolent.Retail.Core.Entities;

public class Customer
{
    public string UUID { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public List<Order> Orders { get; set; } = new();
}