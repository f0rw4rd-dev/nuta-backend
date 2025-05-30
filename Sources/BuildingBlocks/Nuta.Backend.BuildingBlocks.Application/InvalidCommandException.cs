﻿namespace Nuta.Backend.BuildingBlocks.Application;

public class InvalidCommandException : Exception
{
    public List<string> Errors { get; }

    public InvalidCommandException(List<string> errors)
    {
        Errors = errors;
    }
}