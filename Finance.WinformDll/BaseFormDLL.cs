using Finance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance.WinformDll
{
    public partial class BaseFormDLL : Form
    {
        private readonly FinanceContext context;

        public BaseFormDLL()
        {
            InitializeComponent();
        }

        public BaseFormDLL(FinanceContext context)
        {
            InitializeComponent();

            //这三项, 是让父级panel.controls能够add它的前提
            this.TopLevel = false;
            Dock = DockStyle.Fill;
            FormBorderStyle = FormBorderStyle.None;
            Visible = true;
            this.Resize += BaseForm_Resize;
            this.context = context;
        }

        private void BaseForm_Resize(object sender, EventArgs e)
        {
            //throw new NotImplementedException(); 
            this.tbpanel01.Height = (this.splitContainer1.Panel1.Height + this.splitContainer1.Panel2.Height)/2 - 20;
            
        }

        
        
    }
}
