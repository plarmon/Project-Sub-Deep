using UnityEngine;

//Patrick's baby

// Makes sure that there is a camera component
[RequireComponent(typeof(Camera))]
public class MinimapSnapshot : MonoBehaviour {
    Camera snapCam;

    int resWidth = 256;
    int resHeight = 256;

    public RenderTexture minimapTexture;

    private void Awake() {
        snapCam = GetComponent<Camera>();
        // If there is no target texture defined
        if (snapCam.targetTexture == null) {
            minimapTexture = new RenderTexture(resWidth, resHeight, 24);
            snapCam.targetTexture = minimapTexture;
        }
        else {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }

    public void CallTakeSnapshot() {
        // turns on the camera to take a picture
        snapCam.gameObject.SetActive(true);
    }

    private void Update()
    {
        
    }

    void LateUpdate() {
        if (snapCam.gameObject.activeSelf) {
            // Takes the picture and turns the camera off
            snapCam.Render();
            snapCam.gameObject.SetActive(false);
        }
    }
}
