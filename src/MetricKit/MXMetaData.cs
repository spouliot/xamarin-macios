#if IOS && !__MACCATALYST__
using System;

using Foundation;
using ObjCRuntime;
using UIKit;

namespace MetricKit {

	public partial class MXMetaData {

		public virtual NSDictionary DictionaryRepresentation {
			get {
				if (UIDevice.CurrentDevice.CheckSystemVersion (14,0))
					return _DictionaryRepresentation14;
				else
					return _DictionaryRepresentation13;
			}
		}
	}
}
#endif
