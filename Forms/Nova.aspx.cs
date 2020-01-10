using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationFPIS.Controllers;

namespace WebApplicationFPIS.Forms
{
    public partial class Nova : System.Web.UI.Page
    {

        private readonly KvarController k = new KvarController();

        protected void Page_Load(object sender, EventArgs e)
        {
            VratiSifruKvara();

        }

        private void VratiSifruKvara()
        {
            TextBoxSifraKvara.Text = k.VratiSifruKvara().ToString();

        }

        protected void ButtonZapamti_Click(object sender, EventArgs e)
        {
            // int sifraGosta = Convert.ToInt32(TextBoxSifraGosta.Text);
            string opisKvara = TextBoxOpisKvara.Text;

            DateTime dat = DateTime.Now;
            TextBoxObavestenje.Text = k.ZapamtiKvar(1,dat,101, opisKvara);

        }

      
    }
}