﻿using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace DoAnLTTQ1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        internal System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        internal void InitializeComponent()
        {
            this.NUMB_0 = new System.Windows.Forms.Button();
            this.STATE_Shift = new System.Windows.Forms.Button();
            this.STATE_Alpha = new System.Windows.Forms.Button();
            this.STATE_Power = new System.Windows.Forms.Button();
            this.STATE_Mode = new System.Windows.Forms.Button();
            this.OPER_Gt = new System.Windows.Forms.Button();
            this.OPER_Lt = new System.Windows.Forms.Button();
            this.OPER_Ge = new System.Windows.Forms.Button();
            this.OPER_Le = new System.Windows.Forms.Button();
            this.OPER_Eq = new System.Windows.Forms.Button();
            this.OPER_Ne = new System.Windows.Forms.Button();
            this.FUNC_Tan = new System.Windows.Forms.Button();
            this.FUNC_Cos = new System.Windows.Forms.Button();
            this.FUNC_Sin = new System.Windows.Forms.Button();
            this.OPER_Not = new System.Windows.Forms.Button();
            this.OPER_Or = new System.Windows.Forms.Button();
            this.OPER_And = new System.Windows.Forms.Button();
            this.FUNC_Ln = new System.Windows.Forms.Button();
            this.FUNC_Logarit = new System.Windows.Forms.Button();
            this.FUNC_Pow = new System.Windows.Forms.Button();
            this.FUNC_Square = new System.Windows.Forms.Button();
            this.FUNC_Sqrt = new System.Windows.Forms.Button();
            this.FUNC_Fraction = new System.Windows.Forms.Button();
            this.MISC_Dot = new System.Windows.Forms.Button();
            this.MISC_Ans = new System.Windows.Forms.Button();
            this.FUNC_PowerOfTen = new System.Windows.Forms.Button();
            this.CTRL_Equal = new System.Windows.Forms.Button();
            this.OPER_Sub = new System.Windows.Forms.Button();
            this.OPER_Add = new System.Windows.Forms.Button();
            this.NUMB_3 = new System.Windows.Forms.Button();
            this.NUMB_2 = new System.Windows.Forms.Button();
            this.NUMB_1 = new System.Windows.Forms.Button();
            this.OPER_Div = new System.Windows.Forms.Button();
            this.OPER_Mul = new System.Windows.Forms.Button();
            this.NUMB_6 = new System.Windows.Forms.Button();
            this.NUMB_5 = new System.Windows.Forms.Button();
            this.NUMB_4 = new System.Windows.Forms.Button();
            this.CTRL_Ac = new System.Windows.Forms.Button();
            this.CTRL_Del = new System.Windows.Forms.Button();
            this.NUMB_9 = new System.Windows.Forms.Button();
            this.NUMB_8 = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DelLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CTRL_Redo = new System.Windows.Forms.Button();
            this.CTRL_Undo = new System.Windows.Forms.Button();
            this.MISC_CloseBracket = new System.Windows.Forms.Button();
            this.MISC_OpenBracket = new System.Windows.Forms.Button();
            this.CTRL_MoveRight = new System.Windows.Forms.Button();
            this.CTRL_MoveUp = new System.Windows.Forms.Button();
            this.CTRL_MoveLeft = new System.Windows.Forms.Button();
            this.CTRL_MoveDown = new System.Windows.Forms.Button();
            this.InputText = new CustomControls.CalculatorTextbox.CalculatorTextbox();
            this.NUMB_7 = new CustomControls.CustomButton.CustomButton();
            this.customButton2 = new CustomControls.CustomButton.CustomButton();
            this.customButton1 = new CustomControls.CustomButton.CustomButton();
            this.customButton3 = new CustomControls.CustomButton.CustomButton();
            this.customButton4 = new CustomControls.CustomButton.CustomButton();
            this.customButton6 = new CustomControls.CustomButton.CustomButton();
            this.customButton5 = new CustomControls.CustomButton.CustomButton();
            this.SuspendLayout();
            // 
            // NUMB_0
            // 
            this.NUMB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_0.Location = new System.Drawing.Point(28, 575);
            this.NUMB_0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_0.Name = "NUMB_0";
            this.NUMB_0.Size = new System.Drawing.Size(63, 46);
            this.NUMB_0.TabIndex = 0;
            this.NUMB_0.Text = "0";
            this.NUMB_0.UseVisualStyleBackColor = true;
            this.NUMB_0.Click += new System.EventHandler(this.NUMB_0_Click);
            // 
            // STATE_Shift
            // 
            this.STATE_Shift.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STATE_Shift.ForeColor = System.Drawing.SystemColors.WindowText;
            this.STATE_Shift.Location = new System.Drawing.Point(31, 166);
            this.STATE_Shift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.STATE_Shift.Name = "STATE_Shift";
            this.STATE_Shift.Size = new System.Drawing.Size(45, 46);
            this.STATE_Shift.TabIndex = 38;
            this.STATE_Shift.Text = "SHIFT";
            this.STATE_Shift.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.STATE_Shift.UseVisualStyleBackColor = true;
            this.STATE_Shift.Click += new System.EventHandler(this.STATE_Shift_Click);
            // 
            // STATE_Alpha
            // 
            this.STATE_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STATE_Alpha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.STATE_Alpha.Location = new System.Drawing.Point(83, 178);
            this.STATE_Alpha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.STATE_Alpha.Name = "STATE_Alpha";
            this.STATE_Alpha.Size = new System.Drawing.Size(45, 46);
            this.STATE_Alpha.TabIndex = 39;
            this.STATE_Alpha.Text = "ALPHA";
            this.STATE_Alpha.UseVisualStyleBackColor = true;
            this.STATE_Alpha.Click += new System.EventHandler(this.STATE_Alpha_Click);
            // 
            // STATE_Power
            // 
            this.STATE_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STATE_Power.ForeColor = System.Drawing.SystemColors.WindowText;
            this.STATE_Power.Location = new System.Drawing.Point(312, 166);
            this.STATE_Power.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.STATE_Power.Name = "STATE_Power";
            this.STATE_Power.Size = new System.Drawing.Size(45, 46);
            this.STATE_Power.TabIndex = 41;
            this.STATE_Power.Text = "button23";
            this.STATE_Power.UseVisualStyleBackColor = true;
            // 
            // STATE_Mode
            // 
            this.STATE_Mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STATE_Mode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.STATE_Mode.Location = new System.Drawing.Point(261, 178);
            this.STATE_Mode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.STATE_Mode.Name = "STATE_Mode";
            this.STATE_Mode.Size = new System.Drawing.Size(45, 46);
            this.STATE_Mode.TabIndex = 40;
            this.STATE_Mode.Text = "button24";
            this.STATE_Mode.UseVisualStyleBackColor = true;
            // 
            // OPER_Gt
            // 
            this.OPER_Gt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Gt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Gt.Location = new System.Drawing.Point(28, 354);
            this.OPER_Gt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Gt.Name = "OPER_Gt";
            this.OPER_Gt.Size = new System.Drawing.Size(51, 30);
            this.OPER_Gt.TabIndex = 42;
            this.OPER_Gt.Text = ">";
            this.OPER_Gt.UseVisualStyleBackColor = true;
            this.OPER_Gt.Click += new System.EventHandler(this.OPER_Gt_Click);
            // 
            // OPER_Lt
            // 
            this.OPER_Lt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Lt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Lt.Location = new System.Drawing.Point(83, 354);
            this.OPER_Lt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Lt.Name = "OPER_Lt";
            this.OPER_Lt.Size = new System.Drawing.Size(51, 30);
            this.OPER_Lt.TabIndex = 43;
            this.OPER_Lt.Text = "<";
            this.OPER_Lt.UseVisualStyleBackColor = true;
            this.OPER_Lt.Click += new System.EventHandler(this.OPER_Lt_Click);
            // 
            // OPER_Ge
            // 
            this.OPER_Ge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Ge.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Ge.Location = new System.Drawing.Point(137, 354);
            this.OPER_Ge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Ge.Name = "OPER_Ge";
            this.OPER_Ge.Size = new System.Drawing.Size(51, 30);
            this.OPER_Ge.TabIndex = 44;
            this.OPER_Ge.Text = "≥";
            this.OPER_Ge.UseVisualStyleBackColor = true;
            this.OPER_Ge.Click += new System.EventHandler(this.OPER_Ge_Click);
            // 
            // OPER_Le
            // 
            this.OPER_Le.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Le.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Le.Location = new System.Drawing.Point(191, 354);
            this.OPER_Le.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Le.Name = "OPER_Le";
            this.OPER_Le.Size = new System.Drawing.Size(51, 30);
            this.OPER_Le.TabIndex = 45;
            this.OPER_Le.Text = "≤";
            this.OPER_Le.UseVisualStyleBackColor = true;
            this.OPER_Le.Click += new System.EventHandler(this.OPER_Le_Click);
            // 
            // OPER_Eq
            // 
            this.OPER_Eq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Eq.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Eq.Location = new System.Drawing.Point(246, 354);
            this.OPER_Eq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Eq.Name = "OPER_Eq";
            this.OPER_Eq.Size = new System.Drawing.Size(51, 30);
            this.OPER_Eq.TabIndex = 46;
            this.OPER_Eq.Text = "==";
            this.OPER_Eq.UseVisualStyleBackColor = true;
            this.OPER_Eq.Click += new System.EventHandler(this.OPER_Eq_Click);
            // 
            // OPER_Ne
            // 
            this.OPER_Ne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Ne.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Ne.Location = new System.Drawing.Point(301, 354);
            this.OPER_Ne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Ne.Name = "OPER_Ne";
            this.OPER_Ne.Size = new System.Drawing.Size(51, 30);
            this.OPER_Ne.TabIndex = 47;
            this.OPER_Ne.Text = "!=";
            this.OPER_Ne.UseVisualStyleBackColor = true;
            this.OPER_Ne.Click += new System.EventHandler(this.OPER_Ne_Click);
            // 
            // FUNC_Tan
            // 
            this.FUNC_Tan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Tan.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Tan.Location = new System.Drawing.Point(301, 320);
            this.FUNC_Tan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Tan.Name = "FUNC_Tan";
            this.FUNC_Tan.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Tan.TabIndex = 54;
            this.FUNC_Tan.Text = "tan";
            this.FUNC_Tan.UseVisualStyleBackColor = true;
            this.FUNC_Tan.Click += new System.EventHandler(this.FUNC_Tan_Click);
            // 
            // FUNC_Cos
            // 
            this.FUNC_Cos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Cos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Cos.Location = new System.Drawing.Point(246, 320);
            this.FUNC_Cos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Cos.Name = "FUNC_Cos";
            this.FUNC_Cos.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Cos.TabIndex = 53;
            this.FUNC_Cos.Text = "cos";
            this.FUNC_Cos.UseVisualStyleBackColor = true;
            this.FUNC_Cos.Click += new System.EventHandler(this.FUNC_Cos_Click);
            // 
            // FUNC_Sin
            // 
            this.FUNC_Sin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Sin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Sin.Location = new System.Drawing.Point(191, 320);
            this.FUNC_Sin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Sin.Name = "FUNC_Sin";
            this.FUNC_Sin.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Sin.TabIndex = 52;
            this.FUNC_Sin.Text = "sin";
            this.FUNC_Sin.UseVisualStyleBackColor = true;
            this.FUNC_Sin.Click += new System.EventHandler(this.FUNC_Sin_Click);
            // 
            // OPER_Not
            // 
            this.OPER_Not.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Not.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Not.Location = new System.Drawing.Point(137, 320);
            this.OPER_Not.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Not.Name = "OPER_Not";
            this.OPER_Not.Size = new System.Drawing.Size(51, 30);
            this.OPER_Not.TabIndex = 51;
            this.OPER_Not.Text = "not";
            this.OPER_Not.UseVisualStyleBackColor = true;
            this.OPER_Not.Click += new System.EventHandler(this.OPER_Not_Click);
            // 
            // OPER_Or
            // 
            this.OPER_Or.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Or.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Or.Location = new System.Drawing.Point(83, 320);
            this.OPER_Or.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Or.Name = "OPER_Or";
            this.OPER_Or.Size = new System.Drawing.Size(51, 30);
            this.OPER_Or.TabIndex = 50;
            this.OPER_Or.Text = "or";
            this.OPER_Or.UseVisualStyleBackColor = true;
            this.OPER_Or.Click += new System.EventHandler(this.OPER_Or_Click);
            // 
            // OPER_And
            // 
            this.OPER_And.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_And.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_And.Location = new System.Drawing.Point(29, 319);
            this.OPER_And.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_And.Name = "OPER_And";
            this.OPER_And.Size = new System.Drawing.Size(51, 30);
            this.OPER_And.TabIndex = 49;
            this.OPER_And.Text = "and";
            this.OPER_And.UseVisualStyleBackColor = true;
            this.OPER_And.Click += new System.EventHandler(this.OPER_And_Click);
            // 
            // FUNC_Ln
            // 
            this.FUNC_Ln.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Ln.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Ln.Location = new System.Drawing.Point(301, 284);
            this.FUNC_Ln.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Ln.Name = "FUNC_Ln";
            this.FUNC_Ln.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Ln.TabIndex = 60;
            this.FUNC_Ln.Text = "ln";
            this.FUNC_Ln.UseVisualStyleBackColor = true;
            this.FUNC_Ln.Click += new System.EventHandler(this.FUNC_Ln_Click);
            // 
            // FUNC_Logarit
            // 
            this.FUNC_Logarit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Logarit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Logarit.Location = new System.Drawing.Point(246, 284);
            this.FUNC_Logarit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Logarit.Name = "FUNC_Logarit";
            this.FUNC_Logarit.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Logarit.TabIndex = 59;
            this.FUNC_Logarit.Text = "log";
            this.FUNC_Logarit.UseVisualStyleBackColor = true;
            this.FUNC_Logarit.Click += new System.EventHandler(this.FUNC_Logarit_Click);
            // 
            // FUNC_Pow
            // 
            this.FUNC_Pow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Pow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Pow.Location = new System.Drawing.Point(191, 284);
            this.FUNC_Pow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Pow.Name = "FUNC_Pow";
            this.FUNC_Pow.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Pow.TabIndex = 58;
            this.FUNC_Pow.Text = "x^";
            this.FUNC_Pow.UseVisualStyleBackColor = true;
            this.FUNC_Pow.Click += new System.EventHandler(this.FUNC_Pow_Click);
            // 
            // FUNC_Square
            // 
            this.FUNC_Square.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Square.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Square.Location = new System.Drawing.Point(137, 284);
            this.FUNC_Square.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Square.Name = "FUNC_Square";
            this.FUNC_Square.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Square.TabIndex = 57;
            this.FUNC_Square.Text = "x^2";
            this.FUNC_Square.UseVisualStyleBackColor = true;
            this.FUNC_Square.Click += new System.EventHandler(this.FUNC_Square_Click);
            // 
            // FUNC_Sqrt
            // 
            this.FUNC_Sqrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_Sqrt.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Sqrt.Location = new System.Drawing.Point(83, 284);
            this.FUNC_Sqrt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Sqrt.Name = "FUNC_Sqrt";
            this.FUNC_Sqrt.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Sqrt.TabIndex = 56;
            this.FUNC_Sqrt.Text = "√";
            this.FUNC_Sqrt.UseVisualStyleBackColor = true;
            this.FUNC_Sqrt.Click += new System.EventHandler(this.FUNC_Sqrt_Click);
            // 
            // FUNC_Fraction
            // 
            this.FUNC_Fraction.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold);
            this.FUNC_Fraction.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_Fraction.Location = new System.Drawing.Point(29, 284);
            this.FUNC_Fraction.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_Fraction.Name = "FUNC_Fraction";
            this.FUNC_Fraction.Size = new System.Drawing.Size(51, 30);
            this.FUNC_Fraction.TabIndex = 55;
            this.FUNC_Fraction.Text = "/";
            this.FUNC_Fraction.UseVisualStyleBackColor = true;
            this.FUNC_Fraction.Click += new System.EventHandler(this.FUNC_Fraction_Click);
            // 
            // MISC_Dot
            // 
            this.MISC_Dot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.MISC_Dot.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MISC_Dot.Location = new System.Drawing.Point(93, 575);
            this.MISC_Dot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MISC_Dot.Name = "MISC_Dot";
            this.MISC_Dot.Size = new System.Drawing.Size(63, 46);
            this.MISC_Dot.TabIndex = 62;
            this.MISC_Dot.Text = ".";
            this.MISC_Dot.UseVisualStyleBackColor = true;
            this.MISC_Dot.Click += new System.EventHandler(this.MISC_Dot_Click);
            // 
            // MISC_Ans
            // 
            this.MISC_Ans.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MISC_Ans.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MISC_Ans.Location = new System.Drawing.Point(227, 575);
            this.MISC_Ans.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MISC_Ans.Name = "MISC_Ans";
            this.MISC_Ans.Size = new System.Drawing.Size(63, 46);
            this.MISC_Ans.TabIndex = 64;
            this.MISC_Ans.Text = "Ans";
            this.MISC_Ans.UseVisualStyleBackColor = true;
            this.MISC_Ans.Click += new System.EventHandler(this.MISC_Ans_Click);
            // 
            // FUNC_PowerOfTen
            // 
            this.FUNC_PowerOfTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FUNC_PowerOfTen.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FUNC_PowerOfTen.Location = new System.Drawing.Point(160, 575);
            this.FUNC_PowerOfTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FUNC_PowerOfTen.Name = "FUNC_PowerOfTen";
            this.FUNC_PowerOfTen.Size = new System.Drawing.Size(63, 46);
            this.FUNC_PowerOfTen.TabIndex = 63;
            this.FUNC_PowerOfTen.Text = "x10X";
            this.FUNC_PowerOfTen.UseVisualStyleBackColor = true;
            this.FUNC_PowerOfTen.Click += new System.EventHandler(this.FUNC_PowerOfTen_Click);
            // 
            // CTRL_Equal
            // 
            this.CTRL_Equal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.CTRL_Equal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_Equal.Location = new System.Drawing.Point(292, 575);
            this.CTRL_Equal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_Equal.Name = "CTRL_Equal";
            this.CTRL_Equal.Size = new System.Drawing.Size(63, 46);
            this.CTRL_Equal.TabIndex = 65;
            this.CTRL_Equal.Text = "=";
            this.CTRL_Equal.UseVisualStyleBackColor = true;
            this.CTRL_Equal.Click += new System.EventHandler(this.CTRL_Equal_Click);
            // 
            // OPER_Sub
            // 
            this.OPER_Sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Sub.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Sub.Location = new System.Drawing.Point(292, 524);
            this.OPER_Sub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Sub.Name = "OPER_Sub";
            this.OPER_Sub.Size = new System.Drawing.Size(63, 46);
            this.OPER_Sub.TabIndex = 70;
            this.OPER_Sub.Text = "-";
            this.OPER_Sub.UseVisualStyleBackColor = true;
            this.OPER_Sub.Click += new System.EventHandler(this.OPER_Sub_Click);
            // 
            // OPER_Add
            // 
            this.OPER_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Add.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Add.Location = new System.Drawing.Point(227, 524);
            this.OPER_Add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Add.Name = "OPER_Add";
            this.OPER_Add.Size = new System.Drawing.Size(63, 46);
            this.OPER_Add.TabIndex = 69;
            this.OPER_Add.Text = "+";
            this.OPER_Add.UseVisualStyleBackColor = true;
            this.OPER_Add.Click += new System.EventHandler(this.OPER_Add_Click);
            // 
            // NUMB_3
            // 
            this.NUMB_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_3.Location = new System.Drawing.Point(160, 524);
            this.NUMB_3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_3.Name = "NUMB_3";
            this.NUMB_3.Size = new System.Drawing.Size(63, 46);
            this.NUMB_3.TabIndex = 68;
            this.NUMB_3.Text = "3";
            this.NUMB_3.UseVisualStyleBackColor = true;
            this.NUMB_3.Click += new System.EventHandler(this.NUMB_3_Click);
            // 
            // NUMB_2
            // 
            this.NUMB_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_2.Location = new System.Drawing.Point(93, 524);
            this.NUMB_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_2.Name = "NUMB_2";
            this.NUMB_2.Size = new System.Drawing.Size(63, 46);
            this.NUMB_2.TabIndex = 67;
            this.NUMB_2.Text = "2";
            this.NUMB_2.UseVisualStyleBackColor = true;
            this.NUMB_2.Click += new System.EventHandler(this.NUMB_2_Click);
            // 
            // NUMB_1
            // 
            this.NUMB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_1.Location = new System.Drawing.Point(28, 524);
            this.NUMB_1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_1.Name = "NUMB_1";
            this.NUMB_1.Size = new System.Drawing.Size(60, 46);
            this.NUMB_1.TabIndex = 66;
            this.NUMB_1.Text = "1";
            this.NUMB_1.UseVisualStyleBackColor = true;
            this.NUMB_1.Click += new System.EventHandler(this.NUMB_1_Click);
            // 
            // OPER_Div
            // 
            this.OPER_Div.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Div.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Div.Location = new System.Drawing.Point(292, 473);
            this.OPER_Div.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Div.Name = "OPER_Div";
            this.OPER_Div.Size = new System.Drawing.Size(63, 46);
            this.OPER_Div.TabIndex = 75;
            this.OPER_Div.Text = "÷";
            this.OPER_Div.UseVisualStyleBackColor = true;
            this.OPER_Div.Click += new System.EventHandler(this.OPER_Div_Click);
            // 
            // OPER_Mul
            // 
            this.OPER_Mul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPER_Mul.ForeColor = System.Drawing.SystemColors.WindowText;
            this.OPER_Mul.Location = new System.Drawing.Point(227, 473);
            this.OPER_Mul.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OPER_Mul.Name = "OPER_Mul";
            this.OPER_Mul.Size = new System.Drawing.Size(63, 46);
            this.OPER_Mul.TabIndex = 74;
            this.OPER_Mul.Text = "×";
            this.OPER_Mul.UseVisualStyleBackColor = true;
            this.OPER_Mul.Click += new System.EventHandler(this.OPER_Mul_Click);
            // 
            // NUMB_6
            // 
            this.NUMB_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_6.Location = new System.Drawing.Point(160, 473);
            this.NUMB_6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_6.Name = "NUMB_6";
            this.NUMB_6.Size = new System.Drawing.Size(63, 46);
            this.NUMB_6.TabIndex = 73;
            this.NUMB_6.Text = "6";
            this.NUMB_6.UseVisualStyleBackColor = true;
            this.NUMB_6.Click += new System.EventHandler(this.NUMB_6_Click);
            // 
            // NUMB_5
            // 
            this.NUMB_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_5.Location = new System.Drawing.Point(93, 473);
            this.NUMB_5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_5.Name = "NUMB_5";
            this.NUMB_5.Size = new System.Drawing.Size(63, 46);
            this.NUMB_5.TabIndex = 72;
            this.NUMB_5.Text = "5";
            this.NUMB_5.UseVisualStyleBackColor = true;
            this.NUMB_5.Click += new System.EventHandler(this.NUMB_5_Click);
            // 
            // NUMB_4
            // 
            this.NUMB_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_4.Location = new System.Drawing.Point(28, 473);
            this.NUMB_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_4.Name = "NUMB_4";
            this.NUMB_4.Size = new System.Drawing.Size(63, 46);
            this.NUMB_4.TabIndex = 71;
            this.NUMB_4.Text = "4";
            this.NUMB_4.UseVisualStyleBackColor = true;
            this.NUMB_4.Click += new System.EventHandler(this.NUMB_4_Click);
            // 
            // CTRL_Ac
            // 
            this.CTRL_Ac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.CTRL_Ac.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_Ac.Location = new System.Drawing.Point(293, 422);
            this.CTRL_Ac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_Ac.Name = "CTRL_Ac";
            this.CTRL_Ac.Size = new System.Drawing.Size(63, 46);
            this.CTRL_Ac.TabIndex = 80;
            this.CTRL_Ac.UseVisualStyleBackColor = true;
            this.CTRL_Ac.Click += new System.EventHandler(this.CTRL_Ac_Click);
            // 
            // CTRL_Del
            // 
            this.CTRL_Del.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.CTRL_Del.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_Del.Location = new System.Drawing.Point(228, 422);
            this.CTRL_Del.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_Del.Name = "CTRL_Del";
            this.CTRL_Del.Size = new System.Drawing.Size(63, 46);
            this.CTRL_Del.TabIndex = 79;
            this.CTRL_Del.UseVisualStyleBackColor = true;
            this.CTRL_Del.Click += new System.EventHandler(this.CTRL_Del_Click);
            // 
            // NUMB_9
            // 
            this.NUMB_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_9.Location = new System.Drawing.Point(163, 422);
            this.NUMB_9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_9.Name = "NUMB_9";
            this.NUMB_9.Size = new System.Drawing.Size(63, 46);
            this.NUMB_9.TabIndex = 78;
            this.NUMB_9.Text = "9";
            this.NUMB_9.UseVisualStyleBackColor = true;
            this.NUMB_9.Click += new System.EventHandler(this.NUMB_9_Click);
            // 
            // NUMB_8
            // 
            this.NUMB_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.NUMB_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NUMB_8.Location = new System.Drawing.Point(96, 422);
            this.NUMB_8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_8.Name = "NUMB_8";
            this.NUMB_8.Size = new System.Drawing.Size(63, 46);
            this.NUMB_8.TabIndex = 77;
            this.NUMB_8.Text = "8";
            this.NUMB_8.UseVisualStyleBackColor = true;
            this.NUMB_8.Click += new System.EventHandler(this.NUMB_8_Click);
            // 
            // OutputText
            // 
            this.OutputText.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.OutputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputText.Location = new System.Drawing.Point(40, 100);
            this.OutputText.Name = "OutputText";
            this.OutputText.Size = new System.Drawing.Size(312, 30);
            this.OutputText.TabIndex = 86;
            this.OutputText.Text = "output";
            this.OutputText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 20);
            this.label3.TabIndex = 88;
            this.label3.Text = "Flag1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "Flag1";
            // 
            // DelLabel
            // 
            this.DelLabel.AutoSize = true;
            this.DelLabel.BackColor = System.Drawing.Color.White;
            this.DelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DelLabel.Location = new System.Drawing.Point(242, 438);
            this.DelLabel.Name = "DelLabel";
            this.DelLabel.Size = new System.Drawing.Size(40, 18);
            this.DelLabel.TabIndex = 94;
            this.DelLabel.Text = "DEL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(309, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 18);
            this.label5.TabIndex = 95;
            this.label5.Text = "AC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CTRL_Redo
            // 
            this.CTRL_Redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_Redo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_Redo.Location = new System.Drawing.Point(303, 249);
            this.CTRL_Redo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_Redo.Name = "CTRL_Redo";
            this.CTRL_Redo.Size = new System.Drawing.Size(51, 30);
            this.CTRL_Redo.TabIndex = 99;
            this.CTRL_Redo.Text = "Redo";
            this.CTRL_Redo.UseVisualStyleBackColor = true;
            this.CTRL_Redo.Click += new System.EventHandler(this.CTRL_Redo_Click);
            // 
            // CTRL_Undo
            // 
            this.CTRL_Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_Undo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_Undo.Location = new System.Drawing.Point(247, 249);
            this.CTRL_Undo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_Undo.Name = "CTRL_Undo";
            this.CTRL_Undo.Size = new System.Drawing.Size(51, 30);
            this.CTRL_Undo.TabIndex = 98;
            this.CTRL_Undo.Text = "Undo";
            this.CTRL_Undo.UseVisualStyleBackColor = true;
            this.CTRL_Undo.Click += new System.EventHandler(this.CTRL_Undo_Click);
            // 
            // MISC_CloseBracket
            // 
            this.MISC_CloseBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MISC_CloseBracket.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MISC_CloseBracket.Location = new System.Drawing.Point(83, 249);
            this.MISC_CloseBracket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MISC_CloseBracket.Name = "MISC_CloseBracket";
            this.MISC_CloseBracket.Size = new System.Drawing.Size(51, 30);
            this.MISC_CloseBracket.TabIndex = 97;
            this.MISC_CloseBracket.Text = ")";
            this.MISC_CloseBracket.UseVisualStyleBackColor = true;
            this.MISC_CloseBracket.Click += new System.EventHandler(this.MISC_CloseBracket_Click);
            // 
            // MISC_OpenBracket
            // 
            this.MISC_OpenBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MISC_OpenBracket.ForeColor = System.Drawing.SystemColors.WindowText;
            this.MISC_OpenBracket.Location = new System.Drawing.Point(29, 249);
            this.MISC_OpenBracket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MISC_OpenBracket.Name = "MISC_OpenBracket";
            this.MISC_OpenBracket.Size = new System.Drawing.Size(51, 30);
            this.MISC_OpenBracket.TabIndex = 96;
            this.MISC_OpenBracket.Text = "(";
            this.MISC_OpenBracket.UseVisualStyleBackColor = true;
            this.MISC_OpenBracket.Click += new System.EventHandler(this.MISC_OpenBracket_Click);
            // 
            // CTRL_MoveRight
            // 
            this.CTRL_MoveRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_MoveRight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_MoveRight.Location = new System.Drawing.Point(216, 198);
            this.CTRL_MoveRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_MoveRight.Name = "CTRL_MoveRight";
            this.CTRL_MoveRight.Size = new System.Drawing.Size(29, 50);
            this.CTRL_MoveRight.TabIndex = 101;
            this.CTRL_MoveRight.Text = "R";
            this.CTRL_MoveRight.UseVisualStyleBackColor = true;
            this.CTRL_MoveRight.Click += new System.EventHandler(this.CTRL_MoveRight_Click);
            // 
            // CTRL_MoveUp
            // 
            this.CTRL_MoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_MoveUp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_MoveUp.Location = new System.Drawing.Point(165, 166);
            this.CTRL_MoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_MoveUp.Name = "CTRL_MoveUp";
            this.CTRL_MoveUp.Size = new System.Drawing.Size(51, 30);
            this.CTRL_MoveUp.TabIndex = 102;
            this.CTRL_MoveUp.Text = "Up";
            this.CTRL_MoveUp.UseVisualStyleBackColor = true;
            this.CTRL_MoveUp.Click += new System.EventHandler(this.CTRL_MoveUp_Click);
            // 
            // CTRL_MoveLeft
            // 
            this.CTRL_MoveLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_MoveLeft.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_MoveLeft.Location = new System.Drawing.Point(133, 194);
            this.CTRL_MoveLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_MoveLeft.Name = "CTRL_MoveLeft";
            this.CTRL_MoveLeft.Size = new System.Drawing.Size(29, 50);
            this.CTRL_MoveLeft.TabIndex = 103;
            this.CTRL_MoveLeft.Text = "L";
            this.CTRL_MoveLeft.UseVisualStyleBackColor = true;
            this.CTRL_MoveLeft.Click += new System.EventHandler(this.CTRL_MoveLeft_Click);
            // 
            // CTRL_MoveDown
            // 
            this.CTRL_MoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTRL_MoveDown.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CTRL_MoveDown.Location = new System.Drawing.Point(165, 242);
            this.CTRL_MoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CTRL_MoveDown.Name = "CTRL_MoveDown";
            this.CTRL_MoveDown.Size = new System.Drawing.Size(51, 30);
            this.CTRL_MoveDown.TabIndex = 104;
            this.CTRL_MoveDown.Text = "Down";
            this.CTRL_MoveDown.UseVisualStyleBackColor = true;
            this.CTRL_MoveDown.Click += new System.EventHandler(this.CTRL_MoveDown_Click);
            // 
            // InputText
            // 
            this.InputText.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.InputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputText.Location = new System.Drawing.Point(31, 64);
            this.InputText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InputText.Name = "InputText";
            this.InputText.ReadOnly = true;
            this.InputText.Size = new System.Drawing.Size(325, 29);
            this.InputText.TabIndex = 105;
            // 
            // NUMB_7
            // 
            this.NUMB_7.BackColor = System.Drawing.Color.GhostWhite;
            this.NUMB_7.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.NUMB_7.BorderColor = System.Drawing.SystemColors.InfoText;
            this.NUMB_7.BorderRadius = 8;
            this.NUMB_7.BorderSize = 2;
            this.NUMB_7.FlatAppearance.BorderSize = 0;
            this.NUMB_7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NUMB_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUMB_7.ForeColor = System.Drawing.Color.Black;
            this.NUMB_7.Location = new System.Drawing.Point(28, 422);
            this.NUMB_7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NUMB_7.Name = "NUMB_7";
            this.NUMB_7.Size = new System.Drawing.Size(63, 46);
            this.NUMB_7.TabIndex = 90;
            this.NUMB_7.Text = "7";
            this.NUMB_7.TextColor = System.Drawing.Color.Black;
            this.NUMB_7.UseVisualStyleBackColor = false;
            this.NUMB_7.Click += new System.EventHandler(this.NUMB_7_Click);
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customButton2.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.customButton2.BorderColor = System.Drawing.Color.Black;
            this.customButton2.BorderRadius = 15;
            this.customButton2.BorderSize = 2;
            this.customButton2.FlatAppearance.BorderSize = 0;
            this.customButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.Location = new System.Drawing.Point(23, 28);
            this.customButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(340, 116);
            this.customButton2.TabIndex = 81;
            this.customButton2.Text = " ";
            this.customButton2.TextColor = System.Drawing.Color.Black;
            this.customButton2.UseVisualStyleBackColor = false;
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.GhostWhite;
            this.customButton1.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.customButton1.BorderColor = System.Drawing.Color.Black;
            this.customButton1.BorderRadius = 10;
            this.customButton1.BorderSize = 2;
            this.customButton1.FlatAppearance.BorderSize = 0;
            this.customButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ForeColor = System.Drawing.Color.Black;
            this.customButton1.Location = new System.Drawing.Point(171, 68);
            this.customButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(51, 39);
            this.customButton1.TabIndex = 61;
            this.customButton1.Text = "customButton1";
            this.customButton1.TextColor = System.Drawing.Color.Black;
            this.customButton1.UseVisualStyleBackColor = false;
            // 
            // customButton3
            // 
            this.customButton3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.customButton3.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.customButton3.BorderColor = System.Drawing.Color.Black;
            this.customButton3.BorderRadius = 10;
            this.customButton3.BorderSize = 2;
            this.customButton3.FlatAppearance.BorderSize = 0;
            this.customButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton3.ForeColor = System.Drawing.Color.Black;
            this.customButton3.Location = new System.Drawing.Point(23, 150);
            this.customButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton3.Name = "customButton3";
            this.customButton3.Size = new System.Drawing.Size(340, 82);
            this.customButton3.TabIndex = 82;
            this.customButton3.Text = " ";
            this.customButton3.TextColor = System.Drawing.Color.Black;
            this.customButton3.UseVisualStyleBackColor = false;
            // 
            // customButton4
            // 
            this.customButton4.BackColor = System.Drawing.Color.Goldenrod;
            this.customButton4.BackgroundColor = System.Drawing.Color.Goldenrod;
            this.customButton4.BorderColor = System.Drawing.Color.Black;
            this.customButton4.BorderRadius = 10;
            this.customButton4.BorderSize = 2;
            this.customButton4.FlatAppearance.BorderSize = 0;
            this.customButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton4.ForeColor = System.Drawing.Color.Black;
            this.customButton4.Location = new System.Drawing.Point(17, 242);
            this.customButton4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton4.Name = "customButton4";
            this.customButton4.Size = new System.Drawing.Size(347, 156);
            this.customButton4.TabIndex = 83;
            this.customButton4.Text = " ";
            this.customButton4.TextColor = System.Drawing.Color.Black;
            this.customButton4.UseVisualStyleBackColor = false;
            // 
            // customButton6
            // 
            this.customButton6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.customButton6.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.customButton6.BorderColor = System.Drawing.Color.Black;
            this.customButton6.BorderRadius = 10;
            this.customButton6.BorderSize = 2;
            this.customButton6.FlatAppearance.BorderSize = 0;
            this.customButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton6.ForeColor = System.Drawing.Color.Black;
            this.customButton6.Location = new System.Drawing.Point(17, 409);
            this.customButton6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton6.Name = "customButton6";
            this.customButton6.Size = new System.Drawing.Size(347, 225);
            this.customButton6.TabIndex = 85;
            this.customButton6.Text = " ";
            this.customButton6.TextColor = System.Drawing.Color.Black;
            this.customButton6.UseVisualStyleBackColor = false;
            // 
            // customButton5
            // 
            this.customButton5.BackColor = System.Drawing.SystemColors.Control;
            this.customButton5.BackgroundColor = System.Drawing.SystemColors.Control;
            this.customButton5.BorderColor = System.Drawing.Color.Black;
            this.customButton5.BorderRadius = 30;
            this.customButton5.BorderSize = 2;
            this.customButton5.FlatAppearance.BorderSize = 0;
            this.customButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton5.ForeColor = System.Drawing.Color.Black;
            this.customButton5.Location = new System.Drawing.Point(1, 4);
            this.customButton5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customButton5.Name = "customButton5";
            this.customButton5.Size = new System.Drawing.Size(380, 647);
            this.customButton5.TabIndex = 84;
            this.customButton5.Text = " ";
            this.customButton5.TextColor = System.Drawing.Color.Black;
            this.customButton5.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(381, 663);
            this.Controls.Add(this.InputText);
            this.Controls.Add(this.CTRL_MoveDown);
            this.Controls.Add(this.CTRL_MoveLeft);
            this.Controls.Add(this.CTRL_MoveUp);
            this.Controls.Add(this.CTRL_MoveRight);
            this.Controls.Add(this.CTRL_Redo);
            this.Controls.Add(this.CTRL_Undo);
            this.Controls.Add(this.MISC_CloseBracket);
            this.Controls.Add(this.MISC_OpenBracket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DelLabel);
            this.Controls.Add(this.NUMB_7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.CTRL_Ac);
            this.Controls.Add(this.CTRL_Del);
            this.Controls.Add(this.NUMB_9);
            this.Controls.Add(this.NUMB_8);
            this.Controls.Add(this.OPER_Div);
            this.Controls.Add(this.OPER_Mul);
            this.Controls.Add(this.NUMB_6);
            this.Controls.Add(this.NUMB_5);
            this.Controls.Add(this.NUMB_4);
            this.Controls.Add(this.OPER_Sub);
            this.Controls.Add(this.OPER_Add);
            this.Controls.Add(this.NUMB_3);
            this.Controls.Add(this.NUMB_2);
            this.Controls.Add(this.NUMB_1);
            this.Controls.Add(this.CTRL_Equal);
            this.Controls.Add(this.MISC_Ans);
            this.Controls.Add(this.FUNC_PowerOfTen);
            this.Controls.Add(this.MISC_Dot);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.FUNC_Ln);
            this.Controls.Add(this.FUNC_Logarit);
            this.Controls.Add(this.FUNC_Pow);
            this.Controls.Add(this.FUNC_Square);
            this.Controls.Add(this.FUNC_Sqrt);
            this.Controls.Add(this.FUNC_Fraction);
            this.Controls.Add(this.FUNC_Tan);
            this.Controls.Add(this.FUNC_Cos);
            this.Controls.Add(this.FUNC_Sin);
            this.Controls.Add(this.OPER_Not);
            this.Controls.Add(this.OPER_Or);
            this.Controls.Add(this.OPER_And);
            this.Controls.Add(this.OPER_Ne);
            this.Controls.Add(this.OPER_Eq);
            this.Controls.Add(this.OPER_Le);
            this.Controls.Add(this.OPER_Ge);
            this.Controls.Add(this.OPER_Lt);
            this.Controls.Add(this.OPER_Gt);
            this.Controls.Add(this.STATE_Power);
            this.Controls.Add(this.STATE_Mode);
            this.Controls.Add(this.STATE_Alpha);
            this.Controls.Add(this.STATE_Shift);
            this.Controls.Add(this.NUMB_0);
            this.Controls.Add(this.customButton3);
            this.Controls.Add(this.customButton4);
            this.Controls.Add(this.customButton6);
            this.Controls.Add(this.customButton5);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button NUMB_0;
        internal System.Windows.Forms.Button STATE_Shift;
        internal System.Windows.Forms.Button STATE_Alpha;
        internal System.Windows.Forms.Button STATE_Power;
        internal System.Windows.Forms.Button STATE_Mode;
        internal System.Windows.Forms.Button OPER_Gt;
        internal System.Windows.Forms.Button OPER_Lt;
        internal System.Windows.Forms.Button OPER_Ge;
        internal System.Windows.Forms.Button OPER_Le;
        internal System.Windows.Forms.Button OPER_Eq;
        internal System.Windows.Forms.Button OPER_Ne;
        internal System.Windows.Forms.Button FUNC_Tan;
        internal System.Windows.Forms.Button FUNC_Cos;
        internal System.Windows.Forms.Button FUNC_Sin;
        internal System.Windows.Forms.Button OPER_Not;
        internal System.Windows.Forms.Button OPER_Or;
        internal System.Windows.Forms.Button OPER_And;
        internal System.Windows.Forms.Button FUNC_Ln;
        internal System.Windows.Forms.Button FUNC_Logarit;
        internal System.Windows.Forms.Button FUNC_Pow;
        internal System.Windows.Forms.Button FUNC_Square;
        internal System.Windows.Forms.Button FUNC_Sqrt;
        internal System.Windows.Forms.Button FUNC_Fraction;
        internal CustomControls.CustomButton.CustomButton customButton1;
        internal System.Windows.Forms.Button MISC_Dot;
        internal System.Windows.Forms.Button MISC_Ans;
        internal System.Windows.Forms.Button FUNC_PowerOfTen;
        internal System.Windows.Forms.Button CTRL_Equal;
        internal System.Windows.Forms.Button OPER_Sub;
        internal System.Windows.Forms.Button OPER_Add;
        internal System.Windows.Forms.Button NUMB_3;
        internal System.Windows.Forms.Button NUMB_2;
        internal System.Windows.Forms.Button NUMB_1;
        internal System.Windows.Forms.Button OPER_Div;
        internal System.Windows.Forms.Button OPER_Mul;
        internal System.Windows.Forms.Button NUMB_6;
        internal System.Windows.Forms.Button NUMB_5;
        internal System.Windows.Forms.Button NUMB_4;
        internal System.Windows.Forms.Button CTRL_Ac;
        internal System.Windows.Forms.Button CTRL_Del;
        internal System.Windows.Forms.Button NUMB_9;
        internal System.Windows.Forms.Button NUMB_8;
        internal CustomControls.CustomButton.CustomButton customButton2;
        internal CustomControls.CustomButton.CustomButton customButton3;
        internal CustomControls.CustomButton.CustomButton customButton4;
        internal CustomControls.CustomButton.CustomButton customButton5;
        internal CustomControls.CustomButton.CustomButton customButton6;
        public System.Windows.Forms.Label OutputText;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal CustomControls.CustomButton.CustomButton NUMB_7;
        internal System.Windows.Forms.Label DelLabel;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Button CTRL_Redo;
        internal System.Windows.Forms.Button CTRL_Undo;
        internal System.Windows.Forms.Button MISC_CloseBracket;
        internal System.Windows.Forms.Button MISC_OpenBracket;
        internal System.Windows.Forms.Button CTRL_MoveRight;
        internal System.Windows.Forms.Button CTRL_MoveUp;
        internal System.Windows.Forms.Button CTRL_MoveLeft;
        internal System.Windows.Forms.Button CTRL_MoveDown;
        public CustomControls.CalculatorTextbox.CalculatorTextbox InputText;
    }
}