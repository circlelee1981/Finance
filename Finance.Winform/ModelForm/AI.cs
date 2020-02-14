using Finance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Finance.Winform.ModelForm
{
    public partial class AI : Finance.Winform.ModelForm.BaseForm
    {
        public AI()
        {
            InitializeComponent();
        }

        public AI(FinanceContext context) : base(context)
        {
            InitializeComponent();

        }
    }
}
