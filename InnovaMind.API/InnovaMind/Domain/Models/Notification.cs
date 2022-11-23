﻿using InnovaMind.API.Security.Domain.Models;
namespace InnovaMind.API.InnovaMind.Domain.Models;

public class Notification
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
    
    //Relationships
    
    public int EmitterId { get; set; }
    public User Emitter { get; set; }
    
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
}