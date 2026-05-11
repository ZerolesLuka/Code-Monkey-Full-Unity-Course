using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        CuttingCounter.ResetStaticData(); //resets the static data for the cutting counter when the game is reset
        BaseCounter.ResetStaticData(); //resets the static data for the base counter when the game is reset
        TrashCounter.ResetStaticData(); //resets the static data for the trash counter when the game is reset
    }
}



