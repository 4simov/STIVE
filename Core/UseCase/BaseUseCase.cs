using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase
{
    /// <summary>
    /// Oblige la déclaration d'un contrusteur avec en paramètre le context de BDD du Endpoint/ "Terminaison de controller"
    /// </summary>
    public class BaseUseCase
    {
        private readonly DbContext _context;

        /// <summary>
        /// On pratique ici ce que l'on appel une injection de dépendance, en gros le "context"
        /// en paramètre récupère celui initialisé à l'appel de l'API et on le rattache en valeur privée et non modifiable 
        /// pour chaque useCase. Tous les UseCase doivent avoir ce constructeur et la ligne
        /// "private readonly NegosudContext _context;"
        /// </summary>
        /// <param name="context"></param>
        public BaseUseCase(DbContext context) 
        {
            _context = context;
        }
    }
}
