using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace ProCalculator
{
    internal partial class StandardCalculatorControl
    {
        static private StandardCalculator form1;
        
        static public void Init(StandardCalculator f)
        {
            form1 = f;
        }
        static public void InsertContentAtCursor(string content)
        {

        }
        //number panel
        static public void OpenNumberPanel()
        {
            form1.MainPanel_OpenNumberPanelButton.BackColor = Color.FromArgb(205,239,139);
            //Check if Function Panel is open
            if (!form1.funcPanelOn)
                form1.NumberPanel.Location = new Point(2, 281);
            form1.NumberPanel.Show();
            MemoryPanelHeightUpdate();
        }
        static public void CloseNumberPanel()
        {
            form1.MainPanel_OpenNumberPanelButton.BackColor = Color.White;
            //Set back to original position
            form1.NumberPanel.Location = new Point(2, 447);
            form1.NumberPanel.Hide();
            form1.MemoryPanel.Height -= form1.NumberPanel.Height;
        }
        //func panel
        static public void OpenFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.BackColor = Color.FromArgb(255, 242, 204);
            //Check if Number Panel is in first place
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(2, 447);
            form1.FunctionPanel.Show();
            MemoryPanelHeightUpdate();
        }
        static public void CloseFuncPanel()
        {
            form1.MainPanel_OpenFuncPanelButton.BackColor = Color.White;
            //Check if Number Panel is still open
            if (form1.numberPanelOn)
                form1.NumberPanel.Location = new Point(2, 281);
            form1.FunctionPanel.Hide();
            form1.MemoryPanel.Height -= form1.FunctionPanel.Height;
        }
        //meory panel
        static public void OpenMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.BackColor = Color.FromArgb(248, 206, 204);
            MemoryPanelHeightUpdate(); 
            form1.MemoryPanel.Show(); 
        }
        static public void CloseMemoryPanel()
        {
            form1.MainPanel_OpenMemoryPanelButton.BackColor = Color.White;
            form1.MemoryPanel.Hide();
        }
        static public void MemoryPanelHeightUpdate()
        {
            form1.MemoryPanel.Height = form1.Height - 50;
        }

        //INV Mode Toggle
        static public void Toggle_INVMode()
        {
            form1.FUNC_Sin.Text = "sin⁻¹";
            form1.FUNC_Cos.Text = "cos⁻¹";
            form1.FUNC_Tan.Text = "tan⁻¹";
            form1.FUNC_Logarit.Text = "10^";
            form1.FUNC_Ln.Text = "eˣ";
            form1.FUNC_Sqrt.Text = "x²";
        }
        static public void Toggle_NormalMode()
        {
            form1.FUNC_Sin.Text = "sin";
            form1.FUNC_Cos.Text = "cos";
            form1.FUNC_Tan.Text = "tan";
            form1.FUNC_Logarit.Text = "log";
            form1.FUNC_Ln.Text = "ln";
            form1.FUNC_Sqrt.Text = "√";
        }

        //Convert radian - degree mode
        static public void RadianMode()
        {

        }
        static public void DegreeMode()
        {

        }
    }
}