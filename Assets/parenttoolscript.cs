using UnityEngine;

public class parenttoolscript : MonoBehaviour
{
    public bool pickedup = false;
    public GameObject hands;
    public GameObject tool;
    public Rigidbody toolRB; //comment out for no physics on the tool
    private Vector3 originalScale;

    void Start()
    {
        originalScale = tool.transform.lossyScale;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == tool)
                {
                    pickedup = true;
                }
            }
        }
        if (pickedup)
        {
            tool.transform.SetParent(hands.transform, true);
            toolRB.isKinematic = true; //comment out for no physics on the tool
            GetComponent<Collider>().enabled = false;
            if (Input.GetMouseButtonDown(1)) {
                pickedup = false;
            }
        }
        else
        {
            tool.transform.parent = null;
            toolRB.isKinematic = false; //comment out for no physics on the tool
            GetComponent<Collider>().enabled = true;
        }
    }

}
