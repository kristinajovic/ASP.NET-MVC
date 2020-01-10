using System;
using System.Collections.Generic;
using WebApplicationFPIS.Controllers;

namespace WebApplicationFPIS.Forms
{
    public partial class UnosKvaraWebForm : System.Web.UI.Page
    {
        private readonly KvarController k = new KvarController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VratiSobe();
                OsveziPoljaForme();
                TextBoxObavestenje.Text = string.Empty;
                VratiSifruKvara();
            }
        }

        void OsveziPoljaForme()
        {
            TextBoxSifraKvara.Text = string.Empty;
            TextBoxSifraGosta.Text = string.Empty;
            TextBoxImeGosta.Text = string.Empty;
            TextBoxPrezimeGosta.Text = string.Empty;
            TextBoxDatumKvara.Text = string.Empty;
            TextBoxOpisKvara.Text = string.Empty;
        }

        private void VratiSifruKvara()
        {
            TextBoxSifraKvara.Text = k.VratiSifruKvara().ToString();

        }



        private void VratiSobe()
        {
            DropDownListBrojSobe.DataSource = k.VratiSobe();
            DropDownListBrojSobe.DataBind();
        }

        protected void ButtonPonadjiGosta_Click(object sender, EventArgs e)
        {
            int sifraGosta;

            try
            {
                sifraGosta = Convert.ToInt32(TextBoxSifraGosta.Text);
            }
            catch (Exception)
            {
                TextBoxObavestenje.Text = "Šifra gosta mora biti broj.";
                return;
            }

            List<string> gost = k.PronadjiGosta(sifraGosta);

            if (gost != null)
            {
                TextBoxImeGosta.Text = gost[0];
                TextBoxPrezimeGosta.Text = gost[1];
                return;
            }
            else
            {
                TextBoxObavestenje.Text = $"Ne postoji Gost sa šifrom {sifraGosta}!";
            }
        }

        protected void ButtonZapamti_Click(object sender, EventArgs e)
        {
            int sifraGosta;
            DateTime datumKvara;
            int brojSobe;
            string opisKvara;

            try
            {
                sifraGosta = Convert.ToInt32(TextBoxSifraGosta.Text);
            }
            catch (Exception)
            {
                TextBoxObavestenje.Text = "Šifra gosta mora biti broj.";
                return;
            }

            try
            {
                datumKvara = Convert.ToDateTime(TextBoxDatumKvara.Text);
            }
            catch (Exception)
            {
                TextBoxObavestenje.Text = "Datum kvara nije u validnom formatu.";
                return;
            }

            if (datumKvara > DateTime.Now)
            {
                TextBoxObavestenje.Text = "Datum kvara ne moože biti u budućnosti.";
                return;
            }

            try
            {
                brojSobe = Convert.ToInt32(DropDownListBrojSobe.SelectedValue);
            }
            catch (Exception)
            {
                TextBoxObavestenje.Text = "Broj sobe mora biti broj.";
                return;
            }

            if (string.IsNullOrEmpty(TextBoxOpisKvara.Text))
            {
                TextBoxObavestenje.Text = "Uneti opis kvara.";
                return;
            }
            else
            {
                opisKvara = TextBoxOpisKvara.Text;
            }

            TextBoxObavestenje.Text = k.ZapamtiKvar(sifraGosta, datumKvara, brojSobe, opisKvara);

            OsveziPoljaForme();
            VratiSifruKvara();
        }
    }
}