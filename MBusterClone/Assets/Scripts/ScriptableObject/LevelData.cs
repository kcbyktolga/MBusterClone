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
    
    /* 
     Oyundaki bütün seviye mekaniklerinin nasýl olduðunu ön görmediðim içn geçici olarak seviyeler için böyle basit bir þablon kullandým. Bu þablon ilerki bölümler için geniþletilebilir ve Game Manager vasýstasý ile bölümler seviye indeksine göre ayarlanabilir. Not: Bu þablon ilk üç seviye için çalýþýr.
    */
}
