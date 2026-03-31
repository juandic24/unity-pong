using UnityEngine;

public class ButtonSound : MonoBehaviour
{
       public void PlayClick()
    {
        AudioManager.Instance.PlayUIClick();
    }
}
