using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoAnLTTQ1
{
    internal class Control
    {
        //form we are working with
        static private Form1 form1;
        static public void init(Form1 f) {
            form1 = f;
        }
        static public void insertContentIntoInputText(string content)
        {
            if (form1.onInvalidExpressionMode)
            {
                return;
            }
            form1.InputText.Text = form1.InputText.Text.Insert(form1.currentCursorPosition, content);
            form1.currentCursorPosition += content.Length;
        }
        //AC
        static public void Perform_Ac()
        {

        }
        //DEL
        static public void Perform_Del()
        {

        }
        //EQUAL
        static public void Perform_Equal()
        {
            //init expression
            Expression e = new Expression();
            e.setContent(form1.InputText.Text);        
            //check if expression is valid
            if (!e.checkValidity())
            {
                turnOnInvalidExpressionMode();
                return;
            }
            //compute result
            e.buildComputingTree();
            double result = e.computeResult();
            form1.OutputText.Text = result.ToString();
        }
        static public void turnOnInvalidExpressionMode()
        {
            form1.InputText.Text = "Expression Invalid";
            form1.onInvalidExpressionMode = true;
        }
        static public void turnOffInvalidExpressionMode()
        {
            form1.InputText.Text = "";
            form1.onInvalidExpressionMode = false;
        }
        //SHIFT MODE
        static public void Toggle_ShiftMode()
        {

        }
        //ALPHA MODE
        static public void Toggle_AlphaMode()
        {

        }
        //SWITCH MENU
        static public void Open_Menu()
        {

        }
    }
}
