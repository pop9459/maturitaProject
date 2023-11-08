using System; 
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGUI : MonoBehaviour
{
    [SerializeField] public Text pathOneTopText;
    [SerializeField] public Text pathOneButtonText;
    [SerializeField] public Text pathTwoTopText;
    [SerializeField] public Text pathTwoButtonText;
    [SerializeField] public Text sellButtonText;

    static public UpgradeGUI instance;
    public static event Action<int> OnUpgradeClick;

    private void Awake()
    {
        instance = this;
        instance.gameObject.SetActive(false);
    }
    public void InvokeUpgradeClick(int path)
    {
        OnUpgradeClick?.Invoke(path);
    }

}
