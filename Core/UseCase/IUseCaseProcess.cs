// Ces interface servent à généraliser la définitions des UseCase de l'API.
// On a ici 3 cas de figures 
namespace STIVE.Core.UseCase
{
    /// <summary>
    /// Un UseCase vide, le plus basique. En gros ça sert à rien en l'état mais si jamais on veut ajouter une fonction que l'on voudra 
    /// définir et utiliser dans tous nos UseCase c'est ici que ça se passe.
    /// </summary>
    public interface IUseCaseProcess
    {

    }

    /// <summary>
    /// Le UseCase a une classe en paramètre TInput qu'il pourra manipuler et renvoit une classe TOutput en réponse
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IUseCaseProcess<TInput, TOutput> : IUseCaseProcess
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }

    /// <summary>
    /// Le UseCase n'a pas de paramètre et renvoit une réponse de type TOutput
    /// </summary>
    /// <typeparam name="TOutput"></typeparam>
    public interface IUseCaseProcess<TOutput> : IUseCaseProcess 
    {
        Task<TOutput> ExecuteAsync();
    }
}
