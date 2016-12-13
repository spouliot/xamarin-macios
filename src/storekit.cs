//
// StoreKit.cs: This file describes the API that the generator will
// produce for StoreKit
//
// Authors:
//   Miguel de Icaza
//
// Copyright 2009, Novell, Inc.
// Copyright 2012 Xamarin Inc.
//
using XamCore.ObjCRuntime;
using XamCore.Foundation;
using XamCore.CoreFoundation;
using XamCore.StoreKit;
#if !MONOMAC
using XamCore.UIKit;
#endif
using System;

namespace XamCore.StoreKit {

	[Since(6,0)]
	[BaseType (typeof (NSObject))]
	partial interface SKDownload {
#if MONOMAC
		[Export ("state")]
		SKDownloadState DownloadState { get;  }

		[Export ("contentLength", ArgumentSemantic.Copy)]
		NSNumber ContentLength { get; }
#else
		[Export ("downloadState")]
		SKDownloadState DownloadState { get;  }
		
		[Export ("contentLength")]
		long ContentLength { get;  }
#endif

		[Export ("contentIdentifier")]
		string ContentIdentifier { get;  }

		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get;  }

		[Export ("contentVersion", ArgumentSemantic.Copy)]
		string ContentVersion { get;  }

		[Export ("error", ArgumentSemantic.Copy)]
		NSError Error { get;  }

		[Export ("progress")]
		float Progress { get;  } /* float, not CGFloat */

		[Export ("timeRemaining")]
		double TimeRemaining { get;  }

#if MONOMAC
		[Export ("contentURLForProductID:")]
		[Static]
		NSUrl GetContentUrlForProduct (string productId);

		[Export ("deleteContentForProductID:")]
		[Static]
		void DeleteContentForProduct (string productId);
#else
		[Export ("transaction")]
		SKPaymentTransaction Transaction { get;  }

