// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Saber : MonoBehaviour
// {
//     public LayerMask layer;
//     private Vector3 previousPos;

//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
//         {
//             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130){
//                 Destroy(hit.transform.gameObject);
//             }
//         }
//         previousPos = transform.position;
//     }
// }



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Saber : MonoBehaviour
// {
//     public LayerMask layer;
//     public GameObject hitEffectPrefab;  // Assign the particle system prefab in the Inspector
//     private Vector3 previousPos;

//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
//         {
//             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
//             {
//                 // Instantiate the hit effect at the collision point
//                 GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);

//                 // Destroy the hit object (cube)
//                 Destroy(hit.transform.gameObject);
                
//                 // Destroy the hit effect after 1 second
//                 Destroy(hitEffect, 1f);
//             }
//         }
//         previousPos = transform.position;
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    public GameObject hitEffectPrefab;  // Assign the particle system prefab in the Inspector
    public GameObject cubeHalfPrefab;   // Assign the cube half prefab in the Inspector
    private Vector3 previousPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                // Instantiate the hit effect at the collision point
                GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);

                // Instantiate two cube halves at the collision point
                GameObject cubeHalf1 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);
                GameObject cubeHalf2 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);

                // Adjust the positions and sizes of the two halves
                float cubeSize = hit.transform.localScale.x;
                float halfSize = cubeSize / 2f;
                cubeHalf1.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
                cubeHalf2.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
                cubeHalf1.transform.position = hit.point - hit.transform.right * (halfSize / 2f);
                cubeHalf2.transform.position = hit.point + hit.transform.right * (halfSize / 2f);

                // Add rigidbody components to the cube halves
                Rigidbody rb1 = cubeHalf1.AddComponent<Rigidbody>();
                Rigidbody rb2 = cubeHalf2.AddComponent<Rigidbody>();

                // Set the rigidbody properties
                rb1.mass = 1f;
                rb2.mass = 1f;

                // Destroy the original cube
                Destroy(hit.transform.gameObject);
                // Destroy the hit effect after 0.5 second
                Destroy(hitEffect, 0.5f);
                
            }
        }
        previousPos = transform.position;
    }
}
