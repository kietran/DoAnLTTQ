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
        public bool onShiftMode, onAlphaMode;
        public int currentCursorPosition;

        public Form1()
        {
            Control.init(this);
            InitializeComponent();
        }

        /// INSERT BLOCK
       
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
            Control.insertContentIntoInputText("x");
        }

        //OTHER MISC BUTTON
        private void MISC_Dot_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText(".");
        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_PowerOfTen_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("x10");
        }

    
        //CONTROL BLOCK
        private void InputText_Click(object sender, EventArgs e)
        {
            currentCursorPosition = InputText.SelectionStart;
        }
        private void CTRL_Equal_Click(object sender, EventArgs e)
        {

        }
        private void CTRL_Ac_Click(object sender, EventArgs e)
        {

        }

        private void CTRL_Del_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
