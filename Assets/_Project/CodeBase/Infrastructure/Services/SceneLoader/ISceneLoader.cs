using Cysharp.Threading.Tasks;

namespace _Project.CodeBase.Infrastructure.Services.SceneLoader
{
    public interface ISceneLoader
    {
        UniTask Load(SceneType type);
    }
}