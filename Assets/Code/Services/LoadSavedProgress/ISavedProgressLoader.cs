using Code.Data;

namespace Code.Services.LoadSavedProgress
{
    public interface ISavedProgressLoader:IService
    {
        void SaveData();
        PlayerData LoadProgress();
    }
}