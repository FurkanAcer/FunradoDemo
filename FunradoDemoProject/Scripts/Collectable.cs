using TMPro;
using UnityEngine;
public class Collectable : MonoBehaviour
{
    [SerializeField]internal TextMeshProUGUI _tmPro;
    public int playerLevel = 1;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Level"))
        {
            Debug.Log("Level");
            playerLevel += 2;
            _tmPro.text = playerLevel.ToString();
            Destroy(other.gameObject);
        }
    }
    
}
