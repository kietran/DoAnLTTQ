using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ1
{
    //init
    public partial class Form1 : Form
    {
        //mode
        public bool onShiftMode, onAlphaMode;
        public bool onInvalidExpressionMode;
        public bool onDisplayMode;

        //screen
        //khai bao cache
        public Tuple<string, string>[] memoryCaches; //input,output
        public int currentMemoryCachesSize; //so lg phan tu hien tai
        public int maxMemoryCachesSize; //so lg luu toi da
        public int currentCachePosition; //vi tri cache dang xem

        public Form1()
        {
            KeyPreview = true;

            onShiftMode = false;
            onAlphaMode = false;
            onDisplayMode = false;
            onInvalidExpressionMode = false;

            currentMemoryCachesSize = 0;
            currentCachePosition = 0;
            maxMemoryCachesSize = 5;
            memoryCaches = new Tuple<string, string>[maxMemoryCachesSize];

            Control.init(this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = CustomFont.initFont();
            FUNC_Fraction.Font = new Font(pfc.Families[0], 19, FontStyle.Bold);
        }

        //INSERRT
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
            if (onAlphaMode)
                Control.insertContentIntoInputText("LCM(");
            else
                Control.insertContentIntoInputText("/");
        }

        private void OPER_Mul_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("GCD(");
            else
                Control.insertContentIntoInputText("*");
        }

        //OTHER MISC BUTTON
        private void MISC_Dot_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("Rand(");
            else
                Control.insertContentIntoInputText(".");
        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("PreAns");
            else
                Control.insertContentIntoInputText("Ans");
        }

        private void FUNC_PowerOfTen_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("e");
            else
                Control.insertContentIntoInputText("x10");
        }

        //MIDDLE BLOCK
        private void FUNC_Fraction_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("/");
        }

        private void FUNC_Sqrt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("∛");
            else
                Control.insertContentIntoInputText("sqrt");
        }

        private void FUNC_Square_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("^3");
            else
                Control.insertContentIntoInputText("^2");
        }

        private void FUNC_Pow_Click(object sender, EventArgs e)
        {
            Control.insertContentIntoInputText("^");
        }

        private void FUNC_Logarit_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("10^");
            else
                Control.insertContentIntoInputText("log(");
        }

        private void FUNC_Ln_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("e^");
            else
                Control.insertContentIntoInputText("ln(");
        }

        private void OPER_And_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("NAND");
            else
                Control.insertContentIntoInputText("and");
        }

        private void OPER_Or_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("NOR");
            else
                Control.insertContentIntoInputText("or");
        }

        private void OPER_Not_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("XNOR");
            else if (onShiftMode)
                Control.insertContentIntoInputText("XOR");
            else
                Control.insertContentIntoInputText("!");
        }

        private void FUNC_Sin_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("sinh(");
            else if (onShiftMode)
                Control.insertContentIntoInputText("asin(");
            else
                Control.insertContentIntoInputText("sin(");
        }

        private void FUNC_Cos_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("cosh(");
            else if (onShiftMode)
                Control.insertContentIntoInputText("acos(");
            else
                Control.insertContentIntoInputText("cos(");
        }

        private void FUNC_Tan_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                Control.insertContentIntoInputText("tanh(");
            else if (onShiftMode)
                Control.insertContentIntoInputText("atan(");
            else
                Control.insertContentIntoInputText("tan(");
        }

        private void MISC_OpenBracket_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("Abs(");
            else
                Control.insertContentIntoInputText("(");
        }

        private void MISC_CloseBracket_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("Fact(");
            else
                Control.insertContentIntoInputText(")");
        }

        private void OPER_Gt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText(">>");
            else
                Control.insertContentIntoInputText(">");
        }

        private void OPER_Lt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("<<");
            else
                Control.insertContentIntoInputText("<");
        }

        private void OPER_Ge_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("|");
            else
                Control.insertContentIntoInputText(">=");
        }

        private void OPER_Le_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("&");
            else
                Control.insertContentIntoInputText("<=");
        }

        private void OPER_Eq_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("~");
            else
                Control.insertContentIntoInputText("==");
        }

        private void OPER_Ne_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                Control.insertContentIntoInputText("^");
            else
                Control.insertContentIntoInputText("!=");
        }

        //CONTROL 
        private void STATE_Shift_Click(object sender, EventArgs e)
        {
            if (!onShiftMode && !onAlphaMode)
            {
                //Normal mode activate
                //Change shift mode to true
                onShiftMode = true;
                Control.Toggle_ShiftMode();
            }
            else if (!onShiftMode && onAlphaMode)
            {
                //On alphamode
                //change alpha mode to false - activate shift mode
                onShiftMode = true;
                onAlphaMode = false;
                Control.NormalMode();
                Control.Toggle_ShiftMode();
            }
            else if (onShiftMode)
            {
                //Turn off shift mode
                onShiftMode = false;
                Control.NormalMode();
            }
        }
        private void STATE_Alpha_Click(object sender, EventArgs e)
        {
            if (!onShiftMode && !onAlphaMode)
            {
                //Normal mode activate
                //Change alpha mode to true
                onAlphaMode = true;
                Control.Toggle_AlphaMode();
            }
            else if (onShiftMode && !onAlphaMode)
            {
                //On shift mode
                //change shilf mode to false - activate alpha mode
                onShiftMode = false;
                onAlphaMode = true;
                Control.NormalMode();
                Control.Toggle_AlphaMode();
            }
            else if (onAlphaMode)
            {
                //Turn off shift mode
                onAlphaMode = false;
                Control.NormalMode();
            }
        }

        //Control
        private void CTRL_Undo_Click(object sender, EventArgs e)
        {
            this.InputText.Undo();
        }
        private void CTRL_Redo_Click(object sender, EventArgs e)
        {
            this.InputText.Redo();
        }
        private void CTRL_Equal_Click(object sender, EventArgs e)
        {
            Control.Perform_Equal();
        }
        private void CTRL_Ac_Click(object sender, EventArgs e)
        {
            Control.Perform_Ac();
        }
        private void CTRL_Del_Click(object sender, EventArgs e)
        {
            Control.Perform_Del();
        }
        private void CTRL_MoveUp_Click(object sender, EventArgs e)
        {
            Control.loadPreviousCache();
            Control.displayCache();
        }
        private void CTRL_MoveDown_Click(object sender, EventArgs e)
        {
            Control.loadNextCache();
            Control.displayCache();
        }
        private void CTRL_MoveLeft_Click(object sender, EventArgs e)
        {
            InputText.moveCursorLeft();
        }
        private void CTRL_MoveRight_Click(object sender, EventArgs e)
        {
            InputText.moveCursorRight();
        }

        private void STATE_Power_Click(object sender, EventArgs e)
        {
            Control.reset();
        }
    }
}
