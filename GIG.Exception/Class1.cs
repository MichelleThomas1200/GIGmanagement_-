using System;

namespace GIG.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException():base()
            {

            }
        public CustomException(string ErorrMessage):base(ErorrMessage)
        {

        }
    }
}
