using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private Renderer renderer;
    [SerializeField] private Vector2 scroll = new Vector2 (0.05f , 0.05f);
    [SerializeField] private float resetOnX = 100f;
    
    private Vector2 _offset = new Vector2 (0f, 0f);
    private bool _forwards;
     
    void Update () 
    {
        if (_forwards)
            _offset +=  scroll * Time.deltaTime;
        else
            _offset -=  scroll * Time.deltaTime;
        renderer.material.SetTextureOffset ("_MainTex", _offset);
        Debug.Log(_offset);
        if (_offset.x >= resetOnX || _offset.x < 0) 
            _forwards = !_forwards;
    }
}
