using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    public static AdManager instance;
    [SerializeField] private string androidID;
    [SerializeField] private string iosID;
    [SerializeField] private bool testMode;

    private string placementID = "Rewarded_";

    private SandwichBehaviour sandwichBehaviour;

    private void Awake()


    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
#if UNITY_ANDROID || UNITY_EDITOR || UNITY_STANDALONE_WIN
        Advertisement.Initialize(androidID, testMode, this);
        placementID += "Android";
#elif UNITY_IOS
        Advertisement.Initialize(iosID,testMode, this);
        placementID += "iOS";

#endif    

        sandwichBehaviour = GameObject.FindWithTag("Sandwich").GetComponent<SandwichBehaviour>();
        sandwichBehaviour.mark();
    }

    public void ShowAd()
    {
        Advertisement.Show(placementID, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("El anuncio ha fallado al mostrarse");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("El anuncio se ha iniciado");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("El anuncio ha sido mostrado");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("El anuncio se ha completado");
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            sandwichBehaviour.AddSandiwches(1);
        }

    }

    public void OnInitializationComplete()
    {
        Debug.Log("Se ha inicializado el listener");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("El listener ha fallado");
    }
}
