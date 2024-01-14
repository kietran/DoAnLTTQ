using CustomUserControls.RoundedButton;
using CustomUserControls.RoundedPanel;
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
        private int currentlyOnButton = -1;
        int round = 8;
        private RoundedButton[] buttonList;
        private RoundedPanel[] screenList;

        public EquationSolving()
        {
            InitializeComponent();

            buttonList = new RoundedButton[] { TwoDegreeMenu, ThreeDegreeMenu, FourDegreeMenu, TwoUnknowsMenu, ThreeUnknowsMenu, FourUnknowsMenu };
            screenList = new RoundedPanel[] { PolyTwoDegreeScreen, PolyThreeDegreeScreen, PolyFourDegreeScreen, EquaTwoUnknowsScreen, EquaThreeUnknowsScreen, EquaFourUnknowsScreen };

        }


        private void HideAllScreen()
        {
            foreach (RoundedPanel panel in screenList)
            {
                panel.Visible = false;
            }
        }

        private void ResetButtonsBackground()
        {
            foreach (RoundedButton button in buttonList)
            {
                button.InteriorColor = Color.White;
            }
        }

        private void Page1Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 1)
            {    
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 1;
                TwoDegreeMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving polynomial second degree:";
                
                //Switch RoundedPanel
                HideAllScreen();
                PolyTwoDegreeScreen.Visible = true;
                PolyTwoDegreeScreen.Enabled = true;
                PolyTwoDegreeTextBox1.Select();
            }
        }

        private void Page2Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 2)
            {    
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 2;
                ThreeDegreeMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving polynomial third degree:";

                //Switch RoundedPanel
                HideAllScreen();
                PolyThreeDegreeScreen.Visible = true;
                PolyThreeDegreeScreen.Enabled = true;
                PolyThreeDegreeTextBox1.Select();
            }
        }

        private void Page3Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 3)
            {
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 3;
                FourDegreeMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving polynomial fourth degree:";

                //Switch RoundedPanel
                HideAllScreen();
                PolyFourDegreeScreen.Visible = true;
                PolyFourDegreeScreen.Enabled = true;
                PolyFourDegreeLTextBox1.Select();
            }
        }

        private void Page4Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 4)
            {
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 4;
                TwoUnknowsMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving two unknowns equations:";

                //Switch RoundedPanel
                HideAllScreen();
                EquaTwoUnknowsScreen.Visible = true;
                EquaTwoUnknowsScreen.Enabled = true;
                EquaTwoUnknowsTextBox1.Select();
            }
        }

        private void Page5Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 5)
            {
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 5;
                ThreeUnknowsMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving three unknowns equations:";

                //Switch RoundedPanel
                HideAllScreen();
                EquaThreeUnknowsScreen.Visible = true;
                EquaThreeUnknowsScreen.Enabled = true;
                EquaThreeUnknowsTextBox1.Select();
            }
        }

        private void Page6Button_Click(object sender, EventArgs e)
        {
            if (currentlyOnButton != 6)
            {
                //Swich screen button
                ResetButtonsBackground();
                currentlyOnButton = 6;
                FourUnknowsMenu.InteriorColor = Color.Gainsboro;
                NamePageLabel.Text = "Solving four unknowns equations:";

                //Switch RoundedPanel
                HideAllScreen();
                EquaFourUnknowsScreen.Visible = true;
                EquaFourUnknowsScreen.Enabled = true;
                EquaFourUnknowsTextBox1.Select();
            }
        }

        private void PolyTwoDegreeResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = 0, x2 = 0;
                double a = Double.Parse(PolyTwoDegreeTextBox1.Text);
                double b = Double.Parse(PolyTwoDegreeTextBox2.Text);
                double c = Double.Parse(PolyTwoDegreeTextBox3.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("Value of A cannot be 0");
                int numNo = Polynomial.Polynomial2Degree(a, b, c, ref x1, ref x2);


                x1 = System.Math.Round(x1, round);
                x2 = System.Math.Round(x2, round);

                if (numNo == 0)
                {
                    label2.Text = " The given Equation has no real solutions:";
                    PolyTwoDegreeResult1.Hide();
                    PolyTwoDegreeResult2.Hide();
                }
                else if (numNo == 1)
                {
                    PolyTwoDegreeResult1.Show();
                    PolyTwoDegreeResult2.Hide();
                    label2.Text = " The given Equation has a double root solution";
                    PolyTwoDegreeResult1.Text = "x1,x2 = " + x1.ToString();
                }
                else
                {
                    PolyTwoDegreeResult1.Show();
                    PolyTwoDegreeResult2.Show();
                    label2.Text = " The given Equation has two real solutions:";
                    PolyTwoDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyTwoDegreeResult2.Text = "x2 = " + x2.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("Value of A cannot be 0");
            }
        }
        private void PolyThreeDegreeResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = 0, x2 = 0, x3 = 0;
                double a = Double.Parse(PolyThreeDegreeTextBox1.Text);
                double b = Double.Parse(PolyThreeDegreeTextBox3.Text);
                double c = Double.Parse(PolyThreeDegreeTextBox2.Text);
                double d = Double.Parse(PolyThreeDegreeTextBox4.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("Value of A cannot be 0");
                int numNo = Polynomial.Polynomial3Degree(a, b, c, d, ref x1, ref x2, ref x3);

                x1 = System.Math.Round(x1, round);
                x2 = System.Math.Round(x2, round);
                x3 = System.Math.Round(x3, round);

                if (numNo == 1)
                {
                    PolyThreeDegreeResult1.Show();
                    PolyThreeDegreeResult2.Show();
                    PolyThreeDegreeResult3.Show();

                    PolyThreeDegreeSolutionOverview.Text = "The given Equation has 3 real solutions:";
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyThreeDegreeResult2.Text = "x2 = " + x2.ToString();
                    PolyThreeDegreeResult3.Text = "x3 = " + x3.ToString();
                }
                else if (numNo == 2 || numNo == 4)
                {
                    PolyThreeDegreeResult1.Show();
                    PolyThreeDegreeResult2.Hide();
                    PolyThreeDegreeResult3.Hide();

                    PolyThreeDegreeSolutionOverview.Text = "The given Equation has only 1 real solution";
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                }
                else if (numNo == 3)
                {
                    PolyThreeDegreeResult1.Show();
                    PolyThreeDegreeResult2.Show();
                    PolyThreeDegreeResult3.Hide();

                    PolyThreeDegreeSolutionOverview.Text = "The given Equation has 2 real solution";
                    PolyThreeDegreeResult1.Text = "x1 = " + x1.ToString();
                    PolyThreeDegreeResult2.Text = "x2 = " + x2.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("Value of A cannot be 0");
            }
        }

        private void PolyFourDegreeResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Double.Parse(PolyFourDegreeLTextBox1.Text);
                double b = Double.Parse(PolyFourDegreeLTextBox2.Text);
                double c = Double.Parse(PolyFourDegreeLTextBox3.Text);
                double d = Double.Parse(PolyFourDegreeLTextBox4.Text);
                double f = Double.Parse(PolyFourDegreeLTextBox5.Text);
                //Calculate result
                if (a == 0)
                    throw new ArithmeticException("Value of A cannot be 0");
                Complex[] result = Polynomial.Polynomial4Degree(a, b, c, d, f);

                double[] toDisplay = new double[4];
                int numberOfSolutions = 0;
                if (result[0].Imaginary == 0)
                {
                    toDisplay[numberOfSolutions] = result[0].Real.Round(round);
                    numberOfSolutions++;
                }
                if (result[1].Imaginary == 0)
                {
                    toDisplay[numberOfSolutions] = result[1].Real.Round(round);
                    numberOfSolutions++;
                }
                if (result[2].Imaginary == 0)
                {
                    toDisplay[numberOfSolutions] = result[2].Real.Round(round);
                    numberOfSolutions++;
                }
                if (result[3].Imaginary == 0)
                {
                    toDisplay[numberOfSolutions] = result[3].Real.Round(round);
                    numberOfSolutions++;
                }
                PolyFourDegreeResult1.Hide();
                PolyFourDegreeResult2.Hide();
                PolyFourDegreeResult3.Hide();
                PolyFourDegreeResult4.Hide();
                if (numberOfSolutions == 0)
                {
                    label7.Text = " The given Equation has no real solutions";
                }
                else
                {
                    if(numberOfSolutions >= 1)
                    {
                        PolyFourDegreeResult1.Show();
                        PolyFourDegreeResult1.Text = "x1 = " + toDisplay[0].ToString();
                        label7.Text = " The given Equation has only one real solutions:";
                    }
                    if (numberOfSolutions >= 2)
                    {
                        PolyFourDegreeResult2.Show();
                        PolyFourDegreeResult2.Text = "x2 = " + toDisplay[1].ToString();
                        label7.Text = " The given Equation 2 real solutions:";
                    }
                    if (numberOfSolutions >= 3)
                    {
                        PolyFourDegreeResult3.Show();
                        PolyFourDegreeResult3.Text = "x3 = " + toDisplay[2].ToString();
                        label7.Text = " The given Equation has 3 real solutions:";
                    }
                    if (numberOfSolutions >= 4)
                    {
                        PolyFourDegreeResult4.Show();
                        PolyFourDegreeResult4.Text = "x4 = " + toDisplay[3].ToString();
                        label7.Text = " The given Equation has 4 real solutions:";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
                else if (ex is System.ArithmeticException)
                    MessageBox.Show("Value of A cannot be 0");
            }
        }

        private void EquaTwoUnknowsResultButton_Click(object sender, EventArgs e)
        {
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
                    EquaTwoUnknowsResult1.Hide();
                    EquaTwoUnknowsResult2.Hide();

                    label5.Text = " The given system of equations has infinite solution"; 
                }
                else if (numNo == 1)
                {
                    EquaTwoUnknowsResult1.Hide();
                    EquaTwoUnknowsResult2.Hide();
                  
                    label5.Text = " The given system of equations has no solutions";
                }
                else
                {
                    EquaTwoUnknowsResult1.Show();
                    EquaTwoUnknowsResult2.Show();

                    label5.Text = " The given system of equations has a solution:";

                    EquaTwoUnknowsResult1.Text = "x = " + x.ToString();
                    EquaTwoUnknowsResult2.Text = "y = " + y.ToString();
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
            }
        }

        private void EquaThreeUnknowsResultButton_Click(object sender, EventArgs e)
        {

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
                    EquaThreeUnknowsResult1.Show();
                    EquaThreeUnknowsResult2.Show();
                    EquaThreeUnknowsResult3.Show();

                    label11.Text = " The given system of equations has a solutions:";

                    EquaThreeUnknowsResult1.Text = "x = " + result[0].ToString();
                    EquaThreeUnknowsResult2.Text = "y = " + result[1].ToString();
                    EquaThreeUnknowsResult3.Text = "z = " + result[2].ToString();
                }
                else if (resultState == 0)
                {
                    EquaThreeUnknowsResult1.Hide();
                    EquaThreeUnknowsResult2.Hide();
                    EquaThreeUnknowsResult3.Hide();

                    label11.Text = " The given system of equations has infinite solutions:";
                }
                else if (resultState == 1)
                {
                    EquaThreeUnknowsResult1.Hide();
                    EquaThreeUnknowsResult2.Hide();
                    EquaThreeUnknowsResult3.Hide();

                    label11.Text = " The given system of equations has no solution";
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
            }
        }

        private void EquaFourUnknowsResultButton_Click(object sender, EventArgs e)
        {           
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
                    EquaFourUnknowsResult1.Show();
                    EquaFourUnknowsResult2.Show();
                    EquaFourUnknowsResult3.Show();
                    EquaFourUnknowsResult4.Show();

                    label9.Text = " The given system of equations has a solutions:";

                    EquaFourUnknowsResult1.Text = "x = " + result[0].ToString();
                    EquaFourUnknowsResult2.Text = "y = " + result[1].ToString();
                    EquaFourUnknowsResult3.Text = "z = " + result[2].ToString();
                    EquaFourUnknowsResult4.Text = "t = " + result[3].ToString();
                }
                else if (resultState == 0)
                {
                    EquaFourUnknowsResult1.Hide();
                    EquaFourUnknowsResult2.Hide();
                    EquaFourUnknowsResult3.Hide();
                    EquaFourUnknowsResult4.Hide();

                    label9.Text = " The given system of equations has no solution";
                }
                else if (resultState == 1)
                {
                    EquaFourUnknowsResult1.Hide();
                    EquaFourUnknowsResult2.Hide();
                    EquaFourUnknowsResult3.Hide();
                    EquaFourUnknowsResult4.Hide();

                    label9.Text = " The given system of equations has infinite solution";
                }
            }
            catch (Exception ex)
            {
                if (ex is System.FormatException)
                    MessageBox.Show("Invalid Input");
            }
        }

        private void EquationSolving_Load(object sender, EventArgs e)
        {
            Page1Button_Click(sender, e);
            
        }
    }
}