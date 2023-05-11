using DataAnalyzer.Models;
using DataAnalyzer.ViewModels;
using Xunit;

namespace DataAnalyzerTest.ViewModels.Integration;

public class ApplicationConfigurationViewModelTests : IClassFixture<ApplicationConfigurationViewModel>
{
    private IConfigurationModel configurationModel;
    private ApplicationConfigurationViewModel viewModel;

    //[Fact]
    public void Temp()
    {
        // INTEGRATION TESTS
        // all other view models that have config model likely have some dependency on these two values
        // need to verify that their functionality changes based on this view model having updates
        //
        // (i.e., the call to the view model propagated to the config model which all other view models can see)
    }
}
