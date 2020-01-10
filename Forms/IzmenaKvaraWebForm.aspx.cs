using System;
using System.Collections.Generic;
using WebApplicationFPIS.Controllers;

namespace WebApplicationFPIS.Forms
{
    public partial class IzmenaKvaraWebForm : System.Web.UI.Page
    {
        private readonly KvarController k = new KvarController();
        static int sifraKvara;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VratiSobe();
                OsveziPoljaForme();
                GridViewKvarovi.DataSource = null;
                GridViewKvarovi.DataBind();
                TextBoxObavestenje.Text = string.Empty;
                TextBoxZaposleni.Text = VratiZaposlenog();
            }
        }

        void OsveziPoljaForme()
        {
            TextBoxSifraKvara.Text = string.Empty;
            TextBoxSifraGosta.Text = string.Empty;
            TextBoxDatumKvara.Text = string.Empty;
            TextBoxOpisKvara.Text = string.Empty;
        }

        private void VratiSobe()
        {
            DropDownListBrojSobe.DataSource = k.VratiSobe();
            DropDownListBrojSobe.DataBind();
        }

        private string VratiZaposlenog()
        {
            return k.VratiZaposlenog();
        }

        protected void ButtonPonadjiKvarove_Click(object sender, EventArgs e)
        {
            DateTime datumKvara;

            try
            {
                datumKvara = Convert.ToDateTime(TextBoxDatumKvara.Text);
            }
            catch (Exception)
            {
                TextBoxObavestenje.Text = "Datum dolaska nije u validnom formatu.";
                return;
            }

            List<object> rsKvarovi = k.PronadjiKvarove(datumKvara);

            if (rsKvarovi.Count == 0)
            {
                TextBoxObavestenje.Text = $"Ne postoje kvarovi nastali na dan {datumKvara.ToShortDateString()}";
                return;
            }
            else
            {
                GridViewKvarovi.DataSource = rsKvarovi;
                GridViewKvarovi.DataBind();
            }
        }

        protected void ButtonIzaberiKvar_Click(object sender, EventArgs e)
        {
            try
            {
                sifraKvara = Convert.ToInt32(TextBoxSifraKvara.Text);
            }
            catch (Exception)
            {

                TextBoxObavestenje.Text = "Šifra kvara mora biti ceo broj.";
                return;
            }

            List<string> rsSelektovaniKvar = k.SelektujKvar(sifraKvara);

            if (rsSelektovaniKvar == null)
            {
                TextBoxObavestenje.Text = $"Izabrati kvar iz tabele.";

                TextBoxSifraKvara.Text = string.Empty;
                OsveziPoljaForme();

            }
            else
            {
                TextBoxSifraGosta.Text = rsSelektovaniKvar[0];
                DropDownListBrojSobe.Text = rsSelektovaniKvar[1];
                TextBoxOpisKvara.Text = rsSelektovaniKvar[2];

                GridViewKvarovi.DataSource = null;
                GridViewKvarovi.DataBind();
            }
        }

        protected void ButtonIzmeni_Click(object sender, EventArgs e)
        {
            int sifraGosta;
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

            TextBoxObavestenje.Text = k.IzmeniKvar(sifraGosta, brojSobe, opisKvara);
            OsveziPoljaForme();
            GridViewKvarovi.DataSource = null;
            GridViewKvarovi.DataBind();
        }

        protected void ButtonObrisi_Click(object sender, EventArgs e)
        {
            TextBoxObavestenje.Text = k.ObrisiKvar();
            OsveziPoljaForme();
            GridViewKvarovi.DataSource = null;
            GridViewKvarovi.DataBind();
        }

    
    }
}