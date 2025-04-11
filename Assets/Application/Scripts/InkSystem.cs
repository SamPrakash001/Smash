using UnityEngine;
using UnityEngine.UI;

public class InkSystem : MonoBehaviour
{
    public static InkSystem Instence;

    public float inkAmount;
    public float leakMultiplier;
    [SerializeField] private Image _inkBar;

    void Start()
    {
        Instence = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInk()
    {
        if (inkAmount <= 0)
        {
            Debug.Log("Less ink, Refill it");
            return;
        }
        else
        {
            _inkBar.fillAmount = (inkAmount % 100) / 100;
           // Debug.Log((inkAmount % 100) / 100);
        }
    }
}
