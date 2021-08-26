using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 originalPos;
    Vector3 originalScale;

    public Vector3 moveObject;
    public Vector3 rotateObject;
    public Vector3 changeScale;

    public GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.localPosition;
        originalScale = transform.localScale;

        flame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveObject * Time.deltaTime, Space.World);
        transform.Rotate(rotateObject * Time.deltaTime, Space.World);
        transform.localScale += changeScale;

        if(transform.localScale.x > originalScale.x * 2)
        {
            flame.SetActive(false);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            flame.SetActive(true);

            transform.localPosition = originalPos;
            transform.localScale = originalScale;
        }
    }
}
