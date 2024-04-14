﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity;

public class PersonEntity
{
    public string Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public UserEntity User { get; set; }
}