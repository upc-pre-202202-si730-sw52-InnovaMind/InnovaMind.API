﻿using InnovaMind.API.Security.Domain.Models;
namespace InnovaMind.API.InnovaMind.Domain.Models;
public class Address
{
    public string Id { get; set; }
    public int UserId { get; set; }
    public string NameAddress { get; set; }

    //Relationships
    public User User { get; set; }

}
