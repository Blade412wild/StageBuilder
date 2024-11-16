using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomError
{
    public enum ErrorLevel {Recommondation,Fatal}
    public ErrorLevel errorLevel;
    public string message { get; private set; }

    public CustomError(string message)
    {
        this.message = message;
        this.errorLevel = errorLevel;
    }
}
