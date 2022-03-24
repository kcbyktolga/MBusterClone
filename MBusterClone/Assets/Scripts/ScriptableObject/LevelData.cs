using System.Collections.Generic;
using UnityEngine;

namespace MBusterClone
{
    [CreateAssetMenu(menuName ="Data/Level Data",fileName ="Level Data")]
    public class LevelData : ScriptableObject
    {
        public List<Level> levelList;
    }
    
    [System.Serializable]
    public class Level
    {
        public MoneyType type;
    }
}
