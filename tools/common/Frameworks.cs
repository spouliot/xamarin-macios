using System;
using System.Collections.Generic;

using Mono.Cecil;

using Xamarin.Bundler;
using XamCore.Registrar;

public class Framework
{
	public string Namespace;
	public string Name;
	public Version Version;
}

public class Frameworks : Dictionary <string, Framework>
{
	public void Add (string @namespace, int major_version)
	{
		Add (@namespace, @namespace, major_version, 0, 0);
	}

	public void Add (string @namespace, string framework, int major_version)
	{
		Add (@namespace, framework, major_version, 0, 0);
	}

	public void Add (string @namespace, int major_version, int minor_version)
	{
		Add (@namespace, @namespace, major_version, minor_version, 0);
	}

	public void Add (string @namespace, string framework, int major_version, int minor_version)
	{
		Add(@namespace, framework, major_version, minor_version, 0);
	}

	public void Add (string @namespace, string framework, int major_version, int minor_version, int build_version)
	{
		var fr = new Framework () {
			Namespace = Driver.IsUnified ? @namespace : XamCore.Registrar.Registrar.CompatNamespace + "." + @namespace,
			Name = framework,
			Version = new Version (major_version, minor_version, build_version)
		};
		base.Add (fr.Namespace, fr);
	}

	public Framework Find (string framework)
	{
		foreach (var kvp in this)
			if (kvp.Value.Name == framework)
				return kvp.Value;
		return null;
	}

	static Frameworks mac_frameworks;
	public static Frameworks MacFrameworks {
		get {
			if (mac_frameworks == null) {
				mac_frameworks = new Frameworks () {
					{ "Accelerate", 10, 0 },
					{ "AppKit", 10, 0 },
					{ "CoreGraphics", "QuartzCore", 10, 0 },
					{ "CoreImage", "QuartzCore", 10, 0 },
					{ "Foundation", 10, 0 },
					{ "ImageKit", "Quartz", 10, 0 },
					{ "PdfKit", "Quartz", 10, 0 },
					{ "Security", 10, 0 },

					{ "AudioUnit", 10, 2 },
					{ "CoreMidi", "CoreMIDI", 10, 2 },
					{ "WebKit", 10, 2},

					{ "AudioToolbox", 10, 3 },
					{ "CoreServices", 10, 3 },
					{ "CoreVideo", 10, 3 },
					{ "MobileCoreServices", "CoreServices", 10, 3 },
					{ "OpenGL", 10, 3 },
					{ "SystemConfiguration", 10, 3 },

					{ "CoreData", 10, 4 },
					{ "ImageIO", 10, 4 },
					{ "OpenAL", 10, 4 },

					{ "CoreAnimation", "QuartzCore", 10, 5 },
					{ "CoreText", 10, 5 },
					{ "ScriptingBridge", 10, 5 },
					{ "QuickLook", 10, 5 },
					{ "QuartzComposer", "Quartz", 10, 5 },

					{ "QTKit", 10, 6 },
					{ "QuickLookUI", "Quartz", 10, 6 },

					{ "MediaToolbox", 10, 9 },
					{ "AVFoundation", 10, 7 },
					{ "CoreBluetooth", "IOBluetooth", 10, 7 },
					{ "CoreLocation", 10, 7 },
					{ "CoreMedia", 10, 7 },
					{ "CoreWlan", "CoreWLAN", 10, 7 },
					{ "StoreKit", 10, 7 },

					{ "Accounts", 10, 8 },
					{ "AudioVideoBridging", 10, 8 },
					{ "EventKit", 10, 8 },
					{ "GameKit", 10, 8 },
					{ "GLKit", 10, 8 },
					{ "SceneKit", 10, 8 },
					{ "Social", 10, 8 },
					{ "VideoToolbox", 10, 8 },

					{ "AVKit", 10, 9 },
					{ "GameController", 10, 9 },
					{ "ITunesLibrary", "iTunesLibrary", 10, 9 },
					{ "MapKit", 10, 9 },
					{ "MediaAccessibility", 10, 9 },
					{ "MediaLibrary", 10, 9 },
					{ "SpriteKit", 10, 9 },
					{ "JavaScriptCore", "JavaScriptCore", 10, 9 },

					{ "CloudKit", 10, 10 },
					{ "CryptoTokenKit", 10, 10 },
					{ "FinderSync", 10, 10 },
					{ "Hypervisor", 10, 10 },
					{ "LocalAuthentication", 10, 10 },
					{ "MultipeerConnectivity", 10, 10 },
					{ "NotificationCenter", 10, 10 },
					{ "GameplayKit", 10, 11 },
					{ "Contacts", 10, 11 },
					{ "Metal", 10, 11 },
					{ "MetalKit", 10, 11 },
					{ "ModelIO", 10, 11 },

					{ "Intents", 10, 12 },
					{ "SafariServices", "SafariServices", 10, 12 },
					{ "MediaPlayer", "MediaPlayer", 10, 12, 1 },
				};
			}
			return mac_frameworks;
		}
	}

