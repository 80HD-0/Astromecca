using UnityEngine;

public class toolscript : MonoBehaviour
{
    public bool pickedup = false;
    public GameObject hands;
    public GameObject tool;
    public Vector3 offset = new Vector3(0, 0, 0);
    public Vector3 rotation = new Vector3(80, 0, 0);
    public Rigidbody toolRB; //comment out for no physics on the tool

    void Start()
    {
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
            toolRB.isKinematic = true; //comment out for no physics on the tool
            tool.transform.position = hands.transform.position + offset;
            tool.transform.eulerAngles = hands.transform.eulerAngles + rotation;
            GetComponent<Collider>().enabled = false;
            if (Input.GetMouseButtonDown(1)) {
                pickedup = false;
            }
        }
        else
        {
            toolRB.isKinematic = false; //comment out for no physics on the tool
            GetComponent<Collider>().enabled = true;
        }
    }

}
