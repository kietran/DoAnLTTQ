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
    public partial class Form1 : Form
    {
        //mode
        public bool onShiftMode, onAlphaMode;
        public bool onInvalidExpressionMode;
        public bool onDisplayMode;

        //screen
        //khai bao cache
        public Tuple<string, string>[] memoryCaches; //input,output
        public int currentMemoryCachesSize; //so lg phan tu hien tai
        public int maxMemoryCachesSize; //so lg luu toi da
        public int currentCachePosition; //vi tri cache dang xem

        public Form1()
        {
            KeyPreview = true;

            onShiftMode = false;
            onAlphaMode = false;
            onDisplayMode = false;
            onInvalidExpressionMode = false;

            currentMemoryCachesSize = 0;
            currentCachePosition = 0;
            maxMemoryCachesSize = 5;
            memoryCaches = new Tuple<string, string>[maxMemoryCachesSize];

            Control.init(this);
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = CustomFont.initFont();
            FUNC_Fraction.Font = new Font(pfc.Families[0], 19, FontStyle.Bold);
        }
    }
}
