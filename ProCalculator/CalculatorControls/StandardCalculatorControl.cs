using CustomUserControls.MemoryBlock;
using CustomUserControls.RoundedButton;
using MatrixExpression;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

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
        static public void OpenNumberPanel(bool responsiveTurn)
        {
            if (form1.NumberPanel.isPlayingAnimation)
            {
                return;
            }
            form1.numberPanelOn = true;
            form1.disableResponsive = !responsiveTurn;
            form1.NumberPanel.Show();
            form1.MainPanel_OpenNumberPanelButton.InteriorColor = Color.FromArgb(150, 180, 94);
            Point NumbStart = new Point(0, form1.MainPanel.Height - form1.NumberPanel.Height);
            Point NumbEnd = new Point(0, form1.MainPanel.Height + 5);  
            //Check if Function Panel is open
            if (form1.funcPanelOn)
                NumbEnd.Y = form1.MainPanel.Height + form1.FunctionPanel.Height + 10;
            form1.NumberPanel.StartSliding(NumbStart, NumbEnd,20,3);

        }
        static public void CloseNumberPanel(bool responsiveTurn)
        {
            if (form1.NumberPanel.isPlayingAnimation)
            {
                return;
            }
            form1.disableResponsive = !responsiveTurn;
            form1.MainPanel_OpenNumberPanelButton.InteriorColor = Color.FromArgb(205, 235, 139);
            Point NumbStart = new Point();
            NumbStart.X = 0;
            if (form1.funcPanelOn)
            {
                NumbStart.Y = form1.MainPanel.Height + form1.FunctionPanel.Height + 10;
            }
            else
            {
                NumbStart.Y = form1.MainPanel.Height + 5;
            }
            Point NumbEnd = new Point(0, form1.MainPanel.Height - form1.NumberPanel.Height);
            form1.NumberPanel.StartSliding(NumbStart, NumbEnd, 20, 3);

            form1.numberPanelOn = false;
        }
        //func panel
        static public void OpenFuncPanel(bool responsiveTurn)
        {
            if (form1.FunctionPanel.isPlayingAnimation)
            {
                return;
            }
            form1.funcPanelOn = true;
            form1.disableResponsive = !responsiveTurn;
            form1.MainPanel_OpenFuncPanelButton.InteriorColor = Color.FromArgb(200, 187, 149);
            form1.FunctionPanel.Show();

            Point FuncStart = new Point(0, form1.MainPanel.Height-form1.FunctionPanel.Height);
            Point FuncEnd = new Point(0, form1.MainPanel.Height+5);

            form1.FunctionPanel.StartSliding(FuncStart, FuncEnd, 20,2);

            //Check if Number Panel is on
            if (form1.numberPanelOn)
            {
                Point NumbStart = new Point();
                NumbStart.X = 0;
                NumbStart.Y = FuncEnd.Y;

                Point NumbEnd = new Point();
                NumbEnd.X = 0;
                NumbEnd.Y = FuncEnd.Y + form1.FunctionPanel.Height + 5;

                form1.NumberPanel.StartSliding(NumbStart, NumbEnd, 20, 2);
            }
        }
        static public void CloseFuncPanel(bool responsiveTurn)
        {
            if (form1.FunctionPanel.isPlayingAnimation)
            {
                return;
            }
            form1.disableResponsive = !responsiveTurn;
            form1.MainPanel_OpenFuncPanelButton.InteriorColor = Color.FromArgb(255, 242, 204);

            Point FuncEnd = new Point(0, form1.MainPanel.Height - form1.FunctionPanel.Height);
            Point FuncStart = new Point(0, form1.MainPanel.Height + 5);

            form1.FunctionPanel.StartSliding(FuncStart, FuncEnd, 10, 3);

            //Check if Number Panel is on
            if (form1.numberPanelOn)
            {
                form1.NumberPanel.Location = FuncStart;
                
            }
            form1.funcPanelOn = false;
        }
        //meory panel
        static public void OpenMemoryPanel(bool responsiveTurn)
        {
            if (form1.MemoryPanel.isPlayingAnimation)
            {
                return;
            }
            form1.disableResponsive = !responsiveTurn;
            form1.MemoryPanel.Show();
            form1.MainPanel_OpenMemoryPanelButton.InteriorColor = Color.FromArgb(193, 151, 141);
            Point start = new Point(form1.MainPanel.Width - form1.MemoryPanel.Width,0);
            Point end = new Point(form1.MainPanel.Width + 5, 0);
            form1.MemoryPanel.StartSliding(start, end, 10, 2);  
            form1.memoryPanelOn = true;
        }
        static public void CloseMemoryPanel(bool responsiveTurn)
        {
            if (form1.MemoryPanel.isPlayingAnimation)
            {
                return;
            }
            form1.disableResponsive = !responsiveTurn;
            form1.MainPanel_OpenMemoryPanelButton.InteriorColor = Color.FromArgb(248, 206, 204);
            Point start = new Point(form1.MainPanel.Width - form1.MemoryPanel.Width, 0);
            Point end = new Point(form1.MainPanel.Width + 5, 0);
            form1.MemoryPanel.StartSliding(end, start, 10, 2);
            form1.memoryPanelOn = false;
        }

        //form opener
        static public void OpenFormOpenerPanel()
        {
            if (form1.FormOpenerPanel.isPlayingAnimation)
            {
                return;
            }
            form1.formOpenerPanelOn = true;
            form1.FormOpenerPanel.Height = form1.MemoryPanel.Height;
            form1.FormOpenerPanel.Show();
            form1.FormOpenerPanel.BringToFront();
            Point start = new Point(-243, 12);
            Point end = new Point(-10, 12);
            form1.FormOpenerPanel.StartSliding(start, end, 20, 2);
            form1.formOpenerPanelOn = true;
        }
        static public void CloseFormOpenerPanel()
        {
            if (form1.FormOpenerPanel.isPlayingAnimation)
            {
                return;
            }
            Point end = new Point(-243, 12);
            Point start = new Point(-10, 12);
            form1.FormOpenerPanel.StartSliding(start, end, 20, 2);
            form1.formOpenerPanelOn = false;
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
            if (!form1.darkModeOn)
            {
                form1.STATE_INV.ForeColor = Color.Black;
                form1.STATE_INV.BorderColor = Color.Black;
            }
            else
            {
                form1.STATE_INV.ForeColor = Color.White;
                form1.STATE_INV.BorderColor = Color.White;
            }
            
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
            if (!form1.darkModeOn)
            {
                form1.STATE_INV.BorderColor = Color.FromArgb(170, 170, 180);
            }
            else
            {
                form1.STATE_INV.BorderColor = form1.BackColor;
            }
            
            
        }
        static public void SwitchToRadianMode()
        {
            if (!form1.darkModeOn)
            {
                form1.STATE_Radian.ForeColor = Color.Black;
                form1.STATE_Radian.BorderColor = Color.Black;

                form1.STATE_Degree.ForeColor = Color.Gray;
                form1.STATE_Degree.BorderColor = Color.FromArgb(170, 170, 180);
            }
            else
            {
                form1.STATE_Radian.ForeColor = Color.White;
                form1.STATE_Radian.BorderColor = Color.White;

                form1.STATE_Degree.ForeColor = Color.Gray;
                form1.STATE_Degree.BorderColor = form1.BackColor;
            }
            
        }
        static public void SwitchToDegreeMode()
        {
            if (!form1.darkModeOn) { 
                form1.STATE_Degree.ForeColor = Color.Black;
                form1.STATE_Degree.BorderColor = Color.Black;

                form1.STATE_Radian.ForeColor = Color.Gray;
                form1.STATE_Radian.BorderColor = Color.FromArgb(170, 170, 180);
            }
            else
            {
                form1.STATE_Radian.ForeColor = Color.Gray;
                form1.STATE_Radian.BorderColor = form1.BackColor;

                form1.STATE_Degree.ForeColor = Color.White;
                form1.STATE_Degree.BorderColor = Color.White;
            }
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
        
        static public void SwitchToLightTheme()
        {
            form1.MainPanel_OpenFormOpenerPanelButton.Image = Properties.Resources.menuIcon_dark;
            form1.FormOpenerPanel_CloseButton.Image = Properties.Resources.menuIcon_dark;
            form1.BackColor = Color.FromArgb(247, 250, 252);
            //numb panel
            form1.NumberPanel.BorderWidth = 1;
            for (int i = 0; i < form1.NumberPanel.Controls.Count; i++)
            {
                RoundedButton b = form1.NumberPanel.Controls[i] as RoundedButton;
                if (b != null)
                {
                    b.TextColor = Color.Black;
                    b.InteriorColor = Color.FromArgb(250, 252, 255);
                    b.MouseClickBackColor = Color.FromArgb(243, 243, 250);
                    b.MouseHoveringBackColor = Color.FromArgb(245, 245, 250);
                    b.BorderColor = Color.FromArgb(170, 170, 180);
                    b.BorderWidth = 1;
                }
            }
            form1.CTRL_Ac.TextColor = Color.DarkRed;
            form1.CTRL_Back.TextColor = Color.DarkRed;

            form1.NUMB_0.InteriorColor = Color.White;
            form1.NUMB_0.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_0.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_1.InteriorColor = Color.White;
            form1.NUMB_1.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_1.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_2.InteriorColor = Color.White;
            form1.NUMB_2.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_2.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_3.InteriorColor = Color.White;
            form1.NUMB_3.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_3.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_4.InteriorColor = Color.White;
            form1.NUMB_4.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_4.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_5.InteriorColor = Color.White;
            form1.NUMB_5.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_5.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_6.InteriorColor = Color.White;
            form1.NUMB_6.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_6.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_7.InteriorColor = Color.White;
            form1.NUMB_7.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_7.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_8.InteriorColor = Color.White;
            form1.NUMB_8.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_8.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.NUMB_9.InteriorColor = Color.White;
            form1.NUMB_9.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.NUMB_9.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.MISC_Dot.InteriorColor = Color.White;
            form1.MISC_Dot.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.MISC_Dot.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            form1.FUNC_Negate.InteriorColor = Color.White;
            form1.FUNC_Negate.MouseHoveringBackColor = Color.FromArgb(251, 252, 253);
            form1.FUNC_Negate.MouseHoveringBackColor = Color.FromArgb(248, 249, 252);

            //func panel
            form1.FunctionPanel.BorderWidth = 0;
            for (int i = 0; i < form1.FunctionPanel.Controls.Count; i++)
            {
                RoundedButton b = form1.FunctionPanel.Controls[i] as RoundedButton;
                if (b != null)
                {
                    b.TextColor = Color.Black;
                    b.InteriorColor = Color.FromArgb(250, 252, 255);
                    b.MouseHoveringBackColor = Color.FromArgb(245, 245, 250);
                    b.MouseClickBackColor = Color.FromArgb(243, 243, 250);
                    b.BorderColor = Color.FromArgb(170,170,180);
                }
            }
            //exclusive
            if (form1.onINVMode)
            {
                form1.STATE_INV.BorderColor = Color.Black;
            }
            if (!form1.unitForFunction)
            {
                form1.STATE_Radian.BorderColor = Color.Black;
            }
            else
            {
                form1.STATE_Degree.BorderColor = Color.Black;
            }

            //main
            form1.MainPanel_NotifyOutput.ForeColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.MainPanel_OutputTextbox.ForeColor = Color.Black;
            form1.MainPanel_InputTextBox.ForeColor = Color.FromArgb(64,64,64);
            form1.MainPanel_PromptUserToEnter.ForeColor = Color.DimGray;

            form1.MainPanel_InputTextBox.BackColor = form1.BackColor;
            form1.MainPanel_InputTextBox.BlinkingCursorColor = Color.Black;
            form1.MainPanel_CurrentModeTitle.ForeColor = Color.Black;

            //formOpenre
            form1.FormOpenerPanel.InteriorColor = Color.FromArgb(247, 250, 252);

            form1.FormOpenerPanel_TitleLabel1.ForeColor = Color.Black ;
            form1.FormOpenerPanel_TitleLabel2.ForeColor = Color.Black;

            form1.FormOpenerPanel_ConverterOpener.TextColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.FormOpenerPanel_ConverterOpener.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro); 
            form1.FormOpenerPanel_ConverterOpener.MouseClickBackColor = Color.LightGray;

            form1.FormOpenerPanel_GraphOpener.TextColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.FormOpenerPanel_GraphOpener.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro);
            form1.FormOpenerPanel_GraphOpener.MouseClickBackColor = Color.LightGray;

            form1.FormOpenerPanel_EquationOpener.TextColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.FormOpenerPanel_EquationOpener.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro);
            form1.FormOpenerPanel_EquationOpener.MouseClickBackColor = Color.LightGray;

            form1.FormOpenerPanel_MatrixOpener.TextColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.FormOpenerPanel_MatrixOpener.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro);
            form1.FormOpenerPanel_MatrixOpener.MouseClickBackColor = Color.LightGray;

            form1.FormOpenerPanel_DarkTheme.TextColor = Color.FromKnownColor(KnownColor.ControlDark);
            form1.FormOpenerPanel_DarkTheme.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro);
            form1.FormOpenerPanel_DarkTheme.MouseClickBackColor = Color.FromKnownColor(KnownColor.ControlDarkDark);

            form1.FormOpenerPanel_LightTheme.TextColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
            form1.FormOpenerPanel_LightTheme.MouseHoveringBackColor = Color.FromKnownColor(KnownColor.Gainsboro);
            form1.FormOpenerPanel_LightTheme.MouseClickBackColor = Color.LightGray;

            form1.MemoryPanel_Title.ForeColor = Color.Black;
            TurnLightModeForMemory();
            CloseFormOpenerPanel();
        }
        static public void SwitchToDarkTheme()
        {
            form1.MainPanel_OpenFormOpenerPanelButton.Image = Properties.Resources.menuIcon_white;
            form1.FormOpenerPanel_CloseButton.Image = Properties.Resources.menuIcon_white;
            form1.BackColor = Color.FromArgb(30, 32, 39);
            //numb panel
            form1.NumberPanel.BorderWidth = 0;
            for (int i = 0; i < form1.NumberPanel.Controls.Count; i++)
            {
                RoundedButton b = form1.NumberPanel.Controls[i] as RoundedButton;
                if(b != null)
                {
                    b.TextColor = Color.White;
                    b.InteriorColor = Color.FromArgb(48, 50, 59);
                    b.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
                    b.MouseClickBackColor = Color.FromArgb(48, 50, 59);
                    b.BorderWidth = 0;                 
                }
            }
            form1.CTRL_Ac.TextColor = Color.Gold;
            form1.CTRL_Back.TextColor = Color.Gold;

            form1.NUMB_0.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_1.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_2.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_3.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_4.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_5.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_6.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_7.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_8.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.NUMB_9.InteriorColor = Color.FromArgb(57, 58, 67);
            form1.MISC_Dot.InteriorColor = Color.FromArgb(57, 58, 67);
            //func panel
            form1.FunctionPanel.BorderWidth = 0;
            for (int i = 0; i < form1.FunctionPanel.Controls.Count; i++)
            {
                RoundedButton b = form1.FunctionPanel.Controls[i] as RoundedButton;
                if (b != null)
                {
                    b.TextColor = Color.White;
                    b.InteriorColor = Color.FromArgb(48, 50, 59);
                    b.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
                    b.MouseClickBackColor = Color.FromArgb(48, 50, 59);
                    b.BorderColor = form1.BackColor;
                }
            }
            //exclusive
            if (form1.onINVMode)
            {
                form1.STATE_INV.BorderColor = Color.White;
            }
            if (!form1.unitForFunction)
            {
                form1.STATE_Radian.BorderColor = Color.White;
            }
            else
            {
                form1.STATE_Degree.BorderColor = Color.White;
            }

            //main
            form1.MainPanel_NotifyOutput.ForeColor = Color.WhiteSmoke;
            form1.MainPanel_OutputTextbox.ForeColor = Color.White;
            form1.MainPanel_InputTextBox.ForeColor = Color.WhiteSmoke;
            form1.MainPanel_PromptUserToEnter.ForeColor = Color.Gray;
            form1.MainPanel_InputTextBox.BackColor = form1.BackColor;
            form1.MainPanel_InputTextBox.BlinkingCursorColor = Color.WhiteSmoke;
            form1.MainPanel_CurrentModeTitle.ForeColor = Color.White;

            //formOpenre
            form1.FormOpenerPanel.InteriorColor = Color.FromArgb(40,40,50);

            form1.FormOpenerPanel_TitleLabel1.ForeColor = Color.White;
            form1.FormOpenerPanel_TitleLabel2.ForeColor = Color.White;

            form1.FormOpenerPanel_ConverterOpener.TextColor = Color.WhiteSmoke;
            form1.FormOpenerPanel_ConverterOpener.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_ConverterOpener.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.FormOpenerPanel_GraphOpener.TextColor = Color.WhiteSmoke;
            form1.FormOpenerPanel_GraphOpener.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_GraphOpener.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.FormOpenerPanel_EquationOpener.TextColor = Color.WhiteSmoke;
            form1.FormOpenerPanel_EquationOpener.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_EquationOpener.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.FormOpenerPanel_MatrixOpener.TextColor = Color.WhiteSmoke;
            form1.FormOpenerPanel_MatrixOpener.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_MatrixOpener.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.FormOpenerPanel_DarkTheme.TextColor = Color.DarkGray;
            form1.FormOpenerPanel_DarkTheme.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_DarkTheme.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.FormOpenerPanel_LightTheme.TextColor = Color.WhiteSmoke;
            form1.FormOpenerPanel_LightTheme.MouseHoveringBackColor = Color.FromArgb(57, 60, 68);
            form1.FormOpenerPanel_LightTheme.MouseClickBackColor = Color.FromArgb(48, 50, 59);

            form1.MemoryPanel_Title.ForeColor = Color.White;
            TurnDarkModeForMemory();
            CloseFormOpenerPanel();
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
            string text;
            if (result > System.Math.Pow(10, 18)){
                text = "A very large number...";
            }
            else
            {
                result = System.Math.Round(result, 10);
                text = result.ToString();
            }     

            form1.MainPanel_OutputTextbox.Text = text;
            form1.ans = text;
            AddToMemoryPanel(input, text.ToString());
            //cachesNewMemory();
            //form1.on = true;
            return true;
        }
        static public void NegateCurrentInput()
        {
            string input = form1.MainPanel_InputTextBox.Text;
            if (input != string.Empty)
            {
                string result = input;
                if (result[0] == '-' && result[1] == '(' && result[result.Length-1]==')')
                {
                    result = result.Substring(2,result.Length - 3);
                    form1.MainPanel_InputTextBox.Text = result;
                    form1.MainPanel_InputTextBox.CurrentCursorPosition -= 2;
                    form1.MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
                }
                else
                {
                    result = result.Insert(0, "-(");
                    result = result.Insert(result.Length, ")");
                    form1.MainPanel_InputTextBox.Text = result;
                    form1.MainPanel_InputTextBox.CurrentCursorPosition += 2;
                    form1.MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
                }
                
            }
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
            CloseFormOpenerPanel();
        }
        static public void OpenEquationSolving()
        {
            EquationSolving form = new EquationSolving();
            form.Show();
            CloseFormOpenerPanel();
        }
        static public void OpenGraphCalculator()
        {
            CloseFormOpenerPanel();
        }
        static public void OpenConverter()
        {
            CloseFormOpenerPanel();
        }
    }
    //memory
    internal partial class StandardCalculatorControl
    {
        static private List<Tuple<string, string>> history = new List<Tuple<string, string>>();
        static private List<MemoryBlock> memoryBlocks = new List<MemoryBlock>();

        static private void AddRoundedPanelsToList(MemoryBlock comp)
        {
            if (memoryBlocks.Count == 0)
            {
                comp.Location = new Point(3, 80);
                comp.Index = 1;
            }
            else
            {
                comp.Location = new Point(3, 80);
                comp.Index = memoryBlocks.Count + 1;

                for (int i = 0; i < memoryBlocks.Count; i++)
                {
                    memoryBlocks[i].Location = new Point(3, memoryBlocks[i].Location.Y + memoryBlocks[i].Height + 10);
                }
            }

            //handle event
            comp.quitButton.Click += (sender, arg) =>
            {
                Label lb = sender as Label;
                MemoryBlock parent = lb.Parent as MemoryBlock;
                removeMemoryBlockComponentAtPos(parent.Index - 1);
            };

            comp.Click += (sender, arg) =>
            {
                MemoryBlock lb = sender as MemoryBlock;             
                DialogResult r = MessageBox.Show("Load from memory?", "Load from memory", MessageBoxButtons.YesNoCancel);
                if(r == DialogResult.Yes)
                {
                    ClearCalculatorScreen();
                    InsertContentAtCursor(lb.Input.Text);
                    form1.MainPanel_OutputTextbox.Text = lb.Output.Text.Substring(2);
                }
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
            else
            {
                updateMemoryBlockPositionStartAfterPos(pos - 1);
            }
        }
        static public void updateMemoryBlockPositionStartAfterPos(int startPos)
        {
            if (startPos >= memoryBlocks.Count - 1)
            {
                for (int i = startPos; i >= 0; i--)
                {
                    int posY = memoryBlocks[i].Location.Y - memoryBlocks[i].Height - 10;
                    memoryBlocks[i].Location = new Point(0, posY);
                }
            }
            else
            {
                for (int i = startPos; i >= 0; i--)
                {
                    int posY = memoryBlocks[i + 1].Location.Y + memoryBlocks[i + 1].Height + 10;
                    memoryBlocks[i].Location = new Point(0, posY);
                }
            }
        }
        static public void AddToMemoryPanel(string input, string output)
        {
            Tuple<string, string> inputOutput = new Tuple<string, string>(input, output);
            MemoryBlock comp = new MemoryBlock();

            comp.Width = form1.MemoryPanel.Width - 5;
            form1.MemoryPanel.Controls.Add(comp);
            //Display om-screen memory block
            var temp = inputOutput;
            string inputString = temp.Item1;
            string outputString = "= " + temp.Item2;

            //Saving input and output to the queue
            history.Add(inputOutput);
            AddRoundedPanelsToList(comp);

            MemoryBlock block = memoryBlocks[memoryBlocks.Count - 1];
            //block.Visible = true;
            block.Controls[0].Text = inputString;
            block.Controls[1].Text = outputString;

            if (form1.darkModeOn)
            {
                comp.Output.ForeColor = Color.White;
                comp.BorderColor = Color.WhiteSmoke;             
            }
            comp.Input.ForeColor = Color.Gray;
            comp.Output.BackColor = form1.BackColor;
        }
        static public void ClearMemory()
        {
            foreach (MemoryBlock comp in memoryBlocks)
                comp.Dispose();
            history.Clear();
            memoryBlocks.Clear();
            updateMemoryBlockPositionStartAfterPos(0);
        }

        static public void TurnDarkModeForMemory()
        {
            for(int i = 0;i < memoryBlocks.Count; i++)
            {
                memoryBlocks[i].Output.ForeColor = Color.White;
                memoryBlocks[i].Output.BackColor = form1.BackColor;
                memoryBlocks[i].BorderColor = Color.WhiteSmoke;
            }
        }
        static public void TurnLightModeForMemory()
        {
            for (int i = 0; i < memoryBlocks.Count; i++)
            {
                memoryBlocks[i].Output.ForeColor = Color.Black;
                memoryBlocks[i].Output.BackColor = form1.BackColor;
                memoryBlocks[i].BorderColor = Color.Gray;
            }
        }
        static public void ResizeMemoryBlock()
        {
            for (int i = 0; i < memoryBlocks.Count; i++)
            {
                memoryBlocks[i].Width = form1.MemoryPanel.Width - 5;
            }
        }
    }
}