		[Field ("SKDownloadTimeRemainingUnknown")]
		double TimeRemainingUnknown { get; }
#endif
	}

	[BaseType (typeof (NSObject))]
	partial interface SKPayment : NSMutableCopying {
		[Static]
		[Export("paymentWithProduct:")]
		SKPayment CreateFrom (SKProduct product);
#if !MONOMAC
		[Static]
		[Export ("paymentWithProductIdentifier:")]
		[Availability (Introduced = Platform.iOS_3_0, Deprecated = Platform.iOS_5_0, Message = "Use FromProduct(SKProduct) after fetching the list of available products from SKProductRequest instead")]
		SKPayment CreateFrom (string identifier);
#endif

		[Export ("productIdentifier", ArgumentSemantic.Copy)]
		string ProductIdentifier { get; }

		[Export ("requestData", ArgumentSemantic.Copy)]
		NSData RequestData { get; [NotImplemented ("Not available on SKPayment, only available on SKMutablePayment")] set;  }

		[Export ("quantity")]
		nint Quantity { get; }

		[Since (7,0), Mavericks]
		[Export ("applicationUsername", ArgumentSemantic.Copy)]
		string ApplicationUsername { get; }

#if !MONOMAC
		[iOS (8,3)]
		[Export ("simulatesAskToBuyInSandbox")]
		bool SimulatesAskToBuyInSandbox { get; [NotImplemented ("Not available on SKPayment, only available on SKMutablePayment")] set; }
#endif
	}

	[BaseType (typeof (SKPayment))]
	interface SKMutablePayment {
		[Static]
		[Export("paymentWithProduct:")]
		SKMutablePayment PaymentWithProduct (SKProduct product);

		[Static]
		[Export ("paymentWithProductIdentifier:")]
		[Availability (Introduced = Platform.iOS_3_0, Deprecated = Platform.iOS_5_0, Message = "Use PaymentWithProduct(SKProduct) after fetching the list of available products from SKProductRequest instead")]
		SKMutablePayment PaymentWithProduct (string identifier);

		[NullAllowed] // by default this property is null
		[Export ("productIdentifier", ArgumentSemantic.Copy)][New]
		string ProductIdentifier { get; set; }

		[Export ("quantity")][New]
		nint Quantity { get; set; }

		[NullAllowed] // by default this property is null
		[Export ("requestData", ArgumentSemantic.Copy)]
		[Override]
		NSData RequestData { get; set; }

		[Since (7,0), Mavericks]
		[NullAllowed] // by default this property is null
		[Export ("applicationUsername", ArgumentSemantic.Copy)][New]
		string ApplicationUsername { get; set; }

#if !MONOMAC
		[iOS (8,3)]
		[Export ("simulatesAskToBuyInSandbox")]
		bool SimulatesAskToBuyInSandbox { get; set; }
#endif
	}

	[BaseType (typeof (NSObject))]
	interface SKPaymentQueue {
		[Export ("defaultQueue")][Static]
		SKPaymentQueue DefaultQueue { get; }

		[Export ("canMakePayments")][Static]
		bool CanMakePayments { get; }

		[Export ("addPayment:")]
		void AddPayment (SKPayment payment);

		[Export ("restoreCompletedTransactions")]
		void RestoreCompletedTransactions ();

		[Since (7,0), Mavericks]
		[Export ("restoreCompletedTransactionsWithApplicationUsername:")]
		void RestoreCompletedTransactions ([NullAllowed] string username);

		[Export ("finishTransaction:")]
		void FinishTransaction (SKPaymentTransaction transaction);

		[Export ("addTransactionObserver:")]
		void AddTransactionObserver ([Protocolize]SKPaymentTransactionObserver observer);

		[Export ("removeTransactionObserver:")]
		void RemoveTransactionObserver ([Protocolize]SKPaymentTransactionObserver observer);

		[Export ("transactions")]
		SKPaymentTransaction [] Transactions { get; }

		//
		// iOS 6.0
		//
		[Since(6,0)]
		[Export ("startDownloads:")]
		void StartDownloads (SKDownload [] downloads);

		[Since(6,0)]
		[Export ("pauseDownloads:")]
		void PauseDownloads (SKDownload [] downloads);

		[Since(6,0)]
		[Export ("resumeDownloads:")]
		void ResumeDownloads (SKDownload [] downloads);

		[Since(6,0)]
		[Export ("cancelDownloads:")]
		void CancelDownloads (SKDownload [] downloads);


	}
	
	[BaseType (typeof (NSObject))]
	interface SKProduct {
		[Export ("localizedDescription")]
		string LocalizedDescription { get; }

		[Export ("localizedTitle")]
		string LocalizedTitle { get; }

		[Export ("price")]
		NSDecimalNumber Price { get; }

		[Export ("priceLocale")]
		NSLocale PriceLocale { get; }

		[Export ("productIdentifier")]
		string ProductIdentifier { get; }

		[Since(6,0)]
		[Export ("downloadable")]
		bool Downloadable {
#if MONOMAC
			get;
#else
			[Bind ("isDownloadable")]
			get;
#endif
		}

		[Since(6,0)]
#if MONOMAC
		[Export ("contentLengths")]
#else
		[Export ("downloadContentLengths")]
#endif
		NSNumber [] DownloadContentLengths { get;  }

		[Since(6,0)]
#if MONOMAC
		[Export ("contentVersion")]
#else
		[Export ("downloadContentVersion")]
#endif
		string DownloadContentVersion { get;  }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface SKPaymentTransactionObserver {

		[Export ("paymentQueue:updatedTransactions:")][Abstract]
		void UpdatedTransactions (SKPaymentQueue queue, SKPaymentTransaction [] transactions);

		[Export ("paymentQueue:removedTransactions:")]
		void RemovedTransactions (SKPaymentQueue queue, SKPaymentTransaction [] transactions);

		[Export ("paymentQueue:restoreCompletedTransactionsFailedWithError:")]
		void RestoreCompletedTransactionsFailedWithError (SKPaymentQueue queue, NSError error);

		[Export ("paymentQueueRestoreCompletedTransactionsFinished:")]
		void RestoreCompletedTransactionsFinished (SKPaymentQueue queue);

		[Since(6,0)]
		[Export ("paymentQueue:updatedDownloads:")]
		void UpdatedDownloads (SKPaymentQueue queue, SKDownload [] downloads);
	}

	[BaseType (typeof (NSObject))]
	interface SKPaymentTransaction {
		[Export ("error")]
		NSError Error { get; }

		[Export ("originalTransaction")]
		SKPaymentTransaction OriginalTransaction { get; }

		[Export ("payment")]
		SKPayment Payment { get; } 

		[Export ("transactionDate")]
		NSDate TransactionDate { get; }

		[Export ("transactionIdentifier")]
		string TransactionIdentifier { get; }

#if !MONOMAC
		[Availability (Introduced = Platform.iOS_3_0, Deprecated = Platform.iOS_7_0, Message = "Use NSBundle.AppStoreReceiptUrl instead")]
		[Export ("transactionReceipt")]
		NSData TransactionReceipt { get; }
#endif

		[Export ("transactionState")]
		SKPaymentTransactionState TransactionState { get; }

		[Since(6,0)]
		[Export ("downloads")]
		SKDownload [] Downloads { get;  }
	}

	[BaseType (typeof (NSObject), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] {typeof (SKRequestDelegate)})]
	interface SKRequest {
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed]
		NSObject WeakDelegate { get; [NullAllowed] set; }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		SKRequestDelegate Delegate { get; [NullAllowed] set; }

		[Export ("cancel")]
		void Cancel ();

		[Export ("start")]
		void Start ();
	}

	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface SKRequestDelegate {
		[Export ("requestDidFinish:")]
		void RequestFinished (SKRequest request);
		
		[Export ("request:didFailWithError:"), EventArgs ("SKRequestError")]
		void RequestFailed (SKRequest request, NSError error);
	}
		
	[Since (7,0)]
	[Mac (10,9)]
	[BaseType (typeof (SKRequest))]
	interface SKReceiptRefreshRequest {
		[Export ("initWithReceiptProperties:")]
		IntPtr Constructor ([NullAllowed] NSDictionary properties);

		[Wrap ("this (receiptProperties == null ? null : receiptProperties.Dictionary)")]
		IntPtr Constructor ([NullAllowed] SKReceiptProperties receiptProperties);

		[Export ("receiptProperties")]
		NSDictionary WeakReceiptProperties { get; }

		[Wrap ("WeakReceiptProperties")]
		SKReceiptProperties ReceiptProperties { get; }
	}

	[Since (7,0)]
	[Mac (10,9)]
	[Static, Internal]
	interface _SKReceiptProperty {
		[Field ("SKReceiptPropertyIsExpired"), Internal]
		NSString IsExpired { get; }

		[Field ("SKReceiptPropertyIsRevoked"), Internal]
		NSString IsRevoked { get; }

		[Field ("SKReceiptPropertyIsVolumePurchase"), Internal]
		NSString IsVolumePurchase { get; }
	}

	[BaseType (typeof (SKRequest), Delegates=new string [] {"WeakDelegate"}, Events=new Type [] {typeof (SKProductsRequestDelegate)})]
	interface SKProductsRequest {
		[Export ("initWithProductIdentifiers:")]
		IntPtr Constructor (NSSet productIdentifiersStringSet);
		
		[Export ("delegate", ArgumentSemantic.Assign)][NullAllowed][New]
		NSObject WeakDelegate { get; [NullAllowed] set; }

		[Wrap ("WeakDelegate")][New]
		[Protocolize]
		SKProductsRequestDelegate Delegate { get; [NullAllowed] set; }
	}
	
	[BaseType (typeof (NSObject))]
	interface SKProductsResponse {
		[Export ("products")]
		SKProduct [] Products { get; }

		[Export ("invalidProductIdentifiers")]
		string [] InvalidProducts { get; }
	}

	[BaseType (typeof (SKRequestDelegate))]
	[Model]
	[Protocol]
	interface SKProductsRequestDelegate {
		[Export ("productsRequest:didReceiveResponse:")][Abstract][EventArgs ("SKProductsRequestResponse")]
		void ReceivedResponse (SKProductsRequest request, SKProductsResponse response);
	}

