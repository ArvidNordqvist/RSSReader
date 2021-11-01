using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BusinessLayer.Controllers

{
    public class EmptyStringException : Exception
    {
        public override string Message
        {
            get
            {
                return "please add all the things to a podcast";
            }
        }

        public bool textCheck(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
