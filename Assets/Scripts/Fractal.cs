using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fractal : MonoBehaviour
{
    List<GameObject> cubes = new List<GameObject>();

    [SerializeField]
    private GameObject cubePrefab;

    [SerializeField]
    private int iteration;

    [SerializeField]
    private float size;

    void Start()
    {
        //  This statement create a game object given a prefab, position and rotation.
        GameObject go = Instantiate(
            //  This parameter sets a prefab for an instance to be created.
            cubePrefab, 
            //  This parameter sets an instance position to (0, 0, 0).
            Vector3.zero,
            //  This parameter sets an instance rotation to (0, 0, 0).
            Quaternion.identity );
         go.transform.localScale = new Vector3(size, size, size);
         go.GetComponent<MengerBox>().size = size;
        cubes.Add(go);
    }
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            List<GameObject> newCubes = Split(cubes);
            foreach (var go in cubes)
            {
                Destroy(go);
            }
            cubes = newCubes;
        }
    }
        List<GameObject> Split(List<GameObject> cubes)
        {
           List<GameObject> subCubes = new List<GameObject>();
           foreach (var cube in cubes)
     {
            float size = cube.GetComponent<MengerBox>().size;
        for (int x = -1 ; x < 2; x++)
        {
            for(int y = -1; y < 2; y++)
            {
                for(int z = -1; z < 2; z++)
                {
                    float xx = x * ((size / 3f)*3f);
                    float yy = y * ((size / 3f)*3f);
                    float zz = z * ((size / 3f)*3f);

                    Vector3 cubePos = new Vector3(xx, yy, zz)
                    +cube.transform.position;

                    int sum = Mathf.Abs(x) + Mathf.Abs(y) + Mathf.Abs(z) ;
                    if (sum > 1)
                {
                    GameObject copy = Instantiate(cube, cubePos, Quaternion.identity);
                    copy.GetComponent<MengerBox>().size = (size / 3f);
                    copy.transform.localScale = new Vector3((size / 3f)*3f , (size / 3f)*3f, (size / 3f)*3f);

                    subCubes.Add(copy);
                }
            }
        }
    }
     }
           return subCubes;
        
    }
}
