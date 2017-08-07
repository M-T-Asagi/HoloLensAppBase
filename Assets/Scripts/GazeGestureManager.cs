using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GazeGestureManager : MonoBehaviour
{
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject { get; private set; }

    GestureRecognizer recognizer;

    bool mouseDown = false;
    int mouseDownCount = 0;

#if UNITY_EDITOR
    bool onUnityEditor = true;
#else
    bool onUnityEditor = false;
#endif

    // Use this for initialization
    void Awake()
    {
        Instance = this;

        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
        if (!onUnityEditor)
        {
            recognizer.TappedEvent += (source, tapCount, ray) =>
            {
                OnSelect();
            };

            recognizer.HoldStartedEvent += (source, ray) =>
            {
                OnHold();
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }

        // If the focused object changed this frame,
        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();

            if (FocusedObject != null)
                FocusedObject.SendMessage("OnFocused", null, SendMessageOptions.DontRequireReceiver);

            if (oldFocusObject != null)
                oldFocusObject.SendMessage("UnFocused", null, SendMessageOptions.DontRequireReceiver);
        }

        // Debug用マウス操作受付
        if (onUnityEditor)
        {
            DebugMouseInput();
        }
    }

    void DebugMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(mouseDownCount);
            if (mouseDownCount > 60)
            {
                OnHold();
            }
            else
            {
                OnSelect();
            }
            mouseDownCount = 0;
            mouseDown = false;
        }

        if (mouseDown)
        {
            mouseDownCount++;
        }
    }

    void OnHold()
    {
        // Send an OnSelect message to the focused object and its ancestors.
        if (FocusedObject != null)
        {
            FocusedObject.SendMessage("OnHold", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    void OnSelect()
    {
        // Send an OnSelect message to the focused object and its ancestors.
        if (FocusedObject != null)
        {
            Debug.Log(FocusedObject.name);
            FocusedObject.SendMessage("OnSelect", null, SendMessageOptions.DontRequireReceiver);
        }
    }
}