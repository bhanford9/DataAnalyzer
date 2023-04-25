using DataAnalyzer.Common.DataParameters;
using DataAnalyzer.DataImport.DataObjects;
using DataAnalyzerFixtures.ViewModels.DataStructureSetupViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using DataAnalyzerTest.Utilities;
using DataAnalyzer.Models;

namespace DataAnalyzerTest.ViewModels.Unit.DataStructureSetupViewModels
{
    public class ConfigurationGroupingViewModelTests : IClassFixture<ConfigurationGroupingViewModelFixture>
    {
        private readonly ConfigurationGroupingViewModelFixture shared;

        public ConfigurationGroupingViewModelTests(ConfigurationGroupingViewModelFixture sharedData)
        {
            this.shared = sharedData;
            this.shared.MockConfigurationModel = new();
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationDirectory).Returns(string.Empty);
            this.shared.MockConfigurationModel.Setup(x => x.ConfigurationName).Returns(string.Empty);

            this.shared.MockExecutiveCommissioner = new();
        }

        [Fact]
        public void ShouldLoadParametersInOnCreation()
        {
            var mockParameterCollection = this.SetupConfigModelDataParameterCollection();

            this.CreateViewModel();

            mockParameterCollection.Verify(x => x.GetParameters(), Times.Once);
            AssertionExtensions.CountIs(mockParameterCollection.Object.GetParameters(), 3);
            AssertionExtensions.CountIs(this.shared.ViewModel.ParameterNames, 2);
            Assert.True(this.shared.ViewModel.ParameterNames.First().Equals("Groupable"));
            Assert.True(this.shared.ViewModel.ParameterNames.Last().Equals("Groupable"));
        }

        [Fact]
        public void ShouldNotLoadParametersIfModelIsInvalid()
        {
            this.shared.MockConfigurationModel
                .Setup(x => x.DataParameterCollection)
                .Returns(() => null);

            this.CreateViewModel();

            this.shared.MockConfigurationModel.Verify(x => x.DataParameterCollection.GetParameters(), Times.Never);
        }

        [Fact]
        public void ShouldRemoveChildWithUid()
        {
            this.CreateViewModel();
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);

            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 3);

            var uid = this.shared.ViewModel.Children.Skip(1).First().Uid;

            this.shared.ViewModel.RemoveChild(uid);

            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 2);
            Assert.DoesNotContain(uid, this.shared.ViewModel.Children.Select(x => x.Uid));
        }

        [Fact]
        public void ShouldNotRemoveChildWhenUidNotPresent()
        {
            this.CreateViewModel();
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);

            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 3);

            var uid = Guid.NewGuid().ToString();

            this.shared.ViewModel.RemoveChild(uid);

            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 3);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(6)]
        public void ShouldIndicateHasChildrenForChildrenCountGreaterThanZero(int count)
        {
            this.CreateViewModel();
            for (int i= 0; i < count; i++)
                this.shared.ViewModel.AddParameter.Execute(null);

            if (count > 0)
                Assert.True(this.shared.ViewModel.HasChildren);
            else
                Assert.False(this.shared.ViewModel.HasChildren);
        }

        [Theory]
        [InlineData(false, 0)]
        [InlineData(false, 1)]
        [InlineData(true, 0)]
        [InlineData(true, 1)]
        public void ShouldCorrectlyReturnGroupByText(bool isSubRule, int level)
        {
            IDictionary<(bool, bool), string> expectedResults = new Dictionary<(bool, bool), string>()
            {
                { (false, true), "Group By:" },
                { (false, false), "Then By:" },
                { (true, true), "And By:" },
                { (true, false), "And By:" },
            };

            this.CreateViewModel(level);
            this.shared.ViewModel.IsSubRule = isSubRule;

            Assert.Equal(expectedResults[(isSubRule, level == 0)], this.shared.ViewModel.GroupByText);
        }

        [Fact]
        public void ShouldInitializeChildrenWithDefaults()
        {
            this.CreateViewModel();
            this.shared.ViewModel.AddParameter.Execute(null);
            Assert.True(this.shared.ViewModel.Children.First().IsSubRule);
            Assert.Equal(this.shared.ViewModel, this.shared.ViewModel.Children.First().Parent);
        }

        // Test RemoveParameter
        //   IsSubRule(true)
        //   IsSubRule(false) --> Not tested, ignoring for now
        [Fact]
        public void ShouldRemoveParameterFromPrentWhenSubRule()
        {
            this.CreateViewModel();
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);
            this.shared.ViewModel.AddParameter.Execute(null);
            var toRemoveFrom = this.shared.ViewModel.Children.Skip(1).First();
            toRemoveFrom.AddParameter.Execute(null);
            toRemoveFrom.AddParameter.Execute(null);
            var uidToRemove = toRemoveFrom.Children.Last().Uid;

            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 3);
            AssertionExtensions.CountIs(toRemoveFrom.Children, 2);

            toRemoveFrom.Children.Last().RemoveParameter.Execute(uidToRemove);
            
            AssertionExtensions.CountIs(this.shared.ViewModel.Children, 3);
            AssertionExtensions.CountIs(toRemoveFrom.Children, 1);
        }

        [Fact]
        public void ShouldLoadParametersWhenConfigModelChanges()
        {
            this.CreateViewModel();

            AssertionExtensions.CountIs(this.shared.ViewModel.ParameterNames, 0);

            this.SetupConfigModelDataParameterCollection();

            this.shared.MockConfigurationModel.Raise(
                this.shared.GetEventAction<IConfigurationModel>(),
                this.shared.DataParamListChangeArgs);

            AssertionExtensions.CountIs(this.shared.ViewModel.ParameterNames, 2);
        }

        private Mock<IDataParameterCollection> SetupConfigModelDataParameterCollection()
        {
            Mock<IDataParameter<IStats>> groupable = new();
            groupable.Setup(x => x.CanGroupBy).Returns(true);
            groupable.Setup(x => x.Name).Returns("Groupable");
            Mock<IDataParameter<IStats>> notGroupable = new();
            notGroupable.Setup(x => x.CanGroupBy).Returns(false);
            notGroupable.Setup(x => x.Name).Returns("NotGroupable");

            Mock<IDataParameterCollection> mockParameterCollection = new();
            mockParameterCollection.Setup(x => x.GetParameters()).Returns(() =>
                new[] { groupable.Object, notGroupable.Object, groupable.Object });

            this.shared.MockConfigurationModel
                .Setup(x => x.DataParameterCollection)
                .Returns(mockParameterCollection.Object);

            return mockParameterCollection;
        }

        private void CreateViewModel(int level = 0) =>
            this.shared.ViewModel = new(
                this.shared.MockConfigurationModel.Object,
                this.shared.MockExecutiveCommissioner.Object,
                level);
    }
}
