using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    private void Start()
    {
        var uiManager = CompositionRoot.UIManager;
        var pointFactory = CompositionRoot.PointFactory;

        pointFactory.PointCreated += visualisation => visualisation.FailedToMove += uiManager.ShowWarning;
    }
}