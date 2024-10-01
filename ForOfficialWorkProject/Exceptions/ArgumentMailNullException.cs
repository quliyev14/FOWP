using System;
namespace ForOfficialWorkProject.Exceptions
{
    public class ArgumentMailNullException : Exception
    {
        public ArgumentMailNullException(string? message) : base(message) { }
    }
}