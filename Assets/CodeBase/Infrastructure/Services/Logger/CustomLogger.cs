using System;
using CodeBase.Infrastructure.Services.Logger;
using UnityEngine;

namespace CodeBase.Infrastructure.Services
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