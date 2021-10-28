using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BusinessLayer.Controllers

{
    public class ExceptionClass : Exception
    {
        public ExceptionClass()
        {

        }
        public bool checkTextInput(string check)
        {
            int amount = check.Length;
            if (amount >= 2) { return true; }

            

            else
            {
                //string message = "You did not enter 2 or more letters";
                //string caption = "Error Detected in Input";
                //MessageBox.Show(message, caption);
                return false;
            }
        }
    }


}
