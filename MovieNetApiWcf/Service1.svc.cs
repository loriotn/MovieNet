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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private Utilisateur u;
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

        public Utilisateur SetData()
        {
            Utilisateur util = new Utilisateur();
            util.nom_utilisateur = "toto";
            util.prenom_utilisateur = "test";
            util.mdp_utilisateur = "mdp_utilisateur";
            context.utilisateur.Add(util);
            try
            {
                context.utilisateur.Add(util);
                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return util;
        }
    }
}
