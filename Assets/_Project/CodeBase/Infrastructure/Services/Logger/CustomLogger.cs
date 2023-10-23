using System;
using UnityEngine;

namespace _Project.CodeBase.Infrastructure.Services.Logger
{
    public class CustomLogger : ICustomLogger
    {
        public void Log(object message) => 
            Debug.Log($"{message}");
        
        public void LogWarning(object message) => 
            Debug.LogWarning($"{message}");
        
        public void LogError(Exception exception) => 
            throw exception;
    }
}