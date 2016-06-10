using NUnit.Framework;
using System;
using System.Linq;

namespace GISharp.GIRepository.Test
{
    [TestFixture]
    public class TestBaseInfo
    {
        InfoDictionary<BaseInfo> infos;

        [TestFixtureSetUp]
        public void TestGetDefault ()
        {
            // The default repository is process global, so we must initalize it only once.
            // It will be used all of the tests
            Repository.Require ("GLib", "2.0");
            infos = Repository.Namespaces ["GLib"].Infos;
        }

        [Test]
        public void TestEqual ()
        {
            var info1 = infos [0];
            var info2 = Repository.Namespaces["GLib"].FindByName (info1.Name);
            // want to make sure that we compare by value and not by reference
            Assume.That (ReferenceEquals (info1, info2), Is.False);
            Assert.That (info1, Is.EqualTo (info2));
            Assert.That (info1 == info2, Is.True);
            Assert.That (info1 != info2, Is.False);

            info2 = infos [1];
            Assert.That (info1, Is.Not.EqualTo (info2));
            Assert.That (info1 == info2, Is.False);
            Assert.That (info1 != info2, Is.True);

            Assert.That (info1 == null, Is.False);
            Assert.That (info1 != null, Is.True);
            Assert.That (null == info1, Is.False);
            Assert.That (null != info1, Is.True);

            info1 = null;
            info2 = null;
            Assert.That (info1 == info2, Is.True);
            Assert.That (info1 != info2, Is.False);
        }

        [Test]
        public void TestGetType ()
        {
            Assert.That (infos.First ().InfoType, Is.EqualTo (InfoType.Constant));
        }

        [Test]
        public void TestGetNameSpace ()
        {
            Assert.That (infos.First ().Namespace, Is.EqualTo ("GLib"));
        }

        [Test]
        public void TestGetName ()
        {
            Assert.That (infos.First ().Name, Is.EqualTo ("ANALYZER_ANALYZING"));
        }

        [Test]
        public void TestGetAttribute ()
        {
            // TODO: Need to figure out how to add attributes.
            //Assert.That (infos.First ().GetAttribute("type"), Is.EqualTo (""));
        }

        [Test]
        public void TestIterateAttributes ()
        {
            // TODO: Need to figure out how to add attributes.
            foreach (var info in infos) {
                foreach (var pair in info.Attributes) {
                    Console.WriteLine (pair.Key, pair.Value);
                }
            }
        }

        [Test]
        public void TestGetContainer ()
        {
            var function = infos
                .First (i => i.InfoType == InfoType.Function && (i as FunctionInfo).Args.Count > 0) as FunctionInfo;
            var arg = function.Args.First ();
            var container = arg.Container;
            Assert.That (container, Is.EqualTo (function));
        }

        [Test]
        public void TestIsDeprecated ()
        {
            var count = infos.Count (i => i.IsDeprecated == true);
            Assert.That (count, Is.GreaterThan (0));
        }
    }
}
