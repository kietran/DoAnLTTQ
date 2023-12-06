using CustomControls.CalculatorTextbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ1
{
    //insert
    public partial class Form1 : Form
    {

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Control.Perform_Equal();
            }
            else if (e.KeyCode.Equals(Keys.Back))
            {
                Control.Perform_Del();
            }
            else if (ModifierKeys == Keys.Shift)
            {
                //Keys need Shift
                if (e.KeyCode == Keys.Oemplus)
                    Control.insertContentIntoInputText("+");
                else if (e.KeyCode == Keys.D0)
                    Control.insertContentIntoInputText(")");
                else if (e.KeyCode == Keys.D9)
                    Control.insertContentIntoInputText("(");
                else if (e.KeyCode == Keys.D1)
                    Control.insertContentIntoInputText("!");
                else if (e.KeyCode == Keys.D6)
                    Control.insertContentIntoInputText("^");
                else if (e.KeyCode == Keys.D8)
                    Control.insertContentIntoInputText("*");
                else if (e.KeyCode == Keys.Oemcomma)
                    Control.insertContentIntoInputText("<");
                else if (e.KeyCode == Keys.OemPeriod)
                    Control.insertContentIntoInputText(">");
                else if (e.KeyCode == Keys.OemQuestion)
                    Control.insertContentIntoInputText("/");
            }
            else if (ModifierKeys == Keys.Control)
            {
                InputText.OnKeyDown1(e);
            }
            else if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                //number case
                string key = e.KeyCode.ToString();
                if (key.Length > 1)
                    key = key.Replace("NumPad", "").Replace("D", "");
                Control.insertContentIntoInputText(key);
            }
            else if (e.KeyCode == Keys.OemMinus)
                Control.insertContentIntoInputText("-");
            else if (e.KeyCode == Keys.Escape)
                Control.Perform_Ac();
            else if(e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                Control.insertContentIntoInputText(Convert.ToChar(e.KeyValue).ToString().ToLower());
        }

        /// INSERT BLOCK

        //state button
    }

    //control
}
