using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject WarningPrefab;

    public void ShowWarning()
    {
        var warning = Instantiate(WarningPrefab,transform);
        Destroy(warning, 2f);
    }
}