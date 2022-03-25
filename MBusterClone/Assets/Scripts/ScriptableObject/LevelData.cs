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
     Oyundaki b�t�n seviye mekaniklerinin nas�l oldu�unu �n g�rmedi�im i�n ge�ici olarak seviyeler i�in b�yle basit bir �ablon kulland�m. Bu �ablon ilerki b�l�mler i�in geni�letilebilir ve Game Manager vas�stas� ile b�l�mler seviye indeksine g�re ayarlanabilir. Not: Bu �ablon ilk �� seviye i�in �al���r.
    */
}
