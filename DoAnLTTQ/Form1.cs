using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ1
{
    public partial class Form1 : Form
    {
        //state
        //public string 
        public bool onShiftMode, onAlphaMode;
        public bool onInvalidExpressionMode;
        public int currentCursorPosition;

        public Form1()
        {
            onShiftMode = false;
            onAlphaMode = false;
            onInvalidExpressionMode = false;

            currentCursorPosition = 0;
            Control.init(this);
            InitializeComponent();
        }

        /// INSERT BLOCK

        //LOWEST BLOCK
        //NUMBER BUTTON
        private void NUMB_0_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("0");
        }

        private void NUMB_1_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("1");
        }

        private void NUMB_2_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("2");
        }

        private void NUMB_3_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("3");
        }

        private void NUMB_4_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("4");
        }

        private void NUMB_5_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("5");
        }

        private void NUMB_6_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("6");
        }

        private void NUMB_7_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("7");
        }

        private void NUMB_8_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("8");
        }

        private void NUMB_9_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("9");
        }

        //OPERATION BUTTON
        private void OPER_Sub_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("-");
        }

        private void OPER_Add_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("+");
        }

        private void OPER_Div_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("/");
        }

        private void OPER_Mul_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("*");
        }

        //OTHER MISC BUTTON
        private void MISC_Dot_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText(".");
        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("%");
            else
                Control.insertContentIntoInputText("Ans");
        }

        private void FUNC_PowerOfTen_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("pi");
            else if (onAlphaMode)
                Control.insertContentIntoInputText("e");
            else
                Control.insertContentIntoInputText("x10");
        }

        //MIDDLE BLOCK

        private void CTRL_Optn_Click(object sender, EventArgs e)
        {

        }

        private void CTRL_Calc_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_Integral_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_X_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("x");
        }

        private void FUNC_Fraction_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("/");
        }

        private void FUNC_Sqrt_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("sqrt(");
        }

        private void FUNC_Square_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("^2");
        }

        private void FUNC_Pow_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("^");
        }

        private void FUNC_Logarit_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("log(");
        }

        private void FUNC_Ln_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("ln(");
        }

        private void MISC_Sub_Click(object sender, EventArgs e)
        {

        }

        private void MISC_Degree_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_NumericalInverse_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_Sin_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("sin(");
        }

        private void FUNC_Cos_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("cos(");
        }

        private void FUNC_Tan_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("tan(");
        }

        private void CTRL_Sto_Click(object sender, EventArgs e)
        {

        }

        private void CTRL_Eng_Click(object sender, EventArgs e)
        {

        }

        private void MISC_OpenBracket_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("(");
        }

        private void MISC_CloseBracket_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText(")");
        }

        private void MISC_ConvertSToD_Click(object sender, EventArgs e)
        {

        }

        private void MISC_MemoryAdd_Click(object sender, EventArgs e)
        {

        }
        //CONTROL BLOCK
        private void InputText_Click(object sender, EventArgs e)
        {
            currentCursorPosition = InputText.SelectionStart;
        }
        private void CTRL_Equal_Click(object sender, EventArgs e)
        {
            Control.Perform_Equal();
        }
        private void CTRL_Ac_Click(object sender, EventArgs e)
        {
            if (onInvalidExpressionMode)
            {
                Control.turnOffInvalidExpressionMode();
            }
        }

        private void CTRL_Del_Click(object sender, EventArgs e)
        {

        }

        private void InputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutputText_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
