using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMainSystem : MonoBehaviour
{
    public static List<GravityForBody> bodies = new List<GravityForBody>();
    public static List<GravityForBody> virtualBodies = new List<GravityForBody>();
    public static float G = 0.000000667f;
    private void Update()
    {
        GravityForBody.MoveGravityForAll(bodies);
    }
}
