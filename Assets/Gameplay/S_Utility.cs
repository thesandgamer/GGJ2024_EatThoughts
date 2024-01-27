using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Utility : MonoBehaviour
{
    public static Vector3 VinterpTo( Vector3 Current,  Vector3 Target, float DeltaTime, float InterpSpeed)
    {
        // If no interp speed, jump to target value
        if( InterpSpeed <= 0.0f )
        {
            return Target;
        }

        // Distance to reach
        Vector3 Dist = Target - Current;

        // If distance is too small, just set the desired location
        
        if( Dist.sqrMagnitude < 0.0000000000001)
        {
            return Target;
        }

        // Delta Move, Clamp so we do not over shoot.
        Vector3	DeltaMove = Dist * UnityEngine.Mathf.Clamp(DeltaTime * InterpSpeed, 0.0f, 1.0f);

        return Current + DeltaMove;
    }
    
  
}
