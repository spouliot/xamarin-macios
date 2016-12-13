﻿//
// WatchConnectivity bindings
//
// Authors:
//	Alex Soto  <alex.soto@xamarin.com>
//
// Copyright 2015 Xamarin Inc. All rights reserved.
//

using System;
using System.ComponentModel;
using XamCore.ObjCRuntime;
using XamCore.Foundation;

namespace XamCore.WatchConnectivity {

	delegate void WCSessionReplyHandler (NSDictionary<NSString, NSObject> replyMessage);
	delegate void WCSessionReplyDataHandler (NSData replyMessage);

	[iOS (9,0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor]
	interface WCSession {

		[Static]
		[Export ("isSupported")]
		bool IsSupported { get; }

		[Static]
		[Export ("defaultSession")]
		WCSession DefaultSession { get; }

		[Export ("delegate", ArgumentSemantic.Weak)][NullAllowed]
		IWCSessionDelegate Delegate { get; set; }

		[Export ("activateSession")]
		void ActivateSession ();

#if !WATCH
		[Export ("paired")]
		bool Paired { [Bind ("isPaired")] get; }

		[Export ("watchAppInstalled")]
		bool WatchAppInstalled { [Bind ("isWatchAppInstalled")] get; }

		[Export ("complicationEnabled")]
		bool ComplicationEnabled { [Bind ("isComplicationEnabled")] get; }

		[Export ("watchDirectoryURL")]
		NSUrl WatchDirectoryUrl { get; }
#endif

		[Export ("reachable")]
		bool Reachable { [Bind ("isReachable")] get; }

		[NoiOS]
		[Export ("iOSDeviceNeedsUnlockAfterRebootForReachability")]
		bool iOSDeviceNeedsUnlockAfterRebootForReachability { get; }

		[Export ("sendMessage:replyHandler:errorHandler:")]
		void SendMessage (NSDictionary<NSString, NSObject> message, [NullAllowed] WCSessionReplyHandler replyHandler, [NullAllowed] Action<NSError> errorHandler);

		[Export ("sendMessageData:replyHandler:errorHandler:")]
		void SendMessage (NSData data, [NullAllowed] WCSessionReplyDataHandler replyHandler, [NullAllowed] Action<NSError> errorHandler);

		[Export ("applicationContext", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ApplicationContext { get; }

		[Export ("updateApplicationContext:error:")]
		bool UpdateApplicationContext (NSDictionary<NSString, NSObject> applicationContext, out NSError error);

		[Export ("receivedApplicationContext", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> ReceivedApplicationContext { get; }

		[Export ("transferUserInfo:")]
		WCSessionUserInfoTransfer TransferUserInfo (NSDictionary<NSString, NSObject> userInfo);

#if !WATCH
		[Export ("transferCurrentComplicationUserInfo:")]
		WCSessionUserInfoTransfer TransferCurrentComplicationUserInfo (NSDictionary <NSString, NSObject>userInfo);
#endif

		[Export ("outstandingUserInfoTransfers", ArgumentSemantic.Copy)]
		WCSessionUserInfoTransfer [] OutstandingUserInfoTransfers { get; }

		[Export ("transferFile:metadata:")]
		WCSessionFileTransfer TransferFile (NSUrl file, [NullAllowed] NSDictionary<NSString, NSObject> metadata);

		[Export ("outstandingFileTransfers", ArgumentSemantic.Copy)]
		WCSessionFileTransfer [] OutstandingFileTransfers { get; }

		[Field ("WCErrorDomain")]
		NSString ErrorDomain { get; }

		[Watch (2,2)][iOS (9, 3)]
		[Export ("activationState")]
		WCSessionActivationState ActivationState { get; }

		[Watch (3,0)][iOS (10,0)]
		[Export ("hasContentPending")]
		bool HasContentPending { get; }

		[NoWatch][iOS (10,0)]
		[Export ("remainingComplicationUserInfoTransfers")]
		nuint RemainingComplicationUserInfoTransfers { get; }
	}

	interface IWCSessionDelegate { }

	[iOS (9,0)]
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface WCSessionDelegate {

#if !WATCH
		[Export ("sessionWatchStateDidChange:")]
		void SessionWatchStateDidChange (WCSession session);
#endif

		[Export ("sessionReachabilityDidChange:")]
		void SessionReachabilityDidChange (WCSession session);

		[Export ("session:didReceiveMessage:")]
		void DidReceiveMessage (WCSession session, NSDictionary<NSString, NSObject> message);

		[Export ("session:didReceiveMessage:replyHandler:")]
		void DidReceiveMessage (WCSession session, NSDictionary<NSString, NSObject> message, WCSessionReplyHandler replyHandler);

		[Export ("session:didReceiveMessageData:")]
		void DidReceiveMessageData (WCSession session, NSData messageData);

		[Export ("session:didReceiveMessageData:replyHandler:")]
		void DidReceiveMessageData (WCSession session, NSData messageData, WCSessionReplyDataHandler replyHandler);

		[Export ("session:didReceiveApplicationContext:")]
		void DidReceiveApplicationContext (WCSession session, NSDictionary<NSString, NSObject> applicationContext);

		[Export ("session:didFinishUserInfoTransfer:error:")]
		void DidFinishUserInfoTransfer (WCSession session, WCSessionUserInfoTransfer userInfoTransfer, [NullAllowed] NSError error);

		[Export ("session:didReceiveUserInfo:")]
		void DidReceiveUserInfo (WCSession session, NSDictionary<NSString, NSObject> userInfo);

		[Export ("session:didFinishFileTransfer:error:")]
		void DidFinishFileTransfer (WCSession session, WCSessionFileTransfer fileTransfer, NSError error);

		[Export ("session:didReceiveFile:")]
		void DidReceiveFile (WCSession session, WCSessionFile file);

#if XAMCORE_4_0
		[Abstract] // OS 10 beta 1 SDK made this required
#endif
		[Watch (2,2)][iOS (9,3)]
		[Export ("session:activationDidCompleteWithState:error:")]
		void ActivationDidComplete (WCSession session, WCSessionActivationState activationState, [NullAllowed] NSError error);

#if XAMCORE_4_0
		[Abstract] // OS 10 beta 1 SDK made this required
#endif
		[NoWatch][iOS (9,3)]
		[Export ("sessionDidBecomeInactive:")]
		void DidBecomeInactive (WCSession session);

#if XAMCORE_4_0
		[Abstract] // OS 10 beta 1 SDK made this required
#endif
		[NoWatch][iOS (9,3)]
		[Export ("sessionDidDeactivate:")]
		void DidDeactivate (WCSession session);
	}

	[iOS (9,0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // no handle, doc: You do not create instances of this class directly.
	interface WCSessionFile {

		[NullAllowed]
		[Export ("fileURL")]
		NSUrl FileUrl { get; }

		[NullAllowed]
		[Export ("metadata", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Metadata { get; }
	}

	[iOS (9,0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // no handle, doc: You do not create instances of this class yourself.
	interface WCSessionFileTransfer {

		[Export ("file")]
		WCSessionFile File { get; }

		[Export ("transferring")]
		bool Transferring { [Bind ("isTransferring")] get; }

		[Export ("cancel")]
		void Cancel ();
	}

	[iOS (9,0)]
	[BaseType (typeof (NSObject))]
	[DisableDefaultCtor] // no handle, doc: You do not create instances of this class yourself.
	interface WCSessionUserInfoTransfer : NSSecureCoding {

#if !WATCH
		[Export ("currentComplicationInfo")]
		bool CurrentComplicationInfo { [Bind ("isCurrentComplicationInfo")] get; }
#endif

		[Export ("userInfo", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> UserInfo { get; }

		[Export ("transferring")]
		bool Transferring { [Bind ("isTransferring")] get; }

		[Export ("cancel")]
		void Cancel ();
	}

}

