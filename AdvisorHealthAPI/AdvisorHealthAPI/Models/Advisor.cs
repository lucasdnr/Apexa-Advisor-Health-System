﻿using System;
using System.Numerics;

namespace AdvisorHealthAPI.Models;

public class Advisor
{ 
    public Guid Id {  get; init; }
    public string Name { get; private set; }
    public int? SIN { get; private set; }
    public string? Address { get; private set; }
    public int? Phone { get; private set; }
    public string HealthStatus { get; }

    private static Random random = new Random();

    public enum LightColor
    {
        GREEN,
        YELLOW,
        RED
    }

    public Advisor(string name, int sin, string address, int phone) {
        Id = Guid.NewGuid();
        Name = name;
        SIN = sin;
        Address = address;
        Phone = phone;

        // Randomly generated in the backend with the following probabilities:
        // Green=60% Yellow = 20% Red =20%)
        HealthStatus = this.generateHelthStatus();
        
    }

    private string generateHelthStatus()
    {
        int randomNumber = random.Next(1, 101); // Generate a random number between 1 and 100

        if (randomNumber <= 60)
        {
            return LightColor.GREEN.ToString(); // 60% chance for GREEN
        }
        else if (randomNumber <= 80)
        {
            return LightColor.YELLOW.ToString(); // 20% chance for YELLOW
        }
        else
        {
            return LightColor.RED.ToString(); // 20% chance for RED
        }
    }
}