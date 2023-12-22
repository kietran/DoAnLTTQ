using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCalculator
{
    public partial class StandardCalculator : Form
    {
        internal bool numberPanelOn = false, funcPanelOn = false, memoryPanelOn = false;
        private bool isDocking = false;
        private bool modeChoosingPanelOn = false;
        private bool onINVMode = false;
        private bool radianMode = true, degreeMode = false;
        public StandardCalculator()
        {
            StandardCalculatorControl.Init(this);
            InitializeComponent();
        }
        private void StandardCalculator_Load(object sender, EventArgs e)
        {
            NumberPanel.Visible = false;
            FunctionPanel.Visible = false;
            MemoryPanel.Visible = false;
            STATE_Radian.PerformClick();
        }

        //open panel
        private void MainPanel_OpenNumberPanelButton_Click(object sender, EventArgs e)
        {      
            if (!numberPanelOn)
            {
                StandardCalculatorControl.OpenNumberPanel();
            }
            else
            {
                StandardCalculatorControl.CloseNumberPanel();
            }
            numberPanelOn = !numberPanelOn;
        }
        private void MainPanel_OpenFuncPanelButton_Click(object sender, EventArgs e)
        {    
            if (!funcPanelOn)
            {
                StandardCalculatorControl.OpenFuncPanel();
            }
            else
            {
                StandardCalculatorControl.CloseFuncPanel();
            }
            funcPanelOn = !funcPanelOn;
        }

        private void MainPanel_OpenMemoryPanelButton_Click(object sender, EventArgs e)
        {
            if (!memoryPanelOn)
            {
                StandardCalculatorControl.OpenMemoryPanel();
            }
            else
            {
                StandardCalculatorControl.CloseMemoryPanel();
            }
            memoryPanelOn = !memoryPanelOn;
        }


        private void MainPanel_OnTopButton_Click(object sender, EventArgs e)
        {

        }

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
            StandardCalculatorControl.InsertContentAtCursor("%");
        }

        private void OPER_Div_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("÷");
        }
        private void OPER_Mul_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("*");
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
            StandardCalculatorControl.InsertContentAtCursor("sin(");
        }

        private void FUNC_Cos_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("cos(");
        }

        private void FUNC_Tan_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("tan(");
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
            StandardCalculatorControl.InsertContentAtCursor("√");
        }

        private void FUNC_Not_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("!");
        }

        private void FUNC_Pi_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("𝝅");
        }

        private void FUNC_EulerNumber_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("e");
        }

        private void STATE_INV_Click(object sender, EventArgs e)
        {
            if(onINVMode == false)
            {
                onINVMode = true;
                StandardCalculatorControl.Toggle_INVMode();
            }
            else
            {
                onINVMode = false;
                StandardCalculatorControl.Toggle_NormalMode();
            }
        }

        private void FUNC_Logarit_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("log(");
        }

        private void FUNC_Ln_Click(object sender, EventArgs e)
        {
            StandardCalculatorControl.InsertContentAtCursor("ln(");
        }
        private void STATE_Radian_Click(object sender, EventArgs e)
        {
            if(degreeMode == true)
            {
                radianMode = true;
                degreeMode = false;
                StandardCalculatorControl.RadianMode();

                STATE_Radian.BackColor = Color.FromArgb(205, 239, 139);
                STATE_Degree.BackColor = Color.FromArgb(245, 247, 250);

                STATE_Radian.Enabled = false;
                STATE_Degree.Enabled = true;
            }
        }

        private void STATE_Degree_Click(object sender, EventArgs e)
        {
            if (radianMode == true)
            {
                radianMode = false;
                degreeMode = true;
                StandardCalculatorControl.DegreeMode();

                STATE_Degree.BackColor = Color.FromArgb(205, 239, 139);
                STATE_Radian.BackColor = Color.FromArgb(245, 247, 250);

                STATE_Degree.Enabled = false;
                STATE_Radian.Enabled = true;
            }
        }

    }
}
