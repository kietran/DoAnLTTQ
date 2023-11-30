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
        private void NUMB_0_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("0");
        }

        private void MISC_Dot_Click(object sender, EventArgs e)
        {

        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {

        }

        private void FUNC_PowerOfTen_Click(object sender, EventArgs e)
        {

        }

        

        private void OPER_Sub_Click(object sender, EventArgs e)
        {

        }

        private void OPER_Add_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_3_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_2_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_1_Click(object sender, EventArgs e)
        {

        }

        private void OPER_Div_Click(object sender, EventArgs e)
        {

        }

        private void OPER_Mul_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_6_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_5_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_4_Click(object sender, EventArgs e)
        {

        }
        private void NUMB_9_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_8_Click(object sender, EventArgs e)
        {

        }

        private void NUMB_7_Click(object sender, EventArgs e)
        {

        }

        private void customButton5_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {

        }

        private void customButton4_Click(object sender, EventArgs e)
        {

        }

        private void customButton6_Click(object sender, EventArgs e)
        {

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
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
