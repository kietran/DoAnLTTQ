using DoAnLTTQ1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CustomControls.CalculatorTextbox
{
    //undo vs redo
    public partial class CalculatorTextbox : System.Windows.Forms.TextBox
    {
        bool ignoreChange = true;
        List<string> storageUndo_Text = null;
        List<string> storageRedo_Text = null;
        List<int> storageUndo_Cursor = null;
        List<int> storageRedo_Cursor = null;
        public int currentCursorPosition = 0;

        public CalculatorTextbox()
        {
            Click += new EventHandler(OnClick);
            setUp2();
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            storageUndo_Text = new List<string>();
            storageRedo_Text = new List<string>();

            storageUndo_Cursor = new List<int>();
            storageRedo_Cursor = new List<int>();
            ignoreChange = false;

            storageUndo_Text.Add("");
            storageUndo_Cursor.Add(currentCursorPosition);

        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (!ignoreChange)
            {
                this.ClearUndo();
                if (storageUndo_Text.Count > 30) {
                    storageUndo_Text.RemoveAt(0);
                    storageUndo_Cursor.RemoveAt(0);
                }
                if (storageRedo_Text.Count > 30)
                {
                    storageRedo_Text.RemoveAt(0);
                    storageRedo_Cursor.RemoveAt(0);
                }

                storageUndo_Text.Add(this.Text);
                storageUndo_Cursor.Add(currentCursorPosition);
            }
            SelectionStart = currentCursorPosition;
        }
        internal void OnKeyDown1(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Z && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.ClearUndo();
                ignoreChange = true;
                this.Undo();
                ignoreChange = false;
            }
            else if (e.KeyCode == Keys.Y && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                this.ClearUndo();
                ignoreChange = true;
                this.Redo();
                ignoreChange = false;
            }
            else
            {
                base.OnKeyDown(e);
            }
        }
        void OnClick(object sender, EventArgs e)
        {
            currentCursorPosition = SelectionStart;
        }
        public void Redo()
        {
            if (storageRedo_Text.Count > 0)
            {
                this.ignoreChange = true;

                this.Text = storageRedo_Text[storageRedo_Text.Count - 1];
                storageUndo_Text.Add(this.Text);
                storageRedo_Text.RemoveAt(storageRedo_Text.Count - 1);

                this.currentCursorPosition = storageRedo_Cursor[storageRedo_Cursor.Count - 1];
                storageUndo_Cursor.Add(currentCursorPosition);
                storageRedo_Cursor.RemoveAt(storageRedo_Cursor.Count - 1);
                this.ignoreChange = false;
            }
        }
        public new void Undo()
        {
            if (storageUndo_Text.Count > 1)
            {
                this.ignoreChange = true;

                storageRedo_Text.Add(this.Text);
                this.Text = storageUndo_Text[storageUndo_Text.Count - 2];
                storageUndo_Text.RemoveAt(storageUndo_Text.Count - 1);

                storageRedo_Cursor.Add(currentCursorPosition);
                this.currentCursorPosition = storageUndo_Cursor[storageUndo_Cursor.Count - 2];
                storageUndo_Cursor.RemoveAt(storageUndo_Cursor.Count - 1);
                this.ignoreChange = false;

            }
        }
        public new void Clear()
        {
            base.Clear();
            storageUndo_Text.Clear();
            storageRedo_Text.Clear();

            storageUndo_Cursor.Clear();
            storageRedo_Cursor.Clear();
        }

        public void moveCursorLeft()
        {
            if (currentCursorPosition > 0)
            {
                currentCursorPosition--;
            }
            else
            {
                currentCursorPosition = Text.Length;
            }
        }
        public void moveCursorRight()
        {
            if (currentCursorPosition < Text.Length)
            {
                currentCursorPosition++;
            }
            else
            {
                currentCursorPosition = 0;
            }
        }
    }
    //draw fat cursor
    public partial class CalculatorTextbox : System.Windows.Forms.TextBox
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        Timer tmr;
        public PictureBox verticalBar;
        bool phase = false;
        Label useToMeasureTextLength;
        
        void setUp2()
        {
            verticalBar = new PictureBox();
            verticalBar.Size = new Size(3, 29);
            verticalBar.BackColor = Color.Black;

            tmr = new Timer();
            tmr.Interval = 400;
            tmr.Tick += Tmr_Tick;
            tmr.Start();

            useToMeasureTextLength = new Label();
            useToMeasureTextLength.AutoSize = true;
            //useToMeasure
            GotFocus += Tmr_Tick;
            this.GotFocus += new EventHandler(OnFocus);

            Controls.Add(useToMeasureTextLength);
            useToMeasureTextLength.Hide();
            Controls.Add(verticalBar);
        }
        private void OnFocus(object sender, EventArgs e)
        {
            HideCaret(Handle);
        }
        //redraw blinking cursor
        private void Tmr_Tick(object sender, EventArgs e)  
        {
            DrawBlinkingCursor();
        }
        private void DrawBlinkingCursor()
        {
            //useToMeasureTextLength.Text = currentCursorPosition.ToString();
            if (phase)
            {
                if (currentCursorPosition == 0)
                {
                    verticalBar.Location = new Point(0, 0);
                }
                else
                {
                    //start offset of first visible char
                    int startIndex = GetCharIndexFromPosition(new Point(0, 0));
                    useToMeasureTextLength.Text = this.Text.Substring(0, startIndex);
                    int startOffset = useToMeasureTextLength.Width;

                    //real visible char 
                    useToMeasureTextLength.Text = this.Text.Substring(0, currentCursorPosition);
                    int xOffset = useToMeasureTextLength.Size.Width - 15;
                    if (startOffset > 0)
                    {
                        xOffset -= startOffset - 15;
                    }
                    xOffset = System.Math.Min(xOffset, Width - 2);
                    verticalBar.Location = new Point(xOffset, 0);
                }
                verticalBar.Show();
            }
            else
            {
                verticalBar.Hide();
            }
            phase = !phase;
            //this.Text = xInPoints.ToString();
        }
    }
}
