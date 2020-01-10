using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationFPIS.Database;
using WebApplicationFPIS.Models;

namespace WebApplicationFPIS.Controllers
{
    public class KvarController
    {

        private const string UspesnoCuvanje = "USPEŠNO!";
        private const string NeuspesnoCuvanje = "NEUSPEŠNO!";

        public static Kvar izabraniKvar;
        public static int SifraKvara;

        private static List<Kvar> ListaKvarova = new List<Kvar>();

        public int VratiSifruKvara()
        {
            SifraKvara = DBBroker.DajSesiju().VratiSifruKvara();
            return SifraKvara;
        }

        public List<object> VratiSobe()
        {
            List<Soba> sobe = DBBroker.DajSesiju().VratiSobe();
            return sobe.Cast<object>().ToList();
        }

        internal List<string> PronadjiGosta(int sifraGosta)
        {
            Gost g = DBBroker.DajSesiju().PronadjiGosta(sifraGosta);

            if (g == null)
            {
                return null;
            }

            return new List<string>
            {
                { g.Ime },
                { g.Prezime }
            };
        }
        internal string ZapamtiKvar(int sifraGosta, DateTime datumKvara, int brojSobe, string opisKvara)
        {
            Kvar kvar = new Kvar
            {
                KvarID = SifraKvara,
                GostID = sifraGosta,
                DatumKvara = datumKvara,
                BrojSobe = brojSobe,
                OpisKvara = opisKvara,
                IDZaposlenog = 1,
            };
           
            DBBroker.DajSesiju().PokreniDbTransakciju();
            bool ret = DBBroker.DajSesiju().ZapamtiKvar(kvar);

            if (ret)
            {
                DBBroker.DajSesiju().PotvrdiDbTransakciju();
                return UspesnoCuvanje;
            }
            else
            {
                DBBroker.DajSesiju().PonistiDbTransakciju();
                return NeuspesnoCuvanje;
            }
        }

        internal string VratiZaposlenog()
        {
            return DBBroker.DajSesiju().VratiZaposlenog().ToString();
        }

        internal List<object> PronadjiKvarove(DateTime datumKvara)
        {
            ListaKvarova = DBBroker.DajSesiju().PronadjiKvarove(datumKvara);

            if (ListaKvarova == null)
            {
                return null;
            }

            return ListaKvarova.Cast<object>().ToList();
        }

        internal List<string> SelektujKvar(int sifraKvara)
        {
            izabraniKvar = ListaKvarova.Where(e => e.KvarID == sifraKvara).SingleOrDefault();

            if (izabraniKvar == null)
            {
                return null;
            }

            return new List<string>
            {
                izabraniKvar.GostID.ToString(),
                izabraniKvar.BrojSobe.ToString(),
                izabraniKvar.OpisKvara
            };
        }

        internal string IzmeniKvar(int sifraGosta, int brojSobe, string opisKvara)
        {
            izabraniKvar.GostID = sifraGosta;
            izabraniKvar.BrojSobe = brojSobe;
            izabraniKvar.OpisKvara = opisKvara;
            izabraniKvar.IDZaposlenog = 1;

            DBBroker.DajSesiju().PokreniDbTransakciju();
            bool ret = DBBroker.DajSesiju().IzmeniKvar(izabraniKvar);

            if (ret)
            {
                DBBroker.DajSesiju().PotvrdiDbTransakciju();
                return UspesnoCuvanje;
            }
            else
            {
                DBBroker.DajSesiju().PonistiDbTransakciju();
                return NeuspesnoCuvanje;
            }
        }

        internal string ObrisiKvar()
        {
            DBBroker.DajSesiju().PokreniDbTransakciju();
            bool ret = DBBroker.DajSesiju().ObrisiKvar(izabraniKvar.KvarID);

            if (ret)
            {
                ListaKvarova = new List<Kvar>();

                DBBroker.DajSesiju().PotvrdiDbTransakciju();
                return UspesnoCuvanje;
            }
            else
            {
                DBBroker.DajSesiju().PonistiDbTransakciju();
                return NeuspesnoCuvanje;
            }
        }
    }
}