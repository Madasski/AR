using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private PointManager _pointManager;

    public static PointManager PointManager { get; private set; }

    private void Awake()
    {
        PointManager = _pointManager;
    }
}