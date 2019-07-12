// Copyright 2019 Microsoft Corporation

using System.Runtime.InteropServices;
using ObjCRuntime;

namespace SpriteKit {

	[iOS (13,0)][TV (13,0)][Watch (6,0)][Mac (10,15, onlyOn64: true)]
	static public class SKHelper {

		[DllImport (Constants.SpriteKitLibrary)]
		static extern ushort floatToHalfFloat (float f);

		static public ushort ToHalfFloat (this float self)
		{
			return floatToHalfFloat (self);
		}
	}
}