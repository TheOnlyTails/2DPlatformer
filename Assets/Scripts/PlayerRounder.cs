using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class PlayerRounder : MonoBehaviour
{
    [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
    private void LateUpdate()
    {
        // var x = Mathf.Round(100f * transform.position.x) / 100f;
        // var y = Mathf.Round(100f * transform.position.y) / 100f;
        // var newPos = new Vector3(x, y);
        //
        // transform.position = newPos;
    }
}