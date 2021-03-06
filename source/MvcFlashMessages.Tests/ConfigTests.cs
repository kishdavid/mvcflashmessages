﻿using NUnit.Framework;

namespace MvcFlashMessages
{
    [TestFixture]
    public class ConfigTests
    {
        [TearDown]
        public void After_each_test()
        {
            // Reset the CSS classes so default values will be picked up.
            Config.Instance.CloseClickEvent = null;
            Config.Instance.InnerCssClass = null;
            Config.Instance.IsClosable = false;
            Config.Instance.OuterCssClass = null;
        }

        [Test]
        public void CloseClickEvent_can_be_set()
        {
            const string value = "alert(\"Hello, World!\");";
            Config.Instance.CloseClickEvent = value;
            Assert.AreEqual(value, Config.Instance.CloseClickEvent);
        }

        [Test]
        public void InnerCssClass_can_be_set()
        {
            Config.Instance.InnerCssClass = "Inner-test-value";
            Assert.AreEqual("Inner-test-value", Config.Instance.InnerCssClass);
        }

        [Test]
        public void InnerCssClass_has_expected_default_value()
        {
            Config.Instance.InnerCssClass = null;
            Assert.AreEqual("flash-message", Config.Instance.InnerCssClass);
        }

        [Test]
        public void Instance_is_not_null()
        {
            Assert.IsNotNull(Config.Instance);
        }

        [Test]
        public void IsClosable_can_be_set()
        {
            Config.Instance.IsClosable = true;
            Assert.IsTrue(Config.Instance.IsClosable);
        }

        [Test]
        public void IsClosable_has_expected_default_value()
        {
            Assert.IsFalse(Config.Instance.IsClosable);
        }

        [Test]
        public void OuterCssClass_can_be_set()
        {
            Config.Instance.OuterCssClass = "Outer-test-value";
            Assert.AreEqual("Outer-test-value", Config.Instance.OuterCssClass);
        }
        
        [Test]
        public void OuterCssClass_has_expected_default_value()
        {
            Config.Instance.OuterCssClass = null;
            Assert.AreEqual("flash-messages", Config.Instance.OuterCssClass);
        }
    }
}
