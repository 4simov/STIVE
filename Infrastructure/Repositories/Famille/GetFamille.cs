﻿using Core.DTO.Famille;
using Core.UseCase;
using STIVE.Core.UseCase.Famille.Abstraction;
using STIVE.Infrastructure;

namespace Infrastructure.Repositories.FamilleNS
{
    public class UpdateFamille : BaseUseCase<NegosudContext>, IGetFamille
    {
        public UpdateFamille(NegosudContext context) : base(context)
        {
        }

        public Task<List<FamilleResponse>> ExecuteAsync()
        {
            var familles = _dbContext.Famille.ToList();

            List<FamilleResponse> familleResponse = new List<FamilleResponse>();
            foreach (var famille in familles)
            {
                familleResponse.Add(new FamilleResponse
                {
                    Id = famille.Id,
                    Nom = famille.Nom,
                    TypeVin = famille.TypeVin,
                    Photo = famille.Photo,
                });
            }

            return Task.FromResult(familleResponse);
        }
    }
}