#if !MONOMAC
	[NoTV]
	[Since (6,0)]
	[BaseType (typeof (UIViewController),
		   Delegates=new string [] { "WeakDelegate" },
		   Events   =new Type   [] { typeof (SKStoreProductViewControllerDelegate) })]
	interface SKStoreProductViewController {
#if !XAMCORE_4_0
		// SKStoreProductViewController is an OS View Controller which can't be customized
		[Export ("initWithNibName:bundle:")]
		[PostGet ("NibBundle")]
		IntPtr Constructor ([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);
#endif

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set;  }

		[Wrap ("WeakDelegate")]
		[Protocolize]
		SKStoreProductViewControllerDelegate Delegate { get; set; }

		[Export ("loadProductWithParameters:completionBlock:")][Internal]
		[Async]
		void LoadProduct (NSDictionary parameters, [NullAllowed] Action<bool,NSError> callback);

		[Wrap ("LoadProduct (parameters == null ? null : parameters.Dictionary, callback)")]
		[Async]
		void LoadProduct (StoreProductParameters parameters, [NullAllowed] Action<bool,NSError> callback);
	}

	[Since (6,0)]
	[Static]
	interface SKStoreProductParameterKey
	{
		[Field ("SKStoreProductParameterITunesItemIdentifier")]
		NSString ITunesItemIdentifier { get; }

		[iOS (8,0)]
		[Field ("SKStoreProductParameterAffiliateToken")]
		NSString AffiliateToken { get; }

		[iOS (8,0)]
		[Field ("SKStoreProductParameterCampaignToken")]
		NSString CampaignToken { get; }

		[iOS (8,3)]
		[Field ("SKStoreProductParameterProviderToken")]
		NSString ProviderToken { get; }

		[iOS (9,3)]
		[TV (9,2)]
		[Field ("SKStoreProductParameterAdvertisingPartnerToken")]
		NSString AdvertisingPartnerToken { get; }
	}

	[NoTV]
	[BaseType (typeof (NSObject))]
	[Model]
	[Protocol]
	interface SKStoreProductViewControllerDelegate {
		[Export ("productViewControllerDidFinish:"), EventArgs ("SKStoreProductViewController")]
		void Finished (SKStoreProductViewController controller);
	}

	[iOS (9,3)]
	[TV (9,2)]
	[BaseType (typeof (NSObject))]
