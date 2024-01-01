using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCalculator
{
    public partial class EquationSolving : Form
    {
        private int buttonClicked = -1;
        private Button[] tabButtons;
        private Panel[] screenList;

        public EquationSolving()
        {
            InitializeComponent();

            tabButtons = new Button[] { TwoDegreeMenu, ThreeDegreeMenu, FourDegreeMenu, TwoUnknowsMenu, ThreeUnknowsMenu, FourUnknowsMenu };
            screenList = new Panel[] { PolyTwoDegreeScreen, PolyThreeDegreeScreen, PolyFourDegreeScreen, EquaTwoUnknowsScreen, EquaThreeUnknowsScreen, EquaFourUnknowsScreen };
            
        }
        private void test_Load(object sender, EventArgs e)
        {
            TwoDegreeMenu.PerformClick();
        }

        private void SwitchScreen(Panel[] screenList)
        {
            foreach (Panel panel in screenList)
            {
                panel.Visible = false;
                panel.Enabled = false;
            }
        }

        private void Button_Deallocate(Button[] tabButtons)
        {
            foreach (Button button in tabButtons)
            {
                button.BackColor = SystemColors.Control;
                button.Enabled = true;
            }
        }

        private void Page1Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 1)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 1;
                TwoDegreeMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Polynomial Two Degree:";
                TwoDegreeMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                PolyTwoDegreeScreen.Visible = true;
                PolyTwoDegreeScreen.Enabled = true;
            }
        }

        private void Page2Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 2)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 2;
                ThreeDegreeMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Polynomial Three Degree:";
                ThreeDegreeMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                PolyThreeDegreeScreen.Visible = true;
                PolyThreeDegreeScreen.Enabled = true;
            }
        }

        private void Page3Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 3)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 3;
                FourDegreeMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Polynomial Four Degree:";
                FourDegreeMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                PolyFourDegreeScreen.Visible = true;
                PolyFourDegreeScreen.Enabled = true;
            }
        }

        private void Page4Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 4)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 4;
                TwoUnknowsMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Equation Two Unknows:";
                TwoUnknowsMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                EquaTwoUnknowsScreen.Visible = true;
                EquaTwoUnknowsScreen.Enabled = true;
            }
        }

        private void Page5Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 5)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 5;
                ThreeUnknowsMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Equation Three Unknows:";
                ThreeUnknowsMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                EquaThreeUnknowsScreen.Visible = true;
                EquaThreeUnknowsScreen.Enabled = true;
            }
        }

        private void Page6Button_Click(object sender, EventArgs e)
        {
            if (buttonClicked != 6)
            {
                //Swich screen button
                Button_Deallocate(tabButtons);
                buttonClicked = 6;
                FourUnknowsMenu.BackColor = SystemColors.GradientInactiveCaption;
                NamePageLabel.Text = "Equation Four Unknows:";
                FourUnknowsMenu.Enabled = false;

                //Switch Panel
                SwitchScreen(screenList);
                EquaFourUnknowsScreen.Visible = true;
                EquaFourUnknowsScreen.Enabled = true;
            }
        }

        private void EquaFourUnknowsScreen_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 2);
                //Vertical line
                var point1 = new Point(30, 20);
                var point2 = new Point(30, 190);

                //Head horizontal line
                var point3 = new Point(30, 20);
                var point4 = new Point(40, 20);

                //Tail horizontal line
                var point5 = new Point(30, 190);
                var point6 = new Point(40, 190);

                g.DrawLine(p, point1, point2);
                g.DrawLine(p, point3, point4);
                g.DrawLine(p, point5, point6);
            }
        }

        private void EquaThreeUnknowsScreen_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 2);
                //Vertical line
                var point1 = new Point(80, 40);
                var point2 = new Point(80, 180);

                //Head horizontal line
                var point3 = new Point(80, 40);
                var point4 = new Point(90, 40);

                //Tail horizontal line
                var point5 = new Point(80, 180);
                var point6 = new Point(90, 180);

                g.DrawLine(p, point1, point2);
                g.DrawLine(p, point3, point4);
                g.DrawLine(p, point5, point6);
            }
        }

        private void EquaTwoUnknowsScreen_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 2);
                //Vertical line
                var point1 = new Point(100, 60);
                var point2 = new Point(100, 160);

                //Head horizontal line
                var point3 = new Point(100, 60);
                var point4 = new Point(110, 60);

                //Tail horizontal line
                var point5 = new Point(100, 160);
                var point6 = new Point(110, 160);

                g.DrawLine(p, point1, point2);
                g.DrawLine(p, point3, point4);
                g.DrawLine(p, point5, point6);
            }
        }

        private void PolyTwoDegreeResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(PolyTwoDegreeTextBox4.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double x1 = 0, x2 = 0;
                double a = Double.Parse(PolyTwoDegreeTextBox1.Text);
                double b = Double.Parse(PolyTwoDegreeTextBox2.Text);
                double c = Double.Parse(PolyTwoDegreeTextBox3.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("a không được bằng 0");
                int numNo = Polynomial.Polynomial2Degree(a, b, c, ref x1, ref x2);


                x1 = System.Math.Round(x1, round);
                x2 = System.Math.Round(x2, round);

                if (numNo == 0)
                {
                    PolyTwoDegreeResult1.Text = "Vô nghiệm";
                    PolyTwoDegreeResult2.Text = "Vô nghiệm";
                }
                else if (numNo == 1)
                {

                    PolyTwoDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyTwoDegreeResult2.Text = "x2 = " + x1.ToString();
                }
                else
                {
                    PolyTwoDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyTwoDegreeResult2.Text = "x2 = " + x2.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("a không được bằng 0");
            }
        }

        private void PolyThreeDegreeResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(PolyThreeDegreeTextBox5.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double x1 = 0, x2 = 0, x3 = 0;
                double a = Double.Parse(PolyThreeDegreeTextBox1.Text);
                double b = Double.Parse(PolyThreeDegreeTextBox3.Text);
                double c = Double.Parse(PolyThreeDegreeTextBox2.Text);
                double d = Double.Parse(PolyThreeDegreeTextBox4.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("a không được bằng 0");
                int numNo = Polynomial.Polynomial3Degree(a, b, c, d, ref x1, ref x2, ref x3);
               
                x1 = System.Math.Round(x1, round);
                x2 = System.Math.Round(x2, round);
                x3 = System.Math.Round(x3, round);

                if (numNo == 1)
                {
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyThreeDegreeResult2.Text = "x2 = " + x2.ToString();
                    PolyThreeDegreeResult3.Text = "x3 = " + x3.ToString();
                }
                else if (numNo == 2 || numNo == 4)
                {
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyThreeDegreeResult2.Text = "Vô nghiệm";
                    PolyThreeDegreeResult3.Text = "Vô nghiệm";
                }
                else if (numNo == 3)
                {
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyThreeDegreeResult2.Text = "x2 = " + x2.ToString();
                    PolyThreeDegreeResult3.Text = "Vô nghiệm";
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("a không được bằng 0");
            }
        }

        private void PolyFourDegreeResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(PolyFourDegreeLTextBox6.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double a = Double.Parse(PolyFourDegreeLTextBox1.Text);
                double b = Double.Parse(PolyFourDegreeLTextBox2.Text);
                double c = Double.Parse(PolyFourDegreeLTextBox3.Text);
                double d = Double.Parse(PolyFourDegreeLTextBox4.Text);
                double f = Double.Parse(PolyFourDegreeLTextBox5.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("a không được bằng 0");
                Complex[] result = Polynomial.Polynomial4Degree(a, b, c, d, f);


                if (result[0].Imaginary == 0)
                    PolyFourDegreeResult1.Text = "x1 = " + result[0].Real.Round(round).ToString();
                else
                    PolyFourDegreeResult1.Text = "Vô nghiệm";

                if (result[1].Imaginary == 0)
                    PolyFourDegreeResult2.Text = "x2 = " + result[1].Real.Round(round).ToString();
                else
                    PolyFourDegreeResult2.Text = "Vô nghiệm";

                if (result[2].Imaginary == 0)
                    PolyFourDegreeResult3.Text = "x3 = " + result[2].Real.Round(round).ToString();
                else
                    PolyFourDegreeResult3.Text = "Vô nghiệm";

                if (result[3].Imaginary == 0)
                    PolyFourDegreeResult4.Text = "x4 = " + result[3].Real.Round(round).ToString();
                else
                    PolyFourDegreeResult4.Text = "Vô nghiệm";

            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("a không được bằng 0");
            }
        }

        private void EquaTwoUnknowsResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(EquaTwoUnknowsTextBox7.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double x = 0, y = 0;
                double x1 = Double.Parse(EquaTwoUnknowsTextBox1.Text);
                double x2 = Double.Parse(EquaTwoUnknowsTextBox4.Text);
                double y1 = Double.Parse(EquaTwoUnknowsTextBox2.Text);
                double y2 = Double.Parse(EquaTwoUnknowsTextBox5.Text);
                double z1 = Double.Parse(EquaTwoUnknowsTextBox3.Text);
                double z2 = Double.Parse(EquaTwoUnknowsTextBox6.Text);

                int numNo = SimulEquation.SimulEquation2Unknows(x1, x2, y1, y2, z1, z2, ref x, ref y);

                x = System.Math.Round(x, round);
                y = System.Math.Round(y, round);

                if (numNo == 0)
                {
                    EquaTwoUnknowsResult1.Text = "Vô nghiệm";
                    EquaTwoUnknowsResult2.Text = "Vô nghiệm";
                }
                else if (numNo == 1)
                {
                    EquaTwoUnknowsResult1.Text = "Vô số nghiệm";
                    EquaTwoUnknowsResult2.Text = "Vô số nghiệm";
                }
                else
                {
                    EquaTwoUnknowsResult1.Text = "x = " + x.ToString();
                    EquaTwoUnknowsResult2.Text = "y = " + y.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
            }
        }

        private void EquaThreeUnknowsResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(EquaThreeUnknowsTextBox13.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double x1 = Double.Parse(EquaThreeUnknowsTextBox1.Text);
                double x2 = Double.Parse(EquaThreeUnknowsTextBox5.Text);
                double x3 = Double.Parse(EquaThreeUnknowsTextBox9.Text);
                double y1 = Double.Parse(EquaThreeUnknowsTextBox2.Text);
                double y2 = Double.Parse(EquaThreeUnknowsTextBox6.Text);
                double y3 = Double.Parse(EquaThreeUnknowsTextBox10.Text);
                double z1 = Double.Parse(EquaThreeUnknowsTextBox3.Text);
                double z2 = Double.Parse(EquaThreeUnknowsTextBox7.Text);
                double z3 = Double.Parse(EquaThreeUnknowsTextBox11.Text);
                double a = Double.Parse(EquaThreeUnknowsTextBox4.Text);
                double b = Double.Parse(EquaThreeUnknowsTextBox8.Text);
                double c = Double.Parse(EquaThreeUnknowsTextBox12.Text);

                //Calculation
                double[,] matrix = { { x1, y1, z1 }, { x2, y2, z2 }, { x3, y3, z3 } };
                int size = 3;
                double[] RHSMatrix = new double[3] { a, b, c };
                var tuple = SimulEquation.GaussianElimination(size, matrix, RHSMatrix);
                double[] result = SimulEquation.BackCalculation(size, tuple.Item2, tuple.Item3);
                int resultState = tuple.Item1;

                
                result[0] = System.Math.Round(result[0], round);
                result[1] = System.Math.Round(result[1], round);
                result[2] = System.Math.Round(result[2], round);

                //Print result
                if (resultState == 2)
                {
                    EquaThreeUnknowsResult1.Text = "x = " + result[0].ToString();
                    EquaThreeUnknowsResult2.Text = "y = " + result[1].ToString();
                    EquaThreeUnknowsResult3.Text = "z = " + result[2].ToString();
                }
                else if (resultState == 0)
                {
                    EquaThreeUnknowsResult1.Text = "Vô số nghiệm";
                    EquaThreeUnknowsResult2.Text = "Vô số nghiệm";
                    EquaThreeUnknowsResult3.Text = "Vô số nghiệm";
                }
                else if (resultState == 1)
                {
                    EquaThreeUnknowsResult1.Text = "Vô nghiệm";
                    EquaThreeUnknowsResult2.Text = "Vô nghiệm";
                    EquaThreeUnknowsResult3.Text = "Vô nghiệm";
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
            }
        }

        private void EquaFourUnknowsResultButton_Click(object sender, EventArgs e)
        {
            int round = 10;

            try
            {
                round = Int32.Parse(EquaFourUnknowTextBox20.Text);
            }
            catch (Exception)
            {
            }

            try
            {
                double x1 = Double.Parse(EquaFourUnknowsTextBox1.Text);
                double x2 = Double.Parse(EquaFourUnknowsTextBox6.Text);
                double x3 = Double.Parse(EquaFourUnknowsTextBox11.Text);
                double x4 = Double.Parse(EquaFourUnknowsTextBox16.Text);
                double y1 = Double.Parse(EquaFourUnknowsTextBox2.Text);
                double y2 = Double.Parse(EquaFourUnknowsTextBox7.Text);
                double y3 = Double.Parse(EquaFourUnknowsTextBox12.Text);
                double y4 = Double.Parse(EquaFourUnknowsTextBox17.Text);
                double z1 = Double.Parse(EquaFourUnknowsTextBox3.Text);
                double z2 = Double.Parse(EquaFourUnknowsTextBox8.Text);
                double z3 = Double.Parse(EquaFourUnknowsTextBox13.Text);
                double z4 = Double.Parse(EquaFourUnknowsTextBox18.Text);
                double t1 = Double.Parse(EquaFourUnknowsTextBox4.Text);
                double t2 = Double.Parse(EquaFourUnknowsTextBox9.Text);
                double t3 = Double.Parse(EquaFourUnknowsTextBox14.Text);
                double t4 = Double.Parse(EquaFourUnknowsTextBox19.Text);
                double a = Double.Parse(EquaFourUnknowsTextBox5.Text);
                double b = Double.Parse(EquaFourUnknowsTextBox10.Text);
                double c = Double.Parse(EquaFourUnknowsTextBox15.Text);
                double d = Double.Parse(EquaFourUnknowsTextBox20.Text);

                //Calculation
                double[,] matrix = { { x1, y1, z1, t1 }, { x2, y2, z2, t2 }, { x3, y3, z3, t3 }, { x4, y4, z4, t4 } };
                int size = 4;
                double[] RHSMatrix = new double[4] { a, b, c, d };
                var tuple = SimulEquation.GaussianElimination(size, matrix, RHSMatrix);
                double[] result = SimulEquation.BackCalculation(size, tuple.Item2, tuple.Item3);
                int resultState = tuple.Item1;

                result[0] = System.Math.Round(result[0], round);
                result[1] = System.Math.Round(result[1], round);
                result[2] = System.Math.Round(result[2], round);
                result[3] = System.Math.Round(result[3], round);

                //Print result
                if (resultState == 2)
                {
                    EquaFourUnknowsResult1.Text = "x = " + result[0].ToString();
                    EquaFourUnknowsResult2.Text = "y = " + result[1].ToString();
                    EquaFourUnknowsResult3.Text = "z = " + result[2].ToString();
                    EquaFourUnknowsResult4.Text = "t = " + result[3].ToString();
                }
                else if (resultState == 0)
                {
                    EquaFourUnknowsResult1.Text = "Vô số nghiệm";
                    EquaFourUnknowsResult2.Text = "Vô số nghiệm";
                    EquaFourUnknowsResult3.Text = "Vô số nghiệm";
                    EquaFourUnknowsResult4.Text = "Vô số nghiệm";
                }
                else if (resultState == 1)
                {
                    EquaFourUnknowsResult1.Text = "Vô nghiệm";
                    EquaFourUnknowsResult2.Text = "Vô nghiệm";
                    EquaFourUnknowsResult3.Text = "Vô nghiệm";
                    EquaFourUnknowsResult4.Text = "Vô nghiệm";
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Không được để trống");
            }
        }
    }
}
