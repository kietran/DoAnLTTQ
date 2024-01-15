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
        private Label _input;
        private TextBox _output;
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

        public TextBox Output
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
            Output = new TextBox();

            quitButton = new Label();

            Input.Location = new Point(10, 0);
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
            Output.Location = new Point(10, 30);
            Output.AutoSize = false;
            Output.Size = new Size(245, 28);         

            Output.Font = new Font("Comic Sans MS", 14F);
            Output.TextAlign = HorizontalAlignment.Right;
            Output.BorderStyle = BorderStyle.None;
            Output.ReadOnly = true;
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
            Output.TextChanged += (Sender, args) =>
            {
                Graphics g = this.CreateGraphics();
                int textLength = (int)g.MeasureString(Output.Text, Output.Font).Width;
                if (textLength > Output.Width) {
                    Output.TextAlign = HorizontalAlignment.Left;
                }
                else
                {
                    Output.Width = Width - 25;
                    Output.TextAlign = HorizontalAlignment.Right;
                }
            };
            Output.Click += (Sender, e) =>
            {
                OnClick(e);
            };
            quitButton.ForeColor = Color.Brown;
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
            Height = 60;

            InteriorColor = Color.Transparent;
            BorderWidth = 1;
            ArcSize = 5;
            BorderColor = Color.Gray;
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
            quitButton.Location = new Point(Width - 20, 0);

            Input.Width = Width - 25;
            Output.Width = Width - 25;
        }
    }

}