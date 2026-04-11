using System.Runtime.CompilerServices;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum Mode
    {
        LookAt,
        LookAtInverted,
    }

    [SerializeField] private Mode mode;

    private void LateUpdate() //late update is like almost similiar to awake and start, just to diffrentiate
    {
        switch (mode)
        {
        case Mode.LookAt:
            transform.LookAt(Camera.main.transform);
            break;
        case Mode.LookAtInverted:
            Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
            transform.LookAt(transform.position + dirFromCamera);
                break;
        }
        
    }


}
