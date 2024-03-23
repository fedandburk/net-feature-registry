using NUnit.Framework;

namespace Fedandburk.FeatureRegistry.Tests;

[TestFixture]
public class FeatureRegistryTests
{
    private enum TestEnum
    {
        Test
    }

    private class TestClass { }

    [TestFixture]
    public class WhenGetCalled
    {
        [TestFixture]
        public class AndFeatureIsNull
        {
            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForEnum()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = sut[default(Enum)!];
                });
            }

            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForType()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = sut[default(Type)!];
                });
            }

            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForString()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    _ = sut[default(string)!];
                });
            }
        }

        [TestFixture]
        public class AndFeatureIsNotSet
        {
            [Test]
            public void FalseShouldBeReturnedForEnum()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.That(sut[TestEnum.Test], Is.False);
            }

            [Test]
            public void FalseShouldBeReturnedForType()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.That(sut[typeof(TestClass)], Is.False);
            }

            [Test]
            public void FalseShouldBeReturnedForString()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.That(sut["First"], Is.False);
            }
        }

        [TestFixture]
        public class AndFeatureIsDisabled
        {
            [Test]
            public void FalseShouldBeReturnedForEnum()
            {
                var sut = new FeatureRegistryImplementation { [TestEnum.Test] = false };

                Assert.That(sut[TestEnum.Test], Is.False);
            }

            [Test]
            public void FalseShouldBeReturnedForType()
            {
                var sut = new FeatureRegistryImplementation { [typeof(TestClass)] = false };

                Assert.That(sut[typeof(TestClass)], Is.False);
            }

            [Test]
            public void FalseShouldBeReturnedForString()
            {
                var sut = new FeatureRegistryImplementation { ["First"] = false };

                Assert.That(sut["First"], Is.False);
            }
        }

        [TestFixture]
        public class AndFeatureIsEnabled
        {
            [Test]
            public void FalseShouldBeReturnedForEnum()
            {
                var sut = new FeatureRegistryImplementation { [TestEnum.Test] = true };

                Assert.That(sut[TestEnum.Test], Is.True);
            }

            [Test]
            public void FalseShouldBeReturnedForType()
            {
                var sut = new FeatureRegistryImplementation { [typeof(TestClass)] = true };

                Assert.That(sut[typeof(TestClass)], Is.True);
            }

            [Test]
            public void FalseShouldBeReturnedForString()
            {
                var sut = new FeatureRegistryImplementation { ["First"] = true };

                Assert.That(sut["First"], Is.True);
            }
        }
    }

    [TestFixture]
    public class WhenSetCalled
    {
        [TestFixture]
        public class AndFeatureIsNull
        {
            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForEnum()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut[default(Enum)!] = false;
                });
            }

            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForType()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut[default(Type)!] = false;
                });
            }

            [Test]
            public void ArgumentNullExceptionExceptionShouldBeThrownForString()
            {
                var sut = new FeatureRegistryImplementation();

                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut[default(string)!] = false;
                });
            }
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ValueShouldBeSetForEnum(bool isEnabled)
        {
            var sut = new FeatureRegistryImplementation { [TestEnum.Test] = isEnabled };

            Assert.That(sut[TestEnum.Test], Is.EqualTo(isEnabled));
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ValueShouldBeSetForType(bool isEnabled)
        {
            var sut = new FeatureRegistryImplementation { [typeof(TestClass)] = isEnabled };

            Assert.That(sut[typeof(TestClass)], Is.EqualTo(isEnabled));
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ValueShouldBeSetForString(bool isEnabled)
        {
            var sut = new FeatureRegistryImplementation { ["First"] = isEnabled };

            Assert.That(sut["First"], Is.EqualTo(isEnabled));
        }
    }
}