	static Frameworks ios_frameworks;
	public static Frameworks iOSFrameworks {
		get {
			if (ios_frameworks == null) {
				ios_frameworks = new Frameworks () {
					{ "AddressBook",  "AddressBook", 3 },
					{ "Security", "Security", 3 },
					{ "AudioUnit", "AudioToolbox", 3 },
					{ "AddressBookUI", "AddressBookUI", 3 },
					{ "AudioToolbox", "AudioToolbox", 3 },
					{ "AVFoundation", "AVFoundation", 3 },
					{ "CoreAnimation", "QuartzCore", 3 },
					{ "CoreData", "CoreData", 3 },
					{ "CoreGraphics", "CoreGraphics", 3 },
					{ "CoreLocation", "CoreLocation", 3 },
					{ "ExternalAccessory", "ExternalAccessory", 3 },
					{ "Foundation", "Foundation", 3 },
					{ "GameKit", "GameKit", 3 },
					{ "MapKit", "MapKit", 3 },
					{ "MediaPlayer", "MediaPlayer", 3 },
					{ "MessageUI", "MessageUI", 3 },
					{ "MobileCoreServices", "MobileCoreServices", 3 },
					{ "StoreKit", "StoreKit", 3 },
					{ "SystemConfiguration", "SystemConfiguration", 3 },
					{ "OpenGLES", "OpenGLES", 3 },
					{ "UIKit", "UIKit", 3 },

					{ "Accelerate", "Accelerate", 4 },
					{ "EventKit", "EventKit", 4 },
					{ "EventKitUI", "EventKitUI", 4 },
					{ "CoreMotion", "CoreMotion", 4 },
					{ "CoreMedia", "CoreMedia", 4 },
					{ "CoreVideo", "CoreVideo", 4 },
					{ "CoreTelephony", "CoreTelephony", 4 },
					{ "iAd", "iAd", 4 },
					{ "QuickLook", "QuickLook", 4 },
					{ "ImageIO", "ImageIO", 4 },
					{ "AssetsLibrary", "AssetsLibrary", 4 },
					{ "CoreText", "CoreText", 4 },
					{ "CoreMidi", "CoreMIDI", 4 },

					{ "Accounts", "Accounts", 5 },
					{ "GLKit", "GLKit", 5 },
					{ "NewsstandKit", "NewsstandKit", 5 },
					{ "CoreImage", "CoreImage", 5 },
					{ "CoreBluetooth", "CoreBluetooth", 5 },
					{ "Twitter", "Twitter", 5 },

					{ "MediaToolbox", "MediaToolbox", 6 },
					{ "PassKit", "PassKit", 6 },
					{ "Social", "Social", 6 },
					{ "AdSupport", "AdSupport", 6 },

					{ "GameController", "GameController", 7 },
					{ "JavaScriptCore", "JavaScriptCore", 7 },
					{ "MediaAccessibility", "MediaAccessibility", 7 },
					{ "MultipeerConnectivity", "MultipeerConnectivity", 7 },
					{ "SafariServices", "SafariServices", 7 },
					{ "SpriteKit", "SpriteKit", 7 },

					{ "HealthKit", "HealthKit", 8 },
					{ "HomeKit", "HomeKit", 8 },
					{ "LocalAuthentication", "LocalAuthentication", 8 },
					{ "NotificationCenter", "NotificationCenter", 8 },
					{ "PushKit", "PushKit", 8 },
					{ "Photos", "Photos", 8 },
					{ "PhotosUI", "PhotosUI", 8 },
					{ "SceneKit", "SceneKit", 8 },
					{ "CloudKit", "CloudKit", 8 },
					{ "AVKit", "AVKit", 8 },
					{ "CoreAudioKit", "CoreAudioKit", 8 },
					{ "Metal", "Metal", 8 },
					{ "WebKit", "WebKit", 8 },
					{ "NetworkExtension", "NetworkExtension", 8 },
					{ "VideoToolbox", "VideoToolbox", 8 },
					{ "WatchKit", "WatchKit", 8,2 },
					
					{ "ReplayKit", "ReplayKit", 9 },
					{ "Contacts", "Contacts", 9 },
					{ "ContactsUI", "ContactsUI", 9 },
					{ "CoreSpotlight", "CoreSpotlight", 9 },
					{ "WatchConnectivity", "WatchConnectivity", 9 },
					{ "ModelIO", "ModelIO", 9 },
					{ "MetalKit", "MetalKit", 9 },
					{ "MetalPerformanceShaders", "MetalPerformanceShaders", 9 },
					{ "GameplayKit", "GameplayKit", 9 },
					{ "HealthKitUI", "HealthKitUI", 9,3 },

					{ "CallKit", "CallKit", 10 },
					{ "Messages", "Messages", 10 },
					{ "Speech", "Speech", 10 },
					{ "VideoSubscriberAccount", "VideoSubscriberAccount", 10 },
					{ "UserNotifications", "UserNotifications", 10 },
					{ "UserNotificationsUI", "UserNotificationsUI", 10 },
					{ "Intents", "Intents", 10 },
					{ "IntentsUI", "IntentsUI", 10 },
				};
			}
			return ios_frameworks;
		}
	}

