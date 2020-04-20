
using UnityEngine;

public class EzScreen : MonoBehaviour
{
    private static int _counter;
    
    [SerializeField] private string filename;
    
    public void TakeScreenshot()
    {
        ScreenCapture.CaptureScreenshot($"{filename}_{_counter++}.png");
    }
}
