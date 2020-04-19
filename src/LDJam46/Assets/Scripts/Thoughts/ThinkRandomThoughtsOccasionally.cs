using UnityEngine;

public class ThinkRandomThoughtsOccasionally : MonoBehaviour
{
    [SerializeField] private string[] standardThoughts;
    [SerializeField] private FloatReference maxTime = new FloatReference(22f);
    [SerializeField] private FloatReference minTime = new FloatReference(12f);
    
    private float _timeUntilNextThought;
    
    void Update()
    {
        if (standardThoughts.Length == 0)
        {
            Debug.Log("No Thoughts To Think");
            return;
        }
        
        if (_timeUntilNextThought <= 0)
            _timeUntilNextThought = Random.Range(minTime, maxTime);
        
        _timeUntilNextThought -= Time.deltaTime;
        if (_timeUntilNextThought <= 0)
            Message.Publish(new ShowThought(standardThoughts.Random()));
    }
}
