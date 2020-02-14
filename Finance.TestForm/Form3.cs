using Finance.WinformDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.TestForm
{
    public class Form3: BaseFormDLL
    {
        public Form3()
        {
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            this.Enabled = true;
            base.Controls.Clear();
            
        }
    }
}
