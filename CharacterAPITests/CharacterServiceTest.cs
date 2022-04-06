
using System.Collections.Generic;
using CharacterAPI.Services;
using CharacterAPI.Models;
using Xunit;

namespace PeopleAPITests
{
    public class CharacterServiceTest
    {   
        [Fact]
        public void GetAllLists_PassTest()
        {
            //Act
            var actual = CharacterService.GetAll();
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("john"));
            //Assert
            Assert.IsType<List<Character>>(actual);
            Assert.True(doesReturnContainExpected);
        }

        [Fact]
        public void GetImageServicePass_Test()
        {
            //Arrange
            string testUrl = "john";

            //Act
            var actual = CharacterService.Get(testUrl);
            foreach (var item in actual)
            {
                item.Image = null;
            }
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("john"));
            
            //Assert
            Assert.NotEmpty(actual);
            Assert.True(doesReturnContainExpected);
        }

        [Fact]
        public void GetArrayFail_Test()
        {
            //Arrange
            string testUrl = "jon";

            //Act
            var actual = CharacterService.Get(testUrl);
            foreach (var item in actual)
            {
                item.Image = null;
            }
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("jon"));
            
            //Assert
            Assert.Empty(actual);
            Assert.False(doesReturnContainExpected);
        }

        [Fact]
        public void AddCharacter_Test()
        {
            //Arrange
            Character character = new Character {Name = "Janis Joplin"};
            //Act
            CharacterService.Add(character);
            string retrive = "Janis";
            var actual = CharacterService.Get(retrive);
            var doesReturnContainExpected = actual.Exists(s => s.Name.Contains("Janis"));
            //Assert
            Assert.True(doesReturnContainExpected);
        }
    }
}