	static Frameworks watch_frameworks;
	public static Frameworks WatchFrameworks {
		get {
			if (watch_frameworks == null) {
				watch_frameworks = new Frameworks {
					// The CFNetwork framework is in the SDK, but there are no headers inside the framework, so don't enable yet.
					// { "CFNetwork", "CFNetwork", 2 },
					{ "ClockKit", "ClockKit", 2 },
					{ "Contacts", "Contacts", 2 },
					{ "CoreData", "CoreData", 2 },
					{ "CoreFoundation", "CoreFoundation", 2 },
					{ "CoreGraphics", "CoreGraphics", 2 },
					{ "CoreLocation", "CoreLocation", 2 },
					{ "CoreMotion", "CoreMotion", 2 },
					{ "EventKit", "EventKit", 2 },
					{ "Foundation", "Foundation", 2 },
					{ "HealthKit", "HealthKit", 2 },
					{ "HomeKit", "HomeKit", 2 },
					{ "ImageIO", "ImageIO", 2 },
					{ "MapKit", "MapKit", 2 },
					{ "MobileCoreServices", "MobileCoreServices", 2 },
					{ "PassKit", "PassKit", 2 },
					{ "Security", "Security", 2 },
					{ "UIKit", "UIKit", 2 },
					{ "WatchConnectivity", "WatchConnectivity", 2 },
					{ "WatchKit", "WatchKit", 2 },

					//{ "AVFoundation", "AVFoundation", 3 },
					{ "CloudKit", "CloudKit", 3 },
					{ "GameKit", "GameKit", 3 },
					{ "SceneKit", "SceneKit", 3 },
					{ "SpriteKit", "SpriteKit", 3 },
					{ "UserNotifications", "UserNotifications", 3 },
				};
			}
			return watch_frameworks;
		}
	}

