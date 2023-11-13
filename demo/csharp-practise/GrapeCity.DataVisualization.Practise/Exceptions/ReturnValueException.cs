namespace GrapeCity.DataVisualization.Practise.Exceptions
{
    using System;

    internal class ReturnValueException : Exception
    {
        public ReturnValueException(string type)
            : base(string.Format("The \"{0}\" value return exception.", type))
        {
        }
    }
}
