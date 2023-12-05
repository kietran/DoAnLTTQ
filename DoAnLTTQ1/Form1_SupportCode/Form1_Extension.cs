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

namespace DoAnLTTQ1 {
    //insert
    public partial class Form1 : Form
    {
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                Control.Perform_Equal();
            }
            else if (e.KeyCode.Equals(Keys.Back))
            {
                Control.Perform_Del();
            }
            else
            {
                Control.insertContentIntoInputText(e.KeyCode.ToString());
            }

        }

        /// INSERT BLOCK
       
        //state button
    }
    
    //control
}