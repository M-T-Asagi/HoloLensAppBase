using HoloToolkit.Unity;

public class BaseStates : Singleton<BaseStates>
{
    public bool MappingState { get; set; }
    public bool Sharing { get; set; }

    public string SharingAddress;
    public string SpectatorViewAddress;

    protected override void Awake()
    {
        base.Awake();
        MappingState = false;
        Sharing = false;
    }
}
