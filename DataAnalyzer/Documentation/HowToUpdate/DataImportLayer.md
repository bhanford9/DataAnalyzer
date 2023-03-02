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

The last update (and most often forgetten) you'll need to make is adding your *Keys* and and *Data Scraper* to the `ScraperLibrary`. Other examples should already exist, so just follow suit on what others have done. If it is confusing how it is working, it may be useful to better understand the nested dictionary structure.

### Ordered Steps

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

hello

## User Interface

- might need a new UI
- if new UI add boolean for executive commissioner
- add keys to necessary structures