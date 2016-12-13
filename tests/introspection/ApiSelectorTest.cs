//
// Test the generated API selectors against typos or non-existing cases
//
// Authors:
//	Sebastien Pouliot  <sebastien@xamarin.com>
//
// Copyright 2012-2013 Xamarin Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Reflection;
using NUnit.Framework;

#if XAMCORE_2_0
using Foundation;
using ObjCRuntime;
#elif MONOMAC
using MonoMac.Foundation;
using MonoMac.ObjCRuntime;
#else
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
#endif

namespace Introspection {

	public abstract class ApiSelectorTest : ApiBaseTest {
		
		// not everything should be even tried
		
		protected virtual bool Skip (Type type)
		{
			if (type.ContainsGenericParameters)
				return true;
			
			// skip delegate (and other protocol references)
			foreach (object ca in type.GetCustomAttributes (false)) {
				if (ca is ProtocolAttribute)
					return true;
				if (ca is ModelAttribute)
					return true;
			}
			return SkipDueToAttribute (type);
		}

		protected virtual bool Skip (Type type, string selectorName)
		{
#if !XAMCORE_2_0
			// old binding mistake
			if (selectorName == "subscribedCentrals")
				return true;
#else
			// The MapKit types/selectors are optional protocol members pulled in from MKAnnotation/MKOverlay.
			// These concrete (wrapper) subclasses do not implement all of those optional members, but we
			// still need to provide a binding for them, so that user subclasses can implement those members.
			switch (type.Name) {
			case "MKCircle":
			case "MKPolygon":
			case "MKPolyline":
				switch (selectorName) {
				case "canReplaceMapContent":
					return true;
				}
				break;
			case "MKShape":
				switch (selectorName) {
				case "setCoordinate:":
					return true;
				}
				break;
			case "MKPlacemark":
				switch (selectorName) {
				case "setCoordinate:":
				case "subtitle":
					return true;
				}
				break;
			case "MKTileOverlay":
				switch (selectorName) {
				case "intersectsMapRect:":
					return true;
				}
				break;
			// AVAudioChannelLayout and AVAudioFormat started conforming to NSSecureCoding in OSX 10.11 and iOS 9
			case "AVAudioChannelLayout":
			case "AVAudioFormat":
			// NSSecureCoding added in iOS 10 / macOS 10.12
			case "CNContactFetchRequest":
			case "GKEntity":
			case "GKPolygonObstacle":
			case "GKComponent":
			case "GKGraphNode":
			case "WKPreferences":
			case "WKUserContentController":
			case "WKProcessPool":
			case "WKWebViewConfiguration":
			case "WKWebsiteDataStore":
				switch (selectorName) {
				case "encodeWithCoder:":
					return true;
				}
				break;
			// SKTransition started conforming to NSCopying in OSX 10.11 and iOS 9
			case "SKTransition":
			// iOS 10 beta 2
			case "GKBehavior":
			case "MDLTransform":
				switch (selectorName) {
				case "copyWithZone:":
					return true;
				}
				break;
			case "MDLMaterialProperty":
				switch (selectorName) {
				case "copyWithZone:":
					// not working before iOS 10, macOS 10.12
					return !TestRuntime.CheckXcodeVersion (8, 0);
				}
				break;
			// Xcode 8 beta 2
			case "GKGraph":
			case "GKAgent":
			case "GKAgent2D":
			case "NEFlowMetaData":
			case "NWEndpoint":
				switch (selectorName) {
				case "copyWithZone:":
				case "encodeWithCoder:":
					return true;
				}
				break;
			// now conforms to MDLName
			case "MTKMeshBuffer":
				switch (selectorName) {
				case "name":
				case "setName:":
					return true;
				}
				break;
			}
#endif
			// This ctors needs to be manually bound
			switch (type.Name) {
			case "GKPath":
				switch (selectorName) {
				case "initWithPoints:count:radius:cyclical:":
				case "initWithFloat3Points:count:radius:cyclical:":
					return true;
				}
				break;
			case "GKPolygonObstacle":
				switch (selectorName) {
				case "initWithPoints:count:":
					return true;
				}
				break;
			case "MDLMesh":
				switch (selectorName) {
				case "initCapsuleWithExtent:cylinderSegments:hemisphereSegments:inwardNormals:geometryType:allocator:":
				case "initConeWithExtent:segments:inwardNormals:cap:geometryType:allocator:":
				case "initHemisphereWithExtent:segments:inwardNormals:cap:geometryType:allocator:":
				case "initMeshBySubdividingMesh:submeshIndex:subdivisionLevels:allocator:":
				case "initSphereWithExtent:segments:inwardNormals:geometryType:allocator:":
					return true;
				}
				break;
			case "MDLNoiseTexture":
				switch (selectorName) {
				case "initCellularNoiseWithFrequency:name:textureDimensions:channelEncoding:":
				case "initVectorNoiseWithSmoothness:name:textureDimensions:channelEncoding:":
					return true;
				}
				break;
			case "NSImage":
				switch (selectorName) {
				case "initByReferencingFile:":
					return true;
				}
				break;
			// Conform to SKWarpable
			case "SKEffectNode":
			case "SKSpriteNode":
				switch (selectorName) {
				case "setSubdivisionLevels:":
				case "setWarpGeometry:":
					return true;
				}
				break;
			case "SKUniform":
				switch (selectorName) {
				// New selectors
				case "initWithName:vectorFloat2:":
				case "initWithName:vectorFloat3:":
				case "initWithName:vectorFloat4:":
				case "initWithName:matrixFloat2x2:":
				case "initWithName:matrixFloat3x3:":
				case "initWithName:matrixFloat4x4:":
				// Old selectors
				case "initWithName:floatVector2:":
				case "initWithName:floatVector3:":
				case "initWithName:floatVector4:":
				case "initWithName:floatMatrix2:":
				case "initWithName:floatMatrix3:":
				case "initWithName:floatMatrix4:":
					return true;
				}
				break;
			case "SKVideoNode":
				switch (selectorName) {
				case "initWithFileNamed:":
				case "initWithURL:":
				case "initWithVideoFileNamed:":
				case "initWithVideoURL:":
				case "videoNodeWithFileNamed:":
				case "videoNodeWithURL:":
					return true;
				}
				break;
			case "SKWarpGeometryGrid":
				switch (selectorName) {
				case "initWithColumns:rows:sourcePositions:destPositions:":
					return true;
				}
				break;
			case "INPriceRange":
				switch (selectorName) {
				case "initWithMaximumPrice:currencyCode:":
				case "initWithMinimumPrice:currencyCode:":
					return true;
				}
				break;
			case "CKUserIdentityLookupInfo":
				switch (selectorName) {
				case "initWithEmailAddress:":
				case "initWithPhoneNumber:":
				case "lookupInfosWithRecordIDs:": // FAILs on watch yet we do have a unittest for it
				case "lookupInfosWithEmails:": // FAILs on watch yet we do have a unittest for it
				case "lookupInfosWithPhoneNumbers:": // FAILs on watch yet we do have a unittest for it
					return true;
				}
				break;
			case "AVPlayerItemVideoOutput":
				switch (selectorName) {
				case "initWithOutputSettings:":
				case "initWithPixelBufferAttributes:":
					return true;
				}
				break;
			case "MTLBufferLayoutDescriptor": // We do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "stepFunction":
				case "setStepFunction:":
				case "stepRate":
				case "setStepRate:":
				case "stride":
				case "setStride:":
					return true;
				}
				break;
			case "MTLFunctionConstant": // we do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "name":
				case "type":
				case "index":
				case "required":
					return true;
				}
				break;
			case "MTLStageInputOutputDescriptor": // we do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "attributes":
				case "indexBufferIndex":
				case "setIndexBufferIndex:":
				case "indexType":
				case "setIndexType:":
				case "layouts":
					return true;
				}
				break;
			case "MTLAttributeDescriptor": // we do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "bufferIndex":
				case "setBufferIndex:":
				case "format":
				case "setFormat:":
				case "offset":
				case "setOffset:":
					return true;
				}
				break;
			case "MTLAttribute": // we do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "isActive":
				case "attributeIndex":
				case "attributeType":
				case "isPatchControlPointData":
				case "isPatchData":
				case "name":
				case "isDepthTexture":
					return true;
				}
				break;
			case "MTLArgument": // we do have unit tests under monotouch-tests for this properties
				switch (selectorName){
				case "isDepthTexture":
					return true;
				}
				break;
			}

			// old binding mistake
			return (selectorName == "initWithCoder:");
		}

		protected virtual bool CheckResponse (bool value, Type actualType, MethodBase method, ref string name)
		{
			if (value)
				return true;
			
			var mname = method.Name;
			// properties getter and setter will be methods in the _Extensions type
			if (method.IsSpecialName)
				mname = mname.Replace ("get_", "Get").Replace ("set_", "Set");

			// it's possible that the selector was inlined for an OPTIONAL protocol member
			// we do not want those reported (too many false positives) and we have other tests to find such mistakes
			foreach (var intf in actualType.GetInterfaces ()) {
				if (intf.GetCustomAttributes<ProtocolAttribute> () == null)
					continue;
				var ext = Type.GetType (intf.Namespace + "." + intf.Name.Remove (0, 1) + "_Extensions, " + intf.Assembly.FullName);
				if (ext == null)
					continue;
				foreach (var m in ext.GetMethods ()) {
					if (mname != m.Name)
						continue;
					var parameters = method.GetParameters ();
					var ext_params = m.GetParameters ();
					// first parameters is `this XXX This`
					if (parameters.Length == ext_params.Length - 1) {
						bool match = true;
						for (int i = 1; i < ext_params.Length; i++) {
							match |= (parameters [i - 1].ParameterType == ext_params [i].ParameterType);
						}
						if (match)
							return true;
					}
				}
			}
			
			name = actualType.FullName + " : " + name;
			return false;
		}
		
		static IntPtr responds_handle = Selector.GetHandle ("instancesRespondToSelector:");

		[Test]
		public void Protocols ()
		{
			Errors = 0;
			int n = 0;

			foreach (Type t in Assembly.GetTypes ()) {
				if (t.IsNested || !NSObjectType.IsAssignableFrom (t))
					continue;

				foreach (object ca in t.GetCustomAttributes (false)) {
					if (ca is ProtocolAttribute) {
						foreach (var c in t.GetConstructors (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)) {
							ProcessProtocolMember (t, c, ref n);
						}
						foreach (var m in t.GetMethods (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)) {
							ProcessProtocolMember (t, m, ref n);
						}
					}
				}
			}
			Assert.AreEqual (0, Errors, "{0} errors found in {1} protocol selectors validated", Errors, n);
		}

		void ProcessProtocolMember (Type t, MethodBase m, ref int n)
		{
			if (SkipDueToAttribute (m))
				return;

			foreach (object ca in m.GetCustomAttributes (true)) {
				ExportAttribute export = (ca as ExportAttribute);
				if (export == null)
					continue;

				string name = export.Selector;
				if (Skip (t, name))
					continue;

				CheckInit (t, m, name);
				n++;
			}
		}

		protected virtual IntPtr GetClassForType (Type type)
		{
			var fi = type.GetField ("class_ptr", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
			if (fi == null)
				return IntPtr.Zero; // e.g. *Delegate
			return (IntPtr) fi.GetValue (null);
		}

		[Test]
		public void InstanceMethods ()
		{
			Errors = 0;
			int n = 0;
			
			foreach (Type t in Assembly.GetTypes ()) {
				if (t.IsNested || !NSObjectType.IsAssignableFrom (t))
					continue;

				if (Skip (t) || SkipDueToAttribute (t))
					continue;
				
				IntPtr class_ptr = GetClassForType (t);

				if (class_ptr == IntPtr.Zero)
					continue;

				foreach (var c in t.GetConstructors (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)) {
					Process (class_ptr, t, c, ref n);
				}

				foreach (var m in t.GetMethods (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)) {
					Process (class_ptr, t, m, ref n);
				}
			}
			Assert.AreEqual (0, Errors, "{0} errors found in {1} instance selector validated", Errors, n);
		}

		void Process (IntPtr class_ptr, Type t, MethodBase m, ref int n)
		{
			if (m.DeclaringType != t || SkipDueToAttribute (m))
				return;

			foreach (object ca in m.GetCustomAttributes (true)) {
				ExportAttribute export = (ca as ExportAttribute);
				if (export == null)
					continue;

				string name = export.Selector;
				if (Skip (t, name))
					continue;

				CheckInit (t, m, name);

				bool result = bool_objc_msgSend_IntPtr (class_ptr, responds_handle, Selector.GetHandle (name));
				bool response = CheckResponse (result, t, m, ref name);
				if (!response)
					ReportError ("Selector not found for {0}", name);
				n++;
			}
		}

		void CheckInit (Type t, MethodBase m, string name)
		{
			if (SkipInit (name, m))
				return;

			bool init = IsInitLike (name);
			if (m is ConstructorInfo) {
				if (!init)
					ReportError ("Selector {0} used on a constructor (not a method) on {1}", name, t.FullName);
			} else {
				if (init)
					ReportError ("Selector {0} used on a method (not a constructor) on {1}", name, t.FullName);
			}
		}

		bool IsInitLike (string selector)
		{
			if (!selector.StartsWith ("init", StringComparison.OrdinalIgnoreCase))
				return false;
			return selector.Length < 5 || Char.IsUpper (selector [4]);
		}

		protected virtual bool SkipInit (string selector, MethodBase m)
		{
			switch (selector) {
			// NSAttributedString
			case "initWithHTML:documentAttributes:":
			case "initWithRTF:documentAttributes:":
			case "initWithRTFD:documentAttributes:":
			case "initWithURL:options:documentAttributes:error:":
			case "initWithFileURL:options:documentAttributes:error:":
			// AVAudioRecorder
			case "initWithURL:settings:error:":
			case "initWithURL:format:error:":
			// NSUrlProtectionSpace
			case "initWithHost:port:protocol:realm:authenticationMethod:":
			case "initWithProxyHost:port:type:realm:authenticationMethod:":
			// NSUserDefaults
			case "initWithSuiteName:":
			case "initWithUser:":
			// GKScore
			case "initWithCategory:":
			case "initWithLeaderboardIdentifier:":
			// MCSession
			case "initWithPeer:securityIdentity:encryptionPreference:":
			// INSetProfileInCarIntent and INSaveProfileInCarIntent
			case "initWithProfileNumber:profileName:defaultProfile:":
			case "initWithProfileNumber:profileLabel:defaultProfile:":
			case "initWithProfileNumber:profileName:":
			case "initWithProfileNumber:profileLabel:":
			// UISegmentedControl
			case "initWithItems:":
				var mi = m as MethodInfo;
				return mi != null && !mi.IsPublic && mi.ReturnType.Name == "IntPtr";
			default:
				return false;
			}
		}
		
		protected virtual void Dispose (NSObject obj, Type type)
		{
			obj.Dispose ();
		}
		
		// funny, this is how I envisioned the instance version... before hitting run :|
		protected virtual bool CheckStaticResponse (bool value, Type actualType, Type declaredType, ref string name)
		{
			if (value)
				return true;
			
			name = actualType.FullName + " : " + name;
			return false;
		}

		[Test]
		public void StaticMethods ()
		{
			Errors = 0;
			int n = 0;
			
			IntPtr responds_handle = Selector.GetHandle ("respondsToSelector:");
			
			foreach (Type t in Assembly.GetTypes ()) {
				if (t.IsNested || !NSObjectType.IsAssignableFrom (t))
					continue;

				if (Skip (t) || SkipDueToAttribute (t))
					continue;

				FieldInfo fi = t.GetField ("class_ptr", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
				if (fi == null)
					continue; // e.g. *Delegate
				IntPtr class_ptr = (IntPtr) fi.GetValue (null);
				
				foreach (var m in t.GetMethods (BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static)) {
					if (SkipDueToAttribute (m))
						continue;

					foreach (object ca in m.GetCustomAttributes (true)) {
						if (ca is ExportAttribute) {
							string name = (ca as ExportAttribute).Selector;

							if (Skip (t, name))
								continue;

							bool result = bool_objc_msgSend_IntPtr (class_ptr, responds_handle, Selector.GetHandle (name));
							bool response = CheckStaticResponse (result, t, m.DeclaringType, ref name);
							if (!response)
								ReportError (name);
							n++;
						}
					}
				}
			}
			Assert.AreEqual (0, Errors, "{0} errors found in {1} static selector validated", Errors, n);
		}
	}
}
