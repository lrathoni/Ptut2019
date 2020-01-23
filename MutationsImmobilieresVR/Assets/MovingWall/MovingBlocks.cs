using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
 
public class MovingBlocks : MonoBehaviour 
{ 
    Transform CubetoMove; 
    List<int> ChildPosition; 
    bool initialization = false; 
    int[] Rescale = new int[100]; 
    int[] IntervalRescale = new int[100]; 
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
        int NbMove = Random.Range(1, 100); 
        int cubePosition = Random.Range(0, 99); 
        positionTab.Add(cubePosition); 
            for (int i = 1; i < NbMove; i++) 
            { 
                cubePosition = Random.Range(0, 99); 
                if (AlreadyIn(ref positionTab,ref  cubePosition) == false) 
                { 
                    positionTab.Add(cubePosition); 
                    Rescale[i] = Random.Range(150, 1000); 
                    IntervalRescale[i] = Random.Range(1, 20); 
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
                CubetoMove = this.gameObject.transform.GetChild(i); 
                if (CubetoMove.transform.localScale.y >= 100) 
                { 
                    CubetoMove.transform.localScale += new Vector3(0f, revert * IntervalRescale[i], 0f); 
                    if (CubetoMove.transform.localScale.y > Rescale[i] && goFar == false) 
                    { 
                        revert = -1; 
                        goFar = true; 
                    } 
                } 
                if (CubetoMove.transform.localScale.y < 100) 
                { 
                    goFar = false; 
                    revert = 1; 
                } 
            } 
        } 
 
    } 
} 