#if XAMCORE_3_0 // Avoid breaking change in iOS
	[DisableDefaultCtor]
#endif
	interface SKCloudServiceController {
		[Static]
		[Export ("authorizationStatus")]
		SKCloudServiceAuthorizationStatus AuthorizationStatus { get; }

		[Static]
		[Async]
		[Export ("requestAuthorization:")]
		void RequestAuthorization (Action<SKCloudServiceAuthorizationStatus> handler);

		[Async]
		[Export ("requestStorefrontIdentifierWithCompletionHandler:")]
		void RequestStorefrontIdentifier (Action<NSString, NSError> completionHandler);

		[Async]
		[Export ("requestCapabilitiesWithCompletionHandler:")]
		void RequestCapabilities (Action<SKCloudServiceCapability, NSError> completionHandler);

		[Notification]
		[Field ("SKStorefrontIdentifierDidChangeNotification")]
		NSString StorefrontIdentifierDidChangeNotification { get; }

		[Notification]
		[Field ("SKCloudServiceCapabilitiesDidChangeNotification")]
		NSString CloudServiceCapabilitiesDidChangeNotification { get; }
	}

	[iOS (10,1)]
	[NoTV] // __TVOS_PROHIBITED
	[BaseType (typeof(UIViewController))]
	interface SKCloudServiceSetupViewController
	{
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		ISKCloudServiceSetupViewControllerDelegate Delegate { get; set; }

		[Async]
		[Export ("loadWithOptions:completionHandler:")]
		void Load (NSDictionary options, [NullAllowed] Action<bool, NSError> completionHandler);

		[Async]
		[Wrap ("Load (options == null ? null : options.Dictionary, completionHandler)")]
		void Load (SKCloudServiceSetupOptions options, Action<bool, NSError> completionHandler);
	}

	interface ISKCloudServiceSetupViewControllerDelegate {}

	[iOS (10,1)]
	[NoTV] // __TVOS_PROHIBITED on the only member + SKCloudServiceSetupViewController is not in tvOS
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface SKCloudServiceSetupViewControllerDelegate
	{
		[Export ("cloudServiceSetupViewControllerDidDismiss:")]
		void DidDismiss (SKCloudServiceSetupViewController cloudServiceSetupViewController);
	}

	[NoTV, iOS (10,1)]
	[StrongDictionary ("SKCloudServiceSetupOptionsKeys")]
	interface SKCloudServiceSetupOptions
	{
		// Headers comment: Action for setup entry point (of type SKCloudServiceSetupAction).
		SKCloudServiceSetupAction Action { get; set; }

		// Headers comment: Identifier of the iTunes Store item the user is trying to access which requires cloud service setup (NSNumber).
		nint ITunesItemIdentifier { get; set; }
	}

	[NoTV, iOS (10,1)]
	[Internal, Static]
	interface SKCloudServiceSetupOptionsKeys
	{
		[Field ("SKCloudServiceSetupOptionsActionKey")]
		NSString ActionKey { get; }

		[Field ("SKCloudServiceSetupOptionsITunesItemIdentifierKey")]
		NSString ITunesItemIdentifierKey { get; }
	}

	[NoTV, iOS (10,1)]
	enum SKCloudServiceSetupAction
	{
		[Field ("SKCloudServiceSetupActionSubscribe")]
		Subscribe,
	}
#endif
}
