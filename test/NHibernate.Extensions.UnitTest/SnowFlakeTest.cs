using System;
using System.Linq;
using Newtonsoft.Json;
using NHibernate.Extensions.UnitTest.NpgSql.Data;
using Xunit;

namespace NHibernate.Extensions.UnitTest {

    public class SnowFlakeTest : BaseTest {

        [Fact]
        public void _01_CanQuerySnowFlakeId() {
            using (var session = factory.OpenSession()) {
                var entities = session.Query<SnowFlakeTestEntity>()
                    .ToList();
                foreach (var entity in entities) {
                    Assert.True(entity.Id > 0);
                    Console.WriteLine(JsonConvert.SerializeObject(entity));
                }
            }
        }

        [Fact]
        public void _02_CanInsertSnowFlakeId() {
            using (var session = factory.OpenSession()) {
                var entity = new SnowFlakeTestEntity {
                    Name = Guid.NewGuid().ToString("N")
                };
                session.Save(entity);
                Assert.True(entity.Id > 0);
                Console.WriteLine($"Id: {entity.Id}");
            }
        }
    }

}