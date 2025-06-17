using UnityEngine;

public class HitFlashTrigger : MonoBehaviour
{
    [SerializeField] private HitFlash flashEffect;
    [SerializeField] private KeyCode flashKey;
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(flashKey))
        {
            flashEffect.Flash();
        }
    }
}
