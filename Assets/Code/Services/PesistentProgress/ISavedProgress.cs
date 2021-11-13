using Code.Data;

namespace Code.Services.PesistentProgress
{
    public interface ILoadProgress:IService
    {
        void LoadProgress(PlayerData data);
    }

    public interface ISavedProgress : ILoadProgress
    {
        void SavedProgress(PlayerData data);
    }
}