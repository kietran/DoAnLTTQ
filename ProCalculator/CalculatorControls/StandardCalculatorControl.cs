using CustomUserControls.MemoryBlock;
using CustomUserControls.ResultLogComponent;
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
        static private List<Tuple<string, string>> history = new List<Tuple<string, string>>();
        static private List<MemoryBlock> memoryBlocks = new List<MemoryBlock>();

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

        //memory panel handle 

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

        static private void AddRoundedPanelsToList(MemoryBlock comp)
        {
            if (memoryBlocks.Count == 0)
            {
                comp.Location = new Point(0, 80);
                comp.Index = 1;
            }
            else
            {
                MemoryBlock last = memoryBlocks[memoryBlocks.Count - 1];
                comp.Location = new Point(0, last.Location.Y + last.Height + 10);
                comp.Index = memoryBlocks.Count + 1;
            }
            //handle event
            comp.quitButton.Click += (sender, arg) =>
            {
                Label lb = sender as Label;
                MemoryBlock parent = lb.Parent as MemoryBlock;
                removeMemoryBlockComponentAtPos(parent.Index - 1);
            };
            memoryBlocks.Add(comp);
        }

        static public void removeMemoryBlockComponentAtPos(int pos)
        {
            //handle location
            if (memoryBlocks.Count == 0)
            {
                return;
            }
            memoryBlocks.RemoveRange(pos, 1);
            history.RemoveRange(pos, 1);
            for (int i = pos; i < memoryBlocks.Count; i++)
            {
                memoryBlocks[i].Index = i + 1;
            }
            if (memoryBlocks.Count == 0)
            {
                return;
            }
            if (pos == 0)
            {
                memoryBlocks[0].Location = new Point(0, 80);
                updateMemoryBlockPositionStartAfterPos(0);
            }
            else
            {
                updateMemoryBlockPositionStartAfterPos(pos - 1);
            }
        }

        static public void updateMemoryBlockPositionStartAfterPos(int startPos)
        {
            for (int i = startPos + 1; i < memoryBlocks.Count; i++)
            {
                int posY = memoryBlocks[i - 1].Location.Y + memoryBlocks[i - 1].Height + 10;
                memoryBlocks[i].Location = new Point(0, posY);
            }
        }
        static public void AddToMemoryPanel(string input, string output)
        {
            Tuple<string, string> inputOutput = new Tuple<string, string>(input, output);
            MemoryBlock comp = new MemoryBlock();
            form1.MemoryPanel.Controls.Add(comp);
            //Display om-screen memory block
            var temp = inputOutput;
            string inputString = temp.Item1;
            string outputString = temp.Item2;

            //Saving input and output to the queue
            history.Add(inputOutput);
            AddRoundedPanelsToList(comp);

            //
            MemoryBlock block = memoryBlocks[memoryBlocks.Count-1];
            //block.Visible = true;
            block.Controls[0].Text = inputString;
            block.Controls[1].Text = outputString;
        }

        static public void ClearMemory()
        {
            foreach (MemoryBlock comp in memoryBlocks)
                comp.Dispose();
            history.Clear();
            memoryBlocks.Clear();
            updateMemoryBlockPositionStartAfterPos(0);
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
            form1.MemoryPanel.Height = form1.Height - 50;
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
            AddToMemoryPanel(input, text.ToString());

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