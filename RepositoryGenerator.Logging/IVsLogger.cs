using System;

public interface ILogger
{
    void Clear();
    void DeletePane();
    void Log(Exception ex);
    void Log(string message);
}