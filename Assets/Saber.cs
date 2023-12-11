// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class Saber : MonoBehaviour
// // {
// //     public LayerMask layer;
// //     private Vector3 previousPos;

// //     // Start is called before the first frame update
// //     void Start()
// //     {
        
// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
// //         RaycastHit hit;
        // if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        // {
        //     if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130){
        //         Destroy(hit.transform.gameObject);
        //     }
        // }
        // previousPos = transform.position;
// //     }
// // }



// // using System.Collections;
// // using System.Collections.Generic;
// // using UnityEngine;

// // public class Saber : MonoBehaviour
// // {
// //     public LayerMask layer;
// //     public GameObject hitEffectPrefab;  // Assign the particle system prefab in the Inspector
// //     private Vector3 previousPos;

// //     // Start is called before the first frame update
// //     void Start()
// //     {

// //     }

// //     // Update is called once per frame
// //     void Update()
// //     {
// //         RaycastHit hit;
// //         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
// //         {
// //             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
// //             {
// //                 // Instantiate the hit effect at the collision point
// //                 GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);

// //                 // Destroy the hit object (cube)
// //                 Destroy(hit.transform.gameObject);
                
// //                 // Destroy the hit effect after 1 second
// //                 Destroy(hitEffect, 1f);
// //             }
// //         }
// //         previousPos = transform.position;
// //     }
// // }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro; // Import TextMeshPro namespace

// public class Saber : MonoBehaviour
// {
//     public LayerMask layer;
//     public GameObject hitEffectPrefab;
//     public GameObject cubeHalfPrefab;
//     public AudioClip hitSound;
//     private Vector3 previousPos;
//     private int score = 0;
//     public TextMeshProUGUI scoreText; // Reference to TextMeshProUGUI for displaying score

//     // Start is called before the first frame update
//     void Start()
//     {
//         UpdateScoreText(); // Initialize the score text
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
//         {
//             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
//             {
//                 // Play the hit sound
//                 if (hitSound != null)
//                 {
//                     AudioSource.PlayClipAtPoint(hitSound, hit.point);
//                 }

//                 // Increment the score
//                 score++;

//                 // Update the score text on the UI
//                 UpdateScoreText();

//                 // Instantiate the hit effect at the collision point
//                 GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);

//                 // Instantiate two cube halves at the collision point
//                 GameObject cubeHalf1 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);
//                 GameObject cubeHalf2 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);

//                 // Adjust the positions and sizes of the two halves
//                 float cubeSize = hit.transform.localScale.x;
//                 float halfSize = cubeSize / 2f;
//                 cubeHalf1.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                 cubeHalf2.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                 cubeHalf1.transform.position = hit.point - hit.transform.right * (halfSize / 2f);
//                 cubeHalf2.transform.position = hit.point + hit.transform.right * (halfSize / 2f);

//                 // Add rigidbody components to the cube halves
//                 Rigidbody rb1 = cubeHalf1.AddComponent<Rigidbody>();
//                 Rigidbody rb2 = cubeHalf2.AddComponent<Rigidbody>();

//                 // Set the rigidbody properties
//                 rb1.mass = 1f;
//                 rb2.mass = 1f;

//                 // Destroy the original cube
//                 Destroy(hit.transform.gameObject);
//                 // Destroy the hit effect after 0.5 seconds
//                 Destroy(hitEffect, 0.5f);
//             }
//         }
//         previousPos = transform.position;
//     }

//     // Update the score text on the UI
//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + score.ToString();
//         }
//     }
// }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Saber : MonoBehaviour
// {
//     public LayerMask layer;
//     public GameObject hitEffectPrefab;
//     public GameObject cubeHalfPrefab;
//     public AudioClip hitSound;
//     private Vector3 previousPos;
//     private static int totalScore = 0;  // Use a static variable to share the score among all instances
//     public TextMeshProUGUI scoreText;  // Reference to TextMeshProUGUI for displaying score

//     // Start is called before the first frame update
//     void Start()
//     {
//         UpdateScoreText();  // Initialize the score text
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
//         {
//             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
//             {
//                 // Play the hit sound
//                 if (hitSound != null)
//                 {
//                     AudioSource.PlayClipAtPoint(hitSound, hit.point);
//                 }

//                 // Increment the total score
//                 totalScore++;

//                 // Update the score text on the UI
//                 UpdateScoreText();

//                 // Instantiate the hit effect at the collision point
//                 GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);

//                 // Instantiate two cube halves at the collision point
//                 GameObject cubeHalf1 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);
//                 GameObject cubeHalf2 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);

//                 // Adjust the positions and sizes of the two halves
//                 float cubeSize = hit.transform.localScale.x;
//                 float halfSize = cubeSize / 2f;
//                 cubeHalf1.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                 cubeHalf2.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                 cubeHalf1.transform.position = hit.point - hit.transform.right * (halfSize / 2f);
//                 cubeHalf2.transform.position = hit.point + hit.transform.right * (halfSize / 2f);

//                 // Add rigidbody components to the cube halves
//                 Rigidbody rb1 = cubeHalf1.AddComponent<Rigidbody>();
//                 Rigidbody rb2 = cubeHalf2.AddComponent<Rigidbody>();

//                 // Set the rigidbody properties
//                 rb1.mass = 1f;
//                 rb2.mass = 1f;

