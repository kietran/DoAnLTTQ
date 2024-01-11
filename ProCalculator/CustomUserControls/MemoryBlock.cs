using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

using ProCalculator.ClassLibraries;
using ProCalculator;
using System.Threading.Tasks;

namespace CustomUserControls.MemoryBlock
{
    partial class MemoryBlock : RoundedPanel.RoundedPanel
    {
        //main panel -- inherited from panel;
        private Label _input, _output;
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

        public Label Output
        {
            get { return _output; }
            set
            {
                if (_output != value)
                {
                    _output = value;
                }
            }
        }

        public Label Input
        {
            get { return _input; }
            set
            {
                if (_input != value)
                {
                    _input = value;
                }
            }
        }


        public MemoryBlock()
        {
            DoubleBuffered = true;
            Input = new Label();
            Output = new Label();

            quitButton = new Label();

            Input.Size = new Size(245, 30);
            Input.Font = new Font("Comic Sans MS", 12F);
            Input.BackColor = Color.Transparent;
            Input.TextAlign = ContentAlignment.MiddleRight;
            Input.ForeColor = Color.DimGray;
            Input.MouseEnter += (Sender, e) =>
            {
                quitButton.Show();
            };
            Input.MouseHover += (Sender, e) =>
            {
                quitButton.Show();
            };
            Input.MouseLeave += (Sender, e) =>
            {
                OnMouseLeave(e);
            };
            Input.Click += (Sender, e) =>
            {
                OnClick(e);
            };
            Output.Size = new Size(245, 30);
            Output.Font = new Font("Comic Sans MS", 14F);
            Output.BackColor = Color.Transparent;
            Output.AutoSize = true;
            Output.TextAlign = ContentAlignment.MiddleRight;
            Output.MouseEnter += (Sender, e) =>
            {
                quitButton.Show();
            };
            Output.MouseHover += (Sender, e) =>
            {
                quitButton.Show();
            };
            Output.MouseLeave += (Sender, e) =>
            {
                OnMouseLeave(e);
            };
            Output.SizeChanged += (Sender, args) =>
            {
                if (Output.Parent.Width > Output.Width)
                    Output.Location = new Point(Output.Parent.Width - Output.Width, Output.Top);
            };
            Output.Click += (Sender, e) =>
            {
                OnClick(e);
            };
            quitButton.ForeColor = Color.Brown;
            quitButton.Location = new Point(253, 0);
            quitButton.AutoSize = true;
            quitButton.BackColor = Color.Transparent;
            quitButton.Font = new Font("Comic Sans MS", 9F);
            quitButton.Text = "X";
            quitButton.MouseEnter += (Sender, e) =>
            {
                quitButton.Show();
                quitButton.ForeColor = Color.Red;
            };
            quitButton.MouseHover += (Sender, e) =>
            {
                quitButton.Show();
                quitButton.ForeColor = Color.Red;
            };
            quitButton.MouseLeave += (Sender, e) =>
            {
                quitButton.Hide();
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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            quitButton.Show();
        }
        protected override async void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            await Task.Delay(1000);
            quitButton.Hide();
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Width = 270;
            Height = 63;

            InteriorColor = Color.FromArgb(250, 252, 255);
            BorderWidth = 1;
            ArcSize = 5;
            BorderColor = Color.Gainsboro;
            alignContentInMiddle();
            quitButton.Visible = false;
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