using UnityEngine;

public class ServicesInstaller : MonoBehaviour
{
    [SerializeField] private UseCases.UC_GrabableItemsGenerator _TOInstallSpawnCookiesService;
    [SerializeField] private ExternalLayer.TweeningClass _ToInstallTweenEngine;

    private void Awake()
    {
        Services.Instance.AddService<ICookiesSpawner>(_TOInstallSpawnCookiesService);
        Services.Instance.AddService<ITween>(_ToInstallTweenEngine);
    }
}