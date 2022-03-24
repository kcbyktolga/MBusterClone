using UnityEngine;

namespace MBusterClone
{
    public class UVMask : MonoBehaviour
    {      
        void Start()
        {
            GetComponent<MeshRenderer>().material.renderQueue = 3002;
        }
    }
}

