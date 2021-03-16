﻿// Copyright 2017 Microsoft Inc. All rights reserved.

#if !__WATCHOS__

using System;
using Foundation;
using ObjCRuntime;

using Metal;
using MetalPerformanceShaders;

using NUnit.Framework;

namespace MonoTouchFixtures.MetalPerformanceShaders
{

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class MPSImageHistogramSpecificationTest
	{
		IMTLDevice device;

		[OneTimeSetUp]
		public void Metal ()
		{
#if !MONOMAC
			TestRuntime.AssertXcodeVersion (7, 0);

			if (Runtime.Arch == Arch.SIMULATOR)
				Assert.Inconclusive ("Metal Performance Shaders is not supported in the simulator");
#else
			TestRuntime.AssertXcodeVersion (9, 0);
#endif

			device = MTLDevice.SystemDefault;
			// some older hardware won't have a default
			if (device == null || !MPSKernel.Supports (device))
				Assert.Inconclusive ("Metal is not supported");
		}

		[Test]
		public void Constructors ()
		{
			MPSImageHistogramInfo info = new MPSImageHistogramInfo ();
			info.NumberOfHistogramEntries = 256;
			using (var obj = new MPSImageHistogramSpecification (MTLDevice.SystemDefault, ref info)) {
				var rv = obj.HistogramInfo;
				Asserts.AreEqual (info, rv, "HistogramForAlpha");
			}
		}
	}
}

#endif // !__WATCHOS__
