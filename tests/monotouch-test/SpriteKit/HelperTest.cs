using System;

using Foundation;
using SpriteKit;
using ObjCRuntime;

using NUnit.Framework;

namespace MonoTouchFixtures.SpriteKit {

	[TestFixture]
	[Preserve (AllMembers = true)]
	public class HelperTest {

		[Test]
		public void Half ()
		{
			TestRuntime.AssertXcodeVersion (11, 0);

			float f = 0;
			Assert.That (f.ToHalfFloat (), Is.EqualTo (0), "0");

			f = 3.14f;
			Assert.That (f.ToHalfFloat (), Is.EqualTo (1), "3.14");
		}
	}
}