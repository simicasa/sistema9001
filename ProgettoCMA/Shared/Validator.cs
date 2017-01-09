using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgettoCMA
{
    public static class Validator
    {
        public static bool checkString(string str)
        {
            str = str.Trim();
            if(str.Length > 0)
            {
                return true;
            }
            return false;
        }
        public static bool checkTextBox(TextBox textbox, int checkType = CheckType.STRING)
        {
            switch (checkType)
            {
                case CheckType.STRING:
                    return checkString(textbox.Text);
                //case CheckType.INTEGER:
                    //return checkString(textbox.Text);
                //case CheckType.DECIMAL:
                    //return checkString(textbox.Text);
            }
            return false;
        }
    }
    public static class CheckType
    {
        public const int STRING = 1;
        public const int INTEGER = 2;
        public const int DECIMAL = 3;
    }
}
