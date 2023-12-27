using CustomUserControls.RoundedPanel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCalculator
{
    //insert + panel open/close
    internal partial class StandardCalculatorControl
    {
        static private StandardCalculator form1;

        //Save calculated history
        //First-item: input, second-item: output
        static private Queue<Tuple<string, string>> history = new Queue<Tuple<string, string>>();
        static private List<RoundedPanel> memoryBlocks = new List<RoundedPanel>();
        static private int index = 0;

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
            form1.MainPanel_OpenNumberPanelButton.BackColor = Color.FromArgb(205, 239, 139);
            //Check if Function Panel is open
            if (!form1.funcPanelOn)
                form1.NumberPanel.Location = new Point(0, 281);
            form1.NumberPanel.Show();
            UpdateMemoryPanelHeight();
        }
        static public void CloseNumberPanel()
        {
            form1.MainPanel_OpenNumberPanelButton.BackColor = Color.White;
            //Set back to original position
            form1.NumberPanel.Location = new Point(0, 447);
            form1.NumberPanel.Hide();
            form1.MemoryPanel.Height -= form1.NumberPanel.Height;
        }
        //func panel
        static public void OpenFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.BackColor = Color.FromArgb(255, 240, 204);
            //Check if Number Panel is in first place
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(0, 447);
            form1.FunctionPanel.Show();
            UpdateMemoryPanelHeight();
        }
        static public void CloseFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.BackColor = Color.White;
            //Check if Number Panel is still open
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(0, 281);
            form1.FunctionPanel.Hide();
            form1.MemoryPanel.Height -= form1.FunctionPanel.Height;
        }
        //memory panel
        static public void OpenMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.BackColor = Color.FromArgb(248, 206, 204);
            UpdateMemoryPanelHeight();
            form1.MemoryPanel.Show();
        }
        static public void CloseMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.BackColor = Color.White;
            form1.MemoryPanel.Hide();
        }
        static public void UpdateMemoryPanelHeight()
        {
            form1.MemoryPanel.Height = form1.Height - 50;
        }

        static private void AddRoundedPanelsToList()
        {
            foreach (RoundedPanel p in form1.MemoryPanel.Controls.OfType<RoundedPanel>())
                memoryBlocks.Add(p);
        }

        static public void AddToMemoryPanel(string input, string output)
        {
            Tuple<string, string> inputOutput = new Tuple<string, string>(input, output);
            //Display om-screen memory block
            var temp = inputOutput;
            string inputString = temp.Item1;
            string outputString = temp.Item2;

            //Saving input and output to the queue
            if (index >= 10)
            {
                index = 0;
                history.Dequeue();
            }
            history.Enqueue(inputOutput);
            index++;
            AddRoundedPanelsToList();

            //
            RoundedPanel block = memoryBlocks[index - 1];
            block.Visible = true;
            block.Controls[0].Text = inputString;
            block.Controls[1].Text = outputString;
        }   

        static public void ClearMemory()
        {
            //Disappear all blocks
            foreach (RoundedPanel p in form1.MemoryPanel.Controls.OfType<RoundedPanel>())
                p.Visible = false;

            //Clear memory queue and reset index
            history.Clear();
            index = 0;
        }

        static public void MemoryBlockClick(RoundedPanel p1)
        {
            ClearCalculatorScreen();
            InsertContentAtCursor(p1.Controls[0].Text);
            form1.MainPanel_OutputTextbox.Text = p1.Controls[1].Text;
        }

        //INV Mode Toggle
        static public void Toggle_INVMode()
        {
            form1.FUNC_Sin.Text = "sin⁻¹";
            form1.FUNC_Cos.Text = "cos⁻¹";
            form1.FUNC_Tan.Text = "tan⁻¹";
            form1.FUNC_Logarit.Text = "10^";
            form1.FUNC_Ln.Text = "eˣ";
            form1.FUNC_Sqrt.Text = "x²";
        }
        static public void Toggle_NormalMode()
        {
            form1.FUNC_Sin.Text = "sin";
            form1.FUNC_Cos.Text = "cos";
            form1.FUNC_Tan.Text = "tan";
            form1.FUNC_Logarit.Text = "log";
            form1.FUNC_Ln.Text = "ln";
            form1.FUNC_Sqrt.Text = "√";
        }
        static public void RadianMode()
        {

        }
        static public void DegreeMode()
        {

        }
    }
    //calculating
    internal partial class StandardCalculatorControl
    {
        static public bool CheckValidityAndComputeResult()
        {
            Expression e = new Expression();
            string input = form1.MainPanel_InputTextBox.Text;

            handleBullShitInput(input);
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
            form1.MainPanel_OutputTextbox.Text = result.ToString();
            AddToMemoryPanel(input, result.ToString());
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
        static private void handleBullShitInput(string s)
        {
            int i = 0;
            while (i < s.Length)
            {
                if (s[i]==' ')
                {
                    s = s.Substring(0,i)+s.Remove(i);
                }
                i++;
            }
        }
    }
    internal partial class StandardCalculatorControl
    {
        static public void ClearCalculatorScreen()
        {
            form1.MainPanel_InputTextBox.CurrentCursorPosition = 0;
            form1.MainPanel_InputTextBox.Clear();

            form1.MainPanel_OutputTextbox.Text = string.Empty;
            form1.Invalidate();
        }

    }
}