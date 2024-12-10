﻿using Core.DTO.Adresse;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Adresse.Abstraction
{
    public interface IAddAdresse : IUseCaseProcess<AdresseAddRequest, AdresseResponse>
    {

    }
}
