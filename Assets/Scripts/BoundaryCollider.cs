using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class BoundaryCollider : MonoBehaviour
{
    public EdgeCollider2D EdgeCollider;

#if UNITY_EDITOR
    public void Reset()
    {
        EdgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        EdgeCollider.points = new Vector2[]
        {
            new Vector2(-1, -1),
            new Vector2(-1, 1),
            new Vector2(1, 1),
            new Vector2(1, -1),
            new Vector2(-1, -1),
        };
    }

    private void Update()
    {
        Vector2[] newPoints = EdgeCollider.points;
        newPoints[0] = newPoints.Last();
        EdgeCollider.points = newPoints;
    }
#endif
}
