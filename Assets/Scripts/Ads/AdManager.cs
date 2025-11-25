using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsInitializationListener, IUnityAdsLoadListener
{
    public static AdManager instance;

    [SerializeField] private string placementID = "Interstitial_";

    [SerializeField] private string android_ID = "5991789";
    [SerializeField] private string iOS_ID = "5991788";

    [SerializeField] private bool testMode;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
#if UNITY_ANDROID || UNITY_EDITOR || UNITY_STANDALONE_WIN
        Advertisement.Initialize(android_ID, testMode, this);
        placementID += "Android";
#elif UNITY_IOS
        Advertisement.Initialize(iOS_ID, testMode, this);
        placementID+= "iOS";
#endif
    }

    public void LoadAd()
    {
        Advertisement.Load(placementID, this);
    }

    public void ShowAd()
    {
        Advertisement.Show(placementID, this);
    }


    #region IUnityAdsShowListener

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"OnUnityAdsShowFailure {error}: {message}");
        LoadAd();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("OnUnityAdsShowStart");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("OnUnityAdsShowClick");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("OnUnityAdsShowComplete");
        LoadAd();
    }

    #endregion


    #region IUnityAdsInitializationListener

    public void OnInitializationComplete()
    {
        Debug.Log("OnInitializationComplete");
        LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"OnInitializationFailed {error}:  {message}");
    }

    #endregion

    #region IUnityAdsLoadListener

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("OnUnityAdsAdLoaded");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"OnUnityAdsFailedToLoad {error}:  {message}");
    }

    #endregion
}