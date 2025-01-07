﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO.Utilisateur
{
    public class UtilisateurResponse
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Mdp { get; set; }
    }
} 
