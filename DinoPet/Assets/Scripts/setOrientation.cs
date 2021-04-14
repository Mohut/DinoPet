using UnityEngine;

public class setOrientation : MonoBehaviour
{

    public bool isPortrait = true;
    // Start is called before the first frame update
    void Start()
    {
        if (isPortrait)
            Screen.orientation = ScreenOrientation.Portrait;
        else
            Screen.orientation = ScreenOrientation.Landscape;

    }
    
}
