using UnityEngine;

public class ShowRangeOnHover : MonoBehaviour
{
    [SerializeField] GameObject rangeIndicator;
    TurretController turretController;
    private void Awake()
    {
        Physics.autoSyncTransforms = true;
        turretController = GetComponent<TurretController>();
    }

    private void OnMouseEnter()
    {
        if(!Controller.editMode)
        {
            float range = turretController.range * 2;
            rangeIndicator.transform.localScale = new Vector3(range, range, range);
            rangeIndicator.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        Physics.autoSyncTransforms = true;
        rangeIndicator.SetActive(false);
    }
}
