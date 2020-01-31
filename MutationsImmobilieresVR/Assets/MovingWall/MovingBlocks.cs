using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingBlocks : MonoBehaviour
{

    public Transform carpetTransform;
    public Material[] cubeMat;
    Transform CubetoMove;
    List<int> ChildPosition = new List<int>();
    bool initialization = false;
    float[] Rescale = new float[100];
    float[] IntervalRescale = new float[100];
    bool goback = false;
    float comparedScale = 0f;

    float timer = 0f;

    private bool AlreadyIn(ref List<int> positionTab, ref int AddPosition)
    {
        for (int i = 0; i < positionTab.Count; i++)
        {
            if (positionTab[i] == AddPosition)
                return true;
        }
        return false;
    }

    private void InitCubeListMoving(ref List<int> positionTab)
    {
        int NbMove = Random.Range(20,40);
        for (int i = 0; i < NbMove; i++)
        {
            int cubePosition = Random.Range(0, 99);
            if (AlreadyIn(ref positionTab, ref cubePosition) == false)
            {
                positionTab.Add(cubePosition);
                Rescale[i] = Random.Range(150, 1000);
                IntervalRescale[i] = Random.Range(1f, 10f);
            }
            else
                i--;
        }
    }

    // Start is called before the first frame update  
    void Start()
    {
        if (cubeMat.Length ==0)
            return;
        GetComponentInParent<ExitAppear>().enabled = false;
    }

    // Update is called once per frame  
    void Update()
    {
        if (initialization == false)
        {
            InitCubeListMoving(ref ChildPosition);
            initialization = true;
        }

        if (initialization == true )
        {
            for (int i = 0; i < ChildPosition.Count; i++)
            {
                CubetoMove = this.gameObject.transform.GetChild(ChildPosition[i]);


                comparedScale = CubetoMove.transform.localScale.z;
                CubetoMove.transform.localScale = new Vector3(100f, 100f, 100f + Mathf.Abs(Mathf.Sin(Time.time + IntervalRescale[i]) * Rescale[i]));

                if (comparedScale > CubetoMove.transform.localScale.z)
                    goback = true;
                else
                    goback = false;

                if (CubetoMove.transform.localScale.z < 102f && goback == true)
                {
                    CubetoMove.transform.localScale = new Vector3(100f, 100f, 100f);
                    int cubePosition = Random.Range(0, 99);
                    while (AlreadyIn(ref ChildPosition, ref cubePosition) == true)
                        cubePosition = Random.Range(0, 99);
                    ChildPosition[i] = cubePosition;
                    Rescale[i] = Random.Range(150, 1000);
                    IntervalRescale[i] = Random.Range(1f, 20f);
                    CubetoMove.GetComponent<MeshRenderer>().material = cubeMat[Random.Range(0, cubeMat.Length -1)];
                }
            }
        }


        if (carpetTransform.GetComponent<BoxCollider>().enabled == false)
        {
            timer += Time.deltaTime;
        }

        if (carpetTransform.GetComponent<BoxCollider>().enabled == true)
            timer = 0f;

            if (timer >= 60f)
        {
            GetComponent<MovingBlocks>().enabled = false;
            timer = 0f;
            GetComponentInParent<ExitAppear>().enabled = true;
        }
    }
}