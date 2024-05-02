namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device = null;
        private const int CurrentMemoryCapacity = 1000;
        [SetUp]
        public void Setup()
        {
            device = new Device(CurrentMemoryCapacity);
        }

        [Test]
        public void Constructor_Initializes_CorrectPropertiesValues()
        {
            Assert.IsNotNull(device);
            Assert.AreEqual(device.MemoryCapacity, CurrentMemoryCapacity);
            Assert.AreEqual(device.AvailableMemory, CurrentMemoryCapacity);
            Assert.AreEqual(device.Photos, 0);
            Assert.AreNotEqual(device.Applications, null);
        }
        [TestCase(100)]
        public void TakePhoto_SizeIsLessThanAvailableSize_ReturnTrue(int photoSize)
        {
            Assert.That(device.TakePhoto(photoSize), Is.EqualTo(true));
            Assert.That(device.Photos, Is.EqualTo(1));
            Assert.That(device.AvailableMemory == 900);
        }
        [TestCase(1000)]
        public void TakePhoto_SizeIsEacualToAvailableSize_ReturnTrue(int photoSize)
        {
            Assert.That(device.TakePhoto(photoSize), Is.EqualTo(true));
            Assert.That(device.Photos, Is.EqualTo(1));
            Assert.That(device.AvailableMemory == 0);
        }

        [TestCase(1001)]
        public void TakePhoto_SizeIsMoreThanAvailableSize_ReturnFalse(int photoSize)
        {
            Assert.That(device.TakePhoto(photoSize), Is.EqualTo(false));
            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.AvailableMemory == 1000);
        }

        [TestCase("Kali",100)]
        public void InstallApp_AppSizeIsLessThanAvailableMemory(string appName, int appSize)
        {
            string expected = $"Kali is installed successfully. Run application?";
            string actual = device.InstallApp(appName, appSize);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(device.AvailableMemory, 900);
        }
        [TestCase("Kali", 1000)]
        public void InstallApp_AppSizeIsEaqualToAvailableMemory(string appName, int appSize)
        {
            string expected = $"Kali is installed successfully. Run application?";
            string actual = device.InstallApp(appName, appSize);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(device.AvailableMemory, 0);
        }
        [TestCase("Kali", 1001)]
        public void InstallApp_AppSizeIsMoreThanMemory_ThrowEx(string appName, int appSize)
        {
            Exception ex = Assert.Throws<InvalidOperationException> (
                () => device.InstallApp(appName,appSize));
        }

        [Test] 
        public void FormatDevice_CorrectAction()
        {
            device.TakePhoto(100);
            device.InstallApp("kali", 500);
            device.FormatDevice();

            Assert.That(device.Photos, Is.EqualTo(0));
            Assert.That(device.Applications, Is.Empty);
            Assert.That(device.AvailableMemory, Is.EqualTo(CurrentMemoryCapacity));
        }

        [Test] 
        public void GetDeviseStatus_ReturnTrueString()
        {
            int photoSize = 100;
            device.TakePhoto(photoSize);
            device.InstallApp("MyFirstApp", 500);
            device.InstallApp("MySecondApp", 300);

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Memory Capacity: {CurrentMemoryCapacity} MB, Available Memory: {CurrentMemoryCapacity - photoSize - 500 - 300} MB");
            stringBuilder.AppendLine($"Photos Count: 1");
            stringBuilder.AppendLine($"Applications Installed: MyFirstApp, MySecondApp");

            string result = stringBuilder.ToString().TrimEnd();
            string status = device.GetDeviceStatus();

            Assert.AreEqual(result, status);
        }

    }
}