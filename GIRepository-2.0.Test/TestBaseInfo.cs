using System;
using System.Linq;

using FluentAssertions;
using Xunit;

namespace GISharp.GIRepository.Test
{
    public class TestBaseInfo
    {
        InfoDictionary<BaseInfo> infos;

        public TestBaseInfo ()
        {
            // The default repository is process global, so we must initialize it only once.
            // It will be used all of the tests
            Repository.Require ("GLib", "2.0");
            infos = Repository.Namespaces ["GLib"].Infos;
        }

        [Fact]
        public void TestEqual ()
        {
            var info1 = infos [0];
            var info2 = Repository.Namespaces["GLib"].FindByName (info1.Name);
            // want to make sure that we compare by value and not by reference
            ReferenceEquals (info1, info2).Should ().BeFalse ();
            (info1).Should ().Be (info2);
            (info1 == info2).Should ().BeTrue ();
            (info1 != info2).Should ().BeFalse ();

            info2 = infos [1];
            (info1).Should ().NotBe (info2);
            (info1 == info2).Should ().BeFalse ();
            (info1 != info2).Should ().BeTrue ();

            (info1 == null).Should ().BeFalse ();
            (info1 != null).Should ().BeTrue ();
            (null == info1).Should ().BeFalse ();
            (null != info1).Should ().BeTrue ();

            info1 = null;
            info2 = null;
            (info1 == info2).Should ().BeTrue ();
            (info1 != info2).Should ().BeFalse ();
        }

        [Fact]
        public void TestGetType ()
        {
            infos.First ().InfoType.Should ().Be (InfoType.Constant);
        }

        [Fact]
        public void TestGetNameSpace ()
        {
            infos.First ().Namespace.Should ().Be ("GLib");
        }

        [Fact]
        public void TestGetName ()
        {
            infos.First ().Name.Should ().Be ("ANALYZER_ANALYZING");
        }

        [Fact]
        public void TestGetAttribute ()
        {
            // TODO: Need to figure out how to add attributes.
            //(infos.First ().GetAttribute("type")).Should ().Equal ("");
        }

        [Fact]
        public void TestIterateAttributes ()
        {
            // TODO: Need to figure out how to add attributes.
            foreach (var info in infos) {
                foreach (var pair in info.Attributes) {
                    Console.WriteLine (pair.Key, pair.Value);
                }
            }
        }

        [Fact]
        public void TestGetContainer ()
        {
            var function = infos
                .First (i => i.InfoType == InfoType.Function && (i as FunctionInfo).Args.Count > 0) as FunctionInfo;
            var arg = function.Args.First ();
            var container = arg.Container;
            container.Should ().Be (function);
        }

        [Fact]
        public void TestIsDeprecated ()
        {
            var count = infos.Count (i => i.IsDeprecated == true);
            count.Should ().BeGreaterThan (0);
        }
    }
}
