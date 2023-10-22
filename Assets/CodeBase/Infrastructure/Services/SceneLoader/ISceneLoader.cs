using Cysharp.Threading.Tasks;

namespace CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Load(SceneType type);
    }
}