using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    float xMin, xMax;




    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void SetUpMoveBounderies()
    {
        Camera myCamera = Camera.main;
        xMin = myCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = myCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

    }

    private void Move()
    {

        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXpos, transform.position.y);

        
    }
}
