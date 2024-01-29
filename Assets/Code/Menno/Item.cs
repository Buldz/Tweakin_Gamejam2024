using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //Item
    private Transform itemLocation;
    private Rigidbody rb;
    private GameObject _playerObj;
    public bool pickUp = false;
    public bool hasBeenUsed = false;
    public static bool isUsed;


    public void Start()
    {
        gameObject.layer = 6;
        rb = GetComponent<Rigidbody>();
        _playerObj = GameObject.FindGameObjectWithTag("ItemLocation");
        itemLocation = _playerObj.GetComponent<Transform>();
    }

    public void Pickup()
    {
        if (!(this.gameObject.layer == 6))
        {
            this.transform.localScale = this.transform.localScale / 10;
        }
        else
        {
            this.transform.localScale = this.transform.localScale / 3;
        }
        this.transform.position = itemLocation.transform.position;
        this.transform.rotation = itemLocation.transform.rotation;
        this.gameObject.transform.parent = itemLocation.transform;
        rb.isKinematic = true;
        pickUp = true;
    }

    public void Release()
    {
        if (!(this.gameObject.layer == 6))
        {
            this.transform.localScale = this.transform.localScale * 10;
        }
        else
        {
            this.transform.localScale = this.transform.localScale * 3;
        }
        this.gameObject.transform.parent = null;
        this.transform.rotation = Quaternion.identity;
        rb.isKinematic = false;
        pickUp = false;
    }

    public abstract void Use();

    public void Used()
    {
        if (!hasBeenUsed)
        {
            isUsed = true;
        }
        hasBeenUsed = true;

    }

    void Update()
    {
        if (pickUp == false)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }
}