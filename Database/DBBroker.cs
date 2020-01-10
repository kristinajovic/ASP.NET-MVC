using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using WebApplicationFPIS.Models;

namespace WebApplicationFPIS.Database
{
    public class DBBroker
    {
        BazaParkGateEntities db = new BazaParkGateEntities();
        public static DBBroker broker;
        static DbContextTransaction transakcija;

        public static DBBroker DajSesiju()
        {
            if (broker != null)
            {
                return broker;
            }
            broker = new DBBroker();

            return broker;
        }

        internal void PokreniDbTransakciju() => transakcija = db.Database.BeginTransaction();
        internal void PonistiDbTransakciju() => transakcija.Rollback();
        internal void PotvrdiDbTransakciju() => transakcija.Commit();

        internal int VratiSifruKvara()
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {
                List<Kvar> lista = db.Kvar.ToList();
                return lista.Count == 0 ? 1 : lista.Max(x => x.KvarID) + 1;
            }
        }

        internal List<Soba> VratiSobe()
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {
                return db.Soba.ToList();
            }
        }

        internal Zaposleni VratiZaposlenog()
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {
                return db.Zaposleni.FirstOrDefault();
            }
        }

        public List<Kvar> PronadjiKvarove(DateTime datumKvara)
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {
                return db.Kvar.AsNoTracking()
                .Include(k => k.Gost)
                .Include(k => k.Soba)
                .Include(k => k.Zaposleni)
                .Where(k => k.DatumKvara == datumKvara)
                .ToList();
            }
        }

        public bool ZapamtiKvar(Kvar k)
        {
            try
            {
                db.Kvar.Add(k);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Gost PronadjiGosta(int sifraGosta)
        {
            using (BazaParkGateEntities db = new BazaParkGateEntities())
            {
                return db.Gost.AsNoTracking()
                .ToList()
                .Where(g => g.SifraGosta == sifraGosta)
                .SingleOrDefault();
            }
        }

        public bool IzmeniKvar(Kvar k)
        {
            try
            {
                db.Kvar.AddOrUpdate(k);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ObrisiKvar(int sifraKvara)
        {
            try
            {
                Kvar k = db.Kvar.Find(sifraKvara);
                db.Kvar.Remove(k);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}