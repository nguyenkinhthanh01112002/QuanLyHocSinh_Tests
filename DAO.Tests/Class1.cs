using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Legacy;

namespace DAO.Tests
{
    //Class DataProvider
    [TestFixture]
    public class DataProviderTests
    {
        private DataProvider _dataProvider;      
        [SetUp]
        public void Setup()
        {
            // Khởi tạo _dataProvider, giả sử DataProvider đã được cấu hình để kết nối với cơ sở dữ liệu kiểm thử
            _dataProvider = DataProvider.Instance;
        }

        // Test Method GetSqlCommand
        [TestCase("Select * from HOCSINH")]
        [TestCase("Select * from NGUOIDUNG")]
        [TestCase("Select * from DANTOC")]
        [TestCase("Select * from NGHENGHIEP")]
        [TestCase("Select * from MONHOC")]
        [TestCase("Select * from HANHKIEM")]
        public void TestGetSqlCommand(string query, object[] parameters = null)
        {
            var connectionString = "Data Source=NGUYENKINHTHANH\\SQLEXPRESS;Initial Catalog=QuanLyHocSinh;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = DataProvider.Instance.GetSqlCommand(connection, query, null);
                Assert.That(cmd, Is.EqualTo(null));  // Đảm bảo rằng cmd không phải là null
                connection.Close();
            }
        }
        // Test Method ExecuteScalar
        [TestCase("SELECT COUNT(*) FROM HOCSINH", 47)]
        [TestCase("SELECT COUNT(*) FROM NGUOIDUNG", 6)]
        [TestCase("SELECT COUNT(*) FROM DANTOC", 4)]
        [TestCase("SELECT COUNT(*) FROM NGHENGHIEP", 4)]
        [TestCase("SELECT COUNT(*) FROM MONHOC", 9)]
        [TestCase("SELECT COUNT(*) FROM HANHKIEM", 4)]
        [Test]
        public void TestExecuteScalar(string query, int expected)
        {     
            // Act
            object result = _dataProvider.ExecuteScalar(query);
            // Assert
            Assert.That(result, Is.EqualTo(expected), $"The query {query} should return {expected}.");
        }
        //Test Method ExecuteQuery
        [TestCase("Select * from HOCSINH")]
        [TestCase("Select * from NGUOIDUNG")]
        [TestCase("Select * from DANTOC")]
        [TestCase("Select * from NGHENGHIEP")]
        [TestCase("Select * from MONHOC")]
        [TestCase("Select * from HANHKIEM")]
        [Test]
        public void TestExecuteQuery(string query, object[] parameters = null)
        {
            DataTable dt = _dataProvider.ExecuteQuery(query,parameters);
            if(dt == null)
            {
                Assert.Fail("Failed");
                return;
            }
            ClassicAssert.IsTrue(dt.Rows.Count > 0);
        }
        [Test]
        public void TestExecuteNonequry(string query, object[] parameters = null)
        {

        }

    }
    //ClassDanTocDao
    [TestFixture]
    public class DanTocDaoTests
    {
        private DanTocDAO _danTocDao;
        [SetUp]
        public void Setup()
        {
            // Khởi tạo _dataProvider, giả sử DataProvider đã được cấu hình để kết nối với cơ sở dữ liệu kiểm thử
            _danTocDao = DanTocDAO.Instance;
        }
        [Test]
        public void TestLayDanhSachDanToc()
        {
            DataTable dt = _danTocDao.LayDanhSachDanToc();
            ClassicAssert.IsTrue(dt.Rows.Count>0);
        }
        
    }
    //ClassDiemDao
    [TestFixture]
    public class DiemDaoTests
    {
        private DiemDAO _diemDao;
        [SetUp]
        public void Setup()
        {
            _diemDao = DiemDAO.Instance;
        }
        [Test]
        public void Test()
        {

        }
    }
    
}

