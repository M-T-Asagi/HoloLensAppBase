﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SpectatorView
{
    [CustomEditor(typeof(SpectatorView.SpectatorViewManager))]
    public class SpectatorViewManagerEditor : Editor
    {
        bool CheckCredentials()
        {
            return (BuildDeployPrefs.DeviceUser.Trim() != "" && BuildDeployPrefs.DevicePassword.Trim() != "");
        }

        string BuildIPsList()
        {
            string ipCSV = SpectatorViewManager.Instance.ClientHololensCSV;
            string[] ipArray = ipCSV.Split(new char[','], System.StringSplitOptions.RemoveEmptyEntries);

            List<string> ipList = new List<string>();
            foreach (string ip in ipArray)
            {
                ipList.Add(ip.Trim());
            }

            string spectatorViewIP = SpectatorViewManager.Instance.SpectatorViewIP.Trim();
            if (spectatorViewIP != string.Empty && !ipList.Contains(spectatorViewIP))
            {
                ipList.Add(spectatorViewIP);
            }

            ipCSV = string.Empty;
            for (int i = 0; i < ipList.Count; i++)
            {
                ipCSV += ipList[i].Trim();

                if (i < ipList.Count - 1)
                {
                    ipCSV += ",";
                }
            }

            return ipCSV;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            {
                GUILayout.Label("Update IP");

                SpectatorView.SpectatorViewManager svm = (SpectatorView.SpectatorViewManager)target;
                if (GUILayout.Button("Update Spectator View IP"))
                {
                    svm.UpdateSpectatorViewIP();
                }
            }
            EditorGUILayout.EndVertical();

            GUILayout.Space(5);
            EditorGUILayout.BeginVertical("Box");
            {
                GUILayout.Label("App Management");

                if (GUILayout.Button("Open Build Window"))
                {
                    BuildDeployWindow.OpenWindow();
                }

                GUILayout.Space(5);

                if (GUILayout.Button("Build & Deploy Apps"))
                {
                    if (!CheckCredentials())
                    {
                        Debug.LogError("Username and password must be set.");
                        BuildDeployWindow.OpenWindow();
                        return;
                    }

                    BuildDeployPrefs.TargetIPs = BuildIPsList();

                    BuildDeployWindow buildWindow = BuildDeployWindow.GetBuildWindow();
                    buildWindow.BuildAndRun(PlayerSettings.productName);
                }

                if (GUILayout.Button("Deploy Apps"))
                {
                    if (!CheckCredentials())
                    {
                        Debug.LogError("Username and password must be set.");
                        BuildDeployWindow.OpenWindow();
                        return;
                    }

                    BuildDeployPrefs.TargetIPs = BuildIPsList();

                    BuildDeployWindow buildWindow = BuildDeployWindow.GetBuildWindow();
                    buildWindow.Install();
                }

                if (GUILayout.Button("Start Apps"))
                {
                    if (!CheckCredentials())
                    {
                        Debug.LogError("Username and password must be set.");
                        BuildDeployWindow.OpenWindow();
                        return;
                    }

                    BuildDeployWindow buildWindow = BuildDeployWindow.GetBuildWindow();
                    string ips = BuildIPsList();

                    // Always kill first so that we have a clean state
                    buildWindow.KillAppOnIPs(ips);
                    buildWindow.LaunchAppOnIPs(ips);
                }

                if (GUILayout.Button("Terminate Apps"))
                {
                    if (!CheckCredentials())
                    {
                        Debug.LogError("Username and password must be set.");
                        BuildDeployWindow.OpenWindow();
                        return;
                    }

                    BuildDeployWindow buildWindow = BuildDeployWindow.GetBuildWindow();
                    buildWindow.KillAppOnIPs(BuildIPsList());
                }
            }
            EditorGUILayout.EndVertical();
        }
    }
}
