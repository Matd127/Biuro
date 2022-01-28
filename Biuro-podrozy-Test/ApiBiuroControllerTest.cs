using Biuro_Podrozy.Controllers;
using Biuro_Podrozy.Models;
using System;
using Xunit;

namespace Biuro_podrozy_Test
{
    public class ApiBiuroControllerTest
    {
        [Fact]
        public void testAdd()
        {
            //Given
            ICrudDataRepository travels = new MemoryBiuroRepository();
            ApiBiuroController controller = new ApiBiuroController(travels);
            BiuroItem item = new BiuroItem();

            //When
            controller.Add(item);
            //That
            Assert.NotNull(travels.Find(1));
            Assert.Equal(travels.Find(1).Id, 1);
        }

        [Fact]
        public void testDelete()
        {
            //Given
            ICrudDataRepository travels = new MemoryBiuroRepository();
            ApiBiuroController controller = new ApiBiuroController(travels);
            travels.Save(new BiuroItem());
            travels.Save(new BiuroItem());
            //When
            controller.Delete(1);
            //That
            Assert.Null(travels.Find(1));

        }
    }
}
