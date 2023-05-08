# Application
[description about what the application is and the 3 polymorphic layers]

## Import, Category, Flavor, Execution
[description about the significance of these terms and how they drive everything in the application]

## MVVM (Quick)
[description about the different layers in the application]

## Executive Commissioners (rename Commissioners)
[description about what they are and why]

## Model Layer
[description about application-wide model structure]

- Configuration Model - Stores a representation of the application data that will be saved to configuration files in order to manage the state of the application to try to bring it back up where the user left off in a fluid way.
- Main Model - Stores a representation of the application stateful data that all models/viewmodels need to access throughout the application
- Stats Model - Stores a representation of the imported data that will be used by each layer of the application

# Data Import

## Overview

See the How-To-Use section for this page to understand how the application works.

## Scrapers

Scrapers are configurable actors that will take some imported data and scrape through the data to pull out the necessary pieces that are desirable to load into a concrete type within the application.

There is a separate project, `DataScraper`, that handles storing and executing the scraping process. It also contains the DTOs that are created as a result of the data scraping.

There are 6 main interfaces within the scraper project that aid in extracting data in a extensible and configurable way:

- `IDataSource` - the interface containing the information associated with the media source from which data will be scraped.
- `IData` - the interface that all DTOs must abide by in order to be consumed by the application
- `IImportType` - the interface that specifies the media from which data will be imported (i.e., file, database, http, etc.)
- `IScraperCategory` - the interface that specifies a sub category within the import type that will be used for importing. For example, files may use CSV or JSON and databases may use Oracle or MySQL.
- `IScraperFlavor` - the interface that identifies the specific type of data being imported for a given category. For example, there could be 3 different *Flavors* (data types) for CSV import and 9 different *Flavors* for JSON import types.
- `IDataScraper` - the interface that the scrapers must implement to perform the actual act of scraping data from the data source and loading it into the appropriate DTO

This structure enables developers to extend the features of the application with smaller amounts of work. As an example, the application already knows how to deserialize CSV files, load the data into organized data structures and use it within the application. Therefore all that needs to be done if you have a new type of CSV you want the application to consume and use is implementing the `IScrapperFlavor` interface and wiring it into the application.

This structure also helps to easily crowdsource simple tools by making generic layers accessible to everyone. As an example, the application does not yet have an implementation for importing from an Oracle database. Once someone creates this category and wires it into the application, all future users of the application also have the ability to use this implementation and only need to create their own *Flavor* for their specifc Oracle database table(s).

The highest layer of the `DataScraper` project contains a class for orchestrating the scraping (`ScraperExecutive`) and a class for storing the available scrapers (`ScraperLibrary`). The `ScraperLibrary` is a series of nested dictionaries that provides access to registered scrapers. This is a bit of an overzealous data structure, but it provides a convenient innate way of only being able to access scrapers that pertain to the selected import types, scraper categories and scraper flavors. The `ScraperExecutive` provides a means for extracting the correct scraper, validating the data source and executing the scraping. It also provides meaningful exceptions for incorrect attempted use.

Each `IDataScraper` is required to implement a method that takes an `IDataSource` and converts it to a collection of `IData` objects. In order to do this, the first thing you'll want to do is check if a `DataSource` object already exists for the type of media you're trying to scrape from. If it already exists, feel free to use it. If it does not exist (or you need more functionality than the ones that already exist), then you can create your own within the corresponding directory. Next, you'll need to make sure you have an instance of a DTO that you're loading this scraped data into. If an instance that fits your needs does not already exist, then you'll need to create your own that abides by the `IData` interface.

The next three things setup the *Keys* that will be used by the application to properly extract your specific `IDataScraper`. The *Import Type* will be the least likely thing to need to create a new instance of. If there is not already a media type defined that implements the `IImportType` interface for your needs, then create a new one. You'll also need to make sure that a key-value pair has been added to the `ScraperLibrary` dictionary for your specified `IImportType` (other examples of how to do this should exist in the class). At this point it is important to understand the difference between a *Category* and a *Flavor* (described above). Check if an `IScraperCategory` already exists for your needs (its possible that the same *Category* could be used accross different *Import Types*). If one does not already exists that fits your needs, then create your own. The third thing to check is whether an `IScraperFlavor` already exists for the *Category* you're wanting to extend. If not, then add one.

The final class you may need to add is a new `IDataScraper` which does the work of scraping out data into your DTO. Many times a very similar *Data Scraper* already exists for what you're trying to do. Check to see if there are similar ones that you can copy or inherit from to limit the amount of work you need to do to extend the scrapers. For example, there are several CSV scrapers, but there are base CSV scrapers that do the majority of the work and the children only need to supply the mapping of the columns to the respective DTO parameters.

For the last update (and most often forgetten) you'll need to make is adding your *Keys* and and *Data Scraper* to the `ScraperLibrary`. Other examples should already exist, so just follow suit on what others have done. If it is confusing how it is working, it may be useful to better understand the nested dictionary structure.

### Scrapers Ordered Steps

1. Check if a `DataSource` already exists for the type of media you're trying to scrape from
2. If the `IDataSource` you need does not exist already, create one.
3. If there is not an `IData` DTO that exists that fits your needs, then create one.
4. If there is not an `IImportType` media type that exists that fits your needs, then create one.
5. If your `IImportType` has not been added to the `ScraperLibrary` dictionary, then add one.
6. If there is not an `IScraperCategory` that exists that fits your needs, then create one.
7. If there is not an `IScraperFlavor` that exists that fits your needs, then create one.
8. If there is not an `IDataScraper` that exists that fits your needs, then create one.
9. If there is not already a dictionary entry within the `ScraperLibrary` for your (potentially) new *Keys* and *Scraper*, then add it.

