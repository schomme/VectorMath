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
            var v = new Vector(o.X1, o.Y1, o.Z1).Negate();

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

            var r = v1.Add(v2);

            Assert.AreEqual(o.SumX, r.X);
            Assert.AreEqual(o.SumY, r.Y);
            Assert.AreEqual(o.SumZ, r.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void SubstractVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);

            var r = v1.Subtract(v2);

            Assert.IsNotNull(v1);
            Assert.IsNotNull(v2);
            Assert.IsNotNull(r);

            Assert.AreEqual(o.DiffX, r.X);
            Assert.AreEqual(o.DiffY, r.Y);
            Assert.AreEqual(o.DiffZ, r.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]
        public void MultiplyVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var r = v1.Multiply(o.Faktor);

            Assert.AreEqual(o.MultX, r.X);
            Assert.AreEqual(o.MultY, r.Y);
            Assert.AreEqual(o.MultZ, r.Z);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void DivideVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);

            var r = v1.Divide(o.Quotient);

            var delta = 0.00000001d;

            Assert.AreEqual(o.DivX, r.X, delta);
            Assert.AreEqual(o.DivY, r.Y, delta);
            Assert.AreEqual(o.DivZ, r.Z, delta);
        }

        [TestMethod]
        [DynamicData(nameof(TestDatas), DynamicDataSourceType.Property)]

        public void ScalarProductVector(TestData o)
        {
            var v1 = new Vector(o.X1, o.Y1, o.Z1);
            var v2 = new Vector(o.X2, o.Y2, o.Z2);
            
            var scalar = v1.ScalarProduct(v2);

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

            Assert.AreEqual(o.Angle, angle, 0.000001);

        }

    }
}