namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    public class Tests
    {
        private TelevisionDevice tvDevice;
        private const string Brand = "LG";
        private const double Price = 999.99;
        private const int ScreenWidth = 60;
        private const int ScreenHeight = 20;
        [SetUp]
        public void Setup()
        {
            tvDevice = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeight);
        }

        [Test]
        public void Constructor_InitiliazesObject_propertiesAreCorrect()
        {
            Assert.That(tvDevice, Is.Not.Null);
            Assert.That(tvDevice.Brand, Is.EqualTo(Brand));
            Assert.That(tvDevice.Price, Is.EqualTo(Price));
            Assert.That(tvDevice.ScreenWidth, Is.EqualTo(ScreenWidth));
            Assert.That(tvDevice.ScreenHeigth, Is.EqualTo(ScreenHeight));
            Assert.That(tvDevice.CurrentChannel, Is.EqualTo(0));
            Assert.That(tvDevice.Volume, Is.EqualTo(13));
            Assert.That(tvDevice.IsMuted, Is.EqualTo(false));

        }
        [Test]  
        public void ToString_Returns_Correcttring()
        {
            string expected= $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeight}, Price {Price}$";
            string actual = tvDevice.ToString();
            Assert.That (expected, Is.EqualTo(actual)); 
        }
        [Test] 
        public void SwitchOn_SwitchesTheTvOn()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = tvDevice.SwitchOn();
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void ChangeChannel_Returns_CorrectNumber()
        {
            int expected = 78;
            int result = tvDevice.ChangeChannel(expected);
            Assert.That(expected, Is.EqualTo(result));

        }
        [Test]
        public void ChangeChannel_NegativeInputg_ThrowsException()
        {
            int channel = -1;
            Exception ex = Assert.Throws<ArgumentException>(
                () => tvDevice.ChangeChannel(channel));
            
        }
        [Test]
        public void MuteDeviceMethod_ReturnsTrue()
        {
            tvDevice.MuteDevice();
            Assert.AreEqual(true, tvDevice.IsMuted);
            tvDevice.MuteDevice();
            Assert.AreEqual(false, tvDevice.IsMuted);
        }
        [TestCase(10)]
        [TestCase(-10)]
        public void ChangeVolume_UP_Return_TrueOutput(int volumeChange)
        {
            string actual = tvDevice.VolumeChange("UP", volumeChange);
            string expected = $"Volume: 23";
            Assert.AreEqual(actual, expected);
        }
        [TestCase(100)]
        [TestCase(-100)]
        public void ChangeVolumeUp_VolumeisOver100_Return_TrueOutput(int volumeChange)
        {
            string actual = tvDevice.VolumeChange("UP", volumeChange);
            string expected = $"Volume: 100";
            Assert.AreEqual(actual, expected);
        }
        [TestCase(100)]
        [TestCase(-100)]
        public void ChangeVolumeDown_VolumeisUnder0_Return_TrueOutput(int volumeChange)
        {
            string actual = tvDevice.VolumeChange("DOWN", volumeChange);
            string expected = $"Volume: 0";
            Assert.AreEqual(actual, expected);
        }
        [TestCase(10)]
        [TestCase(-10)]
        public void ChangeVolume_Down_10_Return_TrueOutput(int volumeChange)
        {
            string actual = tvDevice.VolumeChange("DOWN", volumeChange );
            string expected = $"Volume: 3";
            Assert.AreEqual(actual, expected);
        }

    }
}