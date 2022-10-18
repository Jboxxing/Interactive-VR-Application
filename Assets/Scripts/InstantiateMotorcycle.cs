using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMotorcycle : MonoBehaviour
{
    public Transform motorcycle;
    public Transform spawned;

    // Start is called before the first frame update
    void Start()
    {
        float x = -2.0f;
        for (int i = 0; i < 3; i++)
        {
            Transform m = Instantiate(motorcycle, new Vector3(x, 0.0f, 20.0f), Quaternion.identity, spawned);
            if (m.position.y < 0)
            {
                m.position = new Vector3(m.position.x, 0.0f, m.position.z);
            }
            x += 2.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