	static Frameworks tvos_frameworks;
	public static Frameworks TVOSFrameworks {
		get {
			if (tvos_frameworks == null) {
				tvos_frameworks = new Frameworks () {
					{ "AVFoundation", "AVFoundation", 9 },
					{ "AVKit", "AVKit", 9 },
					{ "Accelerate", "Accelerate", 9 },
					{ "AdSupport", "AdSupport", 9 },
					{ "AudioToolbox", "AudioToolbox", 9 },
					{ "AudioUnit", "AudioToolbox", 9 },
					{ "CFNetwork", "CFNetwork", 9 },
					{ "CloudKit", "CloudKit", 9 },
					{ "CoreAnimation", "QuartzCore", 9 },
					{ "CoreAudio", "CoreAudio", 9 },
					{ "CoreBluetooth", "CoreBluetooth", 9 },
					{ "CoreData", "CoreData", 9 },
					{ "CoreGraphics", "CoreGraphics", 9 },
					{ "CoreImage", "CoreImage", 9 },
					{ "CoreLocation", "CoreLocation", 9 },
					{ "CoreMedia", "CoreMedia", 9 },
					{ "CoreText", "CoreText", 9 },
					{ "CoreVideo", "CoreVideo", 9 },
					{ "Foundation", "Foundation", 9 },
					{ "GLKit", "GLKit", 9 },
					{ "GameController", "GameController", 9 },
					{ "GameKit", "GameKit", 9 },
					{ "GameplayKit", "GameplayKit", 9 },
					{ "ImageIO", "ImageIO", 9 },
					{ "JavaScriptCore", "JavaScriptCore", 9 },
					{ "MediaAccessibility", "MediaAccessibility", 9 },
					{ "MediaPlayer", "MediaPlayer", 9 },
					{ "Metal", "Metal", 9 },
					{ "MetalKit", "MetalKit", 9 },
					{ "MetalPerformanceShaders", "MetalPerformanceShaders", 9 },
					{ "MobileCoreServices", "MobileCoreServices", 9 },
					{ "ModelIO", "ModelIO", 9 },
					{ "OpenGLES", "OpenGLES", 9 },
					{ "SceneKit", "SceneKit", 9 },
					{ "Security", "Security", 9 },
					{ "SpriteKit", "SpriteKit", 9 },
					{ "StoreKit", "StoreKit", 9 },
					{ "SystemConfiguration", "SystemConfiguration", 9 },
					{ "TVMLKit", "TVMLKit", 9 },
					{ "TVServices", "TVServices", 9 },
					{ "UIKit", "UIKit", 9 },

					{ "MapKit", "MapKit", 9, 2 },

					{ "ExternalAccessory", "ExternalAccessory", 10 },
					{ "HomeKit", "HomeKit", 10 },
					{ "MultipeerConnectivity", 10 },
					{ "Photos", "Photos", 10 },
					{ "PhotosUI", "PhotosUI", 10 },
					{ "ReplayKit", "ReplayKit", 10 },
					{ "UserNotifications", "UserNotifications", 10 },
					{ "VideoSubscriberAccount", "VideoSubscriberAccount", 10 },
				};
			}
			return tvos_frameworks;
		}
	}

	public static void Gather (AssemblyDefinition product_assembly, HashSet<string> frameworks, HashSet<string> weak_frameworks)
	{
		var namespaces = new HashSet<string> ();

		// Collect all the namespaces.
		foreach (ModuleDefinition md in product_assembly.Modules)
			foreach (TypeDefinition td in md.Types)
				namespaces.Add (td.Namespace);

		// Iterate over all the namespaces and check which frameworks we need to link with.
		foreach (var nspace in namespaces) {
			Framework framework;
			if (Driver.Frameworks.TryGetValue (nspace, out framework)) {
				if (Driver.SDKVersion >= framework.Version) {
					var add_to = Driver.MinOSVersion >= framework.Version ? frameworks : weak_frameworks;
					add_to.Add (framework.Name);
					continue;
				}
			}
		}
	}

}
