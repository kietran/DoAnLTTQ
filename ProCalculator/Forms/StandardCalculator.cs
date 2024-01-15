using CustomUserControls.RoundedButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCalculator
{
    public partial class StandardCalculator : Form
    {
        //responsive
        public bool disableResponsive = false;
        public bool finishedLoading = false;
        //panel mode
        public bool numberPanelOn = false, funcPanelOn = false, memoryPanelOn = false;
        public bool formOpenerPanelOn = false;
        bool dockingOn = false;
        public bool darkModeOn = false;

        //calculating
        public bool onINVMode = false;
        public bool unitForFunction = false; //false: RAD, true: DEG
        public string ans = string.Empty;

        //display invalid result timeout
        public bool onDisplayingResult = false;
        public int invalidModeTimeout = 10000; //in ms
        public int invalidModeTimeLeft;
        public Timer invalidModeTimeoutTimer;

        //fake label onTop of in/output
        bool fakeInputLabelOn = true, fakeOutputLabelOn = true;

        //hold button
        bool isHoldingButton = false;
        Timer holdButtonTimer = null;
        RoundedButton currentlyHoldingButton = null;
        /// <INIT>
        /// 
        /// </summary>
        public StandardCalculator()
        {
            finishedLoading = false;
            KeyPreview = true;
            StandardCalculatorControl.Init(this);
            InitializeComponent();
            initInputTextbox();
            initOutputTextbox();
            initHoldEventForButton();
            //tmr for 
            invalidModeTimeoutTimer = new Timer();
            invalidModeTimeoutTimer.Interval = 1000;//check for each 100ms
            invalidModeTimeoutTimer.Tick += (sender, args) =>
            {
                invalidModeTimeLeft -= invalidModeTimeout;
                if(invalidModeTimeLeft <= 0)
                {
                    StandardCalculatorControl.TurnOffDisplayInvalidResultMode();
                }
            };

            holdButtonTimer = new Timer();    
            holdButtonTimer.Tick += (sender, args) =>
            {
                if (isHoldingButton)
                {
                    string content = currentlyHoldingButton.TextContent;
                    if(content == "Back")
                    {
                        StandardCalculatorControl.DeleteContentAtCursor();
                    }
                    else
                    {
                        StandardCalculatorControl.InsertContentAtCursor(content);
                    }
                    holdButtonTimer.Interval = 75;
                }
            };
            GotFocus += (sender, args) =>
            {
                MainPanel_InputTextBox.ShowBlinkingCursor();
            };
            LostFocus += (sender, args) =>
            {
                MainPanel_InputTextBox.HideBlinkingCursor();
            };

            //steal focus mechanism
            Select();

        }
        private void StandardCalculator_Load(object sender, EventArgs e)
        {
            NumberPanel.BringToFront();
            FunctionPanel.BringToFront();
            MainPanel.BringToFront();
            MemoryPanel.SendToBack();

            FunctionPanel.Location = new Point(0, MainPanel.Height - FunctionPanel.Height);
            NumberPanel.Location = new Point(0, MainPanel.Height - NumberPanel.Height);
            MemoryPanel.Location = new Point(MainPanel.Width - MemoryPanel.Width,0);

            FunctionPanel.Hide();
            MemoryPanel.Hide();
            FormOpenerPanel.Hide();

            StandardCalculatorControl.OpenNumberPanel(false);
            StandardCalculatorControl.TurnOnNormalModeForFuncPanel();
            StandardCalculatorControl.SwitchToRadianMode();
            MainPanel_OnTopButtonWithDeclineMark.Visible = false;

            Width = MainPanel.Width + 18;
            Height = MainPanel.Height + NumberPanel.Height + 5 + 47;
            finishedLoading = true;
        }
        private void initInputTextbox()
        {
            MainPanel_InputTextBox.Click += (sender, args) =>
            {
                MainPanel_InputTextBox.CurrentCursorPosition = MainPanel_InputTextBox.SelectionStart;
                MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
                MainPanel_InputTextBox.ShowBlinkingCursor();
            };
            MainPanel_InputTextBox.TextChanged += (sender, args) =>
            {
                if (fakeInputLabelOn)
                {
                    fakeInputLabelOn = false;
                    MainPanel_PromptUserToEnter.Hide();
                }
            };
            MainPanel_InputTextBox.GotFocus += (sender, args) =>
            {
                if (fakeInputLabelOn)
                {
                    MainPanel_PromptUserToEnter.Hide();
                    fakeInputLabelOn = false;
                }
                MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
            };
            MainPanel_InputTextBox.LostFocus += (sender, args) =>
            {
                if (MainPanel_InputTextBox.Text.Length == 0)
                {
                    if (!fakeInputLabelOn)
                    {
                        MainPanel_PromptUserToEnter.Show();
                        fakeInputLabelOn = true;
                    }
                }
            };
            MainPanel_PromptUserToEnter.Click += (sender, args) =>
            {
                MainPanel_InputTextBox.Select();
                MainPanel_InputTextBox.ShowBlinkingCursor();
            };
            MainPanel_InputTextBox.CurrentCursorPositionChanged += (sender, args) =>
            {
                int lasPos = MainPanel_InputTextBox.GetCharIndexFromPosition(new Point(340, 30));
                if (lasPos<MainPanel_InputTextBox.Text.Length-1)
                {
                    MainPanel_ThereIsMore.Show();
                }
                else
                {
                    MainPanel_ThereIsMore.Hide();
                }
            };
        }
        private void initOutputTextbox()
        {
            MainPanel_OutputTextbox.TextChanged += (sender, args) =>
            {
                if (MainPanel_OutputTextbox.Text.Length == 0)
                {
                    if (!fakeOutputLabelOn)
                    {
                        MainPanel_NotifyOutput.Show();
                        fakeOutputLabelOn = true;
                    }
                }
                else
                {
                    if (fakeOutputLabelOn)
                    {
                        MainPanel_NotifyOutput.Hide();
                        fakeOutputLabelOn = false;
                    }
                }
            };
        }

        private void initHoldEventForButton()
        {
            CTRL_Back.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = CTRL_Back;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            CTRL_Back.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            CTRL_Back.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_0.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_0;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_0.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_0.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_1.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_1;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_1.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_1.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };

            // Repeat the above structure for NUMB_2 through NUMB_9, adjusting the references accordingly
            // For NUMB_2
            NUMB_2.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_2;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_2.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_2.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_3.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_3;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_3.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_3.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_4.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_4;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_4.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_4.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };

            // For NUMB_5
            NUMB_5.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_5;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_5.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_5.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_6.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_6;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_6.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_6.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_7.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_7;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_7.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_7.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };

            // For NUMB_8
            NUMB_8.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_8;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_8.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_8.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };

            // For NUMB_9
            NUMB_9.MouseDown += (sender, args) =>
            {
                isHoldingButton = true;
                currentlyHoldingButton = NUMB_9;
                holdButtonTimer.Enabled = true; holdButtonTimer.Interval = 500;
            };
            NUMB_9.MouseUp += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
            NUMB_9.MouseLeave += (sender, args) =>
            {
                isHoldingButton = false;
                holdButtonTimer.Enabled = false;
            };
        }
        /// <open panel>
        /// open panel
        /// </open panel>
        /// 
        private void MainPanel_OpenNumberPanelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!numberPanelOn)
            {
                StandardCalculatorControl.OpenNumberPanel(false);
            }
            else
            {
                StandardCalculatorControl.CloseNumberPanel(false);
            }
        }
        private void MainPanel_OpenFuncPanelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!funcPanelOn)
            {

                StandardCalculatorControl.OpenFuncPanel(false);
            }
            else
            {
                StandardCalculatorControl.CloseFuncPanel(false);
            }
        }

        private void MainPanel_OpenMemoryPanelButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (!memoryPanelOn)
            {
                StandardCalculatorControl.OpenMemoryPanel(false);
            }
            else
            {
                StandardCalculatorControl.CloseMemoryPanel(false);
            }
        }
        private void FormOpenerPanel_CloseButton_Click(object sender, EventArgs e)
        {
            if (formOpenerPanelOn)
            {
                StandardCalculatorControl.CloseFormOpenerPanel();
            }
            else
            {
                Console.WriteLine("Error in form opener");
            }
            formOpenerPanelOn = false;
        }
        private void MainPanel_OpenFormOpenerPanelButton_Click(object sender, EventArgs e)
        {
            if (!formOpenerPanelOn)
            {
                StandardCalculatorControl.OpenFormOpenerPanel();
            }
            else
            {
                Console.WriteLine("Error in form opener");
            }
            formOpenerPanelOn = true;
        }
        //on top
        private void MainPanel_OnTopButton_Click(object sender, EventArgs e)
        {
            if (!dockingOn)
            {
                StandardCalculatorControl.TurnOnDockingMode();
            }
            else
            {
                Console.WriteLine("? Error in On top button");
            }
            dockingOn = true;
        }
        private void MainPanel_OnTopButtonWithDeclineMark_Click(object sender, EventArgs e)
        {
            if (dockingOn)
            {
                StandardCalculatorControl.TurnOffDockingMode();
            }
            else
            {
                Console.WriteLine("? Error in On top with decline button");
            }
            dockingOn = false;
        }
        /// <Insert from keyboard>
        /// 
        /// <insert>
        private void StandardCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            //keys that is the same at all mode
            //numpad
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                //number case
                string key = e.KeyCode.ToString();
                if (key.Length > 1)
                    key = key.Replace("NumPad", "").Replace("D", "");
                StandardCalculatorControl.InsertContentAtCursor(key);
                return;
            }

            //dot, comma, backslash           
            else if (e.KeyCode == Keys.Oemcomma)
            {
                StandardCalculatorControl.InsertContentAtCursor(",");
            }
            else if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.Divide)
            {
                StandardCalculatorControl.InsertContentAtCursor("/");
            }
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                StandardCalculatorControl.InsertContentAtCursor(".");
            }

            //+,-
            else if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                StandardCalculatorControl.InsertContentAtCursor("+");
            }
            else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                StandardCalculatorControl.InsertContentAtCursor("-");
                return;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                StandardCalculatorControl.ClearCalculatorScreen();
            }

            //* at the right
            else if (e.KeyCode == Keys.Multiply)
            {
                StandardCalculatorControl.InsertContentAtCursor("x");
            }
            //char
            else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                StandardCalculatorControl.InsertContentAtCursor(e.KeyCode.ToString().ToLower());
            }

            //left, right
            else if (e.KeyCode.Equals(Keys.Right))
            {
                if (MainPanel_InputTextBox.CurrentCursorPosition < MainPanel_InputTextBox.Text.Length)
                {
                    MainPanel_InputTextBox.CurrentCursorPosition++;
                }
                else
                {
                    MainPanel_InputTextBox.CurrentCursorPosition = 0;
                }
                MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
            }
            else if (e.KeyCode.Equals(Keys.Left))
            {
                if (MainPanel_InputTextBox.CurrentCursorPosition > 0)
                {
                    MainPanel_InputTextBox.CurrentCursorPosition--;
                }
                else
                {
                    MainPanel_InputTextBox.CurrentCursorPosition = MainPanel_InputTextBox.Text.Length;
                }
                MainPanel_InputTextBox.ImmediatelyDrawBlinkingCursor();
            }

            //enter 
            else if (e.KeyCode == Keys.Enter)
            {
                StandardCalculatorControl.CheckValidityAndComputeResult();
                return;
            }
            else if( e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                StandardCalculatorControl.DeleteContentAtCursor();
                return;
            }

            ///Key that differ betwwen mode
            //shift mode mode
            if (ModifierKeys == Keys.Shift)
            {
                if (e.KeyCode == Keys.D1)
                {
                    StandardCalculatorControl.InsertContentAtCursor("!");
                }
                else if (e.KeyCode == Keys.D5)
                {
                    StandardCalculatorControl.InsertContentAtCursor("%");
                }
                else if (e.KeyCode == Keys.D6)
                {
                    StandardCalculatorControl.InsertContentAtCursor("^");
                }
                else if (e.KeyCode == Keys.D8)
                {
                    StandardCalculatorControl.InsertContentAtCursor("*");
                }
                else if (e.KeyCode == Keys.D9)
                {
                    StandardCalculatorControl.InsertContentAtCursor("(");
                }                  
                else if (e.KeyCode == Keys.D0)
                {
                    StandardCalculatorControl.InsertContentAtCursor(")");
                }               
            }
            //normal mode
            else
            {
                if (e.KeyCode>=Keys.D0 && e.KeyCode<=Keys.D9)
                {
                    //number case
                    string key = e.KeyCode.ToString();
                    if (key.Length > 1)
                        key = key.Replace("NumPad", "").Replace("D", "");
                    StandardCalculatorControl.InsertContentAtCursor(key);
                    return;
                }
            }
            
        }
        /// <insert>
        /// 
        /// <insert>

        //Insert Number Panel
        private void NUMB_0_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("0");
        }
        private void NUMB_1_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("1");
        }
        private void NUMB_2_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("2");
        }
        private void NUMB_3_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("3");
        }
        private void NUMB_4_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("4");
        }
        private void NUMB_5_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("5");
        }
        private void NUMB_6_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("6");
        }
        private void NUMB_7_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("7");
        }
        private void NUMB_8_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("8");
        }
        private void NUMB_9_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("9");
        }
        private void FUNC_Percentage_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.NegateCurrentInput();
        }
        private void OPER_Div_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("/");
        }
        private void OPER_Mul_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("x");
        }
        private void OPER_Plus_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("+");
        }
        private void OPER_Sub_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("-");
        }
        private void MISC_Dot_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor(".");
        }

        //Insert Function Panel
        private void FUNC_Sin_Click(object sender, EventArgs e)
        {
            if (onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("asin(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("sin(");
            }
        }
        private void FUNC_Cos_Click(object sender, EventArgs e)
        {

            if (onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("acos(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("cos(");
            }
        }
        private void FUNC_Tan_Click(object sender, EventArgs e)
        {
            if (onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("atan(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("tan(");
            }
        }
        private void MISC_OpenBracket_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("(");
        }
        private void MISC_CloseBracket_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor(")");
        }
        private void FUNC_Pow_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("^");
        }
        private void FUNC_Sqrt_Click(object sender, EventArgs e)
        {
            if (!onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("√(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("^2");
            }
        }
        private void FUNC_Not_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("!");
        }
        private void FUNC_Pi_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("π");
        }
        private void FUNC_EulerNumber_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("e");
        }
        private void STATE_INV_Click(object sender, EventArgs e)
        {
            if (!onINVMode)
            {
                StandardCalculatorControl.TurnOnINVModeForFuncPanel();
            }
            else
            {
                StandardCalculatorControl.TurnOnNormalModeForFuncPanel();
            }
            onINVMode = !onINVMode;
        }

        private void FUNC_Logarit_Click(object sender, EventArgs e)
        {
            if (!onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("log(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("10^");
            }
            
        }

        private void FUNC_Ln_Click(object sender, EventArgs e)
        {
            if (!onINVMode)
            {
                StandardCalculatorControl.InsertContentAtCursor("ln(");
            }
            else
            {
                StandardCalculatorControl.InsertContentAtCursor("e^");
            }
        }
        private void STATE_Radian_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.SwitchToRadianMode();
            unitForFunction = false;
        }

        private void CTRL_Ac_MouseUp(object sender, MouseEventArgs e)
        {
            StandardCalculatorControl.ClearCalculatorScreen();
        }

        private void FormOpenerPanel_MatrixOpener_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.OpenMatrixCalculator();
        }

        private void FormOpenerPanel_EquationOpener_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.OpenEquationSolving();
        }

        private void FormOpenerPanel_GraphOpener_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.OpenGraphCalculator();
        }
        private void FormOpenerPanel_ConverterOpener_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.OpenConverter();
        }

        private void FormOpenerPanel_LightTheme_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.SwitchToLightTheme();
            darkModeOn = false;
        }

        private void FormOpenerPanel_DarkTheme_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.SwitchToDarkTheme();
            darkModeOn = true;
        }

        private void FunctionPanel_LocationChanged(object sender, EventArgs e)
        {
            if (!disableResponsive)
            {
                return;
            }
            //check if need to update form's size
            int currentHeight = System.Math.Max(MainPanel.Height, NumberPanel.Location.Y + NumberPanel.Height);
            currentHeight = System.Math.Max(currentHeight, FunctionPanel.Location.Y + FunctionPanel.Height);
            Height = currentHeight+47;

            //re-enable responsive
            if (funcPanelOn)
            {
                if (FunctionPanel.Location.Y >= MainPanel.Height + 5)
                {
                    disableResponsive = false;
                }
            }
            else
            {
                if (FunctionPanel.Location.Y <= MainPanel.Height - FunctionPanel.Height)
                {
                    disableResponsive = false;
                    FunctionPanel.Hide();
                }
            }
            
        }

        private void NumberPanel_LocationChanged(object sender, EventArgs e)
        {
            if(!disableResponsive) { 
                return; 
            }
            int currentHeight = System.Math.Max(MainPanel.Height, NumberPanel.Location.Y + NumberPanel.Height);
            currentHeight = System.Math.Max(currentHeight, FunctionPanel.Location.Y + FunctionPanel.Height);
            Height = currentHeight+47;

            if (numberPanelOn)
            {
                if (funcPanelOn)
                {
                    if (NumberPanel.Location.Y >= MainPanel.Height + FunctionPanel.Height + 5)
                    {
                        disableResponsive = false;
                    }
                }
                else
                {
                    if (NumberPanel.Location.Y >= MainPanel.Height + 5)
                    {
                        disableResponsive = false;
                    }
                }
                
            }
            else
            {
                if (NumberPanel.Location.Y <= MainPanel.Height - NumberPanel.Height)
                {
                    disableResponsive = false;
                    NumberPanel.Hide();
                }
            }
        }

        private void MemoryPanel_LocationChanged(object sender, EventArgs e)
        {
            if (!disableResponsive)
            {
                return;
            }
            int currentWidth = System.Math.Max(MemoryPanel.Width + MemoryPanel.Location.X, MainPanel.Width);
            Width = currentWidth + 18;
            if (memoryPanelOn)
            {
                if (MemoryPanel.Location.X >= MainPanel.Width + 5)
                {
                    disableResponsive = false;
                }
            }
            else
            {
                if (MemoryPanel.Location.X <= MainPanel.Width - MemoryPanel.Width)
                {
                    disableResponsive = false;
                    MemoryPanel.Hide();
                }
            }
           
        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {
            if (ans != string.Empty)
            {
                StandardCalculatorControl.InsertContentAtCursor(ans);
            }
        }

        private void CTRL_Equal_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.CheckValidityAndComputeResult();
        }

        private void MainPanel_SizeChanged(object sender, EventArgs e)
        {
            Size originMainPanel = new Size(415, 275);
            //scale mainPanel
            double widthScalingFactor = MainPanel.Width / originMainPanel.Width;
            double heightScalingFactor = MainPanel.Height / originMainPanel.Height;

            MainPanel_DecorLine1.Width = MainPanel.Width - 25;
            MainPanel_DecorLine2.Width = MainPanel.Width - 25;

            MainPanel_DecorLine3.Width = MainPanel.Width - 45;
            MainPanel_DecorLine4.Width = MainPanel.Width - 45;

            //scale vertically
            MainPanel_DecorLine4.Location = new Point(MainPanel_DecorLine4.Location.X, MainPanel.Height - 60);
            MainPanel_DecorLine3.Location = new Point(MainPanel_DecorLine4.Location.X, MainPanel.Height - 61);

            //font

            MainPanel_InputTextBox.Width = MainPanel.Width - 75;
            MainPanel_PromptUserToEnter.Width = MainPanel.Width - 75;

            MainPanel_ThereIsMore.Location = new Point(MainPanel_DecorLine1.Location.X + MainPanel_DecorLine1.Width - MainPanel_ThereIsMore.Width, MainPanel_ThereIsMore.Location.Y);
            MainPanel_InputTextBox.Width = MainPanel.Width - 75;

            int y1 = MainPanel_InputTextBox.Location.Y + MainPanel_InputTextBox.Height;
            int y2 = MainPanel_DecorLine3.Location.Y;
            int y3 = MainPanel_OutputTextbox.Height;
            MainPanel_OutputTextbox.Location = new Point(MainPanel_DecorLine1.Location.X + MainPanel_DecorLine1.Width - MainPanel_OutputTextbox.Width, (y1 + y2 - y3) / 2);
            MainPanel_NotifyOutput.Location = MainPanel_OutputTextbox.Location;

            Size formOpenerButtonOrigin = new Size(45, 30);

            MainPanel_OpenFuncPanelButton.Width = Convert.ToInt32(formOpenerButtonOrigin.Width * widthScalingFactor);
            MainPanel_OpenMemoryPanelButton.Width = Convert.ToInt32(formOpenerButtonOrigin.Width * widthScalingFactor);
            MainPanel_OpenNumberPanelButton.Width = Convert.ToInt32(formOpenerButtonOrigin.Width * widthScalingFactor);

            MainPanel_OpenMemoryPanelButton.Location = new Point(MainPanel_DecorLine1.Location.X + MainPanel_DecorLine1.Width - MainPanel_OpenFuncPanelButton.Width, MainPanel_DecorLine4.Location.Y + 15);
            MainPanel_OpenFuncPanelButton.Location = new Point(MainPanel_OpenMemoryPanelButton.Location.X - MainPanel_OpenFuncPanelButton.Width - 10, MainPanel_OpenMemoryPanelButton.Location.Y);
            MainPanel_OpenNumberPanelButton.Location = new Point(MainPanel_OpenFuncPanelButton.Location.X - MainPanel_OpenFuncPanelButton.Width - 10, MainPanel_OpenMemoryPanelButton.Location.Y);

            MainPanel_OnTopButton.Location = new Point(MainPanel_OnTopButton.Location.X, MainPanel_DecorLine3.Location.Y + 15);
            MainPanel_OnTopButtonWithDeclineMark.Location = new Point(MainPanel_OnTopButtonWithDeclineMark.Location.X, MainPanel_DecorLine3.Location.Y + 2);

            //function panel
            FunctionPanel.Width = MainPanel.Width;
            NumberPanel.Width = MainPanel.Width;
        }

        private void FunctionPanel_SizeChanged(object sender, EventArgs e)
        {
            int offsetX = 5, offsetY = 5;
            //scale mainPanel            

            Size buttonNewSize = new Size((FunctionPanel.Width-6*offsetX)/5, (FunctionPanel.Height - 4 * offsetX)/3);
            //size
            foreach(Control c in FunctionPanel.Controls)
            {
                c.Size = buttonNewSize;
            }
            FUNC_Sin.Location = new Point(offsetX, offsetY);
            FUNC_Cos.Location = new Point(FUNC_Sin.Location.X + FUNC_Sin.Width + offsetX, offsetY);
            FUNC_Tan.Location = new Point(FUNC_Cos.Location.X + FUNC_Cos.Width + offsetX, offsetY);
            FUNC_Logarit.Location = new Point(FUNC_Tan.Location.X + FUNC_Tan.Width + offsetX, offsetY);
            FUNC_Ln.Location = new Point(FUNC_Logarit.Location.X + FUNC_Logarit.Width + offsetX, offsetY);

            MISC_OpenBracket.Location = new Point(offsetX, FUNC_Sin.Location.Y + FUNC_Sin.Height + offsetY);
            MISC_CloseBracket.Location = new Point(FUNC_Cos.Location.X, MISC_OpenBracket.Location.Y);
            FUNC_Pow.Location = new Point(FUNC_Tan.Location.X, MISC_OpenBracket.Location.Y);
            FUNC_Sqrt.Location = new Point(FUNC_Logarit.Location.X, MISC_OpenBracket.Location.Y);
            FUNC_Not.Location = new Point(FUNC_Ln.Location.X, MISC_OpenBracket.Location.Y);

            FUNC_Pi.Location = new Point(offsetX, MISC_OpenBracket.Location.Y + MISC_OpenBracket.Height + offsetY);
            FUNC_EulerNumber.Location = new Point(FUNC_Cos.Location.X, FUNC_Pi.Location.Y);
            STATE_INV.Location = new Point(FUNC_Tan.Location.X, FUNC_Pi.Location.Y);
            STATE_Radian.Location = new Point(FUNC_Logarit.Location.X, FUNC_Pi.Location.Y);
            STATE_Degree.Location = new Point(FUNC_Ln.Location.X, FUNC_Pi.Location.Y);
        }

        private void NumberPanel_Resize(object sender, EventArgs e)
        {
            int offsetX = 3, offsetY = 3;
            //scale mainPanel            

            Size buttonNewSize = new Size((NumberPanel.Width - 3 * offsetX-10) / 4, (NumberPanel.Height - 4 * offsetX - 16) / 5);
            //size
            foreach (Control c in NumberPanel.Controls)
            {
                c.Size = buttonNewSize;
            }
            CTRL_Ac.Location = new Point(5, offsetY);
            CTRL_Back.Location = new Point(CTRL_Ac.Location.X + CTRL_Ac.Width + offsetX, offsetY);
            FUNC_Negate.Location = new Point(CTRL_Back.Location.X + CTRL_Back.Width + offsetX, offsetY);
            OPER_Div.Location = new Point(FUNC_Negate.Location.X + FUNC_Negate.Width + offsetX, offsetY);

            NUMB_7.Location = new Point(5, CTRL_Ac.Location.Y + CTRL_Ac.Height + offsetY);
            NUMB_8.Location = new Point(CTRL_Back.Location.X, NUMB_7.Location.Y);
            NUMB_9.Location = new Point(FUNC_Negate.Location.X, NUMB_7.Location.Y);
            OPER_Mul.Location = new Point(OPER_Div.Location.X, NUMB_7.Location.Y);

            NUMB_4.Location = new Point(5, NUMB_7.Location.Y + NUMB_7.Height + offsetY);
            NUMB_5.Location = new Point(CTRL_Back.Location.X, NUMB_4.Location.Y);
            NUMB_6.Location = new Point(FUNC_Negate.Location.X, NUMB_4.Location.Y);
            OPER_Sub.Location = new Point(OPER_Div.Location.X, NUMB_4.Location.Y);

            NUMB_1.Location = new Point(5, NUMB_4.Location.Y + NUMB_4.Height + offsetY);
            NUMB_2.Location = new Point(CTRL_Back.Location.X, NUMB_1.Location.Y);
            NUMB_3.Location = new Point(FUNC_Negate.Location.X, NUMB_1.Location.Y);
            OPER_Plus.Location = new Point(OPER_Div.Location.X, NUMB_1.Location.Y);

            NUMB_0.Location = new Point(5, NUMB_1.Location.Y + NUMB_1.Height + offsetY);
            MISC_Dot.Location = new Point(CTRL_Back.Location.X, NUMB_0.Location.Y);
            MISC_Ans.Location = new Point(FUNC_Negate.Location.X, NUMB_0.Location.Y);
            CTRL_Equal.Location = new Point(OPER_Div.Location.X, NUMB_0.Location.Y);
        }
        private void MemoryPanel_SizeChanged(object sender, EventArgs e)
        {
            MemoryPanel_DecorLine1.Width = MemoryPanel.Width - 10;
            ClearMemory.Location = new Point(MemoryPanel_DecorLine1.Width + MemoryPanel_DecorLine1.Location.X - 45, ClearMemory.Location.Y);
            StandardCalculatorControl.ResizeMemoryBlock();
        }
        private void StandardCalculator_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                return;
            }
            FormOpenerPanel.Height = Height - 47;
            MemoryPanel.Height = Height - 47;
            if (disableResponsive)
            {
                return;
            }
            if (!finishedLoading)
            {
                return;
            }
            if (NumberPanel.isPlayingAnimation || FunctionPanel.isPlayingAnimation || MemoryPanel.isPlayingAnimation)
            {
                return;
            }
            breakPointHorizontal();
            breakPointVertical();
        }
        private void breakPointVertical()
        {
            int realHeight = Height - 47;
            MemoryPanel.Height = realHeight;
            FormOpenerPanel.Height = realHeight;
            //1. relocation and resize
            //big logic         
            //On Top button
            Size mainPanelOriginSize = new Size(415, 275);
            Size funcPanelOriginSize = new Size(415, 160);
            Size numberPanelOriginSize = new Size(415, 330);
            //break point for pop up
            //case 1: only main panel and open funcPanel
            if (realHeight > (mainPanelOriginSize.Height + funcPanelOriginSize.Height + numberPanelOriginSize.Height + 10))
            {
                if (!funcPanelOn)
                {
                    StandardCalculatorControl.OpenFuncPanel(true);
                }
                if (!numberPanelOn)
                {
                    StandardCalculatorControl.OpenNumberPanel(true);
                }
                rescaleVertically();
            }
            else if ((!funcPanelOn) && (!numberPanelOn) && (realHeight > (mainPanelOriginSize.Height + funcPanelOriginSize.Height + 5)))
            {
                MainPanel.Height = mainPanelOriginSize.Height;
                StandardCalculatorControl.OpenFuncPanel(true);
            }
            //case 2: open func panel when reaching maximum size
            else if(((!funcPanelOn) && (numberPanelOn)) && (realHeight > mainPanelOriginSize.Height + funcPanelOriginSize.Height + numberPanelOriginSize.Height + 10))
            {
                MainPanel.Height = mainPanelOriginSize.Height;
                NumberPanel.Height = numberPanelOriginSize.Height;
                StandardCalculatorControl.OpenFuncPanel(true);
            }
            //case 3: open number panel when reaching maximum size
            else if(((funcPanelOn) && (!numberPanelOn)) && (realHeight > mainPanelOriginSize.Height + funcPanelOriginSize.Height + numberPanelOriginSize.Height + 10))
            {
                MainPanel.Height = mainPanelOriginSize.Height;
                FunctionPanel.Height = funcPanelOriginSize.Height;
                StandardCalculatorControl.OpenNumberPanel(true);
            }
            //break point for close down
            else if((numberPanelOn && funcPanelOn) && (realHeight < mainPanelOriginSize.Height + funcPanelOriginSize.Height + numberPanelOriginSize.Height + 5))
            {
                StandardCalculatorControl.CloseFuncPanel(true);
                FunctionPanel.Hide();
            }
            else if((!numberPanelOn) && funcPanelOn && (realHeight < mainPanelOriginSize.Height + funcPanelOriginSize.Height - 5))
            {
                StandardCalculatorControl.CloseFuncPanel(true);
                FunctionPanel.Hide();
            }
            else if((numberPanelOn) && (!funcPanelOn) && (realHeight < mainPanelOriginSize.Height + numberPanelOriginSize.Height - 5))
            {
                StandardCalculatorControl.CloseNumberPanel(true);
                NumberPanel.Hide();
            }
            rescaleVertically();
        }
        private void breakPointHorizontal()
        {
            int realWidth = Width - 18;
            
            Size mainPanelOriginSize = new Size(415, 275);
            Size memoryPanelOriginSize = new Size(275, 999);
            //memory open
            if (!memoryPanelOn && (realWidth > mainPanelOriginSize.Width + memoryPanelOriginSize.Width + 5))
            {
                MainPanel.Width = mainPanelOriginSize.Width;
                StandardCalculatorControl.OpenMemoryPanel(true);
            }
            else if ((memoryPanelOn) && (realWidth < mainPanelOriginSize.Width + memoryPanelOriginSize.Width - 5))
            {
                StandardCalculatorControl.CloseMemoryPanel(true);
                MemoryPanel.Hide();
            }
            rescaleHorizontally();
        }
        private void rescaleVertically()
        {
            int realHeight = Height - 47;

            Size mainPanelOriginSize = new Size(415, 275);
            Size funcPanelOriginSize = new Size(415, 160);
            Size numberPanelOriginSize = new Size(415, 330);
            //allocating slot and resizing
            //vertical
            if (funcPanelOn && !numberPanelOn)
            {
                double total = mainPanelOriginSize.Height + funcPanelOriginSize.Height;
                int heightForMainPanel = Convert.ToInt32((realHeight - 5) * (mainPanelOriginSize.Height / total));
                int heightForFuncPanel = Convert.ToInt32((realHeight - 5) * (funcPanelOriginSize.Height / total));

                MainPanel.Height = heightForMainPanel;
                FunctionPanel.Location = new Point(0, MainPanel.Height + 5);
                FunctionPanel.Height = heightForFuncPanel;
            }
            else if (numberPanelOn && !funcPanelOn)
            {
                double total = mainPanelOriginSize.Height + numberPanelOriginSize.Height;
                int heightForMainPanel = Convert.ToInt32((realHeight - 5) * (mainPanelOriginSize.Height / total));
                int heightForNumberPanel = Convert.ToInt32((realHeight - 5) * (numberPanelOriginSize.Height / total));

                MainPanel.Height = heightForMainPanel;
                NumberPanel.Location = new Point(0, MainPanel.Height + 5);
                NumberPanel.Height = heightForNumberPanel;
            }
            else if (numberPanelOn && funcPanelOn)
            {
                double total = mainPanelOriginSize.Height + numberPanelOriginSize.Height + funcPanelOriginSize.Height;
                int heightForMainPanel = Convert.ToInt32((realHeight - 5) * (mainPanelOriginSize.Height / total));
                int heightForFuncPanel = Convert.ToInt32((realHeight - 5) * (funcPanelOriginSize.Height / total));
                int heightForNumberPanel = Convert.ToInt32((realHeight - 5) * (numberPanelOriginSize.Height / total));

                MainPanel.Height = heightForMainPanel;
                FunctionPanel.Location = new Point(0, MainPanel.Height + 5);
                FunctionPanel.Height = heightForFuncPanel;

                NumberPanel.Location = new Point(0, FunctionPanel.Location.Y + FunctionPanel.Height + 5);
                NumberPanel.Height = heightForNumberPanel;
            }
            else
            {
                MainPanel.Height = realHeight;
            }
        }

        private void StandardCalculator_Layout(object sender, LayoutEventArgs e)
        {
            OnSizeChanged(e);
        }
        private void rescaleHorizontally()
        {
            int realWidth = Width - 18;

            Size mainPanelOriginSize = new Size(415, 275);
            Size funcPanelOriginSize = new Size(415, 160);
            Size numberPanelOriginSize = new Size(415, 330);
            Size memoryPanelOriginSize = new Size(275, 999);
            if (memoryPanelOn)
            {
                double total = mainPanelOriginSize.Width + memoryPanelOriginSize.Width;
                int widthForMainPanel = Convert.ToInt32((realWidth - 5) * (mainPanelOriginSize.Width / total));
                int widthForMemoryPanel = Convert.ToInt32((realWidth - 5) * (memoryPanelOriginSize.Width / total));

                MainPanel.Width = widthForMainPanel;
                MemoryPanel.Location = new Point(MainPanel.Width + 5, 0);
                MemoryPanel.Width = widthForMemoryPanel;
            }
            else
            {
                MainPanel.Width = realWidth;
            }
        }
        private void CTRL_Del_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.DeleteContentAtCursor();
        }

        private void STATE_Degree_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.SwitchToDegreeMode();
            unitForFunction = true;
        }
        private void ClearMemory_Click(object sender, EventArgs e)
        {
            try
            {
                StandardCalculatorControl.ClearMemory();
            }
            catch (Exception)
            {

            }
            MainPanel_DecorLine1.Focus();
        }
    }
}
