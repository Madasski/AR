using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    [SerializeField] private PointManager _pointManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private PointFactory _pointFactory;

    public static PointManager PointManager { get; private set; }
    public static UIManager UIManager { get; private set; }
    public static PointFactory PointFactory { get; private set; }

    private void Awake()
    {
        PointManager = _pointManager;
        UIManager = _uiManager;
        PointFactory = _pointFactory;
    }
}