using UnityEngine;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject left,right,jump;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        left.SetActive(false);
        right.SetActive(false);
        jump.SetActive(false);
#else
        left.SetActive(true);
        right.SetActive(true);
        jump.SetActive(true);
        
#endif
    }
}
