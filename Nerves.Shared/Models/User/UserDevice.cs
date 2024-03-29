﻿namespace Nerves.Shared.Models.User;

public class UserDevice
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? OS { get; set; }

    public string? OSVersion { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public bool IsOnline { get; set; }

    public string? IPv4 { get; set; }

    public string? IPv6 { get; set; }

    public string? MacAddress { get; set; }

    public Dictionary<string, string>? Tags { get; set; }
}
