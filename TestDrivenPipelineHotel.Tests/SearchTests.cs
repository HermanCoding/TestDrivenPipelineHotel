using TestDrivenPipelineHotel.Logic;

namespace TestDrivenPipelineHotel.Tests
{
    public class SearchTests
    {
        [Fact]
        public void SearchRoom_ReturnsListOfRooms()
        {
            //Given
            SearchLogic searchLogic = new SearchLogic();
            var dateFrom = new DateTime(2024, 01, 01);
            var dateTo = new DateTime(2024, 01, 10);
            // RoomTypeModel roomType = new();

            //When
            // var searchedRooms = searchLogic.SearchRoom(dateFrom, dateTo, roomType);
            // var expectedRooms =

            //Then
            // searchedRooms.Should().NotBeNull();
            // searchedRooms.Should().BeEquivalentTo(expectedRooms);

        }
    }
}
