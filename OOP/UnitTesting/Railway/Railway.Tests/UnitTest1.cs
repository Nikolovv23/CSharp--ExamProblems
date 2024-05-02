namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    public class Tests
    {
        private RailwayStation station;
        [SetUp]
        public void Setup()
        {
            string name = "BDJ";
            station = new RailwayStation(name);
        }

        [Test]
        public void Constructor_InicializedTrueValues()
        {
            Assert.That(station.Name, Is.EqualTo("BDJ"));
            Assert.IsNotNull(station.ArrivalTrains);
            Assert.IsNotNull (station.DepartureTrains);
        }
        [TestCase(" ")]
        public void Constructor_NameIsNullOrWhiteSpase_ThrowArgumentEx(string name)
        {
            RailwayStation station1 = null;
            Assert.Throws<ArgumentException>(
                () => station1 = new RailwayStation(name));
        }
        [TestCase("Train007")]
        public void NewArrivalTrain_ArrivalTrains_Enqueue(string trainInfo)
        {
            station.NewArrivalOnBoard(trainInfo);
            Assert.IsTrue(station.ArrivalTrains.Contains(trainInfo));
        }
        [TestCase("Train007")]
        public void ArrivalTrains_CurrentTrain_Arrive(string trainInfo)
        {
            station.NewArrivalOnBoard(trainInfo);
            string actual = station.TrainHasArrived(trainInfo);
            string expected = $"{trainInfo} is on the platform and will leave in 5 minutes.";
            Assert.AreEqual(expected, actual);
            Assert.IsNotEmpty(station.DepartureTrains);
            Assert.IsTrue(station.DepartureTrains.Contains(trainInfo));
            Assert.IsEmpty(station.ArrivalTrains);
        }
        [TestCase("Train007")]
        public void ArrivalTrains_OtherTrain_Arrive(string trainInfo)
        {
            station.NewArrivalOnBoard("train006");
            station.NewArrivalOnBoard("train005");
            station.NewArrivalOnBoard(trainInfo);
            string actual = station.TrainHasArrived(trainInfo);
            string expected = $"There are other trains to arrive before {trainInfo}.";
            Assert.AreEqual(expected, actual);
            Assert.IsEmpty (station.DepartureTrains);
            Assert.IsTrue(station.ArrivalTrains.Count == 3);

        }
        [TestCase("Train007")]
        public void TrainHasLeft_IsTrue(string trainInfo)
        {
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard("train006");
            station.NewArrivalOnBoard("train005");

            station.TrainHasArrived(trainInfo);
            station.TrainHasArrived("train006");

            bool isItLeft = station.TrainHasLeft(trainInfo);
            Assert.IsTrue (station.ArrivalTrains.Count == 1);
            Assert.IsTrue(station.DepartureTrains.Count == 1);
            Assert.IsTrue(isItLeft);
        }
        [TestCase("Train007")]
        public void TrainHasLeft_IsFalse(string trainInfo)
        {
            station.NewArrivalOnBoard(trainInfo);
            station.NewArrivalOnBoard("train006");
            station.NewArrivalOnBoard("train005");

            station.TrainHasArrived(trainInfo);
            station.TrainHasArrived("train006");

            bool isItLeft = station.TrainHasLeft("train005");
            Assert.IsTrue(station.ArrivalTrains.Count == 1);
            Assert.IsTrue(station.DepartureTrains.Count == 2);
            Assert.IsTrue(!isItLeft);
        }

    }
}