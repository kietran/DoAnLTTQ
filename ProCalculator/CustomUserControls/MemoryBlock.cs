using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

using ProCalculator.ClassLibraries;
using ProCalculator;

namespace CustomUserControls.MemoryBlock
{
   partial class MemoryBlock : RoundedPanel.RoundedPanel
    {
        //main panel -- inherited from panel;
        private Label Input, Output;

        //quit button;
        public Label quitButton;

        //built in index
        int _index = 0;
        public int Index
        {
            get { return _index; }
            set
            {
                if (_index != value)
                {
                    _index = value;
                }
            }
        }

        public MemoryBlock()
        {
            DoubleBuffered = true;
            Input = new Label();   
            Output = new Label();

            quitButton = new Label();

            Input.Size = new Size(230, 30);
            Input.Font = new Font("Comic Sans MS", 11F);
            Input.BackColor = Color.Transparent;
            Input.TextAlign = ContentAlignment.MiddleRight;

            Output.Size = new Size(245, 30);
            Output.Font = new Font("Comic Sans MS", 13F);
            Output.BackColor = Color.Transparent;
            Output.TextAlign = ContentAlignment.MiddleRight;

            quitButton.ForeColor = Color.Brown;
            quitButton.Location = new Point(240, 0);
            quitButton.AutoSize = true;
            quitButton.BackColor = Color.Transparent;
            quitButton.Font = new Font("Comic Sans MS", 12F);
            quitButton.Text = "X";
            quitButton.MouseEnter += (Sender, args) =>
            {
                quitButton.ForeColor = Color.Red;
            };
            quitButton.MouseLeave += (Sender, args) =>
            {
                quitButton.ForeColor = Color.Brown;
            };
            //dispose
            quitButton.MouseClick += (Sender, args) =>
            {
                Dispose();
            };

            Controls.Add(Input);
            Controls.Add(Output);

            Controls.Add(quitButton);

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Width = 280;
            Height = 63;
            alignContentInMiddle();
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            BackColor = Color.Transparent;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            alignContentInMiddle();
        }
    }
    
    partial class MemoryBlock : RoundedPanel.RoundedPanel
    {
        private void alignContentInMiddle()
        {
            //position text in middle
            int InputStartPointX = 10;
            int OutputStartPointX = 10;

            
            Input.Location = new Point(InputStartPointX, 0);
            Output.Location = new Point(OutputStartPointX, (Height - Input.Height - 3));
        }

    }

}