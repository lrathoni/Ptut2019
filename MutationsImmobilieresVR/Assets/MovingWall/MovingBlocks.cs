using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
 
public class MovingBlocks : MonoBehaviour 
{ 
    Transform CubetoMove; 
    List<int> ChildPosition = new List<int>();
    bool initialization = false; 
    float[] Rescale = new float[100];
    float[] IntervalRescale = new float[100]; 
    int revert = 1; 
    bool goFar = false; 
 
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
        int NbMove = Random.Range(1, 10); 
        int cubePosition = Random.Range(0, 99); 
        positionTab.Add(cubePosition); 
            for (int i = 1; i < NbMove; i++) 
            { 
                cubePosition = Random.Range(0, 99); 
                if (AlreadyIn(ref positionTab,ref  cubePosition) == false) 
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
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        if (initialization == false) 
        {
            InitCubeListMoving(ref ChildPosition);
            initialization = true; 
        } 
 
        if ( initialization == true ) 
        { 
            for (int i = 0; i < ChildPosition.Count; i++) 
            { 
                CubetoMove = this.gameObject.transform.GetChild(ChildPosition[i]); 
                CubetoMove.transform.localScale = new Vector3(100f, 100f, 100 + Mathf.Abs(Mathf.Sin(Time.time + IntervalRescale[i]) * Rescale[i]) );
            } 
        } 
 
    } 
} 