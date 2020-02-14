using Finance.Models;
using Finance.Winform.ModelForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finance.Winform
{
    public partial class MainFrameForm : Form
    {

        public Form ChildForm { get; set; }

        public MainFrameForm()
        {
            InitializeComponent();
            this.Text = "湛江外代班轮结算系统";

            this.IsMdiContainer = true;
            //var bf = new BaseForm() { TopLevel = false, Dock = DockStyle.Fill, FormBorderStyle = FormBorderStyle.None };
            //this.splitContainer1.Panel2.Controls.Add(bf);
            ////bf.Show();// 不要用这个, 用下面这个属性, 因为属性可以直接在构造函数里写, 而方法需要另外调用
            //bf.Visible = true;

        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            var tnn = e.Node.Name;

            //下面这个写法, 太不优雅了, n多个if, 
            //if (tnn == "每日实收")
            //{
            //    //AddModelForm<ActualIncomeForm>();
            //    //AddModelForm(new ActualIncomeForm(new FinanceContext()));
            //}

            if (DIService.DIRegister.DicFormType.ContainsKey(tnn))
            {
                var type = DIService.DIRegister.DicFormType[tnn];
                var fm = DIService.DIRegister.SP.GetService(type) as Form;
                AddModelForm(fm);
            }
            else
            {
                //do nothing;
            }

        }

        //private void AddModelForm<T>() where T: BaseForm, new()
        //{
        //    if (ChildForm != null)
        //    {
        //        ChildForm.Dispose();
        //    }
        //    ChildForm = new T();
        //    this.splitContainer1.Panel2.Controls.Clear();
        //    this.splitContainer1.Panel2.Controls.Add(ChildForm);
        //}
        private void AddModelForm(Form bf)
        {
            if (ChildForm != null)
            {
                ChildForm.Dispose();
            }
            ChildForm = bf;
            this.splitContainer1.Panel2.Controls.Clear();
            this.splitContainer1.Panel2.Controls.Add(ChildForm);
        }

        
    }
}
