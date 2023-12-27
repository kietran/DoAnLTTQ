using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProCalculator
{
    //insert + panel open/close
    internal partial class StandardCalculatorControl
    {
        static private StandardCalculator form1;
        
        static public void Init(StandardCalculator f)
        {
            form1 = f;
        }
        static public void InsertContentAtCursor(string content)
        {
            string text = form1.MainPanel_InputTextBox.Text.Insert(form1.MainPanel_InputTextBox.CurrentCursorPosition, content);
            form1.MainPanel_InputTextBox.Text = text;
            form1.MainPanel_InputTextBox.CurrentCursorPosition += content.Length;
            form1.MainPanel_InputTextBox.SelectionStart = form1.MainPanel_InputTextBox.CurrentCursorPosition;
            form1.MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
        }
        static public void DeleteContentAtCursor()
        {
            if (form1.MainPanel_InputTextBox.TextLength > 0)
            {
                if (form1.MainPanel_InputTextBox.CurrentCursorPosition == 0)
                {
                    form1.MainPanel_InputTextBox.Text = form1.MainPanel_InputTextBox.Text.Remove(0, 1);
                }
                else
                {
                    form1.MainPanel_InputTextBox.Text = form1.MainPanel_InputTextBox.Text.Remove(form1.MainPanel_InputTextBox.CurrentCursorPosition - 1, 1);
                    form1.MainPanel_InputTextBox.CurrentCursorPosition--;
                    form1.MainPanel_InputTextBox.SelectionStart = form1.MainPanel_InputTextBox.CurrentCursorPosition;
                    form1.MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
                }
            }
        }

        //number panel
        static public void OpenNumberPanel()
        {
            form1.MainPanel_OpenNumberPanelButton.InteriorColor = Color.FromArgb(150, 180, 94);
            //Check if Function Panel is open
            if (!form1.funcPanelOn)
                form1.NumberPanel.Location = new Point(0, 281);
            form1.NumberPanel.Show();
            UpdateMemoryPanelHeight();
        }
        static public void CloseNumberPanel()
        {
            form1.MainPanel_OpenNumberPanelButton.InteriorColor = Color.FromArgb(205, 235, 139);
            //Set back to original position
            form1.NumberPanel.Location = new Point(0, 447);
            form1.NumberPanel.Hide();
            form1.MemoryPanel.Height -= form1.NumberPanel.Height;
        }
        //func panel
        static public void OpenFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.InteriorColor = Color.FromArgb(200, 187, 149);
            //Check if Number Panel is in first place
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(0, 447);
            form1.FunctionPanel.Show();
            UpdateMemoryPanelHeight();
        }
        static public void CloseFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.InteriorColor = Color.FromArgb(255, 242, 204);
            //Check if Number Panel is still open
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(0, 281);
            form1.FunctionPanel.Hide();
            form1.MemoryPanel.Height -= form1.FunctionPanel.Height;
        }
        //meory panel
        static public void OpenMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.InteriorColor = Color.FromArgb(193, 151, 141);
            UpdateMemoryPanelHeight();
            form1.MemoryPanel.Show();
        }
        static public void CloseMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.InteriorColor = Color.FromArgb(248, 206, 204);
            form1.MemoryPanel.Hide();
        }

        //form opener
        static public void OpenFormOpenerPanel()
        {
            form1.FormOpenerPanel.Height = form1.MemoryPanel.Height;
            form1.FormOpenerPanel.Show();
            form1.FormOpenerPanel.BringToFront();
        }
        static public void CloseFormOpenerPanel()
        {
            form1.FormOpenerPanel.Hide();
        }
        static public void UpdateMemoryPanelHeight()
        {
            form1.MemoryPanel.Height = form1.Height - 55;
        }        
    }
    //toggle mode
    internal partial class StandardCalculatorControl
    {
        static public void TurnOnINVModeForFuncPanel()
        {
            form1.FUNC_Sin.TextContent = "sin⁻¹";
            form1.FUNC_Cos.TextContent = "cos⁻¹";
            form1.FUNC_Tan.TextContent = "tan⁻¹";
            form1.FUNC_Logarit.TextContent = "10^";
            form1.FUNC_Ln.TextContent = "eˣ";
            form1.FUNC_Sqrt.TextContent = "x²";
            form1.STATE_INV.ForeColor = Color.Black;
            form1.STATE_INV.BorderColor = Color.Black;
        }
        static public void TurnOnNormalModeForFuncPanel()
        {
            form1.FUNC_Sin.TextContent = "sin";
            form1.FUNC_Cos.TextContent = "cos";
            form1.FUNC_Tan.TextContent = "tan";
            form1.FUNC_Logarit.TextContent = "log";
            form1.FUNC_Ln.TextContent = "ln";
            form1.FUNC_Sqrt.TextContent = "√";
            form1.STATE_INV.ForeColor = Color.Gray;
            form1.STATE_INV.BorderColor = Color.FromArgb(170, 170, 180);
        }
        static public void SwitchToRadianMode()
        {
            form1.STATE_Radian.ForeColor = Color.Black;
            form1.STATE_Radian.BorderColor = Color.Black;

            form1.STATE_Degree.ForeColor = Color.Gray;
            form1.STATE_Degree.BorderColor = Color.FromArgb(170, 170, 180);
        }
        static public void SwitchToDegreeMode()
        {
            form1.STATE_Degree.ForeColor = Color.Black;
            form1.STATE_Degree.BorderColor = Color.Black;

            form1.STATE_Radian.ForeColor = Color.Gray;
            form1.STATE_Radian.BorderColor = Color.FromArgb(170, 170, 180);
        }
        static public void TurnOnDockingMode()
        {
            form1.TopMost = true;
            form1.MainPanel_OnTopButton.Hide();
            form1.MainPanel_OnTopButtonWithDeclineMark.Show();
        }
        static public void TurnOffDockingMode()
        {
            form1.TopMost = false;
            form1.MainPanel_OnTopButton.Show();
            form1.MainPanel_OnTopButtonWithDeclineMark.Hide();
        }
    }
    //calculating
    internal partial class StandardCalculatorControl
    {
        static public bool CheckValidityAndComputeResult()
        {
            Expression e = new Expression();
            string input = form1.MainPanel_InputTextBox.Text;

            handleBullShitInput(ref input);
            e.unitForTrigonometryFunction = !form1.unitForFunction;
            e.setContent(input);
            e.preProcess();
            e.buildComputingTree();
            //check if expression is valid
            if (!e.checkOverallValidity())
            {
                string errorMessage = "Syntax error";
                TurnOnDisplayInvalidResultMode(errorMessage);
                return false;
            }
            //compute result
            double result = e.computeResult();
            if (!e.checkComputingValidity())
            {
                string errorMessage = "Calculating error";
                TurnOnDisplayInvalidResultMode(errorMessage);
                return false;
            }
            string text = (System.Math.Round(result,15)).ToString();
            form1.MainPanel_OutputTextbox.Text = text;

            //cachesNewMemory();
            //form1.on = true;
            return true;
        }
        static public void TurnOnDisplayInvalidResultMode(string errorMessage)
        {
            form1.MainPanel_OutputTextbox.Text = errorMessage;
            form1.invalidModeTimeoutTimer.Start();
            form1.invalidModeTimeLeft = form1.invalidModeTimeout;
            form1.onDisplayingResult = true;
        }
        static public void TurnOffDisplayInvalidResultMode()
        {
            form1.MainPanel_OutputTextbox.Text = string.Empty;
            form1.invalidModeTimeoutTimer.Stop();
            form1.onDisplayingResult = false;
        }
        static private void handleBullShitInput(ref string s)
        {
            int i = 0;
            s = s.Replace('x', '*');
        }
    }
    //open other form
    internal partial class StandardCalculatorControl
    {
        static public void ClearCalculatorScreen()
        {
            form1.MainPanel_InputTextBox.CurrentCursorPosition = 0;
            form1.MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
            form1.MainPanel_InputTextBox.Clear();

            form1.MainPanel_OutputTextbox.Text = string.Empty;
        }
        static public void OpenMatrixCalculator()
        {
            MatrixCalculator form = new MatrixCalculator();
            form.Show();
        }
        static public void OpenEquationSolving()
        {
            EquationSolving form = new EquationSolving();
            form.Show();
        }
        static public void OpenGraphCalculator()
        {

        }
        static public void OpenConverter()
        {

        }
    }
}