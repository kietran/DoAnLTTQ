using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System;

using ProCalculator.ClassLibraries;
namespace CustomUserControls.SystemEquaDecor
{

    public class SystemEquaDecor : Panel
    {
        int _borderWidth = 1;
        //Properties
        [Category("Border")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                if (_borderWidth != value)
                {
                    if (value < 0)
                    {
                        _borderWidth = 0;
                    }
                    this.Invalidate();
                }
            }
        }
        //Constructor
        public SystemEquaDecor()
        {
            DoubleBuffered = true;   
        }
        //init
        protected override void OnPaint(PaintEventArgs pevent)
        {

            base.OnPaint(pevent);
            //draw closing bracket
            //main line
            Graphics g = pevent.Graphics;
            Pen p = new Pen(Color.Black, 2);
            g.DrawLine(p, 5, 5, 5, Height - 5);

            g.DrawLine(p, 5, 5, 15, 5);
            g.DrawLine(p, 5, Height - 5, 15, Height - 5);

            //g.DrawLine(p, Width - 5, 5, Width - 15, 5);
            //g.DrawLine(p, Width - 5, Height - 5, Width - 15, Height - 5);
        }
    }
}