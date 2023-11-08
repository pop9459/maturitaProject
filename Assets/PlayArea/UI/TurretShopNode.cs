using UnityEngine;

public class TurretShopNode : MonoBehaviour {
    [SerializeField] GameObject turret;
    private void OnMouseDown()
    {
        if (!Controller.editMode)
        {
            Instantiate(turret);
        }
    }
}
