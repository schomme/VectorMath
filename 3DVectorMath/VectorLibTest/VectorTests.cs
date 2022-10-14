using VectorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using VectorLibTest;

namespace VectorLibTest
{
    [TestClass]
    public class VectorTests
    {
        private static IEnumerable<object[]> TestDatas { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var json = File.ReadAllText("TestData/testdata.json");
            var objects = JsonConvert.DeserializeObject<List<TestData>>(json);

            TestDatas = objects.Select(i => new[] { i });
        }

        [TestMethod]
        public void CreateNullVector()
        {
            var v = new Vector();
            Assert.AreEqual(0, v.X);
            Assert.AreEqual(0, v.Y);
            Assert.AreEqual(0, v.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void CreateVector(TestData o)
        {
            var v = new Vector(o.X1, o.Y1, o.Z1);
            Assert.IsNotNull(v);
            Assert.AreEqual(o.X1, v.X);
            Assert.AreEqual(o.Y1, v.Y);
            Assert.AreEqual(o.Z1, v.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]
        public void NegateVector(TestData o)
        {
            var v = new Vector(o.X1, o.Y1, o.Z1);
            v.Negate();
            Assert.AreEqual(-o.X1, v.X);
            Assert.AreEqual(-o.Y1, v.Y);
            Assert.AreEqual(-o.Z1, v.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]
        public void AddVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);

            v1.Add(v2);

            Assert.AreEqual(o.SumX, v1.X);
            Assert.AreEqual(o.SumY, v1.Y);
            Assert.AreEqual(o.SumZ, v1.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void SubstractVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);

            v1.Subtract(v2);

            Assert.IsNotNull(v1);
            Assert.IsNotNull(v2);

            Assert.AreEqual(o.DiffX, v1.X);
            Assert.AreEqual(o.DiffY, v1.Y);
            Assert.AreEqual(o.DiffZ, v1.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]
        public void MultiplyVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            v1.Multiply(o.FAKTOR);

            Assert.AreEqual(o.MultX, v1.X);
            Assert.AreEqual(o.MultY, v1.Y);
            Assert.AreEqual(o.MultZ, v1.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void DivideVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);

            v1.Divide(o.QUOTIENT);

            Assert.AreEqual(o.DivX, v1.X, 8);
            Assert.AreEqual(o.DivY, v1.Y, 8);
            Assert.AreEqual(o.DivZ, v1.Z, 8);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void ScalarProductVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);
            
            double scalar = v1.ScalarProduct(v2);

            Assert.AreEqual(o.ScalarProd, scalar);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void CrossProductVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);

            var cross = v1.CrossProduct(v2);

            Assert.AreEqual(o.CrossX, cross.X);
            Assert.AreEqual(o.CrossY, cross.Y);
            Assert.AreEqual(o.CrossZ, cross.Z);

        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]
        public void AngleVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);

            var angle = v1.AngleBetween(v2);

            Assert.AreEqual(o.Angle, angle);

        }

    }
}