using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Google.Play.AppUpdate;
using Google.Play.Common;

public class UpdateController : MonoBehaviour
{
    AppUpdateManager appUpdateManager;
    void Start()
    {
        appUpdateManager = new AppUpdateManager();
        StartCoroutine(CheckForUpdate());
    }

    IEnumerator CheckForUpdate(){
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation =
            appUpdateManager.GetAppUpdateInfo();

        // Wait until the asynchronous operation completes.
        yield return appUpdateInfoOperation;

        if (appUpdateInfoOperation.IsSuccessful){
            var appUpdateInfoResult = appUpdateInfoOperation.GetResult();
            // Check AppUpdateInfo's UpdateAvailability, UpdatePriority,
            // IsUpdateTypeAllowed(), etc. and decide whether to ask the user
            // to start an in-app update.
            var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateUpdate(appUpdateInfoResult, appUpdateOptions));
        }
    }
    IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInfoResult, AppUpdateOptions appUpdateOptions){
        // Creates an AppUpdateRequest that can be used to monitor the
        // requested in-app update flow.
        var startUpdateRequest = appUpdateManager.StartUpdate(
            // The result returned by PlayAsyncOperation.GetResult().
            appUpdateInfoResult,
            // The AppUpdateOptions created defining the requested in-app update
            // and its parameters.
            appUpdateOptions);
        yield return startUpdateRequest;
    }

    //Nie wiem co sie tutaj dzieje ale buja
}
