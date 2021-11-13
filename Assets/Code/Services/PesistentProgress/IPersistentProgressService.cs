using Code.Data;

namespace Code.Services.PesistentProgress
{
    public interface IPersistentProgressService:IService
    {
        PlayerData PlayerData { get; set; }
    }
}