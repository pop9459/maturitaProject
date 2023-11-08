using UnityEngine;

public class TurretPlace : MonoBehaviour
{
    Collider col;
    public float turretValue;
    private void Awake()
    {
        col = GetComponent<Collider>();
        TurretUpgrade turretUpgrade = gameObject.GetComponent<TurretUpgrade>();
        turretValue = turretUpgrade.baseValue;
        Controller.editMode = true;
    }
    private void OnDisable()
    {
        Controller.editMode = false;
    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Destroy(gameObject);
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Node")
            {
                //snap to node
                transform.position = hit.transform.position + new Vector3(0, 1, 0);

                GameObject node = hit.transform.gameObject;
                Node nodeController = node.gameObject.GetComponent<Node>();
                if(Input.GetMouseButtonDown(0) && Controller.money >= turretValue && nodeController.holdingTurret == null)
                {
                    //build
                    transform.SetParent(node.transform);
                    nodeController.holdingTurret = gameObject;
                    gameObject.GetComponent<TurretController>().enabled = true;
                    gameObject.GetComponent<Collider>().enabled = true;
                    Physics.SyncTransforms();
                    Controller.addMoney(-turretValue);
                    col.enabled = true;
                    this.enabled = false;
                } 
            }
            else
            {
                //normal move
                transform.position = hit.point;
            }
        }
    }
}