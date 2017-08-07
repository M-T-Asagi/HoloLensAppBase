using UnityEngine;
using HoloToolkit.Sharing;
using SpectatorView;

public class MainManager : MonoBehaviour
{
    public GameObject Sharing;
    public GameObject SpectatorViewManager;
    public GameObject Anchor;

    private void Awake()
    {
        BaseStates baseStates = BaseStates.Instance;

        if (baseStates.Sharing)
        {
            string SharingServerAddress = baseStates.SharingAddress;
            Sharing.GetComponent<SharingStage>().ServerAddress = SharingServerAddress;
            //SpectatorViewManager.GetComponent<SpectatorViewManager>().SharingServiceIP = SharingServerAddress;
        }
        else
        {
            DeActiveSharings();
        }
    }

    private void DeActiveSharings()
    {
        Sharing.SetActive(false);
        SpectatorViewManager.SetActive(false);

        Destroy(Anchor.GetComponent<ImportExportAnchorManager>());
        Destroy(Anchor.GetComponent<SceneManager>());
        Destroy(Anchor.GetComponent<SV_CustomMessages>());
        Destroy(Anchor.GetComponent<SV_ImportExportAnchorManager>());
        Destroy(Anchor.GetComponent<SV_RemotePlayerManager>());
    }
}
