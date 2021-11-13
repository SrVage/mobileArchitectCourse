using System;

namespace Code.Data
{
    [Serializable]
    public class PlayerData
    {
        public PositionOnLevel PositionOnLevel;

        public PlayerData(string scene)
        {
           PositionOnLevel = new PositionOnLevel(scene);
        }
    }
}