# ---- Étape 1 : Build ----
    FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
    WORKDIR /src
    
    # Copier le fichier projet (assure-toi que le chemin correspond à ta structure)
    COPY STIVE/STIVE.csproj ./STIVE/
    
    # Se placer dans le dossier du projet
    WORKDIR /src/STIVE
    
    # Restaurer les dépendances
    RUN dotnet restore
    
    # Copier tout le reste du code
    COPY . .
    
    # Publier l'application en Release dans le dossier /app/publish
    RUN dotnet publish -c Release -o /app/publish
    
    # ---- Étape 2 : Image runtime ----
    FROM mcr.microsoft.com/dotnet/aspnet:8.0
    WORKDIR /app
    
    # Copier les fichiers publiés depuis l'étape de build
    COPY --from=build /app/publish .
    
    # Exposer le port utilisé par l'application (par exemple, 80)
    EXPOSE 8080
    
    # Définir le point d'entrée
    ENTRYPOINT ["dotnet", "STIVE.dll"]
    