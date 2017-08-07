using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingCircle : MonoBehaviour {
    const float CIRCLE_SIZE = 0.1f;
    const float ROTATION_DEGREE_SPEED = 1.0f;
    const float DEFAULT_ALPHA = 0.5f;
    List<GameObject> circles;

    public Color InitializingColor = Color.magenta;
    public Color ImportingOrExportingColor = Color.yellow;
    public Color UploadingColor = Color.blue;
    public Color DownloadingColor = Color.green;
    public Color FailureColor = Color.red;

    ImportExportAnchorManager anchorManager;
    Color color;

    // Use this for initialization
    void Start () {

        color = Color.white;

        anchorManager = ImportExportAnchorManager.Instance;

        circles = new List<GameObject>();
        foreach (Transform child in transform)
        {
            circles.Add(child.gameObject);
            float deg = (float)(360 / 8 * circles.Count);
            float rad = Mathf.Deg2Rad * deg;
            Vector3 position = child.position;
            position.x = Mathf.Sin(rad) * CIRCLE_SIZE;
            position.y = Mathf.Cos(rad) * CIRCLE_SIZE;
            child.position = position;
            RawImage rawImage = child.Find("RawImage").GetComponent<RawImage>();
            Color color = rawImage.color;
            color.a = DEFAULT_ALPHA;
            rawImage.color = color;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (anchorManager != null)
        {
            switch (anchorManager.CurrentState)
            {
                case ImportExportAnchorManager.ImportExportState.AnchorStore_Initializing:
                case ImportExportAnchorManager.ImportExportState.Start:
                case ImportExportAnchorManager.ImportExportState.AnchorStore_Initialized:
                    color = InitializingColor;
                    break;
                case ImportExportAnchorManager.ImportExportState.Importing:
                case ImportExportAnchorManager.ImportExportState.InitialAnchorRequired:
                case ImportExportAnchorManager.ImportExportState.CreatingInitialAnchor:
                case ImportExportAnchorManager.ImportExportState.DataReady:
                    color = ImportingOrExportingColor;
                    break;
                case ImportExportAnchorManager.ImportExportState.UploadingInitialAnchor:
                    color = UploadingColor;
                    break;
                case ImportExportAnchorManager.ImportExportState.DataRequested:
                    color = DownloadingColor;
                    break;
                case ImportExportAnchorManager.ImportExportState.Failed:
                    color = FailureColor;
                    break;
                default:
                    color = Color.white;
                    break;
            }

            foreach(GameObject circle in circles)
            {
                circle.transform.Find("RawImage").GetComponent<RawImage>().color = color;
            }
        }

        Vector3 rotation = new Vector3(0, 0, -ROTATION_DEGREE_SPEED);
        this.transform.Rotate(rotation);
	}
}