## Data Converters

The *Data Converters* structure is very similar to the *Scrapers*. The *Scrapers* section can better explain some of the details within the structure. This layer takes the result from the *Scrapers* and converts it into a data structure within the application. Keeping a similar structure as the *Scrapers* allows us to have different *Scrapers* that can map to the same internal data sturcure to reduce the number of times we have to build up a new class. For example, if you create a *Scraper* for a database instance and a *Scraper* for an HTTP request that each hold the same type of data, then 2 different *Scrapers* can map to the same *Data Converter*.

Before creating a new *Data Converter*, you'll want to make sure a data object exists within the application that implements the `IStats` interface and contains the information you need. This object will be the data that is used within the rest of the application whenever the respective *Import Type*, *Category* and *Flavor* are selected. 

When creating a new *Data Converter*, the first thing you'll want to do is make sure the necessary *Scraper* already exists for your needs (see the *Scrapers* section above for more information). Next you'll want to check if there is a *Data Converter* that already exists for your needs. If not, you'll need to create one and implement the abstract methods. Note, if you find yourself in a situation where you want to create a new *Data Converter* for an existing *Scraper* that already has a respective *Data Converter*, then you might need to create a new *Flavor* and populate the *ScraperLibrary* as described in the above *Scrapers* section. To hook up your *Data Converter* to the application, you'll need to insert it into the `DataConverterLibrary` in the same way described with the `ScraperLibrary` in the above *Scrapers* section (note, the same import types, categories and flavors are used between each library that is structured in this way, so you don't always have to create new versions of those).

### Converters Ordered Steps

1. Check if an `IDataScraper` already exists for your needs (if not, see the *Scrapers* section for how to set one up)
2. Create a new object that implements the `IStats` interface if one does not already exist that fits your needs
3. Check if an `IDataConverter` already exists for your needs and make one if one does not exist
4. Add your *Data Converter* to the `DataConverterLibrary`

## Services Layer
[Add content about this layer supplying general utilities across the application]

- `IAggregateExecutives` --> needs created for your new type combination. it will hold utilities for your specific data combination throughout the rest of the layers in the application
- This will lead you to seeing you need an `IStatConfiguration`, `IDataConfiguration` and an `IDataOrganizer` for your new type combination. Check to see if one already exists that you can use before creating your own
  - `IStatConfiguration` is application mutable-state of your data. This data structure will hold your imported data to be structured into a cleaner way to be used by the *Execution* step.
  - `IDataConfiguration` is application working-state of your data. It handles data to/from file configuration for the *Data Setup* step and contains an organized structure for the *Execution* step to use.
  - `IDataOrganizer` is the object that will perform the action of converting your data configuration into a structured representation of the data for whatever *Execution* type is going to be executed
- `ExecutiveUtilitiesRepository` --> needs updated with the `IAggregateExecutives` you created

At this point, if you are using a pre-existing *Import Type* (i.e. importing from a file), then you might be able to fully import your data into the application. The next step would then be to move on to the Data Structuring section below. If you had to create a new *Import Type* or if the existing *Import Types* do not supply the needed functionality and you want to update them, then continue on within this Data Import section.

## Model Layer
`Models.DataStructureSetupModels` will be needed

## View Model Layer

## View Layer

- might need a new UI
- if new UI add boolean for executive commissioner
- add keys to necessary structures

# Data Structuring

## Overview

## Most Importantly
`Structure Executive Commissioner` has 2 things driving this part of the application:
1. Setup View Model Repository that maps the currently selected *Import Type*, *Category*, *Flavor* and *Execution Type* to a respective View Model
2. View Display Map that maps the visibility of each view based on the View Model from (1)

## Saved Configuration
Something I did (and didn't realize I was doing)...
- `DataConfigurations` are stored within the `ApplicationConfigurations` directory, but the `DataConfigurations` are their own entity for holding the state of the *Data Setup* step.
- There is another `DataConfigurations` stored within `StatConfigurations` which is confusing and may be duplicate things
- `IStats` made it into its own _Data Import_ directory
- The *Execution* step area has a model for holding serializable data, a model for going to/from serialized state and the *Execution* model, and then an *Execution* model for going to/from the configuration model and the view model

All of this is not quite cohesive and I want to organize a better way for it... Maybe its fine and I just need to define each explicitly. The `DataConfiguration` seems like it is maintaing two things as a single thing, *Application State* and *Serialized State*, which may not be desirable. 

`IDataConfiguration (Stats)` acts as a polymorphic way of storing the `IDataConfiguration (App)` structure with the `IStats` data applied. This requires this extra entity because the `StatsModel` handles the polymorphic structuring of stats by sending this entity an `IStatAccessorColleciton` and an `IDataConfiguration (App)` so that each child of `IDataConfiguration (Stats)` can inately know how to cast/parse/organize the data configuration with the raw data.

TODOs
2. Document the description of each of these things
3. Draw out the paths of execution for each layer *Import* --> *Setup* --> *Execution* (each layer has a use of the above thing(s))
4. Make sure each path makes sense

`*ImportViewModel` --> Apply Active Directory on `ImportModel` --> Updates last used info and stores file mapping to config
  - other than that, import layer doesn't really deal with config things (each importer can deal with its own to/from file)

`*SetupViewModel` --> Calls Save on `DataStructureSetupModel` --> Calls Serialize for `IDataConfiguration`

`*ExecutionViewModel` --> Calls Save on `*ExecutionViewModel.ConfigModel`
`*ExecutionViewModel` --> Calls Save on `StrucutureExecutiveCommissioner` --> Calls Save on active `*SetupViewModel`
  - This seems like it should NOT be necessary. The *Execution* step should NEVER need to update the *Setup* step

# Execution

## Overivew

