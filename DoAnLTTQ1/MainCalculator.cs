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
    public partial class MainCalculator : Form
    {
        //mode
        public bool onShiftMode, onAlphaMode;
        public bool onInvalidExpressionMode;
        public bool onDisplayMode;
        public bool onMenuViewingMode;

        //screen
        //khai bao cache
        public Tuple<string, string>[] memoryCaches; //input,output
        public int currentMemoryCachesSize; //so lg phan tu hien tai
        public int maxMemoryCachesSize; //so lg luu toi da
        public int currentCachePosition; //vi tri cache dang xem

        public MainCalculator()
        {
            InitializeComponent();
            MainCalculatorControl.init(this);

            KeyPreview = true;

            onShiftMode = false;
            onAlphaMode = false;
            onDisplayMode = false;
            onInvalidExpressionMode = false;
            onMenuViewingMode = false;
            MainCalculatorControl.HideMenu();

            currentMemoryCachesSize = 0;
            currentCachePosition = 0;
            maxMemoryCachesSize = 5;
            memoryCaches = new Tuple<string, string>[maxMemoryCachesSize];

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = CustomFont.initFont();
            FUNC_Fraction.Font = new Font(pfc.Families[0], 19, FontStyle.Bold);
        }

        //INSERRT   
        //INSERRT
        private void NUMB_0_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("0");
            label1.Focus();
        }

        private void NUMB_1_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("1");
            label1.Focus();
        }

        private void NUMB_2_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("2");
            label1.Focus();
        }

        private void NUMB_3_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("3");
            label1.Focus();
        }

        private void NUMB_4_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("4");
            label1.Focus();
        }

        private void NUMB_5_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("5");
            label1.Focus();
        }

        private void NUMB_6_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("6");
            label1.Focus();
        }

        private void NUMB_7_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("7");
            label1.Focus();
        }

        private void NUMB_8_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("8");
            label1.Focus();
        }

        private void NUMB_9_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("9");
            label1.Focus();
        }

        //OPERATION BUTTON
        private void OPER_Sub_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("-");
            label1.Focus();
        }

        private void OPER_Add_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("+");
            label1.Focus();
        }

        private void OPER_Div_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("LCM(");
            else
                MainCalculatorControl.insertContentIntoInputText("/");
            label1.Focus();
        }

        private void OPER_Mul_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("GCD(");
            else
                MainCalculatorControl.insertContentIntoInputText("*");
            label1.Focus();
        }

        //OTHER MISC BUTTON
        private void MISC_Dot_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("Rand(");
            else
                MainCalculatorControl.insertContentIntoInputText(".");
            label1.Focus();
        }

        private void MISC_Ans_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("PreAns");
            else
                MainCalculatorControl.insertContentIntoInputText("Ans");
            label1.Focus();
        }

        private void FUNC_PowerOfTen_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("e");
            else
                MainCalculatorControl.insertContentIntoInputText("x10");
            label1.Focus();
        }

        //MIDDLE BLOCK
        private void FUNC_Fraction_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("/");
            label1.Focus();
        }

        private void FUNC_Sqrt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("∛");
            else
                MainCalculatorControl.insertContentIntoInputText("sqrt(");
            label1.Focus();
        }

        private void FUNC_Square_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("^3");
            else
                MainCalculatorControl.insertContentIntoInputText("^2");
            label1.Focus();
        }

        private void FUNC_Pow_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.insertContentIntoInputText("^");
            label1.Focus();
        }

        private void FUNC_Logarit_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("10^");
            else
                MainCalculatorControl.insertContentIntoInputText("log(");
            label1.Focus();
        }

        private void FUNC_Ln_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("e^");
            else
                MainCalculatorControl.insertContentIntoInputText("ln(");
            label1.Focus();
        }

        private void OPER_And_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("NAND");
            else
                MainCalculatorControl.insertContentIntoInputText("and");
            label1.Focus();
        }

        private void OPER_Or_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("NOR");
            else
                MainCalculatorControl.insertContentIntoInputText("or");
            label1.Focus();
        }

        private void OPER_Not_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("XNOR");
            else if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("XOR");
            else
                MainCalculatorControl.insertContentIntoInputText("!");
            label1.Focus();
        }

        private void FUNC_Sin_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("sinh(");
            else if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("asin(");
            else
                MainCalculatorControl.insertContentIntoInputText("sin(");
            label1.Focus();
        }

        private void FUNC_Cos_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("cosh(");
            else if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("acos(");
            else
                MainCalculatorControl.insertContentIntoInputText("cos(");
            label1.Focus();
        }

        private void FUNC_Tan_Click(object sender, EventArgs e)
        {
            if (onAlphaMode)
                MainCalculatorControl.insertContentIntoInputText("tanh(");
            else if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("atan(");
            else
                MainCalculatorControl.insertContentIntoInputText("tan(");
            label1.Focus();
        }

        private void MISC_OpenBracket_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("abs(");
            else
                MainCalculatorControl.insertContentIntoInputText("(");
            label1.Focus();
        }

        private void MISC_CloseBracket_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("fact(");
            else
                MainCalculatorControl.insertContentIntoInputText(")");
            label1.Focus();
        }

        private void OPER_Gt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText(">>");
            else
                MainCalculatorControl.insertContentIntoInputText(">");
            label1.Focus();
        }

        private void OPER_Lt_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("<<");
            else
                MainCalculatorControl.insertContentIntoInputText("<");
            label1.Focus();
        }

        private void OPER_Ge_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("|");
            else
                MainCalculatorControl.insertContentIntoInputText(">=");
            label1.Focus();
        }

        private void OPER_Le_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("&");
            else
                MainCalculatorControl.insertContentIntoInputText("<=");
            label1.Focus();
        }

        private void OPER_Eq_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("~");
            else
                MainCalculatorControl.insertContentIntoInputText("==");
            label1.Focus();
        }

        private void OPER_Ne_Click(object sender, EventArgs e)
        {
            if (onShiftMode)
                MainCalculatorControl.insertContentIntoInputText("^");
            else
                MainCalculatorControl.insertContentIntoInputText("!=");
            label1.Focus();
        }

        //MainCalculatorControl 
        private void STATE_Shift_Click(object sender, EventArgs e)
        {
            if (!onShiftMode && !onAlphaMode)
            {
                //Normal mode activate
                //Change shift mode to true
                onShiftMode = true;
                MainCalculatorControl.Toggle_ShiftMode();
            }
            else if (!onShiftMode && onAlphaMode)
            {
                //On alphamode
                //change alpha mode to false - activate shift mode
                onShiftMode = true;
                onAlphaMode = false;
                MainCalculatorControl.NormalMode();
                MainCalculatorControl.Toggle_ShiftMode();
            }
            else if (onShiftMode)
            {
                //Turn off shift mode
                onShiftMode = false;
                MainCalculatorControl.NormalMode();
            }
            label1.Focus();
        }
        private void STATE_Alpha_Click(object sender, EventArgs e)
        {
            if (!onShiftMode && !onAlphaMode)
            {
                //Normal mode activate
                //Change alpha mode to true
                onAlphaMode = true;
                MainCalculatorControl.Toggle_AlphaMode();
            }
            else if (onShiftMode && !onAlphaMode)
            {
                //On shift mode
                //change shilf mode to false - activate alpha mode
                onShiftMode = false;
                onAlphaMode = true;
                MainCalculatorControl.NormalMode();
                MainCalculatorControl.Toggle_AlphaMode();
            }
            else if (onAlphaMode)
            {
                //Turn off shift mode
                onAlphaMode = false;
                MainCalculatorControl.NormalMode();
            }
            label1.Focus();
        }

        //MainCalculatorControl
        private void CTRL_Undo_Click(object sender, EventArgs e)
        {
            this.InputText.Undo();
            label1.Focus();
        }
        private void CTRL_Redo_Click(object sender, EventArgs e)
        {
            this.InputText.Redo();
            label1.Focus();
        }
        private void CTRL_Equal_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.Perform_Equal();
            label1.Focus();
        }
        private void CTRL_Ac_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.Perform_Ac();
            label1.Focus();
        }
        private void CTRL_Del_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.Perform_Del();
            label1.Focus();
        }
        private void DelLabel_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.Perform_Del();
            label1.Focus();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.Perform_Ac();
            label1.Focus();
        }

        private void CTRL_MoveUp_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.loadPreviousCache();
            MainCalculatorControl.displayCache();
            label1.Focus();
        }
        private void CTRL_MoveDown_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.loadNextCache();
            MainCalculatorControl.displayCache();
            label1.Focus();
        }
        private void CTRL_MoveLeft_Click(object sender, EventArgs e)
        {
            if (onInvalidExpressionMode)
            {
                MainCalculatorControl.turnOffInvalidExpressionMode();
                return;
            }
            InputText.moveCursorLeft();
            label1.Focus();
        }
        private void CTRL_MoveRight_Click(object sender, EventArgs e)
        {
            if (onInvalidExpressionMode)
            {
                MainCalculatorControl.turnOffInvalidExpressionMode();
                return;
            }
            InputText.moveCursorRight();
            label1.Focus();
        }

        private void STATE_Mode_Click(object sender, EventArgs e)
        {
            if (onMenuViewingMode)
            {
                MainCalculatorControl.HideMenu();
                label1.Focus();
            }
            else
            {
                MainCalculatorControl.ShowMenu();
                label1.Focus();
            }
        }

        private void MENU_Normal_Click(object sender, EventArgs e)
        {
            //nothing
            MainCalculatorControl.HideMenu();
            label1.Focus();
        }

        private void MENU_Graph_Click(object sender, EventArgs e)
        {
            //MainCalculatorControl.OpenGraphForm();
            MainCalculatorControl.HideMenu();
        }

        private void MENU_Matrix_Click(object sender, EventArgs e)
        {
            //MainCalculatorControl.OpenMatrixForm();

            MainCalculatorControl.HideMenu();
            label1.Focus();
            Form f = new MatrixCalculator();
            f.Show();
        }
        private void MENU_Equation_Click(object sender, EventArgs e)
        {
            //MainCalculatorControl.OpenEquationForm();
            MainCalculatorControl.HideMenu();
            label1.Focus();
        }

        private void STATE_Power_Click(object sender, EventArgs e)
        {
            MainCalculatorControl.reset();
            label1.Focus();
        }
    }
}