//                 // Destroy the original cube
//                 Destroy(hit.transform.gameObject);
//                 // Destroy the hit effect after 0.5 seconds
//                 Destroy(hitEffect, 0.5f);
//             }
//         }
//         previousPos = transform.position;
//     }

//     // Update the score text on the UI
//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + totalScore.ToString();  // Display the total score
//         }
//     }
// }

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Saber : MonoBehaviour
// {
//     public LayerMask layer;
//     public GameObject hitEffectPrefab;
//     public GameObject cubeHalfPrefab;
//     public AudioClip hitSound;
//     private Vector3 previousPos;
//     private static int totalScore = 0;
//     private HashSet<GameObject> cubesHitThisFrame = new HashSet<GameObject>();
//     private HashSet<GameObject> scoredCubes = new HashSet<GameObject>();
//     private float scoreCooldown = 0.5f; // Cooldown period in seconds
//     private float lastScoreTime = 0f;
//     public TextMeshProUGUI scoreText;

//     void Start()
//     {
//         UpdateScoreText();
//     }

//     void Update()
//     {
//         cubesHitThisFrame.Clear();

//         RaycastHit hit;
//         if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
//         {
//             if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
//             {
//                 if (!cubesHitThisFrame.Contains(hit.transform.gameObject))
//                 {
//                     // Check if enough time has passed since the last score
//                     if (Time.time - lastScoreTime >= scoreCooldown)
//                     {
//                         if (!scoredCubes.Contains(hit.transform.gameObject))
//                         {
//                             AudioSource.PlayClipAtPoint(hitSound, hit.point);
//                             totalScore++;
//                             UpdateScoreText();

//                             GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);
//                             GameObject cubeHalf1 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);
//                             GameObject cubeHalf2 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);

//                             float cubeSize = hit.transform.localScale.x;
//                             float halfSize = cubeSize / 2f;
//                             cubeHalf1.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                             cubeHalf2.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
//                             cubeHalf1.transform.position = hit.point - hit.transform.right * (halfSize / 2f);
//                             cubeHalf2.transform.position = hit.point + hit.transform.right * (halfSize / 2f);

//                             Rigidbody rb1 = cubeHalf1.AddComponent<Rigidbody>();
//                             Rigidbody rb2 = cubeHalf2.AddComponent<Rigidbody>();
//                             rb1.mass = 1f;
//                             rb2.mass = 1f;

//                             scoredCubes.Add(hit.transform.gameObject);
//                             Destroy(hit.transform.gameObject);
//                             Destroy(hitEffect, 0.5f);

//                             // Update the last score time
//                             lastScoreTime = Time.time;
//                         }

//                         cubesHitThisFrame.Add(hit.transform.gameObject);
//                     }
//                 }
//             }
//         }
//         previousPos = transform.position;
//     }

//     void UpdateScoreText()
//     {
//         if (scoreText != null)
//         {
//             scoreText.text = "Score: " + totalScore.ToString();
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saber : MonoBehaviour
{
    public LayerMask layer;
    public GameObject hitEffectPrefab;
    public GameObject cubeHalfPrefab;
    public AudioClip hitSound;
    private Vector3 previousPos;
    private static int totalScore = 0;
    private HashSet<GameObject> cubesHitThisFrame = new HashSet<GameObject>();
    private HashSet<GameObject> scoredCubes = new HashSet<GameObject>();
    private float scoreCooldown = 0.5f; // Cooldown period in seconds
    private float lastScoreTime = 0f;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        cubesHitThisFrame.Clear();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                Destroy(hit.transform.gameObject);
                if (!cubesHitThisFrame.Contains(hit.transform.gameObject))
                {
                    // Check if enough time has passed since the last score
                    if (Time.time - lastScoreTime >= scoreCooldown)
                    {
                        if (!scoredCubes.Contains(hit.transform.gameObject))
                        {
                            AudioSource.PlayClipAtPoint(hitSound, hit.point);
                            totalScore++;
                            UpdateScoreText();

                            Debug.Log("Hit cube: " + hit.transform.gameObject.name);

                            GameObject hitEffect = Instantiate(hitEffectPrefab, hit.point, Quaternion.identity);
                            GameObject cubeHalf1 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);
                            GameObject cubeHalf2 = Instantiate(cubeHalfPrefab, hit.point, Quaternion.identity);

                            float cubeSize = hit.transform.localScale.x;
                            float halfSize = cubeSize / 2f;
                            cubeHalf1.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
                            cubeHalf2.transform.localScale = new Vector3(halfSize, cubeSize, cubeSize);
                            cubeHalf1.transform.position = hit.point - hit.transform.right * (halfSize / 2f);
                            cubeHalf2.transform.position = hit.point + hit.transform.right * (halfSize / 2f);

                            Rigidbody rb1 = cubeHalf1.AddComponent<Rigidbody>();
                            Rigidbody rb2 = cubeHalf2.AddComponent<Rigidbody>();
                            rb1.mass = 1f;
                            rb2.mass = 1f;

                            scoredCubes.Add(hit.transform.gameObject);
                            Destroy(hitEffect, 0.5f);

                            // Update the last score time
                            lastScoreTime = Time.time;
                        }

                        cubesHitThisFrame.Add(hit.transform.gameObject);
                    }
                }
            }
        }
        previousPos = transform.position;
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore.ToString();
        }
    }
}
