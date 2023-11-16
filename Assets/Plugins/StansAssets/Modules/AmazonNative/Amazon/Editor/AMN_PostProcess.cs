#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

public class AMN_PostProcess  {

#if UNITY_ANDROID
[PostProcessBuild(48)]
public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {

string file = SA.Common.Config.ANDROID_DESTANATION_PATH + "AndroidManifest.xml";
string Manifest = SA.Common.Util.Files.Read(file);
Manifest = Manifest.Replace("%APP_BUNDLE_ID%", PlayerSettings.bundleIdentifier);
SA.Common.Util.Files.Write(file, Manifest);
Debug.Log("AMN Post Process Done");

}
#endif

#if UNITY_IPHONE
	[PostProcessBuild(75)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {

		if (AmazonNativeSettings.Instance.IsGameCircleEnabled) {
			string AdSupportLibrary = "AdSupport.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(AdSupportLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = AdSupportLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string SystemConfigurationLibrary = "SystemConfiguration.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(SystemConfigurationLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = SystemConfigurationLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}
		}


		if (AmazonNativeSettings.Instance.IsAdvertisingEnabled) {
			string AdSupportLibrary = "AdSupport.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(AdSupportLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = AdSupportLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string CoreTelephonyLibrary = "CoreTelephony.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(CoreTelephonyLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = CoreTelephonyLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string EventKitUILibrary = "EventKitUI.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(EventKitUILibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = EventKitUILibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string EventKitLibrary = "EventKit.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(EventKitLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = EventKitLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string SystemConfigurationLibrary = "SystemConfiguration.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(SystemConfigurationLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = SystemConfigurationLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}

			string SafariServicesLibrary = "SafariServices.framework";
			if(!SA.IOSDeploy.ISD_Settings.Instance.ContainsFreamworkWithName(SafariServicesLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = SafariServicesLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.ISD_Settings.Instance.Frameworks.Add(F);
			}
		}

	}
#endif


}
#endif
