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

namespace DoAnLTTQ1 {
    //insert
    public partial class MainCalculator : Form
    {
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                MainCalculatorControl.Perform_Equal();
            }
            else if (e.KeyCode.Equals(Keys.Back))
            {
                MainCalculatorControl.Perform_Del();
            }
            else if (e.KeyCode.Equals(Keys.Delete))
            {
                MainCalculatorControl.Perform_Del();
            }
            else if (e.KeyCode.Equals(Keys.Left))
            {
                InputText.moveCursorLeft();
            }
            else if (e.KeyCode.Equals(Keys.Right))
            {
                InputText.moveCursorRight();
            }
            else if (e.KeyCode.Equals(Keys.Oemcomma))
            {
                MainCalculatorControl.insertContentIntoInputText(",");
            }
            else if (e.KeyCode.Equals(Keys.OemQuestion))
            {
                MainCalculatorControl.insertContentIntoInputText("/");
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                MainCalculatorControl.loadPreviousCache();
                MainCalculatorControl.displayCache();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                MainCalculatorControl.loadNextCache();
                MainCalculatorControl.displayCache();
            }
            else if (ModifierKeys == Keys.Shift)
            {
                if(e.KeyCode == Keys.Back)
                {
                    MainCalculatorControl.Perform_Ac();
                }
                else if (e.KeyCode.Equals(Keys.Delete))
                {
                    MainCalculatorControl.Perform_Ac();
                }
                //Keys need Shift
                if (e.KeyCode == Keys.Oemplus)
                    MainCalculatorControl.insertContentIntoInputText("+");
                else if (e.KeyCode == Keys.D0)
                    MainCalculatorControl.insertContentIntoInputText(")");
                else if (e.KeyCode == Keys.D9)
                    MainCalculatorControl.insertContentIntoInputText("(");
                else if (e.KeyCode == Keys.D1)
                    MainCalculatorControl.insertContentIntoInputText("!");
                else if (e.KeyCode == Keys.D6)
                    MainCalculatorControl.insertContentIntoInputText("^");
                else if (e.KeyCode == Keys.D8)
                    MainCalculatorControl.insertContentIntoInputText("*");
                else if (e.KeyCode == Keys.Oemcomma)
                    MainCalculatorControl.insertContentIntoInputText("<");
                else if (e.KeyCode == Keys.OemPeriod)
                    MainCalculatorControl.insertContentIntoInputText(">");
                else if (e.KeyCode == Keys.OemQuestion)
                    MainCalculatorControl.insertContentIntoInputText("/");

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
                MainCalculatorControl.insertContentIntoInputText(key);
            }
            else if (e.KeyCode == Keys.OemMinus)
                MainCalculatorControl.insertContentIntoInputText("-");
            else if (e.KeyCode == Keys.Escape)
                MainCalculatorControl.Perform_Ac();
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                MainCalculatorControl.insertContentIntoInputText(e.KeyCode.ToString().ToLower());
        }

        /// INSERT BLOCK

        //state button
    }
    
    //MainCalculatorControl
}