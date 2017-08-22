using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MovieNetDbProject;
using System.Data.Entity.Validation;

namespace MovieNetApiWcf
{
     public class Service1 : IService1
    {
        public Utilisateur u;
        public Genre g;
        private ModelMovieNet context = new ModelMovieNet();
        public Service1()
        {
            this.u = SetData();
        }
        public string GetName(int id)
        {
            Utilisateur u = context.utilisateur.FirstOrDefault(ut => ut.id_utilisateur == id);
            return u?.nom_utilisateur;
        }

        public string GetFirstName()
        {
            Utilisateur ut = context.utilisateur.FirstOrDefault(c => c.id_utilisateur == 1);
            return ut?.prenom_utilisateur;
        }

        public Utilisateur GetUtilisateur(int id)
        {
            return context.utilisateur.FirstOrDefault(util => util.id_utilisateur == id);
        }

        public List<Utilisateur> GetUtilisateurs()
        {
            return context.utilisateur.ToList();
        }

        public Genre GetGenre()
        {
            return new Genre();
        }
        public Utilisateur SetData()
        {
            Utilisateur util = new Utilisateur();
            return util;
        }

        public void Delete(int id)
        {
            Utilisateur t = context.utilisateur.FirstOrDefault(c => c.id_utilisateur == id);
            if (t != null)
            {
                context.utilisateur.Remove(t);
                context.SaveChanges();
            }
        }

        public List<Utilisateur> SearchUsers(string name)
        {
            List<Utilisateur> util = context.utilisateur.ToList();
            List<Utilisateur> ru = new List<Utilisateur>();
            foreach (Utilisateur t in util)
            {
                if (t.nom_utilisateur.Contains(name))
                {
                    ru.Add(t);
                }
            }
            return ru;
        }

        public Utilisateur GetUtilisateurByLoginAndPassword(string login, string password)
        {
            Utilisateur util = context.utilisateur.FirstOrDefault(ut => ut.nom_utilisateur == login);
            return util?.mdp_utilisateur == password ? util : null;
        }

        public List<Utilisateur> AddUser(Utilisateur util)
        {
            if (util != null)
            {
                util.mdp_utilisateur = "toto";
                util.inscrit = true;
                util.connecte = true;
                context.utilisateur.Add(util);
                context.SaveChanges();
            }
            return (context.utilisateur.ToList());
        }
    }
}
