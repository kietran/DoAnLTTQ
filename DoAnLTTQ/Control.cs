using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoAnLTTQ1
{
    //control 
    //input
    internal partial class Control
    {
        //form we are working with
        static private Form1 form1;
        static private string currentInputText;
        static public void init(Form1 f) {
            form1 = f;
        }
        static public void insertContentIntoInputText(string content)
        {
            if (form1.onInvalidExpressionMode)
            {
                return;
            }
            if (form1.onDisplayMode)
            {
                turnOffDisplayMode();
            }
            form1.InputText.verticalBar.Hide();
            int prev = form1.InputText.currentCursorPosition;
            form1.InputText.currentCursorPosition += content.Length;
            form1.InputText.Text = form1.InputText.Text.Insert(prev, content) ;  
        }
        static public void deleteInputContentAtCursor()
        {
            if (form1.InputText.TextLength > 0)
            {
                if(form1.InputText.currentCursorPosition== 0)
                {
                    form1.InputText.Text = form1.InputText.Text.Remove(0,1);
                }
                else
                {
                    form1.InputText.Text = form1.InputText.Text.Remove(form1.InputText.currentCursorPosition-1,1);
                    form1.InputText.currentCursorPosition--;
                }       
            }
        }
        //AC
        static public void Perform_Ac()
        {
            form1.onDisplayMode = false;
            form1.InputText.Text = string.Empty;
            form1.OutputText.Text = string.Empty;
            form1.InputText.currentCursorPosition = 0;

            if (form1.onInvalidExpressionMode)
            {
                Control.turnOffInvalidExpressionMode();
            }
        }
        //DEL
        static public void Perform_Del()
        {
            deleteInputContentAtCursor();
        }
        /// /EQUAL
        static public void Perform_Equal()
        {
            //init expression
            Expression e = new Expression();
            e.setContent(form1.InputText.Text);
            e.preProcess();
            e.buildComputingTree();
            //check if expression is valid
            if (!e.checkOverallValidity())
            {
                string errorMessage = "Invalid Expression -- " + e.getErrorMessage();
                turnOnInvalidExpressionMode(errorMessage);
                return;
            }
            //compute result
            double result = e.computeResult();
            if (!e.checkComputingValidity())
            {
                string errorMessage = "Calculating error";
                turnOnInvalidExpressionMode(errorMessage);
                return;
            }
            form1.OutputText.Text = result.ToString();

            cachesNewMemory();
            form1.onDisplayMode = true;
        }
        static public void turnOnInvalidExpressionMode(string errorMessage)
        {
            currentInputText = form1.InputText.Text;
            form1.OutputText.Text = "Press AC to break";
            form1.InputText.Text = errorMessage;
            form1.InputText.ReadOnly = true;
            form1.onInvalidExpressionMode = true;       
        }
        static public void turnOffInvalidExpressionMode()
        {
            form1.InputText.Text = currentInputText;
            form1.InputText.ReadOnly = false;
            form1.onInvalidExpressionMode = false;
        }
        static public void reset()
        {
            form1.onAlphaMode = false;
            form1.onShiftMode = false;
            form1.onDisplayMode = false;
            form1.onInvalidExpressionMode = false;
            form1.InputText.Clear();
            Perform_Ac();
            clearCachesMemory();
        }
    }
    //shift mode, alpha mode
    internal partial class Control
    {
        //SHIFT MODE
        static public void Toggle_ShiftMode()
        {
            form1.MISC_OpenBracket.Text = "Abs";
            form1.MISC_CloseBracket.Text = "Fact";
            //redo
            //undo
            form1.FUNC_Sqrt.Text = "∛";
            form1.FUNC_Sqrt.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Square.Text = "x^3";
            form1.FUNC_Logarit.Text = "10^";
            form1.FUNC_Ln.Text = "e^";
            form1.OPER_And.Text = "NAND";
            form1.OPER_And.Font = new Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            form1.OPER_Or.Text = "NOR";
            form1.OPER_Or.Font = new Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            form1.OPER_Not.Text = "XOR";
            form1.OPER_Not.Font = new Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Sin.Text = "asin";
            form1.FUNC_Sin.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Cos.Text = "acos";
            form1.FUNC_Cos.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Tan.Text = "atan";
            form1.FUNC_Tan.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.OPER_Gt.Text = ">>";
            form1.OPER_Lt.Text = "<<";
            form1.OPER_Ge.Text = "|";
            form1.OPER_Le.Text = "&";
            form1.OPER_Le.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            form1.OPER_Eq.Text = "~";
            form1.OPER_Eq.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            form1.OPER_Ne.Text = "^";
            form1.OPER_Ne.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
        }
        //ALPHA MODE
        static public void Toggle_AlphaMode()
        {
            form1.OPER_Not.Text = "XNOR";
            form1.OPER_Not.Font = new Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Sin.Text = "sinh";
            form1.FUNC_Sin.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Cos.Text = "cosh";
            form1.FUNC_Cos.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Tan.Text = "tanh";
            form1.FUNC_Tan.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.OPER_Mul.Text = "GCD";
            form1.OPER_Mul.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.OPER_Div.Text = "LCM";
            form1.OPER_Div.Font = new Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            form1.MISC_Dot.Text = "Rand";
            form1.FUNC_PowerOfTen.Text = "e";
            form1.MISC_Ans.Text = "PreAns";
            form1.MISC_Ans.Font = new Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
        }
        //NORMAL MODE
        static public void NormalMode()
        {
            form1.MISC_OpenBracket.Text = "(";
            form1.MISC_CloseBracket.Text = ")";
            //redo
            //undo
            form1.FUNC_Sqrt.Text = "√";
            form1.FUNC_Sqrt.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Square.Text = "x^2";
            form1.FUNC_Logarit.Text = "log";
            form1.FUNC_Ln.Text = "ln";
            form1.OPER_And.Text = "and";
            form1.OPER_And.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Or.Text = "or";
            form1.OPER_Or.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Not.Text = "not";
            form1.OPER_Not.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Sin.Text = "sin";
            form1.FUNC_Sin.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Cos.Text = "cos";
            form1.FUNC_Cos.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.FUNC_Tan.Text = "tan";
            form1.FUNC_Tan.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Gt.Text = ">";
            form1.OPER_Lt.Text = "<";
            form1.OPER_Ge.Text = "≥";
            form1.OPER_Le.Text = "≤";
            form1.OPER_Le.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Eq.Text = "==";
            form1.OPER_Le.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Ne.Text = "!=";
            form1.OPER_Le.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            form1.OPER_Mul.Text = "x";
            form1.OPER_Mul.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.OPER_Div.Text = "÷";
            form1.OPER_Div.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            form1.MISC_Dot.Text = ".";
            form1.FUNC_PowerOfTen.Text = "x10X";
            form1.MISC_Ans.Text = "Ans";
            form1.MISC_Ans.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        }

        //SWITCH MENU
        static public void Open_Menu()
        {

        }
    }
    //memory caches
    internal partial class Control
    {
        static public void turnOffDisplayMode()
        {
            form1.onDisplayMode = false;
            form1.OutputText.Text = string.Empty;
        }
        static public void cachesNewMemory()
        {
            if (form1.currentMemoryCachesSize < form1.maxMemoryCachesSize)
            {
                //caches new memory
                form1.memoryCaches[form1.currentMemoryCachesSize++] = new Tuple<string, string>(form1.InputText.Text, form1.OutputText.Text);
                form1.currentCachePosition = form1.currentMemoryCachesSize - 1;
            }
            else
            {
                //pop the first
                for (int i = 0; i < form1.maxMemoryCachesSize; i++)
                {
                    form1.memoryCaches[i] = form1.memoryCaches[i + 1];
                }
                form1.memoryCaches[form1.maxMemoryCachesSize] = new Tuple<string, string>(form1.InputText.Text, form1.OutputText.Text);
                form1.currentCachePosition = form1.maxMemoryCachesSize - 1;
            }
        }
        static public void loadPreviousCache()
        {
            if (!form1.onDisplayMode)
            {
                return;
            }
            if (form1.currentCachePosition > 0)
            {
                form1.currentCachePosition--;
            }
        }
        static public void loadNextCache()
        {
            if (!form1.onDisplayMode)
            {
                return;
            }
            if (form1.currentCachePosition < form1.currentMemoryCachesSize - 1)
            {
                form1.currentCachePosition++;
            }
        }
        static public void displayCache()
        {
            if (form1.currentMemoryCachesSize > 0)
            {
                form1.InputText.Text = form1.memoryCaches[form1.currentCachePosition].Item1;
                form1.OutputText.Text = form1.memoryCaches[form1.currentCachePosition].Item2;
            }
        }
        static public void clearCachesMemory()
        {
            form1.memoryCaches = new Tuple<string, string>[form1.maxMemoryCachesSize];
            form1.currentCachePosition = 0;
            form1.currentMemoryCachesSize = 0;
        }
    }
}
